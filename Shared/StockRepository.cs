using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Shared.Converters;
using BlazorApp.Shared.Objects;
using BlazorApp.Shared.Objects.Stock;
using Newtonsoft.Json;

namespace BlazorApp.Shared
{
    public class StockRepository
    {
        private readonly StockConverter _converter;

        public StockRepository()
        {
            _converter = new StockConverter();
        }

        public async Task<List<StockRow>> GetStocks()
        {
            using (var httpClient = new HttpClient())
            using(var httpResponse = await httpClient.GetAsync("https://api.torn.com/torn/?selections=stocks&key=GU4SSKbJAP0zxAex", HttpCompletionOption.ResponseHeadersRead))
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
    }
}
