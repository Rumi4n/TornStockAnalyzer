using System;
using System.Xml.Schema;

namespace BlazorApp.Shared
{
    public class StockRow
    {
        public string Name{ get; set; }

        public string Acronym { get; set; }

        public bool IsActive { get; set; }

        public string Dividend { get; set; }

        public int DividendValue { get; set; }

        public int DividendTime { get; set; }

        public int Shares { get; set; }

        public decimal SharePrice { get; set; }

        public decimal TotalCost => Shares * SharePrice;

        public decimal Roi => DividendValue / DividendTime * 365 / TotalCost * 100;

        public decimal YearlyProfit => DividendValue / DividendTime * 365;
    }
}
