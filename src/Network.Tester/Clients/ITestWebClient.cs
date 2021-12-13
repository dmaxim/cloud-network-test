

using System.Net.Http;

namespace Network.Tester.Clients
{
    public interface ITestWebClient
    {
        HttpClient HttpClient { get; }
    }
}
