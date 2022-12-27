using System;
using System.Threading.Tasks;
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
    }
}