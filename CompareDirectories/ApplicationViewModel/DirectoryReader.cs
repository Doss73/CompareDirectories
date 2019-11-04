using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CompareDirectories.ApplicationViewModel
{
    /// <summary>
    /// Provides operations for reading information about directories
    /// </summary>
    public class DirectoryReader
    {
        /// <summary>
        /// Provides operation of folders select 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Checks whether directory is exist
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsExist(string path)
        {
            if (Directory.Exists(path))
                return true;
            else throw new Exception("The folder is not exist");
        }
        /// <summary>
        /// Provides operation of getting all files paths in specific directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string[] GetFiles(string path)
        {
            string[] arrayZip = Directory.GetFiles(@path, "*.zip");
            return arrayZip.Concat(Directory.GetFiles(path)).ToArray();
        }
    }
}
