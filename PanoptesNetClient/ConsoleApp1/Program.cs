using Newtonsoft.Json.Linq;
using PanoptesNetClient;
using PanoptesNetClient.Models;
using System;

namespace ClientRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Item();
            Console.ReadLine();
        }

        static async void Item()
        {
            ApiClient client = new ApiClient();
            IRequest request = new Request("workflows").ById("2213");
            var test = await client.Get<Workflow>(request);
            Console.WriteLine(test.Id);

            // What do I want to do?

            // client.Get<Workflow>(47)
            // The above call should return the single resource workflow

        }
    }
}
