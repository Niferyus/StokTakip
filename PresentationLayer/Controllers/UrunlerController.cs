using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using ClosedXML.Excel;
using EntityLayer.Concrete;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Satıcı")]
    public class UrunlerController : Controller
    {
        private readonly IUrunlerService urunlerService;

        public UrunlerController(IUrunlerService urunlerService)
        {
            this.urunlerService = urunlerService;
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

        public JsonResult GetUrunler(int page, int rows)
        {
            var totalRecords = urunlerService.GetAll().Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / rows);

            var urunler = urunlerService.GetAll()
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = urunler
            };

            return Json(jsonData);
        }

        [HttpPost]
        public IActionResult AddUrun(Urunler item)
        {   
            item.Approved = true;
            item.Active = true;
            item.InsUserId = HttpContext.Session.GetInt32("OnlineUserId");
            item.CreateDate = DateTime.Now;
            urunlerService.Add(item);
            return Json(new { success = true, message="Ürün başarıyla eklendi" });
        }

        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            urunlerService.Delete(id);
            return Json(new { success = true });
        }

        public JsonResult GetFilterItem(string marka,string adi,string barkod,string stok,int page = 1, int rows=10)
        {
            var query = urunlerService.GetByFilter(marka, adi, barkod, stok);

            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / rows);

            var urunler = query.Skip((page - 1) * rows)
                               .Take(rows)
                               .ToList();

            var response = new
            {
                rows = urunler,
                page = page,
                total = totalPages,
                records = totalRecords
            };
            return Json(response);
        }

        public JsonResult GetById(int id)
        {
            var urun = urunlerService.GetById(id);
            return Json(urun);
        }

        [HttpPost]
        public JsonResult EditUrun(Urunler item)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Json(new { success = false, message = "Doğrulama hatası" });
            //}

            var existingUrun = urunlerService.GetById(item.Id);
            if (existingUrun == null)
            {
                return Json(new { success = false, message = "Ürün bulunamadı" });
            }

            // Gerekli alanları güncelliyoruz.
            existingUrun.Marka = item.Marka;
            existingUrun.Adi = item.Adi;
            existingUrun.BarkodNo = item.BarkodNo;
            existingUrun.Aciklama = item.Aciklama;
            existingUrun.Birim = item.Birim;
            existingUrun.AlisFiyat = item.AlisFiyat;
            existingUrun.SatisFiyat = item.SatisFiyat;
            existingUrun.Stok = item.Stok;

            urunlerService.Edit(existingUrun);
            return Json(new { success = true });
        }





        //[HttpPost]
        //public IActionResult ExcelYukle(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("Lütfen bir Excel dosyası seçin.");
        //    }

        //    using (var stream = new MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //        stream.Position = 0;

        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var result = reader.AsDataSet();
        //            var table = result.Tables[0]; // İlk sayfa

        //            List<Urunler> urunListesi = new List<Urunler>();

        //            for (int i = 1; i < table.Rows.Count; i++) // İlk satır başlık olduğu için 1'den başlıyoruz
        //            {
        //                var urun = new Urunler
        //                {
        //                    UrunAdi = table.Rows[i][0].ToString(), // 1. sütun Ürün Adı
        //                    UrunFiyat = Convert.ToDecimal(table.Rows[i][1]), // 2. sütun Fiyat
        //                    UrunStok = Convert.ToInt32(table.Rows[i][2]) // 3. sütun Stok
        //                };

        //                urunListesi.Add(urun);
        //            }
        //            urunlerService.AddList(urunListesi);
        //        }
        //    }

        //    return RedirectToAction("Index"); // Ürün listesine geri dön
        //}

        //public IActionResult CreateAndUpdate(int? id)
        //{
        //    var entity = (id == null) ? new Urunler() : urunlerService.GetById(id.Value);

        //    if (id != null && id > 0 && entity.UrunID == 0)
        //    {
        //        return NotFound(); //Id dolu geldiği halde kayıt databasede bulunamadı.
        //    }

        //    if (entity.UrunID == 0)//Yeni Kayıt Eklenecek Demek
        //    {
        //        entity.UrunAdi = "Yeni Ürün Adı";
        //    }

        //    return View(entity); //
        //}

        //[HttpPost]
        //public IActionResult CreateAndUpdate(Urunler urun) // Fonk. Adı Edit olacak.
        //{
        //    if (urun.UrunID == 0)  // Yeni kayıt ekleme
        //    {
        //        urunlerService.Add(urun);
        //    }
        //    else  // Güncelleme işlemi
        //    {
        //        var existingUrun = urunlerService.GetById(urun.UrunID);
        //        if (existingUrun == null)
        //        {
        //            return Json(new { success = false, message = "Ürün bulunamadı" });
        //        }

        //        existingUrun.UrunAdi = urun.UrunAdi;
        //        existingUrun.UrunFiyat = urun.UrunFiyat;
        //        existingUrun.UrunStok = urun.UrunStok;

        //        urunlerService.Update(existingUrun);
        //    }

        //    return Json(new { success = true });
        //}

        //public IActionResult Delete(int id)
        //{
        //    //İlgili kayıt databasede varmı kontrol edilir. vede işlem yapan kişinin bu kaydı işlem yetkisi varmı kontrol edilir.
        //    //Gerçek delete yapmayız Active=false yaparız.
        //    var urunvarmi = urunlerService.GetById(id) ?? throw new Exception("Bu ID'ye sahip ürün bulunamadı");
        //    urunlerService.Delete(id);
        //    return RedirectToAction("Index");
        //}
    }
}




