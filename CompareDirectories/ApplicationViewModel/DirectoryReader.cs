using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CompareDirectories.ApplicationViewModel
{
    public class DirectoryReader
    {
        public string GetPath()
        {
            string filename = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.AllowNonFileSystemItems = false;
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                filename = dialog.FileName;
            return filename;
        }

        public bool IsExist(string path)
        {
            if (Directory.Exists(path))
                return true;
            else throw new Exception("The folder is not exist");
        }
        public string[] GetFiles(string path)
        {
            string[] arrayZip = Directory.GetFiles(@path, "*.zip");
            return arrayZip.Concat(Directory.GetFiles(path)).ToArray();
        }
    }
}
