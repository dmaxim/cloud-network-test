
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Network.Tester.Clients;

namespace Network.Tester.Data
{
    public class TestWebRepository : ITestWebRepository
    {
        private readonly ITestWebClient _testWebClient;

        public TestWebRepository(ITestWebClient testWebClient)
        {
            _testWebClient = testWebClient;
        }
        public async Task<HttpResponseMessage> Get(string uri)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/"))
            {
                using (var response = await _testWebClient.HttpClient.SendAsync(request).ConfigureAwait(false))
                {
                    return response;
                }
            }
            //var response = await _testWebClient.HttpClient.GetAsync(new Uri(uri)).ConfigureAwait(false);

            //return response;
        }
    }
}
