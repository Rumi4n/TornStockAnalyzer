using System.Threading.Tasks;
using BlazorApp.Shared;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        private StockRepository _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new StockRepository();
        }

        [Test]
        public async Task Test1()
        {
            var result = await _uut.GetStocks();

            Assert.AreEqual("hello", result);
        }
    }
}