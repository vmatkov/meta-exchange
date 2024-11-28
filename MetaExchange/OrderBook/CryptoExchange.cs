using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaExchange.OrderBook
{
    public class CryptoExchange
    {
        public OrderBook   OrderBook   { get; set; }
        public decimal     EurBalance  { get; set; }
        public decimal     BtcBalance  { get; set; }
        public CryptoExchange() 
        { 
            OrderBook = new OrderBook();

            // Generate balance constraint
            Random random = new Random();
            EurBalance = (decimal)random.NextDouble() * 10000;   // returns numbers between 0 - 10.000
            BtcBalance = (decimal)random.NextDouble() * 100;     // returns numbers between 0 - 100
        }
    }
}
