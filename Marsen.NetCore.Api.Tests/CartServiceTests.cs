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
        readonly LineItem milk = new() {Name = "Milk"};

        [Fact]
        public void TestPutIn()
        {
            this._cart.PutIn(milk);
            this._cart.GetCart().LineItems.Should().Contain(milk);
        }
    }

    public class LineItem
    {
        public string Name { get; set; }
    }

    public class CartService
    {
        readonly CartDTO _dto = new CartDTO {LineItems = new List<LineItem>()};

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