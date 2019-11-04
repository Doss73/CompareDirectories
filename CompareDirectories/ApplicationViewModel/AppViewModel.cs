using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CompareDirectories.ApplicationViewModel
{
    /// <summary>
    /// Wrraper for manage data from models
    /// </summary>
    public class AppViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Represents path of the first directory
        /// </summary>
        private string firstDirectoryPath = "";
        /// <summary>
        /// Represents path of the second directory
        /// </summary>
        private string secondDirectoryPath = "";
        /// <summary>
        /// Represent files from directories
        /// </summary>
        public ObservableCollection<FileProduct> Files { get; set; }
        /// <summary>
        /// Incapsulate BrowseFirstDirectoryCommand
        /// </summary>
        private RelayCommand browseFirstDirectoryCommand;
        /// <summary>
        /// Command to choose the first directory
        /// </summary>
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
        /// <summary>
        /// Incapsulate BrowseSecondDirectoryCommand
        /// </summary>
        private RelayCommand browseSecondDirectoryCommand;
        /// <summary>
        /// Command to choose the second directory
        /// </summary>
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
        /// <summary>
        /// Incapsulate CompareDirectoryCommand
        /// </summary>
        private RelayCommand compareDirectoriesCommand;
        /// <summary>
        /// Command to execute comparing two directories
        /// </summary>
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
                      Files = builder.ShowProduct();
                      OnPropertyChanged("Files");
                  }));
            }
        }
       
        /// <summary>
        /// Provides getting path of the first directory path and checks whether it is exist
        /// </summary>
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
        /// <summary>
        /// Provides getting path of the first directory path and checks whether it is exist
        /// </summary>
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
        
        /// <summary>
        /// Special event for notifies the system of property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Bind concrete property to update changed
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
