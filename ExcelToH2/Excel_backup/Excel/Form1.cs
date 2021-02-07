using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using XJHSelfUse;
using NPOI.SS.Util;
using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.SS.Formula.Functions;
using Match = System.Text.RegularExpressions.Match;
using Org.BouncyCastle.Asn1.Sec;
using System.Collections;
using System.Windows.Forms.VisualStyles;
using System.Threading;

namespace Excel
{
    public partial class Form1 : Form
    {
        ArrayList reg_names = new ArrayList();
        public Form1()
        {
            InitializeComponent();

            ReadUserInfo();
        }

        private void ReadUserInfo()
        {
            int i = 0;
            //获取文本内容
            UserInfo.ReadUserInfo(out string[] str);
            if (str != null)
            {
                try
                {
                    TxtBx_InputPath.Text = str[i++];
                    TxtBx_OutputPath.Text = str[i++];
                    TxtBx_NameFilePath.Text = str[i++];
                    TxtBx_PhyRegCol.Text = str[i++];
                    TxtBx_LogRegCol.Text = str[i++];
                    TxtBx_RWCol.Text = str[i++];
                    TxtBx_BitPosCol.Text = str[i++];
                    TxtBx_ModuleName.Text = str[i++];
                    TxtBx_SheetName.Text = str[i++];
                    CkBx_UseDefault.Checked = bool.Parse(str[i++]);
                    CkBx_UseNameFile.Checked = bool.Parse(str[i++]);
                }
                catch
                {

                }
            }
        }

        private void Btn_SelectInput_Click(object sender, EventArgs e)
        {
            TxtBx_InputPath.Text = FileSelect.SelectInputFile();
        }

        private void Btn_SelectOutput_Click(object sender, EventArgs e)
        {
            if (CkBx_UseDefault.Checked)
                TxtBx_OutputPath.Text = FileSelect.SelectOutputPath();
            else
                TxtBx_OutputPath.Text = FileSelect.SelectOutputFile();
        }

        private void WriteWriteFunctionToFile(StreamWriter file_w, string name1, string name2, string offset, string sbit, string ebit)
        {
            string str = "#define GM_ISP_" + name2.ToUpper() + "_Write_" +
                name1.ToUpper() + "(p, value)\t\tdo{WriteDataU32" + "(p, (" +
                name2.ToUpper() + "_BASE * 4 + (" + offset + ") * 4), value, " + sbit +
                ", " + ebit + ");}while(0)";
            file_w.WriteLine(str);
        }

        private void WriteReadFunctionToFile(StreamWriter file_w, string name1, string name2, string offset, string sbit, string ebit)
        {
            string str = "#define GM_ISP_" + name2.ToUpper() + "_Read_" +
                name1.ToUpper() + "(p, addr)\t\tdo{ReadDataU32" + "(p, (" +
                name2.ToUpper() + "_BASE * 4 + (" + offset + ") * 4), addr," + sbit +
                ", " + ebit + ");}while(0)";
            file_w.WriteLine(str);
        }

        //从单元格中提取出 ‘开始位’
        private string GetStartBit(ISheet sheet, int row, int col)
        {
            Excel.GetCellValue(sheet, row, col, out string str);
            str = str.Trim();
            str = str.Replace(" ", "");
            string pattern = @"([0-9]+)\]";
            Regex re = new Regex(pattern);
            Match ma = re.Match(str);
            return ma.Groups[1].Value;
        }

        //从单元格中提取出 ‘结束位’
        private string GetEndBit(ISheet sheet, int row, int col)
        {
            Excel.GetCellValue(sheet, row, col, out string str);
            str = str.Trim();
            str = str.Replace(" ", "");
            string pattern = @"\[([0-9]+)";
            Regex re = new Regex(pattern);
            Match ma = re.Match(str);
            return ma.Groups[1].Value;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            //创建线程
            Thread thread = new Thread(new ThreadStart(Start));
            //设置为后台线程
            thread.IsBackground = true;
            //开始运行线程
            thread.Start();
        }

