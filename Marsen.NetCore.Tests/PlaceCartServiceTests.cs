using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class PlaceCartServiceTests
    {
        readonly PlaceCartService placeCartService = new();

        [Fact]
        public void TestPutIn()
        {
            var product = new LineItemDTO {Name = "Milk", Price = 7, Qty = 2, SubTotal = 14};
            placeCartService.PutIn(product);
        }
    }

    public class PlaceCartService
    {
        private CartDTO _cart = new ();

        public void PutIn(LineItemDTO lineItem)
        {
            _cart.LineItemList.Add(lineItem);
            this.calcTotal(lineItem);
        }

        private CartDTO calcTotal(LineItemDTO lineItem)
        {
            //// TODO:DISCOUNT
            return _cart;
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
        public List<LineItemDTO> LineItemList = new();
        public int Total { get; set; }
    }
}