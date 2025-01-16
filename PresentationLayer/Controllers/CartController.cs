using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index(int userid)
        {
            var items = cartService.GetCartItems(userid);
            return View(items);
        }

        [HttpPost]
        public JsonResult AddToCart(int userid, int productid, int fiyat)
        {
            try
            {
                cartService.AddToCart(userid, productid, fiyat);
                return Json(new { success = true, message = "Ürün sepete eklendi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }
    }
}
