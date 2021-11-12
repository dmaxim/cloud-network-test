
using System.Net.Http;

namespace Network.Tester.Clients
{
    public class TestWebClient : ITestWebClient
    {
        public TestWebClient(HttpClient client)
        {
            HttpClient = client;
        }
        public HttpClient HttpClient { get; }
    }
}
