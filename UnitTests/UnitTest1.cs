using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Api;
using BlazorApp.Shared;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        private StockRepository _uut;
        private ItemRepository _uut2;

        [SetUp]
        public void Setup()
        {
            _uut = new StockRepository("GU4SSKbJAP0zxAex");
            _uut2 = new ItemRepository();
        }

        [Test]
        public async Task Test1()
        {
            var result = await _uut.GetAllStocksInfo();

            Assert.AreEqual("hello", result);
        }

        [Test]
        public async Task Test2()
        {
            var result = await _uut.GetOwnedStocks();

            Assert.AreEqual("hello", result);
        }

        [Test]
        public async Task Test3()
        {
            var result = await _uut2.GetItems();

            Assert.AreEqual("hello", result);
        }

        [Test]
        public async Task Test4()
        {
            var stockRows = new List<StockRow>();
            stockRows.Add(new StockRow
            {
                StockId = 1,
                Iteration = 1,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 1,
                Iteration = 2,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 1,
                Iteration = 3,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 2,
                Iteration = 1,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 2,
                Iteration = 2,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 2,
                Iteration = 3,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 3,
                Iteration = 1,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 3,
                Iteration = 2,
                IsOwned = false
            });
            stockRows.Add(new StockRow
            {
                StockId = 3,
                Iteration = 3,
                IsOwned = false
            });
            var ownedRows = new List<OwnedStockRow>();
            ownedRows.Add(new OwnedStockRow
            {
                StockId = 1,
                Iteration = 2
            });
            ownedRows.Add(new OwnedStockRow
            {
                StockId = 3,
                Iteration = 1
            });

            WeatherForecastFunction.MarkOwnedStocks(stockRows, ownedRows);

            Assert.AreEqual("hello", stockRows.First().Name);
        }
    }
}