using DirectoryWatcher.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.BLL.DTOs
{
    internal class FolderDTO:IDirectoryItem
    {
        

        public ICollection<IDirectoryItem> DirectoryItems { get; set; }

        public string Name { get; set ; }
        public string FullName { get ; set ; }
    }
}
