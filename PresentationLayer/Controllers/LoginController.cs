using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Dtos.LoginDto;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public int OnlineUserId { get; set; }
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

            if (result.Succeeded)
            {
                OnlineUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
                HttpContext.Session.SetInt32("OnlineUserId", OnlineUserId);

                if (User.IsInRole("Satıcı"))
                {
                    return RedirectToAction("Index", "Urunler");
                }
                else
                {
                    return RedirectToAction("Index", "MusteriUrun");
                }
            }
            else
            {
                return View();
            }
        }
          
    }
}
