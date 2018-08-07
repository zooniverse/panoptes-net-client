using PanoptesNetClient;
using PanoptesNetClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        static async void Test()
        {
            ApiClient client = new ApiClient();
            List<Workflow> test = await client.Workflows.GetList();
            Console.WriteLine(test.Count);
        }
    }
}
