using System.Linq;
using Marsen.NetCore.Api.Model;

namespace Marsen.NetCore.Api.Application
{
    public class PlaceCartService
    {
        public PlaceCartService()
        {
            
        }
        public PlaceCartService(ICartDao cartDao)
        {
            CartDao = cartDao;
        }

        public void PutIn(CartDto cart)
        {
            _cal(cart);
            CartDao.Save();
        }

        private void _cal(CartDto cart)
        {
            cart.LineItemList.ForEach(x => x.SubTotal = x.Price * x.Qty);
            cart.Total = cart.LineItemList.Sum(x => x.SubTotal);
        }

        private ICartDao CartDao { get; }
    }

    public interface ICartDao
    {
        void Save();
    }
}