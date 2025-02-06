using Microsoft.AspNetCore.Mvc;
using PresentationLayer.MockData;

namespace PresentationLayer.Controllers
{
    public class DropdownController : Controller
    {
        public IActionResult Index()
        {
            var Citys = DataService.GetIller();
            return View(Citys);
        }

        [HttpPost]
        public JsonResult GetIlceler(int ilId)
        {
            var ilceler = DataService.GetIlceler().Where(x => x.CityId == ilId).ToList();
            return Json(ilceler);
        }
    }
}
