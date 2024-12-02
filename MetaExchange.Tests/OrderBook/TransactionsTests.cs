using Xunit;
using MetaExchange.OrderBook;
using Type = MetaExchange.OrderBook.Type;
using FluentAssertions;

namespace MetaExchange.Tests.OrderBook
{
    public class TransactionsTests
    {
        [Fact]
        public void Transactions_GetBestTrades_ReturnBestBuyTrades()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (190, 0), (112.5m, 0), (249, 0) };

            //Act
            var result = transactions.GetBestTrades(Type.Buy, 4.20m, predefinedBalances);

            //Assert
            result.Should().NotBeEmpty();
        }
    }
}
