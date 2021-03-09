using System.Linq;
using Marsen.NetCore.Api.Model;
using Marsen.NetCore.Api.ViewModel;

namespace Marsen.NetCore.Api.Application
{
    public class CartService
    {
        private readonly Cart _cart;

        public CartService()
        {
            _cart = new Cart();
        }

        public void PutIn(CartProduct product)
        {
            _cart.PutIn(product);
        }

        public CartView GetCart()
        {
            return new ()
            {
                ProductList = _cart
                    .ProductList
                    .Select(p => new ProductView()
                    {
                        Name = p.Product.Name,
                        Price = p.Product.Price.ToString()
                    }),
                TotalPrice = _cart.TotalPrice
            };
        }
    }
}