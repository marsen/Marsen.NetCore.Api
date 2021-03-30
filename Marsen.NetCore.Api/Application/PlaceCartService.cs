using System.Linq;
using Marsen.NetCore.Api.Factory;
using Marsen.NetCore.Api.Model;
using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Application
{
    public class PlaceCartService
    {
        private readonly ICartDao _cartDao;

        public PlaceCartService()
        {
            var factory = new MockCartFactory();
            _cartDao = factory.Create();
        }

        public PlaceCartService(ICartDao cartDao)
        {
            _cartDao = cartDao;
        }

        public void PutIn(CartDto cart)
        {
            _cal(cart);
            _cartDao.Save();
        }

        private void _cal(CartDto cart)
        {
            cart.LineItemList.ForEach(x => x.SubTotal = x.Price * x.Qty);
            cart.Total = cart.LineItemList.Sum(x => x.SubTotal);
        }
    }
}