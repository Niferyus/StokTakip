using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public void AddToCart(int userid, int productId, decimal fiyat)
        {
            cartRepository.AddToCart(userid, productId, fiyat);
        }

        public void ClearCart(int cartid)
        {
            cartRepository.ClearCart(cartid);
        }

        public List<CartItemDto> GetCartItems(int userid)
        {
            return cartRepository.GetCartItems(userid);
        }

        public void RemoveFromCart(int cartid, int productId)
        {
            cartRepository.RemoveFromCart(cartid, productId);
        }
    }
}
