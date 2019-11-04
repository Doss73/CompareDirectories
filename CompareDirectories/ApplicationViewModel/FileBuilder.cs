using CompareDirectories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompareDirectories.ApplicationViewModel
{
    public class FileBuilder:IBuilder
    {
        private FileProduct file;
        private FileInfo fileInfo;
        ObservableCollection<FileProduct> files = new ObservableCollection<FileProduct>();
        bool isInitialized = false;
        public void Initialize(string filePath)
        {
            file = new FileProduct(filePath);
            fileInfo = new FileInfo(filePath);
            isInitialized = true;
        }

        public void GetName()
        {if(isInitialized)
            file.Name = fileInfo.Name;
        }

        public void GetSize()
        {
            if (isInitialized)
            {
                long bytes = fileInfo.Length;
                file.SizeInBytes = bytes;
                //GB
                if (bytes >= 1073741824.0)
                    file.SizeWithSuffix = String.Format("{0:##.##}", bytes / 1073741824.0) + " GB";
                //MB
                else if (bytes >= 1048576.0)
                    file.SizeWithSuffix = String.Format("{0:##.##}", bytes / 1048576.0) + " MB";
                //KB
                else if (bytes >= 1024.0)
                    file.SizeWithSuffix = String.Format("{0:##.##}", bytes / 1024.0) + " KB";
                //Bytes
                else if (bytes < 1024.0)
                    file.SizeWithSuffix = bytes.ToString() + " Bytes";
            }
        }
        public void GetDate()
        {
            if (isInitialized)
                file.Date = fileInfo.LastWriteTime.Date.ToShortDateString();
        }
        public void GetStatus(string firstPath,string secondPath)
        {
            if (isInitialized)
            {
                string firstFilePath = firstPath + '\\' + file.Name;
                FileInfo fileInFirstFolder = new FileInfo(firstFilePath);
                string secondFilePath = secondPath + '\\' + file.Name;
                FileInfo fileInSecondFolder = new FileInfo(secondFilePath);
                bool[] expressions =
                {
                (fileInFirstFolder.Exists && !fileInSecondFolder.Exists),
                (!fileInFirstFolder.Exists && fileInSecondFolder.Exists),
                (fileInFirstFolder.Exists && fileInSecondFolder.Exists && fileInFirstFolder.Length == fileInSecondFolder.Length),
                (fileInFirstFolder.Exists && fileInSecondFolder.Exists && fileInFirstFolder.Length != fileInSecondFolder.Length)
            };
                for (int i = 0; i < expressions.Length; i++)
                {
                    if (expressions[i])
                    {
                        file.Status = Statuses.Status[i];
                        break;
                    }
                }
            }
        }
        public void AddFile()
        {
            if (isInitialized)
                if (files.Where(obj => obj.Name == file.Name).FirstOrDefault() == null)
                    files.Add(file);
        }
        public ObservableCollection<FileProduct> GetProduct()
        {
            if (isInitialized)
                return files;
            return null;
        }
    }
}
