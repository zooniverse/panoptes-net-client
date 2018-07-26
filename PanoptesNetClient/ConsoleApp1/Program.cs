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
            Classification classification = new Classification();
            var resource = client.Create<Classification>(classification);
            Console.WriteLine(resource);
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
