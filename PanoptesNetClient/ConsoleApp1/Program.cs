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
            IRequest request = new Request("subjects").ById("75248");
            Subject test = await client.Get<Subject>(request);
            Console.WriteLine(test.Links.Project);
            test.Metadata.whatever = "that";
            Console.WriteLine(test.Metadata);
            test = await client.Update<Subject>(test);

            // What do I want to do?

            // client.Get<Workflow>(47)
            // client.Create<Resource>(INFORMATION)
            // client.Post<Resource>(Information)
            
            // Get subject queue
            // The above call should return the single resource workflow

        }
    }
}
