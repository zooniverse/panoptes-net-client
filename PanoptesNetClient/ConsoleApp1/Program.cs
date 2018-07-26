using PanoptesNetClient;
using PanoptesNetClient.Models;
using System;

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
        }
    }
}
