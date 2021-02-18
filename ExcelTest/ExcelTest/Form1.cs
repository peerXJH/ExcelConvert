using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using XJHSelfUse;
using System.Collections;
using System.Text.RegularExpressions;

namespace ExcelTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RestoreUserInfo();
        }

        private delegate void SetTextValueCallBack(string value);// 声明委托，相当于c语言的函数指针
        private delegate void VoidCallBack();// 声明委托

        private void SettbSheetNameValue(string str)
        {
            if (tbSheetName.InvokeRequired)
            {
                SetTextValueCallBack callBack = new SetTextValueCallBack(SettbSheetNameValue);
                tbSheetName.Invoke(callBack, str);
            }
            else
            {
                tbSheetName.Text = str;
            }
        }

        private void SettbModuleNameValue(string str)
        {
            if (tbModuleName.InvokeRequired)
            {
                SetTextValueCallBack callBack = new SetTextValueCallBack(SettbModuleNameValue);
                tbModuleName.Invoke(callBack, str);
            }
            else
            {
                tbModuleName.Text = str;
            }
        }

        private void AddDisplayInfo(string str)
        {
            if (rtbTips.InvokeRequired)
            {
                SetTextValueCallBack callback = new SetTextValueCallBack(AddDisplayInfo);
                rtbTips.Invoke(callback, str);
            }
            else
            {
                rtbTips.AppendText(str);
            }
        }

        private void AddDisplayLineInfo(string str)
        {
            if (rtbTips.InvokeRequired)
            {
                SetTextValueCallBack callback = new SetTextValueCallBack(AddDisplayLineInfo);
                rtbTips.Invoke(callback, str);
            }
            else
            {
                rtbTips.AppendText(str + "\n");
            }
        }

        private void ClearDisplayInfo()
        {
            if (rtbTips.InvokeRequired)
            {
                VoidCallBack callback = new VoidCallBack(ClearDisplayInfo);
                rtbTips.Invoke(callback);
            }
            else
            {
                rtbTips.Text = "";
            }
        }

        private void btSelectInput_Click(object sender, EventArgs e)
        {
            string str = FileSelect.SelectInputFile();
            if (str != null)
            {
                tbInputPath.Text = str;
            }
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            string str;
            if (ckbUseDefault.Checked)
            {
                str = FileSelect.SelectOutputPath();
            }
            else
            {
                str = FileSelect.SelectOutputFile();
            }
            if (str != null)
            {
                tbOutputPath.Text = str;
            }
        }

        private void btSelectConfigFile_Click(object sender, EventArgs e)
        {
            string str = FileSelect.SelectInputFile();
            if (str != null)
            {
                tbConfigFilePath.Text = str;
            }
        }

        private void ckbUseConfigFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbUseConfigFile.Checked)
            {
                btSelectConfigFile.Enabled = true;
                tbConfigFilePath.Enabled = true;
                tbSheetName.Enabled = false;
                tbModuleName.Enabled = false;
                tbBitPosCol.Enabled = false;
                tbLogRegCol.Enabled = false;
                tbPhyRegCol.Enabled = false;
                tbRWCol.Enabled = false;
                tbEndRow.Enabled = false;
                tbStartRow.Enabled = false;
            }
            else
            {
                btSelectConfigFile.Enabled = false;
                tbConfigFilePath.Enabled = false;
                tbSheetName.Enabled = true;
                tbModuleName.Enabled = true;
                tbBitPosCol.Enabled = true;
                tbLogRegCol.Enabled = true;
                tbPhyRegCol.Enabled = true;
                tbRWCol.Enabled = true;
                tbEndRow.Enabled = true;
                tbStartRow.Enabled = true;
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            ParseSheet();
            SaveUserInfo();
            /*List<string> name = new List<string>
            {
                "name1",
                "name2",
                "name3",
                "name13",
                "name21"
            };
            List<string> offset = new List<string>
            {
                "0x00",
                "0x01",
                "0x01",
                "0x01",
                "0x02"
            };
            List<string> range = new List<string>
            {
                "[31:0]",
                "[0]",
                "[10:2]",
                "[20:11]",
                "[15:0]"
            };

            List<string> tt = FormatStructMember(offset, name, range);
            foreach (string s in tt)
            {
                AddDisplayLineInfo(s);
            }*/

        }

        void ThreadTest()
        {

        }

        private void rtbTips_TextChanged(object sender, EventArgs e)
        {
            rtbTips.SelectionStart = rtbTips.Text.Length;
            rtbTips.ScrollToCaret();
        }

        void Start()
        {

        }

        void ParseSheet()
        {
            // 打开工作表
            ClearDisplayInfo();
            AddDisplayLineInfo("\n\nStart parse sheet!\n");
            AddDisplayLineInfo(string.Format("Open excel [{0}] ... ...", tbInputPath.Text));
            IWorkbook wb = Excel.OpenExcel(tbInputPath.Text);
            if (wb == null)
            {
                AddDisplayLineInfo(string.Format("Open excel [{0}] failed.", tbInputPath.Text));
                return;
            }
            AddDisplayLineInfo(string.Format("Open excel [{0}] success.", tbInputPath.Text));
            AddDisplayLineInfo(string.Format("Open sheet [{0}] ... ...", tbSheetName.Text));
            ISheet sheet = wb.GetSheet(tbSheetName.Text);
            if (sheet == null)
            {
                AddDisplayLineInfo(string.Format("Open sheet [{0}] failed.", tbSheetName.Text));
                wb.Close();
                return;
            }
            AddDisplayLineInfo(string.Format("Open sheet [{0}] success.", tbSheetName.Text));

            // 读取工作表里指定的内容
            List<int> row = new List<int>
            {
                int.Parse(tbStartRow.Text),
                int.Parse(tbEndRow.Text)
            };
            Excel.LetterToInt(tbPhyRegCol.Text, out int phycol);
            Excel.LetterToInt(tbLogRegCol.Text, out int logcol);
            Excel.LetterToInt(tbBitPosCol.Text, out int bitcol);
            Excel.LetterToInt(tbRWCol.Text, out int rwcol);
            List<int> col = new List<int>
            {
                phycol,
                logcol,
                rwcol,
                bitcol
            };
            AddDisplayLineInfo(string.Format("Read sheet [{0}] ... ...", sheet.SheetName));
            List<List<string>> result = ReadSheet(sheet, row, col);
            AddDisplayLineInfo(string.Format("Read sheet [{0}] over", sheet.SheetName));

            for (int i = 0; i < result[0].Count; i++)
            {
                AddDisplayInfo(result[0][i].PadRight(8));
                AddDisplayInfo(result[1][i].PadRight(20));
                AddDisplayInfo(result[2][i].PadRight(8));
                AddDisplayLineInfo(result[3][i].PadRight(10));
            }

            // 规范化数据
            List<string> phy = new List<string>();
            List<string> log = new List<string>();
            List<string> rw = new List<string>();
            List<string> bit = new List<string>();
            foreach (string s in result[0])
            {
                // 字母转小写并去除所有空格
                phy.Add(s.ToLower().Trim().Replace(" ", ""));// 偏移值  如：0x1f
            }
            foreach (string s in result[1])
            {
                // 字母转大写去除空格并将除字母数字外的字符转化为下划线
                log.Add(Regex.Replace(s.ToUpper().Trim().Replace(" ", ""), @"\W+", "_"));// 名字
            }
            foreach (string s in result[2])
            {
                rw.Add(s.ToLower());// 读写权限
            }
            foreach (string s in result[3])
            {
                // 去除所有空格
                bit.Add(s.Trim().Replace(" ", ""));// 有效bit位  如：[15:0]或[0]
            }

            for (int i = 0; i < phy.Count; i++)
            {
                AddDisplayInfo(phy[i].PadRight(8));
                AddDisplayInfo(log[i].PadRight(20));
                AddDisplayInfo(rw[i].PadRight(8));
                AddDisplayLineInfo(bit[i].PadRight(10));
            }

            //格式化数据
            //struct
            //List<string> structMember = FormatStructMember(phy, log, bit);
            List<List<string>> structMemberBFB = FormatStructMemberWithBFB(phy, log, bit);

            //for (int i = 0; i < structMember.Count; i++)
            //{
            //    AddDisplayLineInfo(structMember[i]);
            //}

            foreach (List<string> l in structMemberBFB)
            {
                foreach (string s in l)
                {
                    AddDisplayLineInfo(s);
                }
            }

            //输出数据
            HeaderFile hFile = new HeaderFile(tbOutputPath.Text);
            if (!hFile.IsInitSuccess())
            {
                MessageBox.Show("路径：" + Path.GetDirectoryName(tbOutputPath.Text) + "不存在");
                return;
            }
            hFile.AddFileHeadNotes();
            hFile.AddFileMacroAtHead();
            hFile.AddHeadNotes("include");
            hFile.AddIncludeFile("gk_type.h");
            hFile.AddHeadNotes("struct");
            //hFile.AddStruct(structMember, "test");
            hFile.AddStructWithBitField(structMemberBFB, "test");
            hFile.AddFileMacroAtTail();

            hFile.Close();
            wb.Close();
        }

        /// <summary>
        /// 读取指定工作表的指定单元格
        /// </summary>
        /// <param name="sheet">待读取的工作表</param>
        /// <param name="row">前两个数有效，第一个数是开始行，第二个数是结束行，从0开始计算</param>
        /// <param name="col">带读取的列号，从0开始计算</param>
        /// <returns>
        /// 二维列表，顺序与指定‘col’的顺序一致
        /// </returns>
        List<List<string>> ReadSheet(ISheet sheet, List<int> row, List<int> col)
        {
            List<List<string>> ret = new List<List<string>>();
            List<string> tmp;

            foreach (int i in col)
            {
                tmp = new List<string>();
                for (int j = row[0]; j < row[1]; j++)
                {
                    if (Excel.GetCellValue(sheet, j, i, out string str))
                    {
                        tmp.Add(str);
                    }
                }
                ret.Add(tmp);
            }

            return ret;
        }

        List<List<string>> FormatStructMemberWithBFB(List<string> offset, List<string> name, List<string> bitRange)
        {
            List<List<string>> ret = new List<List<string>>();

            // 按位域分块
            string tmp = offset[0];
            List<List<string>> nameBlock = new List<List<string>>();
            List<List<string>> bitBlock = new List<List<string>>();
            List<string> nameTmp = new List<string>();
            List<string> bitTmp = new List<string>();
            List<int> bitNUm = new List<int>();

            foreach (string s in bitRange)
            {
                bitNUm.Add(GetEndBit(s) - GetStartBit(s) + 1);
            }
            nameTmp.Add(name[0]);
            bitTmp.Add(bitRange[0]);

            for (int i = 1; i < offset.Count; i++)
            {
                if (offset[i] == tmp) // 偏移值相同的块
                {
                    // 按照位域的先后顺序添加元素
                    if (bitTmp.Count == 0) // 块内无元素，则直接添加
                    {
                        nameTmp.Add(name[i]);
                        bitTmp.Add(bitRange[i]);
                    }
                    else
                    {
                        // 新元素的开始位最大，则添加到末尾
                        if (GetStartBit(bitRange[i]) > GetEndBit(bitTmp[bitTmp.Count - 1]))
                        {
                            nameTmp.Add(name[i]);
                            bitTmp.Add(bitRange[i]);
                        }
                        else
                        {
                            for (int j = 0; j < bitTmp.Count; j++)
                            {
                                // 查找新元素应该放入的位置
                                if (GetEndBit(bitRange[i]) < GetStartBit(bitTmp[j]))
                                {
                                    nameTmp.Insert(j, name[i]);
                                    bitTmp.Insert(j, bitRange[i]);
                                    break;
                                }
                            }
                        }
                    }
                }
                else // 偏移值不同，开辟新块
                {
                    // 将前一个位域块添加到对应的block
                    nameBlock.Add(nameTmp);
                    bitBlock.Add(bitTmp);
                    // 获取新的偏移值
                    tmp = offset[i];
                    // new新块
                    nameTmp = new List<string>();
                    bitTmp = new List<string>();
                    nameTmp.Add(name[i]);
                    bitTmp.Add(bitRange[i]);
                }
            }
            nameBlock.Add(nameTmp);
            bitBlock.Add(bitTmp);

            for (int i = 0; i < nameBlock.Count; i++)
            {
                ret.Add(HeaderFile.CreateBitFieldBlock("GK_U32", nameBlock[i], bitBlock[i], 32));
            }

            return ret;
        }

        List<string> FormatStructMember(List<string> offset, List<string> name, List<string> bitRange)
        {
            List<List<string>> result = FormatStructMemberWithBFB(offset, name, bitRange);
            List<string> ret = new List<string>();

            for (int i = 0; i < result.Count; i++)
            {
                ret.InsertRange(ret.Count, result[i]);
            }

            return ret;
        }

        int GetStartBit(string bitRange)
        {
            string pattern = @"([0-9]+)\]";
            Regex re = new Regex(pattern);
            Match ma = re.Match(bitRange);
            return int.Parse(ma.Groups[1].Value);
        }

        int GetEndBit(string bitRange)
        {
            string pattern = @"\[([0-9]+)";
            Regex re = new Regex(pattern);
            Match ma = re.Match(bitRange);
            return int.Parse(ma.Groups[1].Value);
        }

        void SaveUserInfo()
        {
            List<string> userInfo = new List<string>();
            userInfo.Add(tbInputPath.Text);
            userInfo.Add(tbOutputPath.Text);
            userInfo.Add(tbConfigFilePath.Text);
            userInfo.Add(tbPhyRegCol.Text);
            userInfo.Add(tbLogRegCol.Text);
            userInfo.Add(tbRWCol.Text);
            userInfo.Add(tbBitPosCol.Text);
            userInfo.Add(tbStartRow.Text);
            userInfo.Add(tbEndRow.Text);
            userInfo.Add(tbSheetName.Text);
            userInfo.Add(tbModuleName.Text);
            userInfo.Add(ckbUseDefault.Checked.ToString());
            userInfo.Add(ckbUseConfigFile.Checked.ToString());
            userInfo.Add(ckbDebugInfo.Checked.ToString());
            UserInfo.SaveUserInfo(userInfo);
        }

        void RestoreUserInfo()
        {
            if (UserInfo.ReadUserInfo(out List<string> info))
            {
                int index = 0;
                tbInputPath.Text = info[index++];
                tbOutputPath.Text = info[index++];
                tbConfigFilePath.Text = info[index++];
                tbPhyRegCol.Text = info[index++];
                tbLogRegCol.Text = info[index++];
                tbRWCol.Text = info[index++];
                tbBitPosCol.Text = info[index++];
                tbStartRow.Text = info[index++];
                tbEndRow.Text = info[index++];
                tbSheetName.Text = info[index++];
                tbModuleName.Text = info[index++];
                ckbUseDefault.Checked = bool.Parse(info[index++]);
                ckbUseConfigFile.Checked = bool.Parse(info[index++]);
                ckbDebugInfo.Checked = bool.Parse(info[index++]);
            }
        }
    }
}
