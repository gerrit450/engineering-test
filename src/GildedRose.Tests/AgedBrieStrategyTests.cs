using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieStrategyTests
    {
        private readonly IQualityUpdateStrategy _agedBrieStrategy = new AgedBrieStrategy();

        [Fact]
        public void GivenQualityIsFifty_WhenCheckingQuality_ThenQualityShouldNotGoAboveFifty()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 };
            const int ExpectedQualityResult = 50;

            _agedBrieStrategy.Update(agedBrie);

            Assert.Equal(ExpectedQualityResult, agedBrie.Quality);
        }

        [Fact]
        public void GivenPastByDate_WhenCheckingQuality_ThenQualityShouldIncreaseByTwo()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 };
            const int ExpectedQualityResult = 2;

            _agedBrieStrategy.Update(agedBrie);

            Assert.Equal(ExpectedQualityResult, agedBrie.Quality);
        }

        [Fact]
        public void GivenItemAndSellinIsGreaterThanZero_WhenCheckingQuality_ThenQualityShouldIncreaseByOne()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };
            const int ExpectedQualityResult = 1;

            _agedBrieStrategy.Update(agedBrie);

            Assert.Equal(ExpectedQualityResult, agedBrie.Quality);
        }
    }
}
