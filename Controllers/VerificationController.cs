using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    [Authorize]
    public class VerificationController : Controller
    {
        private readonly IVerificationRepository _verificationRepository;
        public VerificationController(IVerificationRepository verificationRepository)
        {
            _verificationRepository = verificationRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FileUpload fileObject)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var verificationExists = _verificationRepository.RetrieveVerificationByUserID(userId);
            if (verificationExists == null)
            {
                if (fileObject.file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        fileObject.file.CopyTo(memoryStream);
                        if (memoryStream.Length < 2097152)
                        {
                            var verificationRequest = new Verification()
                            {
                                Content = memoryStream.ToArray(),
                                UserID = userId,
                                Status = "Pending"

                            };
                            _verificationRepository.CreateVerification(verificationRequest);
                            ViewBag.SuccessMessage = "Thank you for submitting your ID to get access to casino games. Estimated wait time is 1-2 days so check back later  ";
                        }
                        else
                        {
                            ModelState.AddModelError("File", "The file is too large");
                        }
                    }
                }
            }
            else if (verificationExists.Status == "Approved")
            {
                ViewBag.ErrorMessage = "YThis account is approved already and allowed to play Casino Games.";
            }
            else if (verificationExists.Status == "Denied")
            {
                ViewBag.ErrorMessage = "Your Verification Request has been rejected by Gamesino Admins. Email support if you think this is an mistake.";
            }
            else if (verificationExists.Status == "Pending")
            {
                ViewBag.ErrorMessage = "Your Verification request is currently being reviewed by Gamesino Admins. Check back Later";
            }
            else if (verificationExists.Status == "")
            {
                ViewBag.ErrorMessage = "There seems to be an issue with your request. Contact support as soon as yyou can to resolve this.";
            }

            return View();
        }
    }
}
