using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDirectories.Interfaces
{
    public interface IBuilder
    {
        void Initialize(string filePath);
        void GetName();
        void GetSize();
        void GetDate();
        void GetStatus(string firstPath, string secondPath);
        void AddFile();
        ObservableCollection<FileProduct> GetProduct();
    }
}
