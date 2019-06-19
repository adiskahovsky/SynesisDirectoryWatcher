using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.BLL.Interfaces
{
    interface IDirectoryItem
    {

        string Name { get; set; }
        string FullName { get; set; }

    }
}