        private void Start()
        {
            if (CkBx_UseNameFile.Checked)
            {
                //使用事先准备好的名字对应文件来代替手动输入
                ReadNames(out string[] str, TxtBx_NameFilePath.Text);
                UserInfo.CreatDebugInfo();
                for (int i = 0; i < str.Length / 2; i++)
                {
                    Set_TxtBx_SheetName_Value(str[i * 2]);
                    Set_TxtBx_ModuleName_Value(str[i * 2 + 1]);
                    ParseExcel();
                    AddDebugInfo();
                }
            }
            else
            {
                ParseExcel();
                UserInfo.SaveDebugInfo(RTBx_Tips.Text);
            }

            //保存用户信息
            SaveUserInfo();
            MessageBox.Show("Success");
        }
        private delegate void SetTextValueCallBack(string value);// 声明委托，相当于c语言的函数指针
        private delegate void VoidCallBack();// 声明委托

        private void AddDebugInfo()
        {
            if (RTBx_Tips.InvokeRequired)//当其他线程（非创建 RTBx_Tips 这个控件的线程）访问该控件时，InvokeRequired 为true
            {
                //实例化委托，相当于C语言定义一个函数指针并指向了 AddDebugInfo 函数
                VoidCallBack callBack = new VoidCallBack(AddDebugInfo);
                RTBx_Tips.Invoke(callBack);//相当于C语言中调用函数指针指向的函数
            }
            else
            {
                UserInfo.AddDebugInfo(RTBx_Tips.Text);
            }
        }

        private void Set_TxtBx_SheetName_Value(string str)
        {
            if (TxtBx_SheetName.InvokeRequired)
            {
                SetTextValueCallBack callBack = new SetTextValueCallBack(Set_TxtBx_SheetName_Value);
                TxtBx_SheetName.Invoke(callBack, str);
            }
            else
            {
                TxtBx_SheetName.Text = str;
            }
        }

        private void Set_TxtBx_ModuleName_Value(string str)
        {
            if (TxtBx_ModuleName.InvokeRequired)
            {
                SetTextValueCallBack callBack = new SetTextValueCallBack(Set_TxtBx_ModuleName_Value);
                TxtBx_ModuleName.Invoke(callBack, str);
            }
            else
            {
                TxtBx_ModuleName.Text = str;
            }
        }

