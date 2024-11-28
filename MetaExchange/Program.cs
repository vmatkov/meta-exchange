// See https://aka.ms/new-console-template for more information
using MetaExchange.OrderBook;

#region TEST 1

Console.WriteLine("--- START TEST 1 ---");
// Get input file
string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "test1.json");
// Init CryptoExchanges and OrderBooks
Transactions transactions = new(inputFilePath);
// Init test EUR Balances
List<(double, double)> predefinedBalances = new() { (190, 0), (112.5, 0), (249, 0) };
// call function
var bestTrades = transactions.GetBestTrades("buy", 4.20, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for(int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " for ", bestTrades[i].Price, " EUR."));
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
bestTrades = transactions.GetBestTrades("buy", 4.20, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " for ", bestTrades[i].Price, " EUR."));
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
predefinedBalances = new() { (190, 0), (650, 0), (249, 0) };
// call function
bestTrades = transactions.GetBestTrades("buy", 4.20, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " for ", bestTrades[i].Price, " EUR."));
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
bestTrades = transactions.GetBestTrades("buy", 20, predefinedBalances);
// write out trades
if (bestTrades.Count > 0)
{
    for (int i = 0; i < bestTrades.Count; i++)
    {
        Console.WriteLine(string.Concat("Exchange Timestamp: ", bestTrades[i].ExchangeName, " Amount bought: ", bestTrades[i].Amount, " for ", bestTrades[i].Price, " EUR."));
    }
}
Console.WriteLine("--- END TEST 4 ---");

#endregion

Console.ReadKey();
