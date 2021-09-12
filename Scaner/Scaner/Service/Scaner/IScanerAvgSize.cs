using System.Collections.Generic;
using System.IO;

namespace Scaner.Service.Scaner
{
    interface IScanerAvgSize
    {
        Dictionary<string, long> GetAvgSizeFiles(DirectoryInfo directoryInfo);
    }
}