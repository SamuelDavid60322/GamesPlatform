using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace GamesPlatform.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IGamesRepository _gamesRepository;
        private readonly IVerificationRepository _verificationRepository;
        public AdminController(RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, IGamesRepository gamesRepository, IVerificationRepository verificationRepository) 
        {
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
            _gamesRepository = gamesRepository;
            _verificationRepository = verificationRepository;
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

        public async Task<IActionResult> ViewVerificationRequests(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["StatusSortParam"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewData["DateOfRequestSortParam"] = sortOrder == "DateOfRequest" ? "dateofrequest_desc" : "DateOfRequest";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var verifications = from v in _applicationDbContext.Verifications select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                verifications = verifications.Where(v => v.UserID.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "status_desc":
                    verifications = verifications.OrderByDescending(v => v.Status);
                    break;
                case "DateOfRequest":
                    verifications = verifications.OrderBy(v => v.DateOfRequest);
                    break;
                case "dateofrequest_desc":
                    verifications = verifications.OrderByDescending(v => v.DateOfRequest);
                    break;
                default:
                    verifications = verifications.OrderBy(v => v.DateOfRequest);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Verification>.CreateAsync(verifications.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public IActionResult UpdateVerificationRequest(int? verificationId)
        {
            if (verificationId == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HandleError", "Error", new { code = 404 });
            }
            var verificationRequest = _verificationRepository.RetrieveVerificationByID((int)verificationId);
            if (verificationRequest == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HandleError", "Error", new { code = 404 });
            }
            using (MemoryStream memoryStream = new MemoryStream(verificationRequest.Content))
            {
                ViewData["Image"] = Convert.ToBase64String(verificationRequest.Content);
            }

            return View(verificationRequest);
        }

        [HttpPost, ActionName("UpdateVerificationRequest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVerificationRequestPost(int? verificationId)
        {
            if (verificationId == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("HandleError", "Error", new { code = 404 });
            }
            var verificationRequestToUpdate = await _applicationDbContext.Verifications.FirstOrDefaultAsync(g => g.VerificationID == verificationId);
            if (await TryUpdateModelAsync<Verification>(
                verificationRequestToUpdate,
                "",
                v => v.Status))
            {
                try
                {
                    await _applicationDbContext.SaveChangesAsync();
                    return RedirectToAction("ViewVerificationRequests");
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes to the database");
                }
            }
            return View(verificationRequestToUpdate);
        }
    }
}
