using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MusteriUrunController : Controller
    {
        private readonly IUrunlerService urunlerService;
        private readonly VisitorCounterService visitorCounterService;

        public MusteriUrunController(IUrunlerService urunlerService, VisitorCounterService visitorcounterservice)
        {
            this.urunlerService = urunlerService;
            this.visitorCounterService = visitorcounterservice;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                visitorCounterService.IncrementVisitorCount();
                ViewBag.VisitorCount = visitorCounterService.GetVisitorCount();
                var userName = User.Identity.Name;
                var onlineUserId = HttpContext.Session.GetInt32("OnlineUserId");
                ViewData["userid"] = onlineUserId;
                ViewBag.Message = $"Hoş geldiniz, {userName}! (ID: {onlineUserId})";

            }   
            var urunler = urunlerService.GetAllDto();
            return View(urunler);
        }
    }
}
