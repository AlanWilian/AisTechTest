using System;
using System.Collections.Generic;
using TechTestAis.Interfaces;
using AisUriProviderApi;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace TechTestAis.Service
{
    public class AisService : IAis
    {
        private AisUriProvider _aisFile;

        private static string path = @"C:\FilesAis\";

        public AisService(AisUriProvider aisFile)
        {
            _aisFile = aisFile;
        }

        public void DeleteFiles()
        {
            Array.ForEach(Directory.GetFiles(path, "*.*"),
              delegate (string path)
              {
                  File.Delete(path);
              }
            );

        }

        public IEnumerable<Uri> GetFiles()
        {
            return _aisFile.Get().ToList();
        }

        public IEnumerable<string> ShowFiles()
        {
            return Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
        }

        public void DownloadFiles(IEnumerable<Uri> uris)
        {
            Directory.CreateDirectory(path);

            Parallel.ForEach(
                     uris,
                     new ParallelOptions { MaxDegreeOfParallelism = 3 },
                     DownloadFileAux
                 );
        }

        private void DownloadFileAux(Uri arg1, ParallelLoopState arg2, long arg3)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(arg1, path + arg1.Segments[2].ToString());
            }

        }
    }
}
