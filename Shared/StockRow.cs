using System;
using System.Globalization;
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

        public string DividendValueString => DividendValue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

        public int DividendTime { get; set; }

        public int Shares { get; set; }

        public decimal SharePrice { get; set; }

        public string SharePriceString => SharePrice.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

        public decimal TotalCost => Shares * SharePrice;

        public string TotalCostString => TotalCost.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

        public decimal Roi => DividendValue / DividendTime * 365 / TotalCost;

        public string RoiString => Roi.ToString("P", CultureInfo.CreateSpecificCulture("en-US"));

        public decimal YearlyProfit => DividendValue / DividendTime * 365;

        public string YearlyProfitString => YearlyProfit.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
    }
}
