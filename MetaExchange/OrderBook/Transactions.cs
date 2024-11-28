using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MetaExchange.OrderBook
{
    public class Transactions
    {
        public List<OrderBook>      OrderBooks      { get; set; }
        public List<CryptoExchange> CryptoExchanges { get; set; }

        public Transactions(string filePath) {
            OrderBooks      = [];
            CryptoExchanges = [];
            GenerateCryptoExchanges(filePath);
        }

        private void GenerateCryptoExchanges(string filePath) {
            var orderBooks  = File.ReadAllLines(filePath);

            foreach (var orderBook in orderBooks) 
            {
                var startIndex      = orderBook.IndexOf('{'); // Avoid Timestamp at beginning of line
                var orderBookJson   = orderBook.Substring(startIndex);

                var temp = JsonSerializer.Deserialize<OrderBook>(orderBookJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if(temp != null) OrderBooks.Add(temp);
            }

            for(var i = 0; i < OrderBooks.Count; i++) CryptoExchanges.Add(new() { OrderBook = OrderBooks[i] });
        }
    }
}
