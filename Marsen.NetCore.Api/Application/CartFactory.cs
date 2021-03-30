using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Application
{
    public class CartFactory
    {
        public ICartDao Create(string mock)
        {
            switch (mock)
            {
                case "Mock":
                    return new MockCartDao();
                default:
                    return new CartDao();
            }
        }
    }
}