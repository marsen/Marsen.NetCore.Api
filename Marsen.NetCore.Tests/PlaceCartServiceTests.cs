using System.Collections.Generic;
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

        private  CartDto GetTestCart()
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