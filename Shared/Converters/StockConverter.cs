using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Shared.Objects.Stock;

namespace BlazorApp.Shared.Converters
{
    internal class StockConverter
    {
        private Dictionary<int, int> _stockValueDictionary { get; } = new Dictionary<int, int>();

        public async Task<List<StockRow>> ConvertToRows(StockRaws raw)
        {
            var result = new List<StockRow>();

            await UpdateStockValues();

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
            result.Add(GetRowFromRaw(raw.stocks._35));

            return result;
        }

        private StockRow GetRowFromRaw(StockRaw raw)
        {
            return new StockRow
            {
                StockId = raw.stock_id,
                Name = raw.name,
                Iteration = 1,
                Acronym = raw.acronym,
                IsActive = raw.benefit.type == "active",
                Dividend = raw.benefit.description,
                DividendValue = _stockValueDictionary[raw.stock_id],
                DividendTime = raw.benefit.frequency,
                Shares = raw.benefit.requirement,
                SharePrice = raw.current_price
            };
        }

        public async Task<List<OwnedStockRow>> ConvertToRows(OwnedStockRaws raw)
        {
            var result = new List<OwnedStockRow>();
            
            AddIfNotNull(result, raw.stocks._1);
            AddIfNotNull(result, raw.stocks._2);
            AddIfNotNull(result, raw.stocks._3);
            AddIfNotNull(result, raw.stocks._4);
            AddIfNotNull(result, raw.stocks._5);
            AddIfNotNull(result, raw.stocks._6);
            AddIfNotNull(result, raw.stocks._7);
            AddIfNotNull(result, raw.stocks._8);
            AddIfNotNull(result, raw.stocks._9);
            AddIfNotNull(result, raw.stocks._10);
            AddIfNotNull(result, raw.stocks._11);
            AddIfNotNull(result, raw.stocks._12);
            AddIfNotNull(result, raw.stocks._13);
            AddIfNotNull(result, raw.stocks._14);
            AddIfNotNull(result, raw.stocks._15);
            AddIfNotNull(result, raw.stocks._16);
            AddIfNotNull(result, raw.stocks._17);
            AddIfNotNull(result, raw.stocks._18);
            AddIfNotNull(result, raw.stocks._19);
            AddIfNotNull(result, raw.stocks._20);
            AddIfNotNull(result, raw.stocks._21);
            AddIfNotNull(result, raw.stocks._22);
            AddIfNotNull(result, raw.stocks._23);
            AddIfNotNull(result, raw.stocks._24);
            AddIfNotNull(result, raw.stocks._25);
            AddIfNotNull(result, raw.stocks._26);
            AddIfNotNull(result, raw.stocks._27);
            AddIfNotNull(result, raw.stocks._28);
            AddIfNotNull(result, raw.stocks._29);
            AddIfNotNull(result, raw.stocks._30);
            AddIfNotNull(result, raw.stocks._31);
            AddIfNotNull(result, raw.stocks._32);
            AddIfNotNull(result, raw.stocks._33);
            AddIfNotNull(result, raw.stocks._34);
            AddIfNotNull(result, raw.stocks._35);

            return result;
        }

        private void AddIfNotNull(List<OwnedStockRow> result, OwnedStockRaw raw)
        {
            if (raw == null) return;

            result.Add(GetRowFromRaw(raw));
        }

        private OwnedStockRow GetRowFromRaw(OwnedStockRaw raw)
        {
            return new OwnedStockRow
            {
                StockId = raw.stock_id,
                Iteration = 3// raw.dividend.increment
            };
        }

        private async Task UpdateStockValues()
        {
            _stockValueDictionary.Clear();

            var itemRepository = new ItemRepository();
            var items = await itemRepository.GetItems();
            var itemsValues = items.ToDictionary(x => x.Id, x => x.Value);

            _stockValueDictionary.Add(1, 50000000);
            _stockValueDictionary.Add(2, 0);
            _stockValueDictionary.Add(3, 0);
            _stockValueDictionary.Add(4, itemsValues[368]);
            _stockValueDictionary.Add(5, 12000000);
            _stockValueDictionary.Add(6, 4000000);
            _stockValueDictionary.Add(7, itemsValues[365]);
            _stockValueDictionary.Add(8, 0);
            _stockValueDictionary.Add(9, 1000000);
            _stockValueDictionary.Add(10, 80000000);
            _stockValueDictionary.Add(11, 0);
            _stockValueDictionary.Add(12, 25000000);
            _stockValueDictionary.Add(13, 0);
            _stockValueDictionary.Add(14, 0);
            _stockValueDictionary.Add(15, itemsValues[367]);
            _stockValueDictionary.Add(16, itemsValues[370]);
            _stockValueDictionary.Add(17, itemsValues[369]);
            _stockValueDictionary.Add(18, itemsValues[366]);
            _stockValueDictionary.Add(19, itemsValues[364]);
            _stockValueDictionary.Add(20, 0);
            _stockValueDictionary.Add(21, 0);
            _stockValueDictionary.Add(22, 45000000);
            _stockValueDictionary.Add(23, 0);
            _stockValueDictionary.Add(24, itemsValues[818]);
            _stockValueDictionary.Add(25, 0);
            _stockValueDictionary.Add(26, 0);
            _stockValueDictionary.Add(27, 0);
            _stockValueDictionary.Add(28, 0);
            _stockValueDictionary.Add(29, 0);
            _stockValueDictionary.Add(30, 0);
            _stockValueDictionary.Add(31, 0);
            _stockValueDictionary.Add(32, itemsValues[817]);
            _stockValueDictionary.Add(33, 0);
            _stockValueDictionary.Add(34, 0);
            _stockValueDictionary.Add(35, 4500000);
        }
    }
}
