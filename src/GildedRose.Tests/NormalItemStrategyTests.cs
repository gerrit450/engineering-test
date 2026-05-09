using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests;

public class NormalItemStrategyTests
{
    private readonly IQualityUpdateStrategy _normalItemStrategy = new NormalItemStrategy();

    [Fact]
    public void GivenQualityIsZero_WhenCheckingQuality_ThenQualityShouldNotGoBelowZero()
    {
        var normal_item = new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 0 };
        const int ExpectedQualityResult = 0;

        _normalItemStrategy.Update(normal_item);

        Assert.Equal(ExpectedQualityResult, normal_item.Quality);
    }

    [Fact]
    public void GivenSellinIsPastByDate_WhenCheckingQuality_ThenQualityShouldReduceTwiceAsFast()
    {
        var normal_item =  new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 10 };
        const int ExpectedQualityResult = 8;

        _normalItemStrategy.Update(normal_item);

        Assert.Equal(ExpectedQualityResult, normal_item.Quality);
    }

    [Fact]
    public void GivenNormalItem_WhenCheckingQuality_SellInValueShouldReducebyOne()
    {
        var normal_item = new Item { Name = "+5 Dexterity Vest", SellIn = 5, Quality = 0 };
        const int ExpectedSellInResult = 4;

        _normalItemStrategy.Update(normal_item);

        Assert.Equal(ExpectedSellInResult, normal_item.SellIn);
    }
}