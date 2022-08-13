using System.Threading.Tasks;
using exam8.Models;
using exam8.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exam8.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
       

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
          
        }

        public async Task<IActionResult> Index(string userName)
        {
            User user = await _profileService.GetUser(userName);
            if (user is null)
            {
                return RedirectToAction("Error", "Errors", new {statusCode = 404});
            }
            return View(user);
        }
    }
}