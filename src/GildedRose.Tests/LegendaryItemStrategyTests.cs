using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests
{
    public class LegendaryItemStrategyTests
    {
        private readonly IQualityUpdateStrategy legendaryItemStrategy = new LegendaryItemStrategy();

        [Fact]
        public void GivenLegendaryItem_WhenCheckingQuality_ThenQualityShouldNeverDecrease()
        {
            var legendaryItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };
            const int ExpectedQualityResult = 80;

            legendaryItemStrategy.Update(legendaryItem);

            Assert.Equal(ExpectedQualityResult, legendaryItem.Quality);
        }

        [Fact]
        public void GivenLegendaryItem_WhenCheckingQuality_ThenSellPastDateShouldNeverDecrease()
        {
            var legendaryItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };
            const int ExpectedSellinResult = 1;

            legendaryItemStrategy.Update(legendaryItem);

            Assert.Equal(ExpectedSellinResult, legendaryItem.SellIn);
        }
    }
}
