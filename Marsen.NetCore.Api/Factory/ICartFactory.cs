using Marsen.NetCore.Api.Repository;

namespace Marsen.NetCore.Api.Factory
{
    public interface ICartFactory
    {
        ICartDao Create();
    }
}