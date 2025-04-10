using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class MusterilerController : Controller
    {
        private readonly IMusterilerService musteriService;

        public MusterilerController(IMusterilerService musteriService)
        {
            this.musteriService = musteriService;
        }

        public IActionResult Index()
        {
            var musteriler = musteriService.GetAll();
            return View(musteriler);
        }

        public IActionResult CreateAndUpdate(int? id)
        {
            if (id == null)
            {
                return View(new Musteriler());
            }

            var musteri = musteriService.GetById(id.Value);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        [HttpPost]
        public IActionResult CreateAndUpdate(Musteriler musteri)
        {
            if(!ModelState.IsValid)
            {
                return View(musteri);
            }

            if (musteri.MusteriID == 0)
            {
                musteriService.Add(musteri);
            }
            else
            {
                musteriService.Update(musteri);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) 
        {
            musteriService.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
