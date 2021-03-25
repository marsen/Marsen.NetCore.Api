using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void TestPutIn()
        {
            CartService cartService = new CartService();
            var lineItem = new LineItem {Name = "Milk"};
            cartService.PutIn(lineItem);
            var cart = cartService.GetCart();
            var actual = cart.LineItems.Contains(lineItem);
            Assert.Equal(true, actual);
        }
    }

    public class LineItem
    {
        public string Name { get; set; }
    }

    public class CartService
    {
        readonly CartDTO _dto = new CartDTO{ LineItems = new List<LineItem>() };

        public void PutIn(LineItem lineItem)
        {
            var list = _dto.LineItems.ToList();
            list.Add(lineItem);
            _dto.LineItems = list;
        }

        public CartDTO GetCart()
        {
            return _dto;
        }
    }

    public class CartDTO
    {
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}