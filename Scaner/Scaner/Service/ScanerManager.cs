using Scaner.Service.Pathfinders;
using Scaner.Service.Scaner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner.Service
{
    class ScanerManager : IScanerManager
    {
        private readonly IPathfinderDirectrory pathfinderDirectrory;
        private readonly IPathfinderFile pathfinderFile;
        private readonly IScanerAvgSize scanerAvgSize;
        private readonly IScanerTypeCount scanerTypeCount;

        public ScanerManager(IPathfinderDirectrory pathfinderDirectrory, IPathfinderFile pathfinderFile, IScanerAvgSize scanerAvgSize, IScanerTypeCount scanerTypeCount)
        {
            this.pathfinderDirectrory = pathfinderDirectrory;
            this.pathfinderFile = pathfinderFile;
            this.scanerAvgSize = scanerAvgSize;
            this.scanerTypeCount = scanerTypeCount;
        }

        public void WriteAllData(DirectoryInfo directoryInfo)
        {
            using (StreamWriter sw = new StreamWriter("data.html", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("Directorys");
                foreach (var item in pathfinderDirectrory.GetMyDirectories(directoryInfo))
                {
                    sw.WriteLine($"NameDirectory:{item.Name}   SizeDirectory:{item.Size}");
                }

                sw.WriteLine("Files");
                foreach (var item in pathfinderFile.GetMyFiles(directoryInfo))
                {
                    sw.WriteLine($"NameFiles:{item.Size}   SizeFiles:{item.Name} TypeFiles:{item.Type}");
                }

                sw.WriteLine("DataFilesType");
                foreach (var item in scanerAvgSize.GetAvgSizeFiles(directoryInfo))
                {
                    sw.WriteLine($"FilesType{item.Key}   FilesSize{item.Value}");
                }

            }
        }


        public void WriteDataFiles(DirectoryInfo directoryInfo, string type)
        {
            using (StreamWriter sw = new StreamWriter("data.html", true, System.Text.Encoding.Default))
            {
                var value = scanerTypeCount.GetCountType(directoryInfo, type);
                sw.WriteLine("DataFile");
                sw.WriteLine($"CountType:{value.Item1}   Percent{value.Item2}");

            }
        }
    }
}
