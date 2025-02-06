using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICartRepository
    {
        public List<CartItemDto> GetCartItems(int userid);
        public void AddToCart(int userid,int productId,decimal fiyat);

        public void RemoveFromCart(int cartid,int productId);

        public void ClearCart(int cartid);

    }
}
