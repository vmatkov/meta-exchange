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
        public double      EurBalance  { get; set; }
        public double      BtcBalance  { get; set; }
        public CryptoExchange() 
        { 
            OrderBook = new OrderBook();

            // Generate balance constraint
            Random random = new Random();
            EurBalance = random.NextDouble() * 10000;   // returns numbers between 0 - 10.000
            BtcBalance = random.NextDouble() * 100;     // returns numbers between 0 - 100
        }
    }
}
