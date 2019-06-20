using DirectoryWatcher.BLL.DTOs;
using DirectoryWatcher.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace DirectoryWatcher.BLL.Services
{
    internal class DirectoryWatcherService
    {


        private Object lockObj;

      //  List<IDirectoryItem> DirectoryItemsDtos = new List<IDirectoryItem>();

        private string _mainDirectoryPath;

        public string MainDirectoryPath
        {
            get { return _mainDirectoryPath; }
            set { _mainDirectoryPath = value; }
        }


        public event EventHandler<IDirectoryItem> NewDirectoryParsed;
        public event EventHandler<IDirectoryItem> ItemChanged;



        public DirectoryWatcherService()
        {
            lockObj = new Object();
        }
                    

        public async Task<ICollection<IDirectoryItem>> GetFoldersInfoAsync(string directoryPath)
        {

            return   await Task<ICollection<DirectoryInfo>>.Run(async ()=> {

                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                var directories = directoryInfo.GetDirectories();
                var files = directoryInfo.GetFiles();

                List<IDirectoryItem> result = new List<IDirectoryItem>();
           
                result = result.Union(directories.Select(p => new FolderFullInfo { FullName = p.FullName, Name = p.Name, DirectoryItems = null })).ToList();

                result = result.Union(files.Select(p => new FileFullInfo() { FullName = p.FullName, Name = p.Name, FileByteCount = p.Length })).ToList();
                

                foreach (var item in result.Where(p => p.GetType().Equals(typeof(FolderFullInfo))).Cast<FolderFullInfo>())
                {
                    item.DirectoryItems = await GetFoldersInfoAsync(item.FullName);

                    //NewDirectoryParsed(this, (IDirectoryItem)item);


                }
                

                return result;

            });
            
           

            
        }



        public async void DirectoryTracking(ICollection<IDirectoryItem> directoryItems, ICollection<IDirectoryItem> DirectoryItemsDtos)
        {
            if (directoryItems != null)
            {
                await Task.Run(() =>
                {

                    while (true)
                    {

                        foreach (var directoryItemDto in DirectoryItemsDtos.Where(p=> p.GetType().Equals(typeof(FolderFullInfo))).Cast<FolderFullInfo>())//foreach (var directoryItem in directoryItems)
                        {
                            bool flag = false;
                            foreach (var directoryItem in directoryItems.Where(p => p.GetType().Equals(typeof(FolderFullInfo))).Cast<FolderFullInfo>())
                            {


                                if (directoryItemDto.FullName.Equals(directoryItem.FullName))
                                {

                                    flag = true;
                                    DirectoryTracking(directoryItem.DirectoryItems, directoryItemDto.DirectoryItems);
                                }

                            }

                            if (!flag)
                                ItemChanged(this, directoryItemDto);

                        }
















                        

                    }
                });
            }

            

        }


        public async Task Start(string startDirectoryPath)
        {

            var res = await GetFoldersInfoAsync(startDirectoryPath);
            DirectoryItemsDtos = res.ToList();
            res.ToList()[0].FullName = "hui";
            DirectoryTracking(res);


        }

    }
}
