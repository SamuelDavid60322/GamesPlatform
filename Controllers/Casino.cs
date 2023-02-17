using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class Casino : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
