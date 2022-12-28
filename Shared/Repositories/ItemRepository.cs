using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Shared.Converters;
using Newtonsoft.Json;

namespace BlazorApp.Shared.Repositories
{
    public class ItemRepository
    {
        private readonly ItemConverter _converter;

        private readonly string _apiKey;

        public ItemRepository(string apiKey)
        {
            _converter = new ItemConverter();
            _apiKey = apiKey;
        }

        public async Task<List<ItemRow>> GetItems()
        {
            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync($"https://api.torn.com/torn/368,365,367,370,369,366,364,818,817?selections=items&key={_apiKey}", HttpCompletionOption.ResponseHeadersRead))
            {
                httpResponse.EnsureSuccessStatusCode();

                try
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var jsonDeserialized = JsonConvert.DeserializeObject<ItemRaws>(result);
                    return _converter.ConvertToRows(jsonDeserialized);
                }
                catch // Could be ArgumentNullException or UnsupportedMediaTypeException
                {
                    Console.WriteLine("HTTP Response was invalid or could not be deserialised.");
                    throw;
                }
            }
        }
    }

    public class ItemRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class ItemRaws
    {
        public ItemListRaw items { get; set; }
    }

    public class ItemListRaw
    {
        [JsonProperty("364")]
        public ItemRaw _364 { get; set; }

        [JsonProperty("365")]
        public ItemRaw _365 { get; set; }

        [JsonProperty("366")]
        public ItemRaw _366 { get; set; }

        [JsonProperty("367")]
        public ItemRaw _367 { get; set; }

        [JsonProperty("368")]
        public ItemRaw _368 { get; set; }

        [JsonProperty("369")]
        public ItemRaw _369 { get; set; }

        [JsonProperty("370")]
        public ItemRaw _370 { get; set; }

        [JsonProperty("817")]
        public ItemRaw _817 { get; set; }

        [JsonProperty("818")]
        public ItemRaw _818 { get; set; }
    }

    public class ItemRaw
    {
        public string name { get; set; }
        public string description { get; set; }
        public string effect { get; set; }
        public string requirement { get; set; }
        public string type { get; set; }
        public object weapon_type { get; set; }
        public int buy_price { get; set; }
        public int sell_price { get; set; }
        public int market_value { get; set; }
        public int circulation { get; set; }
        public string image { get; set; }
    }
}
