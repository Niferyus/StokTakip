using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MusteriUrunController : Controller
    {
        private readonly IUrunlerService urunlerService;

        public MusteriUrunController(IUrunlerService urunlerService)
        {
            this.urunlerService = urunlerService;
        }



        public IActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                
                var userName = User.Identity.Name;

                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                ViewBag.Message = $"Hoş geldiniz, {userName}! (ID: {userId})";
            }
            
            var urunler = urunlerService.GetAllDto();
            return View(urunler);
        }
    }
}
