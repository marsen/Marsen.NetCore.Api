using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class PlaceCartServiceTests
    {
        readonly PlaceCartService placeCartService = new();

        [Fact]
        public void TestCartTotal()
        {
            var cart = GetTestCart();
            placeCartService.PutIn(cart);
            Assert.Equal(29,cart.Total);
        }

        private  CartDTO GetTestCart()
        {
            var cart = new CartDTO
            {
                LineItemList = new List<LineItemDTO>
                {
                    new() {Name = "Milk", Price = 7, Qty = 2, SubTotal = 14},
                    new() {Name = "Oil", Price = 5, Qty = 3, SubTotal = 15},
                },
                Total = 14
            };
            return cart;
        }
    }

    public class PlaceCartService
    {
        public void PutIn(CartDTO cart)
        {
            _cal(cart);
        }

        private void _cal(CartDTO cart)
        {
            cart.Total = cart.LineItemList.Sum(x => x.SubTotal);
        }
    }

    public class LineItemDTO
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }
    }

    public class CartDTO
    {
        public List<LineItemDTO> LineItemList { get; set; }
        public int Total { get; set; }
    }
}