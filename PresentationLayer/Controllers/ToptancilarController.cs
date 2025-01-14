using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class ToptancilarController : Controller
    {
        private readonly IToptancilarService toptancilarService;

        public ToptancilarController(IToptancilarService toptancilarService)
        {
            this.toptancilarService = toptancilarService;
        }

        public IActionResult Index()
        {
            var toptancilar = toptancilarService.GetAllDto();
            return View(toptancilar);
        }

        public IActionResult Delete(int id)
        {
            toptancilarService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateAndUpdate(int? id)
        {
            if (id == null)
            {
                return View(new Toptancilar());
            }

            var toptanci = toptancilarService.GetById(id.Value);
            if (toptanci == null)
            {
                return NotFound();
            }
            return View(toptanci);
        }

        [HttpPost]
        public IActionResult CreateAndUpdate(Toptancilar toptanci)
        {
            if (toptanci.ToptanciID == 0)
            {
                toptancilarService.Add(toptanci);
            }
            else
            {
                toptancilarService.Update(toptanci);
            }
            return RedirectToAction("Index");
        }
    }
}
