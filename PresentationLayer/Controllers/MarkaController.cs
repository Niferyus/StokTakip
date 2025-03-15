using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace PresentationLayer.Controllers
{
    public class MarkaController : Controller
    {
        private readonly IMarkaService _markaService;

        public MarkaController(IMarkaService markaService)
        {
            _markaService = markaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetItems()
        {
            var items = await _markaService.GetAllMarka();
            return Json(new { success = true , items });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteItem(int id)
        {
            await _markaService.Delete(id);
            return Json(new { success = true });
        }
        public async Task<Marka> GetById(int id)
        {
            var item = await _markaService.GetById(id);
            return item;
        }
        public JsonResult Save(Marka entity)
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
            entity.IsActive = true;
            if (entity.Id == 0)
            {
                create = true;
            }
            _markaService.Save(entity);
            return Json(new { success = true, create = create });
        }
        public PartialViewResult FormPartial(int id)
        {
            ViewBag.Id = id;
            return PartialView();
        }
    }
}
