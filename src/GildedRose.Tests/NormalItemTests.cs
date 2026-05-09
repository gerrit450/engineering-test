using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests;

public class NormalItemTests
{

    [Fact]
    public void GivenQualityIsZero_WhenCheckingQuality_ThenQualityShouldNotGoBelowZero()
    {
        // arrange
        var item_list = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 0 } };
        const int ExpectedQualityResult = 0;

        // act
        var app = new QualityControl();
        app.UpdateQuality(item_list);

        // assert
        Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
    }

    [Fact]
    public void GivenSellinIsPastByDate_WhenCheckingQuality_ThenQualityShouldReduceTwiceAsFast()
    {
        // arrange
        var item_list = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 10 } };
        const int ExpectedQualityResult = 8;

        // act
        var app = new QualityControl();
        app.UpdateQuality(item_list);

        // assert
        Assert.Equal(ExpectedQualityResult, item_list[0].Quality);
    }

    [Fact]
    public void GivenNormalItem_WhenCheckingQuality_SellInValueShouldReducebyOne()
    {
        // arrange
        var item_list = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 0 } };
        const int ExpectedSellInResult = 4;

        // act
        var app = new QualityControl();
        app.UpdateQuality(item_list);

        // assert
        Assert.Equal(ExpectedSellInResult, item_list[0].SellIn);
    }
}