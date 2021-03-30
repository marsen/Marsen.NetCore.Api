using System.Linq;
using Marsen.NetCore.Api.Model;
using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Application
{
    public class PlaceCartService
    {
        private readonly ICartDao _cartDao;

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