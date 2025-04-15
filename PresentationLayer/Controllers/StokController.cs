using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PresentationLayer.Controllers
{
    public class StokController : Controller
    {
        private readonly IStokService _stokService;

        public StokController(IStokService service)
        {
            _stokService = service;
        }

        public async Task<JsonResult> GetByUrunId(int id)
        {
            var items = await _stokService.GetByUrunId(id);
            return Json(items);
        }

        public async Task<JsonResult> Update(StockChange stock)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false});
            }
            var result = await _stokService.StokGiris(stock.StockId, stock.Miktar);
            return Json(new { success =  result});
        }
    }
}
