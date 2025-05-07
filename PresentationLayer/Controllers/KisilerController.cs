using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete.Class;
using EntityLayer.Concrete.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class KisilerController : Controller
    {
        private readonly IKisiService _kisilerService;

        public KisilerController(IKisiService _kisilerService)
        {
            this._kisilerService = _kisilerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<List<Kisiler>> GetAll()
        {
            return await _kisilerService.GetAllDefault();
        }
        public async Task<JsonResult> GetItems(int page, int rows)
        {
            var items = await _kisilerService.GetAllDto(page, rows);
            var jsonData = new
            {
               total = items.TotalPages,
               page = page,
               rows = items,
               totalRecords = items.TotalRecords
            };
            return Json(jsonData);
        }

        public async Task<JsonResult> DeleteItem(int id)
        {
            await _kisilerService.Delete(id);
            return Json(new {success = true});
        }

        public PartialViewResult FormPartial(int id) 
        {
            var model = new KisiViewModel
            {
                TumTurler = Enum.GetValues(typeof(KisiTuru))
            .Cast<KisiTuru>()
            .Select(t => new SelectListItem
            {
                Text = t.ToString(),
                Value = ((int)t).ToString()
            }).ToList()
            };
            ViewBag.id = id;
            return PartialView(model);
        }

        public async Task<JsonResult> Save(KisiViewModel model)
        {
            KisiTuru tur = 0;
            //bitwise or
            foreach (var secilen in model.SecilenTurler)
            {
                tur |= (KisiTuru)secilen;
            }

            var kisi = new Kisiler
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                FirmaAdi = model.FirmaAdi,
                Telefon = model.Telefon,
                Eposta = model.Eposta,
                Adres = model.Adres,
                Tur = tur,
            };
            var create = false;
            if(model.Id == 0)
            {
                create = true;
            }

            await _kisilerService.Save(kisi);
            return Json(new { success = true, create = create });
        }
    }
}
  