using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Dtos.RegisterDto;

namespace PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newuser = new AppUser()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.Username,
                Email = user.Mail,
            };
            var result = await _userManager.CreateAsync(newuser, user.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
