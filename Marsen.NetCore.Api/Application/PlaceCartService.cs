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
            cart.LineItemList.ForEach(x => x.SubTotal = x.Price * x.Qty);
            cart.Total = cart.LineItemList.Sum(x => x.SubTotal);
        }
    }
}