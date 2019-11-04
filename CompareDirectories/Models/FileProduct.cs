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
        private string filePath;
        private string name;
        private string sizeWithSuffix;
        private long sizeInBytes;
        private DateTime date;
        private string status;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
              
            }
        }
        public string SizeWithSuffix
        {
            get { return sizeWithSuffix; }
            set
            {
                sizeWithSuffix = value;
                
            }
        }
        public long SizeInBytes
        {
            get { return sizeInBytes; }
            set
            {
                sizeInBytes = value;
            }
        }
        public string Date
        {
            get { return date.ToShortDateString(); }
            set
            {
                DateTime.TryParse(value, out date);
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
               
            }
        }
        public FileProduct(string filePath)
        {
            this.filePath = filePath;
        }
      
    }
}
