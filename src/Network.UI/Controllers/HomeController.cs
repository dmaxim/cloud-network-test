using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Network.UI.Infrastructure.Configuration;
using Network.UI.Models;

namespace Network.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NetworkTestConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IOptions<NetworkTestConfiguration>configuration)
        {
            _logger = logger;
            _configuration = configuration.Value;
        }

        public IActionResult Index()
        {
            return View(_configuration);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}