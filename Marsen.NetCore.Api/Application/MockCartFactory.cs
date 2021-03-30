using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Application
{
    public interface ICartFactory
    {
        ICartDao Create();
    }

    public class MockCartFactory : ICartFactory
    {
        public ICartDao Create()
        {
            return new MockCartDao();
        }
    }

    public class CartFactory : ICartFactory
    {
        public ICartDao Create()
        {
            return new CartDao();
        }
    }
}