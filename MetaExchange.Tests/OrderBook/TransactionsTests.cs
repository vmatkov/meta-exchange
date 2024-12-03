using Xunit;
using MetaExchange.OrderBook;
using Type = MetaExchange.OrderBook.Type;
using FluentAssertions;

namespace MetaExchange.Tests.OrderBook
{
    public class TransactionsTests
    {
        #region Buying
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
        #endregion Buying
        #region Selling
        [Fact]
        public void Transactions_GetBestTrades_SellAllBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (868.05m, 2.50m), (15384m, 3m), (253m, 11m) };

            //Act
            var result = transactions.GetBestTrades(Type.Sell, 16.50m, predefinedBalances);
            var expectedResult = new List<(string, decimal, decimal)>
            {
                ("2024-11-27T15:22:00.2518856Z", 8000m, 5m),
                ("2024-11-27T15:22:00.2518855Z", 3000m, 2m),
                ("2024-11-27T15:22:00.2518854Z", 2100.0m, 1.5m),
                ("2024-11-27T15:22:00.2518854Z", 1200m, 1m),
                ("2024-11-27T15:22:00.2518856Z", 6480m, 6m),
                ("2024-11-27T15:22:00.2518855Z", 1000m, 1m)
            };

            //Assert
            result.Should().NotBeEmpty();
            result.Should().Equal(expectedResult);
        }

        [Fact]
        public void Transactions_GetBestTrades_SellNoBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (868.05m, 0m), (15384m, 0m), (253m, 0m) };

            //Act
            var result = transactions.GetBestTrades(Type.Sell, 16.50m, predefinedBalances);

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void Transactions_GetBestTrades_SellPartOfBTC()
        {
            //Arrange - variables, classes, mocks
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
            Transactions transactions = new(inputFilePath);
            List<(decimal, decimal)> predefinedBalances = new() { (0, 0), (0, 0), (0, 0.5m) };

            //Act
            var result = transactions.GetBestTrades(Type.Sell, 0.50m, predefinedBalances);
            var expectedResult = new List<(string, decimal, decimal)>
            {
                ("2024-11-27T15:22:00.2518856Z", 800m, 0.5m)
            };

            //Assert
            result.Should().Equal(expectedResult);
        }
        #endregion Selling
    }
}
