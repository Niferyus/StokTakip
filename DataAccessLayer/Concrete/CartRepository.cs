using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CartRepository : ICartRepository
    {
        private readonly Context context;

        public CartRepository(Context context)
        {
            this.context = context;
        }

        public Cart ControlCart(int userid)
        {
            var cart = context.Carts.FirstOrDefault(p => p.UserId == userid);
            if (cart == null)
            {
                context.Carts.Add(new EntityLayer.Concrete.Cart
                {
                    UserId = userid,
                });
                context.SaveChanges();
            }
            return cart;
        }

        public void AddToCart(int userid,int productId,decimal fiyat)
        {
            
            var cart = ControlCart(userid);
            context.CartItems.Add(new EntityLayer.Concrete.CartItem
            {
                CartID = cart.CartId,
                UrunID = productId,
                Adet = 1,
                Fiyat = fiyat
            });
            context.SaveChanges();
        }
        public void ClearCart(int cartid)
        {
            context.CartItems.RemoveRange(context.CartItems.Where(p => p.CartID == cartid));
            context.SaveChanges();
        }

        public void RemoveFromCart(int cartid,int productId)
        {
            context.CartItems.RemoveRange(context.CartItems.Where(p => p.CartID == cartid && p.UrunID == productId));
            context.SaveChanges();
        }

        public List<CartItem> GetCartItems(int userid)
        {
            var cart = ControlCart(userid);
            var cartitems = context.CartItems.Where(p => p.CartID == cart.CartId).ToList();
            return cartitems;
        }
    }
}
