using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;


namespace XJHSelfUse
{
    class Excel
    {
        /// <summary>
        /// 打开excel文件，最终得到IWorkbook
        /// </summary>
        /// <param name="filename">excel文件的路径</param>
        /// <returns></returns>
        public static IWorkbook OpenExcel(string filename)
        {
            IWorkbook wb = null;
            FileStream file_excel = null;
            if (!File.Exists(filename))
            {
                MessageBox.Show("\'" + filename + "\' is not exist!");
                return wb;
            }
            try
            {
                file_excel = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (Exception e)
            {
                MessageBox.Show("catch exception:" + e);
                return wb;
            }
            if (filename.EndsWith(".xls"))
            {
                wb = new HSSFWorkbook(file_excel);
            }
            else if (filename.EndsWith(".xlsx"))
            {
                wb = new XSSFWorkbook(file_excel);
            }
            else
            {
                MessageBox.Show("File \"" + filename + "\" is not endwith \".xls\" or \".xlsx\"");
            }
            file_excel.Close();
            return wb;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="sheet">工作表</param>
        /// <param name="row">单元格所在行</param>
        /// <param name="col">单元格所在列</param>
        /// <param name="str">用于输出单元格的内容或错误提示</param>
        /// <returns>返回true代表成功获取单元格的值,此时‘str’的值是单元格的内容
        /// 返回false代表获取失败，此时‘str’的值是错误提示</returns>
        static public bool GetCellValue(ISheet sheet, int row, int col, out string str)
        {
            str = "";
            if (sheet == null)
            {
                str = "sheet is null";
                return false;
            }
            if (row < 0)
            {
                str = "row is less than 0";
                return false;
            }
            if (col < 0)
            {
                str = "col is less than 0";
                return false;
            }
            IRow irow = sheet.GetRow(row);
            if (irow == null)
            {
                str = "the cell is not exist";
                return false;
            }
            ICell cell = irow.GetCell(col);
            if (cell == null)
            {
                str = "the cell is not exist";
                return false;
            }
            if (cell.IsMergedCell)
            {
                str = GetMergedCellValue(sheet, row, col);
            }
            else
            {
                str = cell.ToString();
            }


            return true;
        }

        /// <summary>
        /// 获取单元格的值
        /// </summary>
        /// <param name="sheet">工作表</param>
        /// <param name="row">单元格所在行</param>
        /// <param name="col">单元格所在列</param>
        /// <param name="str">用于输出单元格的内容或错误提示</param>
        /// <param name="merged">表示指定单元格是否是合并单元格</param>
        /// <returns>返回true代表成功获取单元格的值,此时‘str’的值是单元格的内容
        /// 返回false代表获取失败，此时‘str’的值是错误提示</returns>
        static public bool GetCellValue(ISheet sheet, int row, int col, out string str, out bool merged)
        {
            str = "";
            merged = false;
            if (sheet == null)
            {
                str = "sheet is null";
                return false;
            }
            if (row < 0)
            {
                str = "row is less than 0";
                return false;
            }
            if (col < 0)
            {
                str = "col is less than 0";
                return false;
            }
            IRow irow = sheet.GetRow(row);
            if (irow == null)
            {
                str = "the cell is not exist";
                return false;
            }
            ICell cell = irow.GetCell(col);
            if (cell == null)
            {
                str = "the cell is not exist";
                return false;
            }
            if (cell.IsMergedCell)
            {
                str = GetMergedCellValue(sheet, row, col);
                merged = true;
            }
            else
            {
                str = cell.ToString();
            }


            return true;
        }

        /// <summary>
        /// 获取合并单元格的内容，此单元格必须存在且是合并单元格，否则会出错
        /// </summary>
        /// <param name="sheet">工作表</param>
        /// <param name="row">单元格所在行</param>
        /// <param name="col">单元格所在列</param>
        /// <returns>获取到的内容</returns>
        static public string GetMergedCellValue(ISheet sheet, int row, int col)
        {
            string str = "";
            int merged_count = sheet.NumMergedRegions;//获取整张表中合并单元格的数量
            for (int i = 0; i < merged_count; i++)
            {
                //通过合并单元格的索引获取合并单元格的范围
                CellRangeAddress range = sheet.GetMergedRegion(i);
                //判断目标单元格是否在此范围内
                if (row >= range.FirstRow && row <= range.LastRow &&
                    col >= range.FirstColumn && col <= range.LastColumn)
                {
                    ICell cell = sheet.GetRow(range.FirstRow).GetCell(range.FirstColumn);
                    str = cell.ToString();
                }
            }
            return str;
        }

        /// <summary>
        /// 将字母转化成数字，excel专用
        /// </summary>
        /// <param name="str">待转换的字符串</param>
        /// <param name="value">转换后的值</param>
        /// <returns>true转换成功，false转换失败</returns>
        static public bool LetterToInt(string str, out int value)
        {
            value = 0;
            str = str.ToUpper();
            if (str.Length == 0)
            {
                return false;
            }
            if (IsAllLetter(str))
            {
                foreach (char c in str)
                {
                    value *= 26;
                    value += c - 'A' + 1;
                }
                value -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断字符串是否全为字母
        /// </summary>
        /// <param name="ss">待判断的字符串</param>
        /// <returns>true字符串全是字母，false字符串不全是字母</returns>
        static public bool IsAllLetter(string ss)
        {
            string pattern = @"^[A-Za-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(ss);
        }
    }
}
