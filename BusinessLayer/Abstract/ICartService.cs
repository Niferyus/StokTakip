using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICartService
    {
        public void AddToCart(int userid, int productId, decimal fiyat);

        public void RemoveFromCart(int cartid, int productId);

        public void ClearCart(int cartid);

        public List<CartItemDto> GetCartItems(int userid);
    }
}
