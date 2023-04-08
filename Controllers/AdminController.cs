using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace GamesPlatform.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGamesRepository _gamesRepository;
        public AdminController(RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, IGamesRepository gamesRepository) 
        {
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
            _gamesRepository = gamesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name= model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            
            return View(model);
        }
    }
}