        private void ParseExcel()
        {
            //清空寄存器名字表
            reg_names.Clear();
            //清空提示信息
            ClearInfo();
            DisplayLineInfo("Start!");
            DisplayLineInfo("Sheet name: " + TxtBx_SheetName.Text);
            DisplayLineInfo("Open Excel \'" + TxtBx_InputPath.Text + "\' " + "...");
            //打开工作簿，获取工作表
            IWorkbook wb = Excel.OpenExcel(TxtBx_InputPath.Text);
            if (wb == null)
            {
                DisplayLineInfo("Workbook is null");
                return;
            }
            DisplayLineInfo("Open Excel \'" + TxtBx_InputPath.Text + "\' " + " success");
            ISheet ws = wb.GetSheet(TxtBx_SheetName.Text);
            //获取列号，由输入的字母转数字
            int col_phy = Excel.LetterToInt(TxtBx_PhyRegCol.Text);
            int col_log = Excel.LetterToInt(TxtBx_LogRegCol.Text);
            int col_bit = Excel.LetterToInt(TxtBx_BitPosCol.Text);
            int col_rw = Excel.LetterToInt(TxtBx_RWCol.Text);
            DisplayLineInfo("Get colnum success");
            //用于计数，记一个合并单元格内同一个名字使用的次数，用于函数命名后缀
            int count_name = 0;
            //打开输出文件
            StreamWriter file_w;
            try
            {
                if (CkBx_UseDefault.Checked)
                    file_w = new StreamWriter(TxtBx_OutputPath.Text + "\\" + TxtBx_ModuleName.Text.ToLower() + ".h");
                else
                    file_w = new StreamWriter(TxtBx_OutputPath.Text);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Could not find a part of the path \'" + TxtBx_OutputPath.Text + "\'");
                return;
            }
            file_w.WriteLine("#ifndef __" + TxtBx_ModuleName.Text.ToUpper() + "_H__");
            file_w.WriteLine("#define __" + TxtBx_ModuleName.Text.ToUpper() + "_H__");
            file_w.WriteLine();
            file_w.WriteLine("#include \"defaultbin.h\"");
            file_w.WriteLine();

            DisplayLineInfo("Start read excel");
            for (int i = 2; i <= ws.LastRowNum; i++)
            {
                try
                {
                    DisplayLineInfo("Line: " + (i + 1).ToString());
                    int count = 0;
                    //如果当前单元格为合并单元格且内容为空时，将count对应位置1
                    //即当前单元格不是合并单元格的首个单元格
                    if (Excel.GetCellValue(ws, i, col_phy, out string offset) is false)
                        if (ws.GetRow(i).GetCell(col_phy).StringCellValue == "") count |= 1;
                    if (Excel.GetCellValue(ws, i, col_log, out string name1) is false)
                        if (ws.GetRow(i).GetCell(col_log).StringCellValue == "") count |= 2;
                    if (Excel.GetCellValue(ws, i, col_rw, out string rw) is false)
                        if (ws.GetRow(i).GetCell(col_rw).StringCellValue == "") count |= 4;
                    if (Excel.GetCellValue(ws, i, col_bit, out string bit) is false)
                        if (ws.GetRow(i).GetCell(col_bit).StringCellValue == "") count |= 8;

                    //只要有一个为空，就跳过
                    if (offset == "" || name1 == "" || rw == "" || bit == "")
                    {
                        DisplayLineInfo("\toffset,name,rw,bit,someone is null");
                        continue;
                    }

                    if (CkBx_DebugInfo.Checked)
                        DisplayLineInfo("Trim...");
                    //去除字符串首尾的空字符
                    offset = offset.Trim();
                    offset = offset.Replace(" ", "");
                    offset = offset.ToLower();
                    name1 = name1.Trim();
                    name1 = name1.Replace(" ", "");
                    name1 = name1.ToUpper();
                    name1 = Regex.Replace(name1, @"\W+", "_");
                    rw = rw.Trim();
                    rw = rw.Replace(" ", "");
                    bit = bit.Trim();
                    bit = bit.Replace(" ", "");

                    if (CkBx_DebugInfo.Checked)
                        DisplayLineInfo("Trim success");

                    //如果offset bit name1的格式不对则跳过
                    if (IsIllegal(offset, bit, name1))
                    {
                        DisplayLineInfo("\toffset or bit or name1 or all is illegal!");
                        continue;
                    }

                    //count等于0b1111则说明前面4个单元格的内容都为空
                    if (count == 0b1111)
                    {
                        DisplayLineInfo("\toffset,name,rw,bit, all merged and all is null");
                        continue;
                    }
                    else if ((count & 0b1010) == 0b0010)
                    {
                        count_name++;
                        name1 = name1 + "_" + count_name.ToString();
                    }
                    else if ((count & 0b1010) == 0b0000)
                    {
                        count_name = 0;
                    }




                    string sbit = GetStartBit(ws, i, col_bit);
                    string ebit = GetEndBit(ws, i, col_bit);
                    string name2 = TxtBx_ModuleName.Text.Trim();
                    name2 = name2.Replace(" ", "");

                    if (CkBx_DebugInfo.Checked)
                        DisplayLineInfo("Compare With RegNames...");
                    //保证后面的函数名不重复
                    name1 = CompareWithRegNames(name1);

                    if (CkBx_DebugInfo.Checked)
                        DisplayLineInfo("Write to head file...");

                    if (rw.Contains('W') || rw.Contains('w'))
                    {
                        WriteWriteFunctionToFile(file_w, name1, name2, offset, sbit, ebit);
                    }
                    if (rw.Contains('R') || rw.Contains('r'))
                    {
                        WriteReadFunctionToFile(file_w, name1, name2, offset, sbit, ebit);
                    }
                    file_w.Flush();
                    if (CkBx_DebugInfo.Checked)
                        DisplayLineInfo("Write success");
                }
                catch (NullReferenceException)
                {
                    DisplayLineInfo("\tMaybe the cell is not exist");
                    //MessageBox.Show("Maybe the cell is not exist");
                    continue;
                }
                catch
                {
                    MessageBox.Show("Some thing err!");
                    break;
                }
            }

            file_w.WriteLine("#endif");
            file_w.Close();
            if (wb != null) wb.Close();

            for (int i = 0; i < reg_names.Count; i++)
            {
                if (CkBx_DebugInfo.Checked)
                    DisplayLineInfo(reg_names[i].ToString());
            }
        }

        private void DisplayInfo(string str)
        {
            RTBx_Tips.Text += str;
        }

