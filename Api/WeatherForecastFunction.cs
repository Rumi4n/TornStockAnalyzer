using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class WeatherForecastFunction
    {
        private static string GetSummary(int temp)
        {
            var summary = "Mild";

            if (temp >= 32)
            {
                summary = "Hot";
            }
            else if (temp <= 16 && temp > 0)
            {
                summary = "Cold";
            }
            else if (temp <= 0)
            {
                summary = "Freezing!";
            }

            return summary;
        }

        [FunctionName("WeatherForecast")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var randomNumber = new Random();
            var temp = 0;

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temp = randomNumber.Next(-20, 55),
                Summary = GetSummary(temp)
            }).ToArray();

            return new OkObjectResult(result);
        }

        [FunctionName("TornStockAnalyze")]
        public static async Task<IActionResult> GetTornStockAnalyze(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [FromQuery(Name="key")] string apiKey,
            ILogger log)
        {
            var stockRepository = new StockRepository();
            
            var stocks = await stockRepository.GetStocks();
            var result = GetHigherIterations(stocks.Where(x => x.DividendValue > 0));
            var ordered = result.OrderByDescending(x => x.Roi).ToList();
            ordered.First().Name = apiKey;
            ordered.Last().Name = req.Query["key"];

            return new OkObjectResult(ordered.ToArray());
        }

        private static List<StockRow> GetHigherIterations(IEnumerable<StockRow> originalRows)
        {
            var result = new List<StockRow>();

            foreach (var row in originalRows)
            {
                result.Add(row);
                result.Add(GetIncrementationFor(row, 2));
                result.Add(GetIncrementationFor(row, 3));
                result.Add(GetIncrementationFor(row, 4));
            }

            return result;
        }

        private static StockRow GetIncrementationFor(StockRow row, int iteration)
        {
            return new StockRow
            {
                Name = row.Name,
                Iteration = iteration,
                Acronym = row.Acronym,
                IsActive = row.IsActive,
                Dividend = row.Dividend,
                DividendValue = row.DividendValue,
                DividendTime = row.DividendTime,
                Shares = row.Shares * Convert.ToInt16(Math.Pow(2, iteration-1)),
                SharePrice = row.SharePrice
            };
        }
    }
}
