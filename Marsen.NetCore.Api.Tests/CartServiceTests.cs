using System;
using System.Linq;
using FluentAssertions;
using Marsen.NetCore.Api.Models;
using Marsen.NetCore.Api.Services;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class CartServiceTests
    {
        readonly CartService _cart = new();
        readonly LineItemDTO milk = new() {Id = "MilkId", Name = "Milk", Price = 10};
        readonly LineItemDTO oil = new() {Id = "OilId", Name = "Oil", Price = 7};

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

        [Fact]
        public void TestSubTotalShouldBePriceMultiplyByQty()
        {
            this._cart.PutIn(oil);
            this._cart.PutIn(milk);
            this._cart.PutIn(milk);
            var item = GetItemInCartBy("MilkId");
            Assert.Equal(20, item.Subtotal);
        }


        [Fact]
        public void TestSubTotalPutInSpecifiedQty()
        {
            this._cart.PutIn(oil);
            this._cart.PutIn(milk, 2);
            var item = GetItemInCartBy("MilkId");
            Assert.Equal(20, item.Subtotal);
        }

        [Fact]
        public void TestTotal()
        {
            this._cart.PutIn(milk, 2);
            this._cart.PutIn(oil, 2);
            var item = this._cart.GetCart();
            Assert.Equal(34, item.Total);
        }

        private LineItemDTO GetItemInCartBy(string id)
        {
            return this._cart.GetCart().LineItems.First(x => x.Id == id);
        }
    }
}