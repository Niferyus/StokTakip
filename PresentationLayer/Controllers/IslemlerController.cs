using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class IslemlerController : Controller
    {
        private readonly IIslemlerService islemlerService;
        private readonly IUrunlerService urunlerService;

        public IslemlerController(IIslemlerService islemlerService, IUrunlerService urunlerService)
        {
            this.islemlerService = islemlerService;
            this.urunlerService = urunlerService;
        }

        public IActionResult Index()
        {
            var islemler = islemlerService.GetAll();
            return View(islemler);
        }

        public IActionResult CreateAndUpdate(int id)
        {
            var newIslem = new Islemler
            {
                MusteriID = id,
                Tarih = DateOnly.FromDateTime(DateTime.Now),
                Satis = true,
                UrunID = 0,
                Adet = 1,   
                ToplamFiyat = 0, 
            };
            return View(newIslem);
        }

        [HttpPost]
        public IActionResult CreateAndUpdate(Islemler islem)
        {
            var urun = urunlerService.GetById(islem.UrunID);
            if (urun == null)
            {
                return NotFound();
            }

            islem.ToplamFiyat = urun.UrunFiyat * islem.Adet;

            
            if (urun.UrunStok < islem.Adet)
            {
               ModelState.AddModelError("Adet", "Stok yetersiz");
               return View(islem);
            }
            
            islemlerService.Add(islem);
            
            if (islem.Satis)
            {
                urun.UrunStok -= islem.Adet;
            }
            else
            {
                urun.UrunStok += islem.Adet;
            }

            urunlerService.Update(urun);

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            islemlerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
