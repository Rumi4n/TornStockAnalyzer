using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Shared.Converters;
using BlazorApp.Shared.Objects.OwnedStock;
using BlazorApp.Shared.Objects.Stock;
using Newtonsoft.Json;

namespace BlazorApp.Shared.Repositories
{
    public class StockRepository
    {
        private readonly StockConverter _converter;

        private readonly string _apiKey;

        public StockRepository(string apiKey)
        {
            _converter = new StockConverter(apiKey);
            _apiKey = apiKey;
        }

        public async Task<List<StockRow>> GetAllStocksInfo()
        {
            using (var httpClient = new HttpClient())
            using(var httpResponse = await httpClient.GetAsync($"https://api.torn.com/torn/?selections=stocks&key={_apiKey}", HttpCompletionOption.ResponseHeadersRead))
            {
                httpResponse.EnsureSuccessStatusCode();
                
                try
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var jsonDeserialized = JsonConvert.DeserializeObject<StockRaws>(result);
                    return await _converter.ConvertToRows(jsonDeserialized);
                }
                catch // Could be ArgumentNullException or UnsupportedMediaTypeException
                {
                    Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
                    throw;
                }
            }
        }

        public async Task<List<OwnedStockRow>> GetOwnedStocks()
        {
            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync($"https://api.torn.com/user/?selections=stocks&key={_apiKey}", HttpCompletionOption.ResponseHeadersRead))
            {
                httpResponse.EnsureSuccessStatusCode();

                try
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var jsonDeserialized = JsonConvert.DeserializeObject<OwnedStockRaws>(result);
                    return await _converter.ConvertToRows(jsonDeserialized);
                }
                catch // Could be ArgumentNullException or UnsupportedMediaTypeException
                {
                    Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
                    throw;
                }
            }
        }
    }
}
