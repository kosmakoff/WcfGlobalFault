using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TheService;

namespace TheHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(FaultyService)))
            {
                host.Open();

                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
