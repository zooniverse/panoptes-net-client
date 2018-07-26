using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PanoptesNetClient;
using PanoptesNetClient.Models;
using PanoptesNetClientTests;
using System.Net.Http;
using System.Threading.Tasks;

namespace PanoptesNetClientTests_NUnit
{
    [TestFixture]
    public class ApiClientTests
    {
        private Mock<FakeHttpMessageHandler> _fakeHttpMessageHandler;
        private HttpClient _httpClient;
        public ApiClient Client;

        [SetUp]
        public void SetUp()
        {
            _fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("{\"workflows\":[{\"id\":\"45\"}]}")
            });

            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
            Client = new ApiClient(_httpClient);
        }

        // <summary>
        // Ensure the ApiClient correctly creates a Request object with Type method 
        // </summary>
        [Test]
        public void Type()
        {
            IRequest request = new Request("projects");
            string expected = "api/projects/";

            Assert.AreEqual(expected, request.Endpoint);
        }

        // <summary>
        // Test that Get returns a single object that is not null
        // </summary>
        [Test]
        public async Task Get()
        {
            IRequest request = new Request("workflows").ById("45");
            var result = await Client.Get<Workflow>(request);
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<IResource>(result);
        }

        /// <summary>
        /// Test the GetList returns a list object of the expected amount
        /// </summary>
        [Test]
        public async Task GetList()
        {
            IRequest request = new Request("workflows").ById("45");
            var result = await Client.GetList<Workflow>(request);
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Count, 1);
        }
    }
}
