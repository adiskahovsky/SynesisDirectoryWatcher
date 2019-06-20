using DirectoryWatcher.PL.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.PL.WPF.Models
{
    public class DirectoryModel : IThreeModelItem
    {
        public string FullName { get; set; }
        public string Name { get ; set; }

        public ObservableCollection<IThreeModelItem> directoryModelItems { get; set; }


    }
}
