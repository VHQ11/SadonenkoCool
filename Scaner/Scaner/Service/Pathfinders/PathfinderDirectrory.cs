using Scaner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaner.Service.Pathfinders
{
    class PathfinderDirectrory : IPathfinderDirectrory
    {
        private List<MyDirectory> directories = new List<MyDirectory>();
        PathfinderFile PathfinderFile = new PathfinderFile();

        public ICollection<MyDirectory> GetMyDirectories(DirectoryInfo directoryInfo)
        {
            SearchDirectory(directoryInfo);
            return directories;

        }

        private void SearchDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Exists)
            {
                var files = PathfinderFile.GetMyFiles(directoryInfo);
                long size = 0;
                foreach (var f in files)
                {
                    size += f.Size;
                }

                directories.Add(new MyDirectory() { Name = directoryInfo.Name, Size = size });

                if (directoryInfo.GetDirectories() != null)
                {
                    foreach (var d in directoryInfo.GetDirectories())
                    {
                        SearchDirectory(d);
                    }
                }
            }
        }


    }
}
