// See https://aka.ms/new-console-template for more information
using MetaExchange.OrderBook;
using System;
using Type = MetaExchange.OrderBook.Type;

#region BUYING TESTS
Console.WriteLine("--- BUYING TESTS ---");
#region TEST 1

Console.WriteLine("--- START TEST 1 ---");
// Get input file
string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
// Init CryptoExchanges and OrderBooks
Transactions transactions = new(inputFilePath);
// Init test EUR Balances
List<(decimal, decimal)> predefinedBalances = new() { (190, 0), (112.5m, 0), (249, 0) };
// call function
var bestTrades = transactions.GetBestTrades(Type.Buy, 4.20m, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for(int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 1 ---");

#endregion

#region TEST 2

Console.WriteLine("--- START TEST 2 ---");
// Get input file
inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
// Init CryptoExchanges and OrderBooks
transactions = new(inputFilePath);
// Init test EUR Balances
predefinedBalances = new() { (190, 0), (650, 0), (249, 0) };
// call function
bestTrades = transactions.GetBestTrades(Type.Buy, 4.20m, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 2 ---");

#endregion

#region TEST 3

Console.WriteLine("--- START TEST 3---");
// Get input file
inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test2.txt");
// Init CryptoExchanges and OrderBooks
transactions = new(inputFilePath);
// Init test EUR Balances
predefinedBalances = new() { (190, 0), (500, 0), (249, 0) };
// call function
bestTrades = transactions.GetBestTrades(Type.Buy, 4.20m, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 3 ---");

#endregion

#region TEST 4

Console.WriteLine("--- START TEST 4 ---");
// Get input file
inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test2.txt");
// Init CryptoExchanges and OrderBooks
transactions = new(inputFilePath);
// Init test EUR Balances
predefinedBalances = new() { (100000, 0), (100000, 0), (100000, 0) };
// call function
bestTrades = transactions.GetBestTrades(Type.Buy, 20, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 4 ---");

#endregion
Console.WriteLine("--- BUYING TESTS ---");
#endregion

#region SELLING TESTS
Console.WriteLine("--- SELLING TESTS ---");
#region TEST 1
Console.WriteLine("--- START TEST 1 ---");
// Get input file
inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
// Init CryptoExchanges and OrderBooks
transactions = new(inputFilePath);
// Init test EUR Balances
predefinedBalances = new() { (190, 0), (112.5m, 0), (249, 0.5m) };
// call function
bestTrades = transactions.GetBestTrades(Type.Sell, 1.5m, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount sold: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 1 ---");
#endregion

#region TEST 2
#endregion

#region TEST 3
#endregion

#region TEST 4
#endregion
Console.WriteLine("--- SELLING TESTS ---");
#endregion


Console.WriteLine("--- RANDOM TEST ---");
inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "order_books_data.json");
transactions = new(inputFilePath);
Console.WriteLine("--- SELLING ---");
bestTrades = transactions.GetBestTrades(Type.Sell, 0.0002m);
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount sold: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- SELLING ---");
Console.WriteLine("--- BUYING ---");
bestTrades = transactions.GetBestTrades(Type.Buy, 5.0m);
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " BTC for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- BUYING ---");
Console.WriteLine("--- RANDOM TEST ---");

Console.ReadKey();
