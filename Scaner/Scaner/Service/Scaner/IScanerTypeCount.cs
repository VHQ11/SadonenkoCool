using System.IO;

namespace Scaner.Service.Scaner
{
    interface IScanerTypeCount
    {
        (float, float) GetCountType(DirectoryInfo directoryInfo, string type);
    }
}