﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanoptesNetClient;
using System.Configuration;
using System.Collections.Specialized;

namespace ClientRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiClient client = ApiClient.Instance;
            var test = client.Type("projects").ById("1594").GetAsync();
            Console.ReadLine();
        }
    }
}
