using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class BirimController : Controller
    {
        private readonly IBirimService _birimService;

        public BirimController(IBirimService birimService)
        {
            _birimService = birimService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAllBirim()
        {
          var items = await _birimService.GetAllBirim();
          return Json(new { success = true, items });
        }

        public async Task<Birim> GetById(int id)
        {
            var item = await _birimService.GetById(id);
            return item;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteItem(int id)
        {
            await _birimService.Delete(id);
            return Json(new { success = true });
        }

        public JsonResult Save(Birim entity)
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
            _birimService.Save(entity);
            return Json(new { success = true, create = create });
        }

        public PartialViewResult FormPartial(int id)
        {
            ViewBag.Id = id;
            return PartialView();
        }
    }
}
