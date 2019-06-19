using DirectoryWatcher.BLL.DTOs;
using DirectoryWatcher.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWatcher.BLL.Services
{
    internal class DirectoryWatcherService
    {

        private string _mainDirectoryPath;

        public string MainDirectoryPath
        {
            get { return _mainDirectoryPath; }
            set { _mainDirectoryPath = value; }
        }



        public async Task<ICollection<IDirectoryItem>> GetFoldersInfoAsync(string directoryPath)
        {

            return   await Task<ICollection<DirectoryInfo>>.Run(async ()=> {

                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                var directories = directoryInfo.GetDirectories();
                var files = directoryInfo.GetFiles();

                List<IDirectoryItem> result = new List<IDirectoryItem>();
           
                result = result.Union( directories.Select(p => new FolderFullInfo { FullName = p.FullName, Name = p.Name,DirectoryItems = null })).ToList();

                result = result.Union(files.Select(p=> new FileFullInfo() { FullName = p.FullName,Name = p.Name,FileByteCount = p.Length})).ToList();

                foreach (var item in result.Where(p => p.GetType().Equals(typeof(FolderFullInfo))).Cast<FolderFullInfo>())
                {
                    item.DirectoryItems = await GetFoldersInfoAsync(item.FullName);


                }


                return result;

            });
            
           

            
        }




        public void Start()
        {
            

        }

    }
}
