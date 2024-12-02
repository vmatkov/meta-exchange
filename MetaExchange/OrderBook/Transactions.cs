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
            
            OrderBooks.Clear();
            CryptoExchanges.Clear();
            
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

            if(OrderBooks != null)
            {
                for (var i = 0; i < OrderBooks.Count; i++)
                {
                    var orderBook = OrderBooks[i];
                    orderBook.Asks = orderBook.Asks.OrderBy(o => o.Order?.Price).ToList();
                    orderBook.Bids = orderBook.Bids.OrderByDescending(o => o.Order?.Price).ToList();
                }

                for (var i = 0; i < OrderBooks.Count; i++) CryptoExchanges.Add(new() { OrderBook = OrderBooks[i] });
            }
        }

        public List<(string ExchangeName, decimal Price, decimal Amount)> GetBestTrades(Type type, decimal amount)
        {
            var result = new List<(string ExchangeName, decimal Price, decimal Amount)>();
            var remainingAmount = amount;

            if(type == Type.Buy)
            {
                if(CryptoExchanges != null)
                {
                    var allAsks = CryptoExchanges.SelectMany(exchange => exchange.OrderBook.Asks.Select(ask => new
                    {
                        Id                  = ask.Order.Id,
                        ExchangeName        = exchange.OrderBook.AcqTime.ToString(),
                        Price               = ask.Order.Price,
                        AvailableBtc        = ask.Order.Amount,
                        Exchange            = exchange
                    }))
                    .OrderBy(ask => ask.Price) // order by price per 1 BTC
                    .ToList();

                    for (var i = 0; i < allAsks.Count; i++)
                    {
                        var ask = allAsks[i];
                        if (remainingAmount <= 0) break;

                        decimal buyingAmount = Math.Min(remainingAmount, ask.AvailableBtc);
                        var affordable = ask.Exchange.EurBalance > ask.Price * buyingAmount;

                        if (affordable && buyingAmount > 0 && ask.Exchange.EurBalance > 0) 
                        {
                            result.Add((ask.ExchangeName, ask.Price * buyingAmount, buyingAmount));
                            ask.Exchange.EurBalance -= ask.Price * buyingAmount;
                            remainingAmount -= buyingAmount;
                        }
                        else if(!affordable && buyingAmount > 0 && ask.Exchange.EurBalance > 0)
                        {
                            buyingAmount = ask.Exchange.EurBalance / ask.Price;
                            result.Add((ask.ExchangeName, ask.Price * buyingAmount, buyingAmount));
                            ask.Exchange.EurBalance -= ask.Price * buyingAmount;
                            remainingAmount -= buyingAmount;
                        }

                    }

                    if (remainingAmount > 0)
                    {
                        Console.WriteLine($"You could only purchase {amount - remainingAmount} in the currect constraint.");
                    }
                }
            }
            else if (type == Type.Sell)
            {
                if(CryptoExchanges != null)
                {
                    var allBids = CryptoExchanges.SelectMany(exchange => exchange.OrderBook.Bids.Select(bid => new
                    {
                        Id = bid.Order.Id,
                        ExchangeName = exchange.OrderBook.AcqTime.ToString(),
                        Price = bid.Order.Price,
                        AvailableBtc = bid.Order.Amount,
                        Exchange = exchange
                    }))
                    .OrderByDescending(bid => bid.Price) // order by price per 1 BTC
                    .ToList();

                    for (int i = 0; i < allBids.Count; i++)
                    {
                        var bid = allBids[i];
                        if (remainingAmount <= 0) break;

                        var sellingAmount = Math.Min(remainingAmount, bid.AvailableBtc);
                        if (sellingAmount > 0 && bid.Exchange.BtcBalance > 0)
                        {
                            result.Add((bid.ExchangeName, bid.Price * sellingAmount, sellingAmount));
                            bid.Exchange.BtcBalance -= sellingAmount;
                            remainingAmount -= sellingAmount;
                        }
                    }

                    if (remainingAmount > 0)
                    {
                        Console.WriteLine($"You could only sell {amount - remainingAmount} in the currect constraint.");
                    }
                }
            }

            return result;
        }

        public List<(string ExchangeName, decimal Price, decimal Amount)> GetBestTrades(Type type, decimal amount, List<(decimal, decimal)> predefinedBalances)
        {
            if (CryptoExchanges != null)
            {
                // FOR TEST PURPUSES
                if (predefinedBalances != null)
                {
                    for (int i = 0; i < predefinedBalances.Count; i++)
                    {
                        CryptoExchanges[i].EurBalance = predefinedBalances[i].Item1;
                        CryptoExchanges[i].BtcBalance = predefinedBalances[i].Item2;
                    }
                }
                return GetBestTrades(type, amount);
            }
            return [];
        }
    }
}
