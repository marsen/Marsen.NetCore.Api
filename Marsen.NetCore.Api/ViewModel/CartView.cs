using System.Collections.Generic;

namespace Marsen.NetCore.Api.ViewModel
{
    public class CartView
    {
        public IEnumerable<ProductView> ProductList { get; init; }
        public int TotalPrice { get; init; }
    }
}