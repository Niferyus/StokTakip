using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class KisilerController : Controller
    {
        private readonly IKisilerService KisilerService;

        public KisilerController(IKisilerService KisilerService)
        {
            this.KisilerService = KisilerService;
        }

        //public IActionResult Index()
        //{
        //    var Kisiler = KisilerService.GetAllDto();
        //    return View(Kisiler);
        //}

        //public IActionResult Delete(int id)
        //{
        //    KisilerService.Delete(id);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult CreateAndUpdate(int? id)
        //{
        //    if (id == null)
        //    {
        //        return View(new Kisiler());
        //    }

        //    var toptanci = KisilerService.GetById(id.Value);
        //    if (toptanci == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(toptanci);
        //}

        //[HttpPost]
        //public IActionResult CreateAndUpdate(Kisiler toptanci)
        //{
        //    if (toptanci.ToptanciID == 0)
        //    {
        //        KisilerService.Add(toptanci);
        //    }
        //    else
        //    {
        //        KisilerService.Update(toptanci);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
