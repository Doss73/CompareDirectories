using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CompareDirectories.ApplicationViewModel
{
    public class AppViewModel:INotifyPropertyChanged
    {
        private string firstDirectoryPath = "";
        private string secondDirectoryPath = "";
        
        public ObservableCollection<FileProduct> Files { get; set; }
        
        private RelayCommand browseFirstDirectoryCommand;
        public RelayCommand BrowseFirstDirectoryCommand
        {
            get
            {
                return browseFirstDirectoryCommand ??
                  (browseFirstDirectoryCommand = new RelayCommand(obj =>
                  {
                      firstDirectoryPath = new DirectoryReader().GetPath();
                      OnPropertyChanged("FirstDirectoryPath");
                  }));
            }
        }
        private RelayCommand browseSecondDirectoryCommand;
        public RelayCommand BrowseSecondDirectoryCommand
        {
            get
            {
                return browseSecondDirectoryCommand ??
                  (browseSecondDirectoryCommand = new RelayCommand(obj =>
                  {
                      secondDirectoryPath = new DirectoryReader().GetPath();
                      OnPropertyChanged("SecondDirectoryPath");
                  }));
            }
        }
        private RelayCommand compareDirectoriesCommand;
        public RelayCommand CompareDirectoriesCommand
        {
            get
            {
                return compareDirectoriesCommand ??
                  (compareDirectoriesCommand = new RelayCommand(obj =>
                  {
                      TableBuilder tableBuilder = new TableBuilder();
                      FileBuilder builder = new FileBuilder();
                      tableBuilder.Construct(builder,firstDirectoryPath, secondDirectoryPath);
                      Files = builder.GetProduct();
                      OnPropertyChanged("Files");
                  }));
            }
        }
       
        public string FirstDirectoryPath
        {
            get 
            {
                return firstDirectoryPath; 
            }
            set
            {
                    firstDirectoryPath = value;
                    OnPropertyChanged("FirstDirectoryPath");
                    new DirectoryReader().IsExist(firstDirectoryPath);
            }
        }
        public string SecondDirectoryPath
        {
            get { return secondDirectoryPath; }
            set
            {
                    secondDirectoryPath = value;
                    OnPropertyChanged("SecondDirectoryPath");
                    new DirectoryReader().IsExist(secondDirectoryPath);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
