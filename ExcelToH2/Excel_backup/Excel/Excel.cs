using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Excel
{
    class Excel
    {
        public static IWorkbook OpenExcel(string filename)
        {
            IWorkbook wb = null;
            FileStream file_excel = null;
            try
            {
                file_excel = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("file \"" + filename + "\" not found");
                return wb;
            }
            catch (IOException)
            {
                MessageBox.Show("The process cannot access the file \'" + filename + "\' because it is being used by another process.");
                return wb;
            }
            if (filename.EndsWith(".xls"))
            {
                wb = new HSSFWorkbook(file_excel);
            }
            else if (filename.EndsWith(".xlsx"))
            {
                wb = new XSSFWorkbook(filename);
            }
            else
            {
                MessageBox.Show("File \"" + filename + "\" is not endwith \".xls\" or \".xlsx\"");
            }
            file_excel.Close();
            return wb;
        }

        static public string GetMergedCellValue(ISheet sheet, int row, int col)
        {
            int merged_count = sheet.NumMergedRegions;
            for (int i = 0; i < merged_count; i++)
            {
                CellRangeAddress range = sheet.GetMergedRegion(i);
                if (row >= range.FirstRow && row <= range.LastRow &&
                    col >= range.FirstColumn && col <= range.LastColumn)
                {
                    ICell cell = sheet.GetRow(range.FirstRow).GetCell(range.FirstColumn);
                    if (cell.CellType == CellType.Numeric) return cell.NumericCellValue.ToString();
                    else return cell.StringCellValue;
                }
            }
            return null;
        }
        // 获取指定的单元格的内容，如果是合并的单元格，则获取左上角单元格的内容
        // 参数：
        // sheet    指定的工作表
        // row      单元格所在的行序号，从0开始
        // col      单元格所在的列序号，从0开始
        // str      返回的单元格内容
        // 返回值为 bool 类型，
        //          true代表指定单元格不是合并单元格
        //          false代表指定单元格是合并单元格
        // 注意：当单元格不存在时，返回值是true，但str是空，即 ""
        static public bool GetCellValue(ISheet sheet, int row, int col, out string str)
        {
            IRow irow = sheet.GetRow(row);
            if(irow == null)
            {
                str = "";
                return true;
            }
            ICell cell = irow.GetCell(col);
            if (cell == null)
            {
                str = "";
                return true;
            }

            if (cell.IsMergedCell)
            {
                str = GetMergedCellValue(sheet, row, col);
                return false;
            }
            else
            {
                if (cell.CellType == CellType.Numeric) str = cell.NumericCellValue.ToString();
                else str = cell.StringCellValue;
                return true;
            }
        }

        static public int LetterToInt(string str)
        {
            int value = -1;
            str.ToUpper();
            if (IsAllLetter(str))
            {
                value = str[0] - 'A';
            }
            return value;
        }

        static public bool IsAllLetter(string ss)
        {
            string pattern = @"^[A-Za-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(ss);
        }
    }
}
