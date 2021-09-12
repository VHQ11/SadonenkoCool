using Scaner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner.Service.Pathfinders
{
    class PathfinderFile : IPathfinderFile
    {
        private List<MyFile> files = new List<MyFile>();


        public List<MyFile> GetMyFiles(DirectoryInfo directoryInfo)
        {
            SearchFiles(directoryInfo);
            return files;
        }

        private void SearchFiles(DirectoryInfo directoryInfo)
        {


            if (directoryInfo.Exists)
            {
                foreach (var f in directoryInfo.GetFiles())
                {
                    files.Add(new MyFile() { Name = f.Name, Size = f.Length, Type = f.Extension });
                }

                if (directoryInfo.GetDirectories() != null)
                {
                    foreach (var d in directoryInfo.GetDirectories())
                    {
                        SearchFiles(d);
                    }
                }

            }
            else
                throw new NullReferenceException("Не существует папки");

        }
    }
}
