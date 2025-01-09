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
        private readonly IToptancilarService toptancilarService;

        public IslemlerController(IIslemlerService islemlerService, IUrunlerService urunlerService, IToptancilarService toptancilarService)
        {
            this.islemlerService = islemlerService;
            this.urunlerService = urunlerService;
            this.toptancilarService = toptancilarService;
        }

        public IActionResult Index()
        {
            var islemlerDtos = islemlerService.GetAllDto();
            return View(islemlerDtos);
        }

        public IActionResult Create(int id,bool satismi)
        {
            var newIslem = new Islemler();
            if (satismi)
            {
                newIslem = new Islemler
                {
                    MusteriID = id,
                    Tarih = DateTime.Now,
                    Satis = satismi,
                    UrunID = 0,
                    Adet = 1,
                    ToplamFiyat = 0,
                };
            }
            else
            {
                newIslem = new Islemler
                {
                    ToptanciID = id,
                    Tarih = DateTime.Now,
                    Satis = satismi,
                    UrunID = toptancilarService.GetById(id).UrunID,
                    Adet = 1,
                    ToplamFiyat = 0,
                };
            }
            
            return View(newIslem);
        }

        [HttpPost]
        public IActionResult Create(Islemler islem)
        {
            var urun = urunlerService.GetById(islem.UrunID);
            if (urun == null)
            {
                return NotFound();
            }

            if (islem.Satis)
            {
                islem.ToplamFiyat = urun.UrunFiyat * islem.Adet;
                if (urun.UrunStok < islem.Adet)
                {
                    ModelState.AddModelError("Adet", "Stok yetersiz");
                    return View(islem);
                }
                urun.UrunStok -= islem.Adet;
            }
            else
            {
                var toptanci = toptancilarService.GetById(islem.ToptanciID!);
                islem.ToplamFiyat = toptanci.SatisFiyati! * islem.Adet; 
                if (toptanci.Adet < islem.Adet)
                {
                    ModelState.AddModelError("Adet", "Stok yetersiz");
                    return View(islem);
                }
                toptanci.Adet -= islem.Adet;
                urun.UrunStok += islem.Adet;
            }

            islemlerService.Add(islem);
            urunlerService.Update(urun);

            return RedirectToAction("Index");

        }
    }
}
