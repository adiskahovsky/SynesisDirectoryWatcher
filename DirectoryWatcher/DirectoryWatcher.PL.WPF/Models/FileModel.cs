using DirectoryWatcher.PL.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.PL.WPF.Models
{
    public class FileModel : IThreeModelItem
    {
        public string FullName { get ; set ; }
        public string Name { get; set; }


        public long Lenght { get; set; }
    }
}
