// See https://aka.ms/new-console-template for more information



namespace Binance.Spot.SpotAccountTradeExamples
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Common;
    using Binance.Spot;
    using Binance.Spot.Models;
    using Microsoft.Extensions.Logging;

    public class NewOrder_Example
    {
        public static async Task Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<NewOrder_Example>();

            HttpMessageHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
            HttpClient httpClient = new HttpClient(handler: loggingHandler);

            string apiKey = "";
            string apiSecret = "";

            var spotAccountTrade = new SpotAccountTrade(httpClient, apiKey: apiKey, apiSecret: apiSecret, baseUrl: "https://api2.binance.com");
            //Console.WriteLine("Today's time: {0}", DateTime.Now.TimeOfDay);
            Console.WriteLine("unixTime time: {0}", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
            decimal quantity = 0.05m;
            var result = await spotAccountTrade.NewOrder("BNBUSDT", Side.BUY, OrderType.MARKET, quantity: quantity);
            //Console.WriteLine("Today's time: {0}", DateTime.Now.TimeOfDay);
            Console.WriteLine("unixTime time: {0}", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        }
    }
}

/*

using System;
using System.Threading.Tasks;
using Binance.Spot;



//Console.WriteLine("Hello, World!");
class Program
{


    static async Task Main(string[] args)
    {
        Console.WriteLine("Today's time: {0}", DateTime.Now.TimeOfDay);
        
        Market market = new Market();

        string serverTime = await market.CheckServerTime();


        Console.WriteLine(serverTime);


        Console.WriteLine("Today's time: {0}", DateTime.Now.TimeOfDay);
    }
}

*/