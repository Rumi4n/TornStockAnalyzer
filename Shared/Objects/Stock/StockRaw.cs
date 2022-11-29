namespace BlazorApp.Shared.Objects.Stock
{
    public class StockRaw
    {
        public int stock_id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public decimal current_price { get; set; }
        public long market_cap { get; set; }
        public long total_shares { get; set; }
        public int investors { get; set; }
        public BenefitRaw benefit { get; set; }
    }
}