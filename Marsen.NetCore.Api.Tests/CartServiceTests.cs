using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class CartServiceTests
    {
        readonly CartService _cart = new();
        readonly LineItem milk = new() {Name = "Milk", Subtotal = 10, Price = 10,Qty = 1};

        [Fact]
        public void TestPutIn()
        {
            this._cart.PutIn(milk);
            this._cart.GetCart().LineItems.Should().Contain(milk);
        }

        [Fact]
        public void TestSubTotal()
        {
            this._cart.PutIn(milk);
            var item = this._cart.GetCart().LineItems.First();
            Assert.Equal(10, item.Subtotal);
        }

        [Fact(Skip = "Later")]
        public void TestSubTotalShouldBePriceMultiplyByQty()
        {
            this._cart.PutIn(milk);
            this._cart.PutIn(milk);
            var item = this._cart.GetCart().LineItems.First();
            Assert.Equal(20, item.Subtotal);
        }
    }

    public class LineItem
    {
        public string Name { get; set; }
        public int Subtotal { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }

    public class CartService
    {
        readonly CartDTO _dto = new() {LineItems = new List<LineItem>()};

        public void PutIn(LineItem lineItem)
        {
            var list = _dto.LineItems.ToList();
            list.Add(lineItem);
            list.ForEach(x => x.Subtotal = x.Qty * x.Price);
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