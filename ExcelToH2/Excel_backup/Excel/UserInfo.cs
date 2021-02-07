using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XJHSelfUse
{
    class UserInfo
    {
        public static void SaveUserInfo(string[] str)
        {
            FileStream file = FileSelect.CreatnewOrTruncate("UserInfo.txt");
            BinaryWriter bin_w = new BinaryWriter(file);
            StreamWriter txt_w = new StreamWriter(file);
            foreach (string s in str)
            {
                txt_w.WriteLine(s);
                txt_w.Flush();
                //bin_w.Write(s);
                //bin_w.Write("\n");
            }
            file.Close();
        }

        public static void ReadUserInfo(out string[] str)
        {
            try
            {
                StreamReader file_r = new StreamReader("UserInfo.txt");
                int linenum = 0;
                // 获取文本的行数，获取下一个字符，如果到末尾peek()返回-1
                while (file_r.Peek() > 0)
                {
                    file_r.ReadLine();
                    linenum++;
                }
                file_r.Close();
                //重新打开文件，将读指针移到文件头
                file_r = new StreamReader("UserInfo.txt");

                str = new string[linenum];
                //读取文件每行的内容，存到str中
                for (int i = 0; i < linenum; i++)
                {
                    str[i] = file_r.ReadLine().Trim();
                }

                file_r.Close();
            }
            catch (FileNotFoundException)
            {
                str = null;
            }
        }

        public static void CreatDebugInfo()
        {
            FileStream file = FileSelect.CreatnewOrTruncate("DebugInfo.txt");

            file.Close();
        }

        public static void SaveDebugInfo(string[] str)
        {
            FileStream file = FileSelect.CreatnewOrTruncate("DebugInfo.txt");
            BinaryWriter bin_w = new BinaryWriter(file);
            StreamWriter txt_w = new StreamWriter(file);
            foreach (string s in str)
            {
                txt_w.WriteLine(s);
                txt_w.Flush();
                //bin_w.Write(s);
                //bin_w.Write("\n");
            }
            file.Close();
        }

        public static void SaveDebugInfo(string str)
        {
            FileStream file = FileSelect.CreatnewOrTruncate("DebugInfo.txt");
            BinaryWriter bin_w = new BinaryWriter(file);
            StreamWriter txt_w = new StreamWriter(file);

            txt_w.WriteLine(str);
            txt_w.Flush();

            file.Close();
        }

        public static void AddDebugInfo(string[] str)
        {
            FileStream file = new FileStream
                    ("DebugInfo.txt", FileMode.Append, FileAccess.Write);
            BinaryWriter bin_w = new BinaryWriter(file);
            StreamWriter txt_w = new StreamWriter(file);
            foreach (string s in str)
            {
                txt_w.WriteLine(s);
                txt_w.Flush();
                //bin_w.Write(s);
                //bin_w.Write("\n");
            }
            file.Close();
        }

        public static void AddDebugInfo(string str)
        {
            FileStream file = new FileStream
                    ("DebugInfo.txt", FileMode.Append, FileAccess.Write);
            BinaryWriter bin_w = new BinaryWriter(file);
            StreamWriter txt_w = new StreamWriter(file);

            txt_w.WriteLine(str);
            txt_w.Flush();
            file.Close();
        }
    }
}
