using Xunit;

namespace Marsen.NetCore.Api.Tests
{
    public class PlaceCartServiceTests
    {
        readonly PlaceCartService placeCartService = new();

        [Fact]
        public void TestPutIn()
        {
            var product = new ProductDTO {Name = "Milk", Price = 10, Qty = 1};
            placeCartService.PutIn(product);
        }
    }

    public class PlaceCartService
    {
        public void PutIn(ProductDTO product)
        {
            this.calcTotal(product);
        }

        private void calcTotal(ProductDTO product)
        {
            //// Do Something
        }
    }

    public class ProductDTO
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}