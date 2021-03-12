using System;
using System.Linq;
using Marsen.NetCore.Api.Model;

namespace Marsen.NetCore.Api.Application
{
    public class PlaceCartService
    {
        public void PutIn(CartDto cart)
        {
            _cal(cart);
        }

        private void _cal(CartDto cart)
        {
            cart.Total = cart.LineItemList.Sum(x => x.SubTotal);
        }

        public CartDto GetCart()
        {
            throw new NotImplementedException("TODO get current user cart, so you need stateful and data persistence");
        }
    }
}