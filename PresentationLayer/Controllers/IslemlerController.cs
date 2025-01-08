using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class IslemlerController : Controller
    {
        private readonly IIslemlerService islemlerService;

        public IslemlerController(IIslemlerService islemlerService)
        {
            this.islemlerService = islemlerService;
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
            };
            return View(newIslem);
        }

        [HttpPost]
        public IActionResult CreateAndUpdate(Islemler islem)
        {
            islemlerService.Add(islem);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            islemlerService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
