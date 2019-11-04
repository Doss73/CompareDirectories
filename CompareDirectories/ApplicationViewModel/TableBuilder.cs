using CompareDirectories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectories.ApplicationViewModel
{
    /// <summary>
    /// Provides constructing of files list
    /// </summary>
    public class TableBuilder
    {
        /// <summary>
        /// Provides correct constructing of files list
        /// </summary>
        /// <param name="fileBuilder"></param>
        /// <param name="firstPath"></param>
        /// <param name="secondPath"></param>
        public void Construct(IFileBuilder fileBuilder,string firstPath, string secondPath)
        {
            string[] filesFromFirstFolder = new DirectoryReader().GetFiles(firstPath);
            string[] filesFromSecondFolder = new DirectoryReader().GetFiles(secondPath);
            string[][] allFiles = new string[][] { filesFromFirstFolder, filesFromSecondFolder };
            for(int i = 0; i < allFiles.Length; i++)
            {
                for(int j = 0; j < allFiles[i].Length; j++)
                {
                    fileBuilder.Initialize(allFiles[i][j]);
                    fileBuilder.GetName();
                    fileBuilder.GetSize();
                    fileBuilder.GetDate();
                    fileBuilder.GetStatus(firstPath,secondPath);
                    fileBuilder.AddFile();
                }
            }
        }
    }
}
