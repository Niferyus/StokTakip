using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class UrunlerController : Controller
    {
        private readonly IUrunlerService urunlerService;

        public UrunlerController(IUrunlerService urunlerService)
        {
            this.urunlerService = urunlerService;
        }

        public IActionResult Index()
        {
            var urunler = urunlerService.GetAll();
            return View(urunler);
        }

        public IActionResult CreateAndUpdate(int? id)
        {
            if (id == null)
            {
                return View(new Urunler());
            }

            var urun = urunlerService.GetById(id.Value);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        [HttpPost]
        public IActionResult CreateAndUpdate(Urunler urun)
        {
                if (urun.UrunID == 0)
                {
                    urunlerService.Add(urun);
                }
                else
                {
                    urunlerService.Update(urun);
                }
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            urunlerService.Delete(id);
            return RedirectToAction("Index");
        }
    }


}

