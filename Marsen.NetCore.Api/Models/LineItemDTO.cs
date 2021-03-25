namespace Marsen.NetCore.Api.Models
{
    public class LineItemDTO
    {
        public string Name { get; set; }
        public int Subtotal { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
        public string Id { get; set; }
    }
}