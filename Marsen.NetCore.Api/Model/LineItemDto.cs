namespace Marsen.NetCore.Api.Model
{
    public class LineItemDto
    {
        public string Name { get; init; }
        public int Qty { get; init; }
        public int Price { get; init; }
        public int SubTotal { get; init; }
    }
}