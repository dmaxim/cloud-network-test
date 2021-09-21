using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Network.Tester.Data;
using Network.Tester.Models;
using Network.UI.Models;

namespace Network.UI.Controllers
{
    public class WineryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWineryRepository _wineryRepository;

        public WineryController(ILogger<HomeController> logger, IWineryRepository wineryRepository)
        {
            _logger = logger;
            _wineryRepository = wineryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var wineries = _wineryRepository.GetAll().ToList();
            return View(new WineryIndexModel(wineries));
        }


        private IList<Winery> GetWineries()
        {
            return new List<Winery>
            {
                new Winery { WineryName = "Test", WineryId = 2, StreetAddress = "222 Test Street"}
            };
        }
        
    }
}