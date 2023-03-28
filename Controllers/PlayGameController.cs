using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class PlayGameController : Controller
    {
        public IActionResult PlayGame(string gameID)
        {
            ViewBag.GameID = gameID;
            return View();
        }
    }
}
