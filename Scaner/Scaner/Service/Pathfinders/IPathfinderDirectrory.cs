using Scaner.Models;
using System.Collections.Generic;
using System.IO;

namespace Scaner.Service.Pathfinders
{
    interface IPathfinderDirectrory
    {
        ICollection<MyDirectory> GetMyDirectories(DirectoryInfo directoryInfo);
    }
}