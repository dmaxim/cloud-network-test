
using System.Net.Http;
using System.Threading.Tasks;

namespace Network.Tester.Data
{
    public interface ITestWebRepository
    {
        Task<HttpResponseMessage> Get(string uri);
    }
}
