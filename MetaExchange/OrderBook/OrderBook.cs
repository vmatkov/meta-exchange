using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaExchange.OrderBook
{
    public class OrderBook
    {
        public string AcqTime { get; set; }
        public List<Orders> Bids { get; set; }
        public List<Orders> Asks { get; set; }

        public OrderBook()
        {
            AcqTime = string.Empty;
            Bids    = [];
            Asks    = [];
        }
    }

    public class Orders
    {
        public Order? Order { get; set; }
    }
}
