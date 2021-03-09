namespace Marsen.NetCore.Api.Model
{
    public class CartProduct
    {
        public readonly Product Product;
        public readonly int Qty;

        public CartProduct(Product product, int qty)
        {
            Product = product;
            Qty = qty;
        }

        public int SubTotal => Product.Price.Value * Qty;
    }
}