using System.IO;

namespace Scaner.Service
{
    interface IScanerManager
    {
        void WriteAllData(DirectoryInfo directoryInfo);
        void WriteDataFiles(DirectoryInfo directoryInfo, string type);
    }
}