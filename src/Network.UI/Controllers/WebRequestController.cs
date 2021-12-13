using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Network.Tester.Data;
using Network.UI.Models;

namespace Network.UI.Controllers
{
    public class WebRequestController : Controller
    {
        private readonly ITestWebRepository _testWebRepository;
        public WebRequestController(ITestWebRepository testWebRepository)
        {
            _testWebRepository = testWebRepository;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _testWebRepository.Get("test").ConfigureAwait(false);
            return View(new WebRequestResponse((int)response.StatusCode));
        }
    }
}
