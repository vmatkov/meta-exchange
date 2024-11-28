namespace MetaExchange.OrderBook
{
    public class Order
    {
        public string Id        { get; set; } = string.Empty;
        public string Time      { get; set; } = string.Empty;
        public string Type      { get; set; } = string.Empty;
        public string Kind      { get; set; } = string.Empty;
        public double Amount    { get; set; }
        public double Price     { get; set; }
    }
}