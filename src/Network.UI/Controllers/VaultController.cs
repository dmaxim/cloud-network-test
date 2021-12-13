using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Network.UI.Models;

namespace Network.UI.Controllers
{
    public class VaultController : Controller
    {
        private readonly IConfiguration _configuration;
        public VaultController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View(new VaultIndexModel(_configuration));
        }
    }
}
