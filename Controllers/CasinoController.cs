using GamesPlatform.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class CasinoController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        public CasinoController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
