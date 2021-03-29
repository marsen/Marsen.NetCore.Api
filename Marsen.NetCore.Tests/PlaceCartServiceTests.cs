using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class PlaceCartServiceTests
    {
        readonly PlaceCartService placeCartService ;
        private ICartDao _cartDao;

        public PlaceCartServiceTests()
        {
            _cartDao = Substitute.For<ICartDao>();
            placeCartService = new PlaceCartService();
            placeCartService.CartDao = _cartDao;
        }
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
            var expectedMilkSubtotal = 14;
            var expectedOilSubtotal = 15;
            var cart = GetTestSubTotalCart();
            placeCartService.PutIn(cart);
            var milk = cart.LineItemList.First(x => x.Id == "MilkId");
            var oil = cart.LineItemList.First(x => x.Id == "OilId");
            Assert.Equal(expectedMilkSubtotal, milk.SubTotal);
            Assert.Equal(expectedOilSubtotal, oil.SubTotal);
        }

        [Fact]
        public void TestPutIn()
        {
            var cart = GetTestCart();
            placeCartService.PutIn(cart);
            _cartDao.Received().Save();
        }

        private CartDto GetTestSubTotalCart()
        {
            var cart = new CartDto
            {
                LineItemList = new List<LineItemDto>
                {
                    new() {Id = "OilId", Name = "Oil", Price = 5, Qty = 3,},
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
                    new() {Name = "Milk", Price = 7, Qty = 2,},
                    new() {Name = "Oil", Price = 5, Qty = 3,},
                },
            };
            return cart;
        }
    }
}