using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace XJHSelfUse
{
    class FileSelect
    {
        public static string SelectInputFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        public static string SelectInputFile(string filter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        public static string SelectOutputFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        public static string SelectOutputFile(string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        public static string SelectOutputPath()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.SelectedPath;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 创建新文件或以打开已存在的文件的同时清除全部内容
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <returns>成功打开返回文件的FileStream，若文件的路径不存在则返回null</returns>
        public static FileStream CreateNewOrTruncate(string filename)
        {
            if(!Directory.Exists(Path.GetDirectoryName(Path.GetFullPath(filename))))
            {
                return null;
            }
            if(File.Exists(filename))
            {
                FileStream file = new FileStream
                    (filename, FileMode.Truncate, FileAccess.Write);
                return file;
            }
            else
            {
                FileStream file = new FileStream
                    (filename, FileMode.CreateNew, FileAccess.Write);
                return file;
            }
        }

        public static List<string> ReadFile(string fileName)
        {
            List<string> ret = new List<string>();

            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string tmp;

                while((tmp = reader.ReadLine()) != null)
                {
                    ret.Add(tmp);
                }
            }
            return ret;
        }
    }


}
