using System.Collections.Generic;
using BlazorApp.Shared.Objects;

namespace BlazorApp.Shared.Converters
{
    internal class StockConverter
    {
        public List<StockRow> ConvertToRows(StockRaws raw)
        {
            var result = new List<StockRow>();

            result.Add(GetRowFromRaw(raw.stocks._1));
            result.Add(GetRowFromRaw(raw.stocks._2));
            result.Add(GetRowFromRaw(raw.stocks._3));
            result.Add(GetRowFromRaw(raw.stocks._4));
            result.Add(GetRowFromRaw(raw.stocks._5));
            result.Add(GetRowFromRaw(raw.stocks._6));
            result.Add(GetRowFromRaw(raw.stocks._7));
            result.Add(GetRowFromRaw(raw.stocks._8));
            result.Add(GetRowFromRaw(raw.stocks._9));
            result.Add(GetRowFromRaw(raw.stocks._10));
            result.Add(GetRowFromRaw(raw.stocks._11));
            result.Add(GetRowFromRaw(raw.stocks._12));
            result.Add(GetRowFromRaw(raw.stocks._13));
            result.Add(GetRowFromRaw(raw.stocks._14));
            result.Add(GetRowFromRaw(raw.stocks._15));
            result.Add(GetRowFromRaw(raw.stocks._16));
            result.Add(GetRowFromRaw(raw.stocks._17));
            result.Add(GetRowFromRaw(raw.stocks._18));
            result.Add(GetRowFromRaw(raw.stocks._19));
            result.Add(GetRowFromRaw(raw.stocks._20));
            result.Add(GetRowFromRaw(raw.stocks._21));
            result.Add(GetRowFromRaw(raw.stocks._22));
            result.Add(GetRowFromRaw(raw.stocks._23));
            result.Add(GetRowFromRaw(raw.stocks._24));
            result.Add(GetRowFromRaw(raw.stocks._25));
            result.Add(GetRowFromRaw(raw.stocks._26));
            result.Add(GetRowFromRaw(raw.stocks._27));
            result.Add(GetRowFromRaw(raw.stocks._28));
            result.Add(GetRowFromRaw(raw.stocks._29));
            result.Add(GetRowFromRaw(raw.stocks._30));
            result.Add(GetRowFromRaw(raw.stocks._31));
            result.Add(GetRowFromRaw(raw.stocks._32));
            result.Add(GetRowFromRaw(raw.stocks._33));
            result.Add(GetRowFromRaw(raw.stocks._34));

            return new List<StockRow>();
        }

        private StockRow GetRowFromRaw(StockRaw raw)
        {
            return new StockRow
            {
                Name = raw.name,
                Acronym = raw.acronym,
                IsActive = raw.benefit.type == "active",
                Dividend = raw.benefit.description,
                DividendValue = 1000,
                DividendTime = raw.benefit.frequency,
                Shares = raw.benefit.requirement,
                SharePrice = raw.current_price
            };
        }
    }
}
