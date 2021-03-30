using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Factory
{
    public class MockCartFactory : ICartFactory
    {
        public ICartDao Create()
        {
            return new MockCartDao();
        }
    }
}