using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            ViewBag.UserId = userid;
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

        public IActionResult ClearCart(int cartid)
        {
            cartService.ClearCart(cartid);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int cartid, int productid)
        {
            cartService.RemoveFromCart(cartid, productid);
            return RedirectToAction("Index");
        }
    }
}
