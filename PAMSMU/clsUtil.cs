using System;
using System.IO;
using System.Windows.Forms;

namespace PAMSMU
{
    internal class clsUtil
    {
        private static string _GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        private static bool _CreateFolderIfDoesNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                    return true;
                }
                catch (IOException IoExp)
                {

                    MessageBox.Show(IoExp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private static string _ReplcementNameImage(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            string Extn = fileInfo.Extension;
            return _GenerateGUID() + Extn;
        }
        public static bool CopyImageToFolderImage(ref string SourcePath)
        {
            string DestinationPath = @"C:\PAMSMU-People-Images\";

            if (!_CreateFolderIfDoesNotExist(DestinationPath))
            {
                return false;
            }

            DestinationPath = DestinationPath + _ReplcementNameImage(SourcePath);
            try
            {
                File.Copy(SourcePath, DestinationPath, true);
            }
            catch (IOException IoExp)
            {

                MessageBox.Show(IoExp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourcePath = DestinationPath;
            return true;

        }
    }
}
