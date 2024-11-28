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
    }
}
