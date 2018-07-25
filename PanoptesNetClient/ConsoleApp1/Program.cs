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
            Item();
            Console.ReadLine();
        }

        static async void Item()
        {
            ApiClient client = new ApiClient();

            Classification classification = new Classification();
            Console.WriteLine(classification);
            classification.Links = new ClassificationLinks("1857", "3251");
            classification.Links.Subjects.Add("75248");
            var result = await client.Create<Classification>(classification);
            Console.WriteLine(result.Id);

            // What do I want to do?

            // client.Get<Workflow>(47)
            // client.Create<Resource>(INFORMATION)
            // client.Post<Resource>(Information)
            
            // Get subject queue
            // The above call should return the single resource workflow

        }
    }
}
