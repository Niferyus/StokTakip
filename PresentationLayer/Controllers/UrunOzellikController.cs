using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Nodes;

namespace PresentationLayer.Controllers
{
    public class UrunOzellikController : Controller
    {
        private readonly IUrunOzellikService _urunOzellikService;

        public UrunOzellikController(IUrunOzellikService urunOzellikService)
        {
            _urunOzellikService = urunOzellikService;
        }

        public IActionResult Index(string type)
        {
            ViewBag.Type = type;
            return View();
        }

        public async Task<JsonResult> GetItems(string type)
        {
            var items = await _urunOzellikService.GetAllOzellik(type);
            return Json(new { success = true , items });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteItem(int id)
        {
            await _urunOzellikService.Delete(id);
            return Json(new { success = true });
        }
        public async Task<UrunOzellikleri> GetById(int id)
        {
            var item = await _urunOzellikService.GetById(id);
            return item;
        }
        public JsonResult Save(UrunOzellikleri entity)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();

                return Json(new { success = false, errors });
            }
            var create = false;
            //entity.IsActive = true;
            if (entity.Id == 0)
            {
                create = true;
            }
            _urunOzellikService.Save(entity);
            return Json(new { success = true, create = create });
        }
        public PartialViewResult FormPartial(int id, string type)
        {
            ViewBag.Type = type;
            ViewBag.Id = id;
            return PartialView();
        }
    }
}
