using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Network.Tester.Data;
using Network.UI.Models;

namespace Network.UI.Controllers
{
    public class CorpController : Controller
    {
        private readonly ICorpRepository _corpRepository;

        public CorpController(ICorpRepository corpRepository)
        {
            _corpRepository = corpRepository;
        }
        public IActionResult Index()
        {
            var corps = _corpRepository.GetAll()
                .Take(10)
                .ToList();

            return View(new CorpIndexViewModel(corps));
        }
    }
}