        private void DisplayLineInfo(string str)
        {
            if (RTBx_Tips.InvokeRequired)
            {
                SetTextValueCallBack callBack = new SetTextValueCallBack(DisplayLineInfo);
                RTBx_Tips.Invoke(callBack, str);
            }
            else
            {
                RTBx_Tips.Text += str + "\n";
            }
        }

        private void ClearInfo()
        {
            if (RTBx_Tips.InvokeRequired)
            {
                VoidCallBack callBack = new VoidCallBack(ClearInfo);
                RTBx_Tips.Invoke(callBack);
            }
            else
            {

                RTBx_Tips.Clear();
            }
        }

        private void SaveUserInfo()
        {
            int j = 0;
            string[] str = new string[11];
            str[j++] = TxtBx_InputPath.Text;
            str[j++] = TxtBx_OutputPath.Text;
            str[j++] = TxtBx_NameFilePath.Text;
            str[j++] = TxtBx_PhyRegCol.Text;
            str[j++] = TxtBx_LogRegCol.Text;
            str[j++] = TxtBx_RWCol.Text;
            str[j++] = TxtBx_BitPosCol.Text;
            str[j++] = TxtBx_ModuleName.Text;
            str[j++] = TxtBx_SheetName.Text;
            str[j++] = CkBx_UseDefault.Checked.ToString();
            str[j++] = CkBx_UseNameFile.Checked.ToString();
            UserInfo.SaveUserInfo(str);
        }

        private void Btn_Test_Click(object sender, EventArgs e)
        {
        }

        private void ReadNames(out string[] str, string path)
        {
            StreamReader file_r = new StreamReader(path);
            int linenum = 0;
            while (file_r.Peek() > 0)
            {
                file_r.ReadLine();
                linenum++;
            }
            file_r.Close();
            file_r = new StreamReader(path);
            DisplayLineInfo("line num: " + linenum);
            //RTBx_Tips.Text += "line num: " + linenum;
            str = new string[linenum];
            for (int i = 0; i < linenum; i++)
            {
                str[i] = file_r.ReadLine().Trim();
            }

        }

        private void CkBx_UseNameFile_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBx_UseNameFile.Checked)
            {
                TxtBx_ModuleName.Enabled = false;
                TxtBx_SheetName.Enabled = false;
            }
            else
            {
                TxtBx_ModuleName.Enabled = true;
                TxtBx_SheetName.Enabled = true;
            }
        }

        private void Btn_SelectNameFile_Click(object sender, EventArgs e)
        {
            TxtBx_NameFilePath.Text = FileSelect.SelectInputFile();
        }

        private void RTBx_Tips_TextChanged(object sender, EventArgs e)
        {
            RTBx_Tips.SelectionStart = RTBx_Tips.Text.Length;
            RTBx_Tips.ScrollToCaret();
        }

        private bool IsIllegal(string offset, string bit, string name1)
        {
            if (Regex.IsMatch(offset, @"^0[xX][0-9a-fA-F]+$") is false) return true;
            //if (Regex.IsMatch(bit, @"^\[[0-9]+\]$") is false)
            //    if (Regex.IsMatch(bit, @"^\[[0-9]+:[0-9]+\]$") is false)
            //        if (Regex.IsMatch(bit, @"^\[[0-9]+：[0-9]+\]$") is false)
            //            return true;
            if (Regex.IsMatch(bit, @"^\[[0-9]+\]$") is false)
                if (Regex.IsMatch(bit, @"^\[[0-9]+[：:][0-9]+\]$") is false)
                    return true;
            if (Regex.IsMatch(name1, @"^[0-9A-Z_]+$") is false) return true;
            return false;

        }

        private void AddToStringArray(string str)
        {

        }

        //输入一个寄存器名，返回一个不与之前重复的名字
        //reg_names 存储所有的寄存器名
        //遍历reg_names比较是否有重复，如有重复则加上序号后缀
        private string CompareWithRegNames(string str)
        {
            string tmp = str;
            int count = 0;
            for (int i = 0; i < reg_names.Count; i++)
            {
                int result = reg_names[i].ToString().CompareTo(tmp);
                if (result == 0)
                {
                    tmp = str + "_" + count.ToString();
                }
                else if (result < 0)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            reg_names.Add(tmp);
            return tmp;
        }
    }
}
