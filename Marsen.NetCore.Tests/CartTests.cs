using FluentAssertions;
using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Model;
using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class CartTests
    {
        readonly CartService _cartService = new();

        /// <summary>
        /// Test Data
        /// </summary>
        private Product milk = new() {Name = "Milk", Price = new Money {Value = 10, Symbol = "NTD"}};

        [Fact]
        public void TestCartTotal()
        {
            _cartService.PutIn(new CartProduct(milk, 1));
            var cart = _cartService.GetCart();
            cart.TotalPrice.Should().Be(10);
        }

        [Fact]
        public void TestCartSubtotal()
        {
            CartProduct cartProduct = new CartProduct(milk, 1);
            Assert.Equal(10, cartProduct.SubTotal);
        }
    }
}