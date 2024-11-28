using Microsoft.AspNetCore.Mvc;
using MetaExchange.OrderBook;

namespace MetaExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaExchangeController : ControllerBase
    {
        [HttpGet("Trade")]
        public IActionResult Trade(string type, decimal amount)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "order_books_data.json");
            Transactions trade = new(inputFilePath);

            var response = trade.GetBestTrades(type, amount).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }

        [HttpGet("BuyTest1")]
        public IActionResult BuyTest1(string type = "buy", decimal amount = 4.20m)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions trade = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (190, 0), (112.5m, 0), (249, 0) };

            var response = trade.GetBestTrades(type, amount, predefinedBalances).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }

        [HttpGet("BuyTest2")]
        public IActionResult BuyTest2(string type = "buy", decimal amount = 4.20m)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions trade = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (190, 0), (650, 0), (249, 0) };

            var response = trade.GetBestTrades(type, amount, predefinedBalances).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }

        [HttpGet("BuyTest3")]
        public IActionResult BuyTest3(string type = "buy", decimal amount = 4.20m)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test2.txt");
            Transactions trade = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (190, 0), (500, 0), (249, 0) };

            var response = trade.GetBestTrades(type, amount, predefinedBalances).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }

        [HttpGet("BuyTest4")]
        public IActionResult BuyTest4(string type = "buy", decimal amount = 20.00m)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test2.txt");
            Transactions trade = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (100000, 0), (100000, 0), (100000, 0) };

            var response = trade.GetBestTrades(type, amount, predefinedBalances).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }

        [HttpGet("SaleTest1")]
        public IActionResult SaleTest1(string type = "sell", decimal amount = 1.50m)
        {
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions trade = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (190, 1.5m), (112.5m, 2), (249, 0) };

            var response = trade.GetBestTrades(type, amount, predefinedBalances).Select(t => new
            {
                OrderName = t.ExchangeName,
                Price = t.Price,
                Amount = t.Amount
            });

            return Ok(response);
        }
    }
}
