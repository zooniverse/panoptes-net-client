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
            ApiClient client = new ApiClient();
            IRequest request = new Request("workflows").ById("2213");
            var test = client.GetAsync(request);
            Console.ReadLine();
        }
    }
}
