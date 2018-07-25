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

            IRequest request = new Request("subjects").ById("75248");

            var result = await client.GetList<Subject>(request);
            Console.WriteLine(result);

            // TODO: Allow client to get item by ID
        }

        static Classification BuildClassification()
        {
            Classification classification = new Classification();
            classification.Links = new ClassificationLinks("1857", "3251");
            classification.Links.Subjects.Add("75248");
            
            classification.Metadata.StartedAt = DateTime.Now.ToString();
            classification.Metadata.FinishedAt = "";
            classification.Metadata.UserAgent = "Galaxy Zoo Touch Table";
            classification.Metadata.UserLanguage = "en";
            classification.Metadata.WorkflowVersion = "5.8";

            return classification;
        }
    }
}
