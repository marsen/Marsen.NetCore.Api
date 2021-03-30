using Marsen.NetCore.Api.Application;
using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Factory
{
    public class CartFactory : ICartFactory
    {
        public ICartDao Create()
        {
            return new CartDao();
        }
    }
}