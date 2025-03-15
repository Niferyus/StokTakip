using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class LayouttController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
