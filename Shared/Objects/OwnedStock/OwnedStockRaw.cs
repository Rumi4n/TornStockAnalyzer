namespace BlazorApp.Shared.Objects.OwnedStock
{
    public class OwnedStockRaw
    {
        public int stock_id { get; set; }
        public long total_shares { get; set; }
        public DividendRaw dividend { get; set; }
        public object transactions { get; set; }
    }
}