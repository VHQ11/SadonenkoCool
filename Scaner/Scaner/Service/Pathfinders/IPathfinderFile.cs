using Scaner.Models;
using System.Collections.Generic;
using System.IO;

namespace Scaner.Service.Pathfinders
{
    interface IPathfinderFile
    {
        List<MyFile> GetMyFiles(DirectoryInfo directoryInfo);
    }
}