using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult PreLoaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FoooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
    }
}
