using Xunit;
using MetaExchange.OrderBook;
using Type = MetaExchange.OrderBook.Type;
using FluentAssertions;

namespace MetaExchange.Tests.OrderBook
{
    public class TransactionsTests
    {
        [Fact]
        public void Transactions_GetBestTrades_BuyAllBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (868.05m, 0), (15384m, 0), (253m, 0) };

            //Act
            var result = transactions.GetBestTrades(Type.Buy, 14.20m, predefinedBalances);
            var expectedResult = new List<(string, decimal, decimal)>
            {
                ("2024-11-27T15:22:00.2518854Z", 76.05m, 0.39m),
                ("2024-11-27T15:22:00.2518856Z", 250m, 1m),
                ("2024-11-27T15:22:00.2518856Z", 3.00m, 0.01m),
                ("2024-11-27T15:22:00.2518854Z", 792.00m, 2.00m),
                ("2024-11-27T15:22:00.2518855Z", 384.00m, 0.80m),
                ("2024-11-27T15:22:00.2518855Z", 15000.00m, 10.00m)
            };

            //Assert
            result.Should().NotBeEmpty();
            result.Should().Equal(expectedResult);
        }

        [Fact]
        public void Transactions_GetBestTrades_CannotBuyBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (0, 0), (0, 0), (0, 0) };

            //Act
            var result = transactions.GetBestTrades(Type.Buy, 14.20m, predefinedBalances);

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void Transactions_GetBestTrades_BuyPartOfBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (0, 0), (15384, 0), (0, 0) };

            //Act
            var result = transactions.GetBestTrades(Type.Buy, 14.20m, predefinedBalances);
            var expectedResult = new List<(string, decimal, decimal)>
            {
                ("2024-11-27T15:22:00.2518855Z", 384.00m, 0.80m),
                ("2024-11-27T15:22:00.2518855Z", 15000.00m, 10.00m)
            };

            //Assert
            result.Should().Equal(expectedResult);
        }
    }
}
