using System.Collections.Generic;
using BlazorApp.Shared.Repositories;

namespace BlazorApp.Shared.Converters
{
    public class ItemConverter
    {
        public List<ItemRow> ConvertToRows(ItemRaws raws)
        {
            var result = new List<ItemRow>();

            result.Add(GetRowFromRaw(364, raws.items._364));
            result.Add(GetRowFromRaw(365, raws.items._365));
            result.Add(GetRowFromRaw(366, raws.items._366));
            result.Add(GetRowFromRaw(367, raws.items._367));
            result.Add(GetRowFromRaw(368, raws.items._368));
            result.Add(GetRowFromRaw(369, raws.items._369));
            result.Add(GetRowFromRaw(370, raws.items._370));
            result.Add(GetRowFromRaw(817, raws.items._817));
            result.Add(GetRowFromRaw(818, raws.items._818));

            return result;
        }

        private ItemRow GetRowFromRaw(int id, ItemRaw raw)
        {
            return new ItemRow
            {
                Id = id,
                Name = raw.name,
                Value = raw.market_value
            };
        }
    }
}