using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using PanoptesNetClient;
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
            _httpClient = new HttpClient(_fakeHttpMessageHandler.Object);
        }

        // <summary>
        // Ensure the ApiClient correctly creates a Request object with Type method 
        // </summary>
        [Test]
        public void Type()
        {
            IRequest request = Client.Type("projects");
            string expected = "api/projects/";

            Assert.AreEqual(expected, request.Endpoint);
        }

        // <summary>
        // Test that GetAsync returns the correct object that is not null
        // </summary>
        [Test]
        public async Task GetAsync()
        {
            _fakeHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("{\"success\": false,\"error-codes\": [\"It's a fake error!\",\"It's a fake error\"]}")
            });
            Client = new ApiClient(_httpClient);

            var result = await Client.Type("projects").ById("45").GetAsync();
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<JObject>(result);
        }
    }
}
