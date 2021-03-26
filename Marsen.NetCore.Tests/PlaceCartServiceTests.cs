using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class PlaceCartServiceTests
    {
        readonly PlaceCartService placeCartService = new();

        [Fact]
        public void TestCartTotal()
        {
            var expected = 29;
            var cart = GetTestCart();
            placeCartService.PutIn(cart);
            cart.Total.Should().Be(expected);
        }

        [Fact]
        public void TestSubTotal()
        {
            var expected = 14;
            var cart = GetTestSubTotalCart();
            placeCartService.PutIn(cart);
            var item = cart.LineItemList.First(x => x.Id == "MilkId");
            Assert.Equal(expected, item.SubTotal);
        }

        private CartDto GetTestSubTotalCart()
        {
            var cart = new CartDto
            {
                LineItemList = new List<LineItemDto>
                {
                    new() {Name = "Oil", Price = 5, Qty = 2,},
                    new() {Id = "MilkId", Name = "Milk", Price = 7, Qty = 2,},
                },
            };
            return cart;
        }

        private CartDto GetTestCart()
        {
            var cart = new CartDto
            {
                LineItemList = new List<LineItemDto>
                {
                    new() {Name = "Milk", Price = 7, Qty = 2, SubTotal = 14},
                    new() {Name = "Oil", Price = 5, Qty = 3, SubTotal = 15},
                },
                Total = 14
            };
            return cart;
        }
    }
}