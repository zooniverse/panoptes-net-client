using NUnit.Framework;
using PanoptesNetClient;
using System.Collections.Specialized;

namespace PanoptesNetClientTests_NUnit
{
    [TestFixture]
    public class RequestTests
    {
        // <summary>
        // Test ById correctly adds an attribute and builds a relevant endpoint
        // </summary>
        [Test]
        public void ById()
        {
            IRequest request = new Request("projects");
            request.ById("45");
            request.BuildEndpoint();
            string expected = "api/projects/45";
            Assert.AreEqual(expected, request.Endpoint);
        }

        // <summary>
        // Test WithArgs builds a query string and builds a relevant endpoint
        // </summary>
        [Test]
        public void WithArgs()
        {
            IRequest request = new Request("projects");
            NameValueCollection query = new NameValueCollection();
            query.Add( "id", "45" );
            query.Add( "approved", "true" );
            request.WithArgs(query);
            request.BuildEndpoint();
            string expected = "api/projects/?id=45&approved=true";
            Assert.AreEqual(request.Endpoint, expected);
        }
    }
}
