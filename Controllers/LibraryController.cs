using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
