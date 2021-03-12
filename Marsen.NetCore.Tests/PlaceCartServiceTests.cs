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
            var cart = new CartDTO
            {
                LineItemList = new List<LineItemDTO> { new() { Name = "Milk", Price = 7, Qty = 2, SubTotal = 14}},
            };
            placeCartService.Calculate(cart);
            Assert.Equal(14,cart.Total);
        }
    }

    public class PlaceCartService
    {
        public void Calculate(CartDTO cart)
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