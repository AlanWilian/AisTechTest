using System;
using System.Collections.Generic;
using TechTestAis.Interfaces;

namespace TechTestAis.Controller
{
    class AisController
    {

        private IAis _aisService;
        public AisController(IAis aisService)
        {
            _aisService = aisService;
        }

        public IEnumerable<Uri> GetFiles()
        {
            return _aisService.GetFiles();
        }

        public IEnumerable<string> ShowFiles()
        {
            return _aisService.ShowFiles();
        }

        public void DeleteFiles()
        {
            _aisService.DeleteFiles();
        }

        public void DownloadFiles(IEnumerable<Uri> uris)
        {
            _aisService.DownloadFiles(uris);
        }
    }
}
