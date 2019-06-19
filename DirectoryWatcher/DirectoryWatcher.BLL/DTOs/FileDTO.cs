using DirectoryWatcher.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.BLL.DTOs
{
    internal class FileDTO:IDirectoryItem
    {
        
        public long FileByteCount { get; set; }
        public string Name { get ; set ; }
        public string FullName { get ; set ; }
    }
}
