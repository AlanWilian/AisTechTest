using System;
using AisUriProviderApi;
using TechTestAis.Controller;
using TechTestAis.Service;
using System.Linq;
using System.IO;
using System.Threading;
using TechTestAis.Exceptions;

namespace TechTestAis
{
    class Program
    {

        static void Main()
        {

            try
            {
                Thread execPeriodic = new Thread(new ThreadStart(ExecutePeriodic));
                execPeriodic.Start();
            }
            catch (DomainException e)
            {
                throw new DomainException("An error occurred " + e.Message);
            }
            catch (IOException e)
            {
                throw new DomainException("An error occurred " + e.Message);
            }
            catch (Exception e)
            {
                throw new DomainException("An error occurred " + e.Message);
            }

        }

        private static void ExecutePeriodic()
        {
            while (true)
            {
                var files = new AisController(new AisService(new AisUriProvider()));
                var filesAvailable = files.GetFiles().ToList();

                Console.WriteLine(" ------ Output available files ------");
                filesAvailable.ForEach(x => Console.WriteLine(x));

                Console.WriteLine(" ------ Last Files ------ ");
                files.ShowFiles().ToList().ForEach(x => Console.WriteLine(x));

                Console.WriteLine(" ------ Delete old files ------");
                files.DeleteFiles();

                Console.WriteLine(" ------ Download files ------");
                files.DownloadFiles(filesAvailable);

                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
        }

    }
}
