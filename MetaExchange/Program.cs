// See https://aka.ms/new-console-template for more information
using MetaExchange.OrderBook;

Console.WriteLine("Hello, World!");

string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", "order_books_data.json");
Transactions transactions = new(inputFilePath);
