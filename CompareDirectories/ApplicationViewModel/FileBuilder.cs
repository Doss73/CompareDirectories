﻿using CompareDirectories.Interfaces;
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
    /// <summary>
    /// Provides creation file by concrete way 
    /// </summary>
    public class FileBuilder:IFileBuilder
    {
        /// <summary>
        /// Represent building file
        /// </summary>
        private FileProduct file;
        /// <summary>
        /// Instance of FileInfo for getting information for file
        /// </summary>
        private FileInfo fileInfo;
        /// <summary>
        /// List of created files
        /// </summary>
        ObservableCollection<FileProduct> files = new ObservableCollection<FileProduct>();
        /// <summary>
        /// Represent whether instance of FileProduct is created
        /// </summary>
        bool isInitialized = false;
        /// <summary>
        /// Create instance of FileProduct
        /// </summary>
        /// <param name="filePath"></param>
        public void Initialize(string filePath)
        {
            file = new FileProduct(filePath);
            fileInfo = new FileInfo(filePath);
            isInitialized = true;
        }
        /// <summary>
        /// Getting name of the file
        /// </summary>
        public void GetName()
        {if(isInitialized)
            file.Name = fileInfo.Name;
        }
        /// <summary>
        /// Getting size of file in string and bytes formats
        /// </summary>
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
        /// <summary>
        /// Getting date of last editing of dile
        /// </summary>
        public void GetDate()
        {
            if (isInitialized)
                file.Date = fileInfo.LastWriteTime.Date.ToShortDateString();
        }
        /// <summary>
        /// Dettermines correct status of file
        /// </summary>
        /// <param name="firstPath"></param>
        /// <param name="secondPath"></param>
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
                        file.Status = Statuses.status[i];
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Adds file to list
        /// </summary>
        public void AddFile()
        {
            if (isInitialized)
                if (files.Where(obj => obj.Name == file.Name).FirstOrDefault() == null)
                    files.Add(file);
        }
        /// <summary>
        /// Returns list of files
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<FileProduct> ShowProduct()
        {
            if (isInitialized)
                return files;
            return null;
        }
    }
}
