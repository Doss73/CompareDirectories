using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectories.Interfaces
{
    /// <summary>
    /// Provides creation file with it properties
    /// </summary>
    public interface IFileBuilder
    {
        /// <summary>
        /// Create instance of FileProduct
        /// </summary>
        /// <param name="filePath"></param>
        void Initialize(string filePath);
        /// <summary>
        /// Getting name of the file
        /// </summary>
        void GetName();
        /// <summary>
        /// Getting size of file
        /// </summary>
        void GetSize();
        /// <summary>
        /// Getting date of last editing of dile
        /// </summary>
        void GetDate();
        /// <summary>
        /// Dettermines correct status of file
        /// </summary>
        /// <param name="firstPath"></param>
        /// <param name="secondPath"></param>
        void GetStatus(string firstPath, string secondPath);
        /// <summary>
        /// Adds file to list
        /// </summary>
        void AddFile();
        /// <summary>
        /// Returns list of files
        /// </summary>
        /// <returns></returns>
        ObservableCollection<FileProduct> ShowProduct();
    }
}
