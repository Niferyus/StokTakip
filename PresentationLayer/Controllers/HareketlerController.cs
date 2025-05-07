using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class HareketlerController : Controller
    {
        private readonly IHareketlerService _hareketlerService;
        private readonly IKisiService _kisiService;
        private readonly IDepoService _depoService;
        private readonly IUrunService _urunService;

        public HareketlerController(IHareketlerService hareketlerService,IKisiService kisiService,IDepoService depoService,IUrunService urunService)
        {
            _hareketlerService = hareketlerService;
            _kisiService = kisiService;
            _depoService = depoService;
            _urunService = urunService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetItems(int page, int rows)
        {
            var items = await _hareketlerService.GetAllDto(page, rows);
            var jsonData = new
            {
                total = items.TotalPages,
                page = page,
                totalRecords = items.TotalRecords,
                rows = items
            };
            return Json(jsonData);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteItem(int id)
        {
            await _hareketlerService.Delete(id);
            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<JsonResult> Save(HareketlerDto entity)
        {
            var create = false;
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage)
            //        .ToList();

            //    return Json(new { success = false, errors });
            //}

            int depoid = 0, urunid = 0, kisiid = 0;


            if (entity.Id == 0)
            {
                depoid = await _depoService.GetdepoId(entity.DepoAdi);
                urunid = await _urunService.GeturunId(entity.UrunAdi);
                kisiid = await _kisiService.GetkisiId(entity.KisiAdi);
                create = true;
            }

            Hareketler hareketler = new Hareketler();

            hareketler.Id = entity.Id;
            hareketler.Tarih = entity.Tarih;
            hareketler.Miktar = entity.Miktar;
            hareketler.BirimFiyat = entity.BirimFiyat;
            hareketler.ToplamFiyat = entity.Miktar * entity.BirimFiyat;
            hareketler.DepoId = depoid;
            hareketler.KisiId = kisiid;
            hareketler.UrunId = urunid;
            hareketler.IslemTuru = entity.IslemTuru;
            await _hareketlerService.Save(hareketler);
            return Json(new { success = true, create = create });
        }

        public PartialViewResult FormPartial()
        {           
            return PartialView();
        }
    }
}
