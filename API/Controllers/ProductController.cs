using API.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUrunService _urunservice;

        public ProductController(IUrunService service)
        {
            _urunservice = service;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> fromMobileSave([FromBody] MobileProduct item)
        {
            if(item == null) return BadRequest();
            Urunler urun = new Urunler();
            urun.BarkodNo = item.barcode;
            urun.Adi = item.name;
            urun.Aciklama = item.description;
            urun.AlisFiyat = item.purchasePrice;
            urun.SatisFiyat = item.salePrice;
            urun.Stok = item.stockAmount;
            urun.CreateDate = DateTime.Now;
            urun.Approved = true;
            urun.Active = true;
            await _urunservice.Save(urun);
            return Ok();
        }

        [HttpGet("GetByBarcode")]
        public async Task<IActionResult> GetByBarcode(string barcode)
        {
            if(barcode == null) return BadRequest();
            var item = await _urunservice.GetByBarcode(barcode);
            return Ok(item);
        }

        [HttpGet("Deneme")]
        public IActionResult Deneme()
        {
            var denemee = "asffafsaf";
            return Ok(denemee);
        }
    }
}
