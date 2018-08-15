using Moq;
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
                Content = new StringContent("{\"classifications\":[{\"id\":\"45\"}]}")
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
            string expected = "api/projects";

            Assert.AreEqual(expected, request.Endpoint);
        }

        // <summary>
        // Test that Get returns a single object that is not null
        // </summary>
        [Test]
        public async Task Get()
        {
            Classification result = await Client.Classifications.Get("45");
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<IResource>(result);
        }

        /// <summary>
        /// Test that GetList returns a list object of the expected amount
        /// </summary>
        [Test]
        public async Task GetList()
        {
            var result = await Client.Classifications.GetList();
            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Count, 1);
        }

        /// <summary>
        /// Test that Create returns a single object that is not null
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Create()
        {
            Classification classification = new Classification();
            var result = await Client.Classifications.Create(classification, "classifications");
            Assert.That(result, Is.Not.Null);
            Assert.IsInstanceOf<Classification>(result);
        }
    }
}
