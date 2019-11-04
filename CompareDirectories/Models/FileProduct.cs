using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CompareDirectories
{
    public class FileProduct
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string SizeWithSuffix { get; set; }
        public long SizeInBytes { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public FileProduct(string filePath)
        {
            FilePath = filePath;
        }
      
    }
}
