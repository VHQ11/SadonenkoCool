using Scaner.Service;
using Scaner.Service.Pathfinders;
using Scaner.Service.Scaner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Scaner
{
    class Program
    {

        static void Main(string[] args)
        {
            IPathfinderDirectrory pathfinderDirectrory = new PathfinderDirectrory();
            IPathfinderFile pathfinderFile = new PathfinderFile();
            IScanerAvgSize scanerAvgSize = new ScanerAvgSize(new PathfinderFile());
            IScanerTypeCount scanerTypeCount = new ScanerTypeCount(new PathfinderFile());

            IScanerManager scanerManager = new ScanerManager(pathfinderDirectrory, pathfinderFile, scanerAvgSize, scanerTypeCount);

            Console.WriteLine("Если вы хотите просканировать папку нажмите 1,если зотите проанализировать тип файла в папке нажмите 2 ");
            while (true)
            {
                string value = Console.ReadLine();
                if (value == "1")
                {
                    Console.WriteLine("Введите путь к папке.пример[C:\\Test] с двойным слешем после диска");
                    string path = Console.ReadLine();
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    scanerManager.WriteAllData(directoryInfo);
                }
                else
                {
                    Console.WriteLine("Введите путь к папке.пример[C:\\Test] с двойным слешем после диска ");
                    string path = Console.ReadLine();
                    Console.WriteLine("Введите тип файла. пример[.txt]");
                    string type = Console.ReadLine();
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    scanerManager.WriteDataFiles(directoryInfo, type);
                }

                Console.WriteLine("Если больше ничего не нужно нажмите 0");
                value = Console.ReadLine();

                if (value == "0")
                    break;
                    
            }

        }
    }

     
    

}