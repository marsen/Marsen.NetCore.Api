namespace Marsen.NetCore.Api.Model
{
    public struct Money
    {
        public int Value { get; init; }
        public string Symbol { get; init; }
        public override string ToString() => $"{Value} {Symbol}";
    }
}