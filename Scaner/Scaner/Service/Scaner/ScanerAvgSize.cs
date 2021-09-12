using Scaner.Service.Pathfinders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner.Service.Scaner
{
    class ScanerAvgSize : IScanerAvgSize
    {
        List<AvgFIleSize> filesAvg = new List<AvgFIleSize>();
        private readonly IPathfinderFile pathfinder;

        public ScanerAvgSize(IPathfinderFile pathfinder)
        {
            this.pathfinder = pathfinder;
        }

        public Dictionary<string, long> GetAvgSizeFiles(DirectoryInfo directoryInfo)
        {
            Dictionary<string, long> files = new Dictionary<string, long>();
            SizeTypeSearch(directoryInfo);
            foreach (var f in filesAvg)
            {
                long value = f.Size / f.Count;
                files.Add(f.Type, value);
            }
            return files;
        }

        private void SizeTypeSearch(DirectoryInfo directoryInfo)
        {
            var files = pathfinder.GetMyFiles(directoryInfo);
            bool cheked = true;
            foreach (var f in files)
            {
                if ((filesAvg.Any()))
                {
                    for (int i = 0; i < filesAvg.Count; i++)
                    {
                        cheked = false;
                        if (filesAvg.ElementAt(i).Type == f.Type)
                        {
                            filesAvg.ElementAt(i).Size += f.Size;
                            filesAvg.ElementAt(i).Count++;
                            break;

                        }
                        else
                            cheked = true;
                    }
                    if (cheked)
                        filesAvg.Add(new AvgFIleSize() { Size = f.Size, Type = f.Type, Count = 1 });


                }
                else
                    filesAvg.Add(new AvgFIleSize() { Size = f.Size, Type = f.Type, Count = 1 });

            }

        }

        private class AvgFIleSize
        {
            public long Size { get; set; }
            public string Type { get; set; }
            public int Count { get; set; } = 0;

        }
    }
}
