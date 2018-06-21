using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanoptesNetClient;
using System.Configuration;

namespace ClientRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiClient test = ApiClient.Instance;
            Console.WriteLine("test");
            var appSettings = ConfigurationManager.AppSettings;
            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
