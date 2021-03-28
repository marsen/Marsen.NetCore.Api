namespace Marsen.NetCore.Api.Model
{
    public class LineItemDto
    {
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }
        public string Id { get; set; }
    }
}