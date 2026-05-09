using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieTests
    {

        [Fact]
        public void GivenAgedBrieAndQualityIsFifty_WhenCheckingQuality_ThenQualityShouldNotGoAboveFifty()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            const int ExpectedQualityResult = 50;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenAgedBrieAndPastByDate_WhenCheckingQuality_ThenQualityShouldIncreaseByTwo()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 } };
            const int ExpectedQualityResult = 2;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenAgedBrieItemAndSellinIsGreaterThanZero_WhenCheckingQuality_ThenQualityShouldIncreaseByOne()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            const int ExpectedQualityResult = 1;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }
    }
}
