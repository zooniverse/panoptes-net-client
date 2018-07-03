using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PanoptesNetClient;
using System.Threading.Tasks;

namespace PanoptesNetClientTests_NUnit
{
    [TestFixture]
    public class ApiClientTests
    {
        // <summary>
        // Call the initial instance to set up and create the client singleton
        // </summary>
        [Test]
        public void CanInit()
        {
            ApiClient client = new ApiClient();
        }

        // <summary>
        // Ensure the ApiClient correctly creates a Request object with Type method 
        // </summary>
        [Test]
        public void Type()
        {
            ApiClient client = new ApiClient();
            IRequest request = client.Type("projects");
            string expected = "api/projects/";

            Assert.AreEqual(expected, request.Endpoint);
        }

        [Test]
        public async Task GetAsync()
        {
            ApiClient client = new ApiClient();
            JObject resource = await client.Type("projects").ById("45").GetAsync();
        }
    }
}
