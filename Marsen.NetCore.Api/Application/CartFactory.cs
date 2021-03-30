using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Application
{
    public static class CartFactory
    {
        public static ICartDao Create(string mock)
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