using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DepoController : Controller
    {
        private readonly IDepoService _depoService;
        private readonly IMapper _mapper;

        public DepoController(IDepoService depoService, IMapper mapper)
        {
            _depoService = depoService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetDepos(int page = 1)
        {
            int pageSize = 5;
            var items = await _depoService.GetAllDepo(page, pageSize);
            //var mappedItems = _mapper.Map<List<DepoDto>>(items.items);
            //var paginationResult = new Pagination<DepoDto>(mappedItems, items.items.Count, page, pageSize);
            var jsonData = new
            {
                total = items.TotalPages,
                page = page,
                records = items.items.Count,
                rows = items.items
            };
            return Json(jsonData);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteItem(int id)
        {
            try
            {
                await _depoService.Delete(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Depo silinirken bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Save(DepoDto entity)
        {
            var create = false;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, errors });
            }         
            var depo = await _depoService.ConvertToEntity(entity);
            if (entity.Id == 0)
            {
                depo.Active = true;
                depo.CreateDate = DateTime.Now;
                depo.InsUserId = (int)HttpContext.Session.GetInt32("OnlineUserId");
                depo.Approved = true;
                create = true;
            }
            await _depoService.Save(depo);
            return Json(new { success = true, create = create });
        }

        public async Task<JsonResult> GetItem(int id)
        {
            var item = await _depoService.GetById(id);
            if (item == null)
            {
                return Json(new { success = false, message = "Depo bulunamadı" });
            }

            var mappedItem = _mapper.Map<Depo, DepoDto>(item);
            return Json(new { success = true, data = mappedItem });
        }

        //public async Task<JsonResult> GetDepoUrun(int depoId)
        //{
        //  var items = await _depoService.GetDepoUrunler(depoId, 1, 5);
        //    var mappedItems = _mapper.Map<List<UrunlerDto>>(items.items);
        //    var paginationResult = new Pagination<UrunlerDto>(mappedItems, items.items.Count, 1, 5);
        //    var jsonData = new
        //    {
        //        total = paginationResult.TotalPages,
        //        page = 1,
        //        records = items.items.Count,
        //        rows = paginationResult.items
        //    };
        //    return Json(jsonData);
        //}

        public IActionResult GetPopUpContent(int id)
        {
            return FormPartial(id);
        }

        public PartialViewResult FormPartial(int id)
        {
            ViewBag.Id = id;
            return PartialView("~/Views/Depo/FormPartial.cshtml");
        }

        public PartialViewResult UrunPartial(int id)
        {
            return PartialView("~/Views/Depo/UrunPartial.cshtml",id);
        }

        public async Task<JsonResult> GetAllYerlesim(int id)
        {
            var items = await _depoService.GetAllYerlesim(id);
            var jsonData = new
            {
                success = true,
                data = items
            };
            return Json(jsonData);
        }
    }
}