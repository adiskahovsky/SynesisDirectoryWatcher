using DirectoryWatcher.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryWather.PL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();

 
            System.Console.ReadKey();

        }

        private async static void Start()
        {
            DirectoryWatcherService directoryWatcherService = new DirectoryWatcherService() { MainDirectoryPath = @"C:\Kahovsky" };
            await directoryWatcherService.Start(@"C:\Kahovsky\Новая папка");

        }
    }
}
