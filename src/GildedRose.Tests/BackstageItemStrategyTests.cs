using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstageItemStrategyTests
    {
        private readonly IQualityUpdateStrategy _backstageItemStrategy = new BackstageItemStrategy();

        [Fact]
        public void GivenSellinIsMoreThanTenDays_WhenCheckingQuality_ThenQualityShouldIncreaseOnce()
        {
            var backStagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 };
            const int ExpectedQualityResult = 1;

            _backstageItemStrategy.Update(backStagePass);

            Assert.Equal(ExpectedQualityResult, backStagePass.Quality);
        }

        [Fact]
        public void GivenSellinIsLessThanTenDays_WhenCheckingQuality_ThenQualityShouldIncreaseTwice()
        {
            var backStagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 0 };
            const int ExpectedQualityResult = 2;

            _backstageItemStrategy.Update(backStagePass);

            Assert.Equal(ExpectedQualityResult, backStagePass.Quality);
        }

        [Fact]
        public void GivenSellinIsLessThanFiveDays_WhenCheckingQuality_ThenQualityShouldIncreaseByThree()
        {
            var backStagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 0 };
            const int ExpectedQualityResult = 3;

            _backstageItemStrategy.Update(backStagePass);

            Assert.Equal(ExpectedQualityResult, backStagePass.Quality);
        }

        [Fact]
        public void GivenIsPastDueDate_WhenCheckingQuality_ThenQualityShouldEqualToZero()
        {
            var backStagePass = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0 };
            const int ExpectedQualityResult = 0;

            _backstageItemStrategy.Update(backStagePass);

            Assert.Equal(ExpectedQualityResult, backStagePass.Quality);
        }
    }
}
