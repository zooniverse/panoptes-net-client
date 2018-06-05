using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PanoptesNetClient;

namespace PanoptesNetClientTests_NUnit
{
    [TestFixture]
    public class ApiClientTests
    {
        [Test]
        public void HelloWorldTest()
        {
            ApiClient test = new ApiClient();
            Console.WriteLine("HELLO THERE");
            Assert.True(true);
        }
    }
}
