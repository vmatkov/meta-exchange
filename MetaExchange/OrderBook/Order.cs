using System.Text.Json.Serialization;

namespace MetaExchange.OrderBook
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Type
    {
        Buy = 0,
        Sell = 1
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Kind
    {
        Limit = 0,
        Market = 1,
        Stop = 2
    }

    public class Order
    {
        public string Id        { get; set; } = string.Empty;
        public string Time      { get; set; } = string.Empty;
        public Type Type        { get; set; } 
        public Kind Kind        { get; set; }
        public decimal Amount   { get; set; }
        public decimal Price    { get; set; }
    }
}