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

        public static FileStream CreatnewOrTruncate(string filename)
        {
            try
            {
                FileStream file = new FileStream
                    (filename, FileMode.CreateNew, FileAccess.Write);
                return file;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory not found");
                return null;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
                return null;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Param not found");

                return null;
            }
            catch (IOException)
            {
                FileStream file = new FileStream
                    (filename, FileMode.Truncate, FileAccess.Write);
                return file;
            }
        }
    }


}
