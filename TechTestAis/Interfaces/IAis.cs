using System;
using System.Collections.Generic;

namespace TechTestAis.Interfaces
{
    public interface IAis
    {
        IEnumerable<Uri> GetFiles();
        IEnumerable<string> ShowFiles();
        void DeleteFiles();
        void DownloadFiles(IEnumerable<Uri> uris);
    }
}
