using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class Sulfuras
    {
        [Fact]
        public void GivenLegendaryItem_WhenCheckingQuality_ThenQualityShouldNeverDecrease()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            const int ExpectedQualityResult = 80;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenLegendaryItem_WhenCheckingQuality_ThenSellPastDateShouldNeverDecrease()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            const int ExpectedSellinResult = 1;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedSellinResult, item_list[0].SellIn);
        }
    }
}
