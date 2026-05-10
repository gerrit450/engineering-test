using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredStrategyTest
    {
        private readonly IQualityUpdateStrategy _conjuredItemStrategy = new ConjuredItemStrategy();

        [Theory]
        [InlineData(5, 10, 8)]
        [InlineData(1, 16, 14)]
        [InlineData(8, 0, 0)]
        public void GivenQualityIsGreaterOrEqualToZero_WhenCheckingQuality_ThenQualityShouldDegradeByTwo(int inputSellin, int inputQuality, int expectedQualityResult)
        {
            var conjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = inputSellin, Quality = inputQuality };

            _conjuredItemStrategy.Update(conjuredItem);

            Assert.Equal(expectedQualityResult, conjuredItem.Quality);
        }

        [Fact]
        public void GivenConjuredItem_WhenCheckingQuality_ThenSellInValueShouldReducebyOne()
        {
            var conjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
            var expectedSellInResult = 4;

            _conjuredItemStrategy.Update(conjuredItem);

            Assert.Equal(expectedSellInResult, conjuredItem.SellIn);
        }

        [Theory]
        [InlineData(-2, 10, 6)]
        [InlineData(-1, 2, 0)]
        [InlineData(-15, 50, 46)]
        public void GivenSellInIsLessThanZero_WhenCheckingQuality_ThenQualityShouldDegradeByFour(int inputSellin, int inputQuality, int expectedQualityResult)
        {
            var conjuredItem = new Item { Name = "Conjured Mana Cake", SellIn = inputSellin, Quality = inputQuality };

            _conjuredItemStrategy.Update(conjuredItem);

            Assert.Equal(expectedQualityResult, conjuredItem.Quality);

        }
    }
}