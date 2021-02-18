using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace XJHSelfUse
{
    class HeaderFile
    {
        FileStream Header { get; }
        StreamWriter HeaderWrite { get; }

        /// <summary>
        /// 初始化该类的实例，创建操作指定头文件的FileStream和StreamWriter
        /// </summary>
        /// <param name="filename">头文件名</param>
        public HeaderFile(string filename)
        {
            Header = FileSelect.CreateNewOrTruncate(filename);
            if (Header != null)
            {
                HeaderWrite = new StreamWriter(Header);
            }
        }

        /// <summary>
        /// 判断实例初始化成功与否
        /// </summary>
        /// <returns>false代表文件路径不存在而初始化失败，true代表初始化成功</returns>
        public bool IsInitSuccess()
        {
            if (Header == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 将缓冲区的数据写入文件
        /// </summary>
        public void Flush()
        {
            HeaderWrite.Flush();
        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void Close()
        {
            HeaderWrite.Close();
        }

        /// <summary>
        /// 按照默认模板添加文件头注释
        /// </summary>
        /// <param name="Author">作者</param>
        /// <param name="Description">描述</param>
        public void AddFileHeadNotes(string Author = "", string Description = "")
        {
            string notes =
                "/******************************************************************************\n" +
                "Copyright (C)\n" +
                "\n" +
                "File Name     : " + Path.GetFileName(Header.Name) + "\n" +
                "Version       : Initial Draft\n" +
                "Author        : " + Author + "\n" +
                "Created       : " + DateTime.Now.ToString("yyyy/MM/dd") + "\n" +
                "Description   : " + Description + "\n" +
                "History       : \n" +
                "1.Date        : " + DateTime.Now.ToString("yyyy/MM/dd") + "\n" +
                "  Author      : " + Author + "\n" +
                "  Modification: Created file\n" +
                "*******************************************************************************/";
            HeaderWrite.WriteLine(notes);
        }

        /// <summary>
        /// 板块头注释
        /// </summary>
        /// <param name="description">描述</param>
        public void AddHeadNotes(string description)
        {
            string notes =
                "\n" +
                "/*----------------------------------------------------------------------------*/\n" +
                "/*" + description.PadRight(76) + "*/\n" +
                "/*----------------------------------------------------------------------------*/";
            HeaderWrite.WriteLine(notes);
        }

        /// <summary>
        /// 向文件添加 ‘include 头文件’的代码，效果示例：#include "filename"
        /// </summary>
        /// <param name="filename">需要包含的头文件名</param>
        public void AddIncludeFile(string filename)
        {
            HeaderWrite.WriteLine("#include \"{0}\"", filename);
        }

        /// <summary>
        /// 向文件添加 条件编译 前半部分代码，防止重复包含，
        /// 效果示例：
        /// #ifndef __filename__
        /// #define __filename__
        /// </summary>
        public void AddFileMacroAtHead()
        {
            string Macro = Path.GetFileNameWithoutExtension(Header.Name).ToUpper();
            Macro = "__" + Macro + "_H__";
            HeaderWrite.WriteLine("#ifndef " + Macro);
            HeaderWrite.WriteLine("#define " + Macro);
        }

        /// <summary>
        /// 向文件添加 条件编译 后半部分代码，防止重复包含，
        /// 效果示例：
        /// #endif /*__filename__*/
        /// </summary>
        public void AddFileMacroAtTail()
        {
            string Macro = Path.GetFileNameWithoutExtension(Header.Name).ToUpper();
            Macro = "__" + Macro + "_H__";
            HeaderWrite.WriteLine("#endif /*" + Macro + "*/");
        }

        /// <summary>
        /// 向文件追加 枚举 定义
        /// </summary>
        /// <param name="member">枚举成员 格式要求：成员名 或 成员名+‘=’+值 'example'或'example=1'</param>
        /// <param name="name">枚举结构的名字</param>
        public void AddEnum(List<string> member, string name)
        {
            name = name.ToUpper();
            if (!name.EndsWith("_E"))
            {
                name += "_E";
            }
            string str =
                "typedef enum _" + name + "\n" +
                "{\n";
            foreach (string s in member)
            {
                str += "    " + s.ToUpper() + ",\n";
            }
            str += "} " + name + ";\n";

            HeaderWrite.WriteLine(str);
        }

        /// <summary>
        /// 向文件追加 共用体 定义
        /// </summary>
        /// <param name="member">共用体成员 格式要求：类型+空格+变量名'int example'</param>
        /// <param name="name">共用体结构的名字</param>
        public void AddUnion(List<string> member, string name)
        {
            name = name.ToUpper();
            if (!name.EndsWith("_U"))
            {
                name += "_U";
            }
            string str =
                "typedef union _" + name + "\n" +
                "{\n";
            foreach (string s in member)
            {
                if (s.EndsWith(";"))
                {
                    str += "    " + s + "\n";
                }
                else
                {
                    str += "    " + s + ";\n";
                }
            }
            str += "} " + name + ";\n";
            HeaderWrite.WriteLine(str);
        }

        /// <summary>
        /// 向文件加入 带位域的共用体 定义
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="member">共用体位域成员 格式要求：变量名+‘:’+位数 'example : 2'</param>
        /// <param name="name">共用体名字</param>
        public void AddUnionBitField(string type, List<string> member, string name)
        {
            name = name.ToUpper();
            if (!name.EndsWith("_U"))
            {
                name += "_U";
            }
            string str =
                "typedef union _" + name + "\n" +
                "{\n" +
                "    " + type + " all;\n" +
                "    struct\n" +
                "    {\n";
            foreach (string s in member)
            {
                if (s.EndsWith(";"))
                {
                    str += "        " + type + " " + s + "\n";
                }
                else
                {
                    str += "        " + type + " " + s + ";\n";
                }
            }
            str += "    }bitc;\n";
            str += "} " + name + ";\n";
            HeaderWrite.WriteLine(str);
        }

        /// <summary>
        /// 向文件追加 结构体 定义
        /// </summary>
        /// <param name="member">结构体成员 格式要求：类型+空格+变量名'int example;'或'int example : 12;'</param>
        /// <param name="name">结构体的名字</param>
        public void AddStruct(List<string> member, string name)
        {
            name = name.ToUpper();
            if (!name.EndsWith("_S"))
            {
                name += "_S";
            }
            string str =
                "typedef struct _" + name + "\n" +
                "{\n";
            foreach (string s in member)
            {
                str += "    " + s + "\n";
            }
            str += "} " + name + ";\n";
            HeaderWrite.WriteLine(str);
        }

        /// <summary>
        /// 向文件追加 结构体 定义, 位域块之间会有空行
        /// </summary>
        /// <param name="member">结构体成员 格式要求：类型+空格+变量名'int example;'或'int example : 12;'</param>
        /// <param name="name">结构体的名字</param>
        public void AddStructWithBitField(List<List<string>> member, string name)
        {
            name = name.ToUpper();
            if (!name.EndsWith("_S"))
            {
                name += "_S";
            }
            string str =
                "typedef struct _" + name + "\n" +
                "{\n";
            foreach (List<string> l in member)
            {
                str += "\n";
                foreach (string s in l)
                {
                    str += "    " + s + "\n";
                }
            }
            str += "} " + name + ";\n";
            HeaderWrite.WriteLine(str);
        }

        /// <summary>
        /// 向文件追加 宏定义
        /// </summary>
        /// <param name="macro">
        /// 宏定义内容 格式要求：可以不带‘#define ’例：'U32 int'或'#define U32 int'
        /// 
        /// </param>
        public void AddMacro(List<string> macro)
        {
            foreach (string s in macro)
            {
                if (s.StartsWith("#define "))
                {
                    HeaderWrite.WriteLine(s);
                }
                else
                {
                    HeaderWrite.WriteLine("#define " + s);
                }
            }
        }

        /// <summary>
        /// 向文件追加 函数声明
        /// </summary>
        /// <param name="func">函数声明内容 格式要求： 'void function(int example)'</param>
        public void AddFunctionDeclare(List<string> func)
        {
            foreach (string s in func)
            {
                HeaderWrite.WriteLine(s);
            }
        }

        /// <summary>
        /// 生成一个位域块
        /// </summary>
        /// <param name="type">变量类型</param>
        /// <param name="name">变量名</param>
        /// <param name="bitNum">对应变量的位数</param>
        /// <param name="typeBitNum">该类型的总位数</param>
        /// <returns>一个位域块</returns>
        static public List<string> CreateBitFieldBlock(string type, List<string> name, List<int> bitNum, int typeBitNum)
        {
            List<string> ret = new List<string>();
            int sum = 0;
            foreach (int n in bitNum)
            {
                sum += n;
            }
            for (int i = 0; i < bitNum.Count; i++)
            {
                ret.Add(type + " " + name[i] + " : " + bitNum[i] + ";");
            }
            int reserved = typeBitNum - sum;
            if (reserved > 0)
            {
                ret.Add(type + " : " + reserved + ";");
            }


            //// 给位域加注释
            //List<string> notes = new List<string>();
            //int tmp = 0;
            //foreach (int n in bitNum)
            //{
            //    if (n == 1)
            //    {
            //        notes.Add(string.Format("/* [{0}]", tmp).PadRight(11) + "*/");
            //    }
            //    else
            //    {
            //        notes.Add(string.Format("/* [{0}:{1}]", tmp + n - 1, tmp).PadRight(11) + "*/");
            //    }
            //    tmp += n;
            //}
            //if (reserved > 0)
            //{
            //    if(reserved == 1)
            //    {
            //        notes.Add(string.Format("/* [{0}]", tmp).PadRight(11) + "*/");
            //    }
            //    else
            //    {
            //        notes.Add(string.Format("/* [{0}:{1}]", tmp + reserved - 1, tmp).PadRight(11) + "*/");
            //    }
            //}

            //int maxLen = 0;
            //foreach (string s in ret)
            //{
            //    maxLen = s.Length > maxLen ? s.Length : maxLen;
            //}
            //for (int i = 0; i < ret.Count; i++)
            //{
            //    ret[i] = ret[i].PadRight(maxLen + 1) + notes[i];
            //}

            return ret;
        }

        /// <summary>
        /// 生成位域块，位数不足会自动使用无名位域补全
        /// </summary>
        /// <param name="type">变量类型</param>
        /// <param name="name">变量名</param>
        /// <param name="bitRange">位域范围，格式要求： [a:b]或[a] a、b为数字且a>=b</param>
        /// <param name="typeBitNum">该类型的位数</param>
        /// <returns>字符串列表</returns>
        static public List<string> CreateBitFieldBlock(string type, List<string> name, List<string> bitRange, int typeBitNum)
        {
            List<string> ret = new List<string>();
            List<int> bitNum = new List<int>();
            List<string> nameTmp = new List<string>();
            int end = -1;
            for (int i = 0; i < name.Count; i++)
            {
                int start = GetStartBit(bitRange[i]);
                if (start - end != 1) // 无名位域
                {
                    bitNum.Add(start - end - 1);
                    nameTmp.Add("");
                }

                end = GetEndBit(bitRange[i]);
                bitNum.Add(end - start + 1);
                nameTmp.Add(name[i]);
            }

            int sum = 0;
            foreach (int n in bitNum)
            {
                sum += n;
            }
            for (int i = 0; i < bitNum.Count; i++)
            {
                ret.Add(type + " " + nameTmp[i] + " : " + bitNum[i] + ";");
            }
            int reserved = typeBitNum - sum;
            if (reserved > 0)
            {
                ret.Add(type + " : " + reserved + ";");
            }

            return ret;
        }

        /// <summary>
        /// 获取开始位
        /// </summary>
        /// <param name="bitRange">位域范围，格式要求： [a:b]或[a] a、b为数字且a>=b</param>
        /// <returns>开始位</returns>
        static public int GetStartBit(string bitRange)
        {
            string pattern = @"([0-9]+)\]";
            Regex re = new Regex(pattern);
            Match ma = re.Match(bitRange);
            return int.Parse(ma.Groups[1].Value);
        }

        /// <summary>
        /// 获取结束位
        /// </summary>
        /// <param name="bitRange">位域范围，格式要求： [a:b]或[a] a、b为数字且a>=b</param>
        /// <returns>结束位</returns>
        static public int GetEndBit(string bitRange)
        {
            string pattern = @"\[([0-9]+)";
            Regex re = new Regex(pattern);
            Match ma = re.Match(bitRange);
            return int.Parse(ma.Groups[1].Value);
        }
    }
}
