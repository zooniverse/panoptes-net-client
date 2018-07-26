using Newtonsoft.Json.Linq;
using PanoptesNetClient;
using PanoptesNetClient.Models;
using System;
using System.Collections.Generic;

namespace ClientRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadLine();
        }

        static async void Test()
        {
            ApiClient client = new ApiClient();
            IRequest request = new Request("workflows").ById("3251");
            Workflow test = await client.Get<Workflow>("3251");
            Console.WriteLine(test.Retirement);
        }
    }
}
