using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstageItemTests
    {
        [Fact]
        public void GivenBackstageItemAndSellinIsMoreThanTenDays_WhenCheckingQuality_ThenQualityShouldIncreaseOnce()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 } };
            const int ExpectedQualityResult = 1;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenBackstageItemAndSellinIsLessThanTenDays_WhenCheckingQuality_ThenQualityShouldIncreaseTwice()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 0 } };
            const int ExpectedQualityResult = 2;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenBackstageItemAndSellinIsLessThanFiveDays_WhenCheckingQuality_ThenQualityShouldIncreaseByThree()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 0 } };
            const int ExpectedQualityResult = 3;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }

        [Fact]
        public void GivenBackstageItemAndIsPastDueDate_WhenCheckingQuality_ThenQualityShouldEqualToZero()
        {
            // arrange
            var item_list = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -2, Quality = 0 } };
            const int ExpectedQualityResult = 0;

            // act
            var app = new QualityControl();
            app.UpdateQuality(item_list);

            // assert
            Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
        }
    }
}
