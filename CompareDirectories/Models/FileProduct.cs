using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CompareDirectories
{
    /// <summary>
    /// Provides model of file
    /// </summary>
    public class FileProduct
    {
        /// <summary>
        /// File path
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Name of file
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents size of file
        /// </summary>
        public string SizeWithSuffix { get; set; }
        /// <summary>
        /// Size of file reprsent as number for correct sorting
        /// </summary>
        public long SizeInBytes { get; set; }
        /// <summary>
        /// Date of last editing file
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Represent status of file
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Creates instance of FileProduct class
        /// </summary>
        /// <param name="filePath"></param>
        public FileProduct(string filePath)
        {
            FilePath = filePath;
        }
      
    }
}
