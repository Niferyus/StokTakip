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
using System.Text.Json.Nodes;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class UrunlerController : Controller
    {
        private readonly IUrunService urunService;
        private readonly IMapper _mapper;
        private readonly IStokService _stokService;
        public UrunlerController(IUrunService urunlerService, IMapper _mapper, IStokService _stokService)
        {
            this._mapper = _mapper;
            urunService = urunlerService;
            this._stokService = _stokService;
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
        public async Task<JsonResult> DeleteItem(int id)
        {
            await urunService.Delete(id);
            return Json(new { success = true });
        }
        //UrunlerDtoFilter
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

        public async Task<JsonResult> GetById(int id)
        {
            var urun = await urunService.GetById(id);
            return Json(urun);
        }

        public async Task<JsonResult> Save(UrunlerDto entity)
        {
            JsonNode depoVerileriJson = null;
            if (!string.IsNullOrEmpty(entity.DepoVerileri))
            {
                depoVerileriJson = JsonNode.Parse(entity.DepoVerileri);
                Console.WriteLine("consollllllllllllllll" + depoVerileriJson.ToJsonString());
            }
            else
            {
                Console.WriteLine("Depo Verileri NULL geldi!");
            }

            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values
            //       .SelectMany(v => v.Errors)
            //       .Select(e => e.ErrorMessage)
            //       .ToList();

            //    return Json(new { success = false, errors });
            //}

            var item = await urunService.ConvertToEntity(entity);
            var create = false;
            if (item.Id == 0)
            {
                //Stok stok = new Stok();
                //stok.StokMiktari = Convert.ToInt32(hedefDepostok);
                //stok.DepoId = Convert.ToInt32(hedefDepoid);                
                item.InsUserId = (int)HttpContext.Session.GetInt32("OnlineUserId");
                item.CreateDate = DateTime.Now;
                item.Approved = true;
                item.Active = true;
                create = true;
            }
            await urunService.Save(item);
            if (create)
            {
                List<Stok> stoks = [];
                JsonArray? obj = depoVerileriJson as JsonArray;
                foreach (JsonNode depo in obj)
                {
                    Stok stock = new Stok();
                    stock.DepoId = depo["depoid"].GetValue<int>();
                    stock.StokMiktari = depo["stok"].GetValue<int>();
                    stock.UrunId = item.Id;
                    stoks.Add(stock);
                }
                
                Stok stok = new Stok();
                stok.UrunId = item.Id;
                stok.StokMiktari = entity.Stok;
                stok.DepoId = await _stokService.GetDefaultDepo();
                stoks.Add(stok);
                
                await _stokService.Create(stoks);
            }
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




