using DirectoryWatcher.PL.WPF.Interfaces;
using DirectoryWatcher.PL.WPF.Models;
using DirectoryWatcher.PL.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.PL.WPF.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private ObservableCollection<IThreeModelItem> _directories;

        public ObservableCollection<IThreeModelItem> Directories
        {
            get { return _directories; }
            set { _directories = value; OnPropertyChanged(); }
        }



        public MainWindowViewModel()
        {
            Directories = new ObservableCollection<IThreeModelItem>();
            { new DirectoryModel() { FullName = "fsdfsdfds", Name = "fsdfsdfsd" }; }
            
        }

  



    }
}
