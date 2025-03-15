using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml.Office;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Globalization;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class UrunlerController : Controller
    {
        private readonly IUrunService urunService;
        private readonly IMapper _mapper;
        public UrunlerController(IUrunService urunlerService, IMapper _mapper)
        {
            this._mapper = _mapper;
            this.urunService = urunlerService;
        }

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }   
        }

        public async Task<JsonResult> GetUrunler(int page = 1)
        {
            int pageSize = 5;
            var items = await urunService.GetAllUrunlerDto(page,pageSize);
            var jsonData = new
            {
                total = items.TotalPages,
                page = page,
                rows = items
            };
            return Json(jsonData);
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            urunService.Delete(id);
            return Json(new { success = true });
        }

        public async Task<JsonResult> GetFilterItem(string marka,string adi,string barkod,string stok,string baslangicTarihi,string bitisTarihi,int page = 1)
        {
            int pagesize = 5;

            var items = await urunService.GetByFilter(marka, adi, barkod, stok,baslangicTarihi,bitisTarihi ,page, pagesize);
            
            var response = new
            {
                rows = items,
                page = page,
                total = items.TotalPages,
            };
            return Json(response);
        }

        public JsonResult GetById(int id)
        {
            var urun = urunService.GetById(id);
            return Json(urun.Result);
        }

        public JsonResult Save(UrunlerDto entity)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                   .SelectMany(v => v.Errors)
                   .Select(e => e.ErrorMessage)
                   .ToList();

                return Json(new { success = false, errors });
            }
            var item = _mapper.Map<UrunlerDto, Urunler>(entity);
            var create = false;
            if (item.Id == 0)
            {
                item.InsUserId = (int)HttpContext.Session.GetInt32("OnlineUserId");
                item.CreateDate = DateTime.Now;
                item.Approved = true;
                item.Active = true;
                create = true;
            }
            urunService.Save(item);
            return Json(new { success = true, create = create });
        }

        public IActionResult DownloadTemplate()
        {
            var fileBytes = urunService.GenerateTemplate();
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Urunler_Template.xlsx");
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {   
            int userid = (int)HttpContext.Session.GetInt32("OnlineUserId");
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            await urunService.ImportFromExcelAsync(stream.ToArray(),userid);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetPopUpContent(int id)
        {
            return FormPartial(id);
        }

        public PartialViewResult FormPartial(int id)
        {
            ViewBag.Id = id;
            return PartialView("~/Views/Urunler/FormPartial.cshtml");
        }

        public PartialViewResult ExcelPartial()
        {
            return PartialView("~/Views/Urunler/ExcelPartial.cshtml");
        }

        //public async Task<IActionResult> ExportToExcel()
        //{
        //    var products = await urunService.GetAll();
        //    var fileBytes = urunService.ExportToExcel(products);
        //    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Urunler.xlsx");
        //}

        //[HttpPost]
        //public JsonResult AddUrun(Urunler item)
        //{
        //    //if(!ModelState.IsValid)
        //    //{
        //    //    return Json(new { success = false, message = "Doğrulama hatası" });
        //    //}
        //    item.Approved = true;
        //    item.Active = true;
        //    item.InsUserId = (int)HttpContext.Session.GetInt32("OnlineUserId");
        //    item.CreateDate = DateTime.Now;
        //    urunService.Add(item);
        //    return Json(new {success = true});
        //}

        //[HttpPost]
        //public JsonResult EditUrun(Urunler item)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Json(new { success = false, message = "Doğrulama hatası" });
        //    //}

        //    var existingUrun = urunlerService.GetById(item.Id);
        //    if (existingUrun == null)
        //    {
        //        return Json(new { success = false, message = "Ürün bulunamadı" });
        //    }

        //    // Gerekli alanları güncelliyoruz.
        //    existingUrun.Marka = item.Marka;
        //    existingUrun.Adi = item.Adi;
        //    existingUrun.BarkodNo = item.BarkodNo;
        //    existingUrun.Aciklama = item.Aciklama;
        //    existingUrun.Birim = item.Birim;
        //    existingUrun.AlisFiyat = item.AlisFiyat;
        //    existingUrun.SatisFiyat = item.SatisFiyat;
        //    existingUrun.Stok = item.Stok;

        //    urunService.Save(existingUrun);
        //    return Json(new { success = true });
        //}
    }
}




