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
            cartService.PutIn(new LineItem {Name = "Milk"});
            var cart = cartService.GetCart();
            var actual = cart.LineItems.Contains(new LineItem {Name = "Milk"});
            Assert.Equal(true, actual);
        }
    }

    public class LineItem
    {
        public string Name { get; set; }
    }

    public class CartService
    {
        public void PutIn(LineItem lineItem)
        {
            throw new NotImplementedException();
        }

        public CartDTO GetCart()
        {
            throw new NotImplementedException();
        }
    }

    public class CartDTO
    {
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}