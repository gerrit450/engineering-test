using GildedRose.Console;
using GildedRose.Console.Strategies;
using Xunit;

namespace GildedRose.Tests
{
    public class ItemFactoryTests
    {
        public static IEnumerable<object[]> ItemStrategyTestData =>
        [
            ["Aged Brie", typeof(AgedBrieStrategy)],
            ["Backstage passes to a TAFKAL80ETC concert", typeof(BackstageItemStrategy)],
            ["Sulfuras, Hand of Ragnaros", typeof(LegendaryItemStrategy)],
            ["Normal Item", typeof(NormalItemStrategy)],
            ["Conjured Mana Cake", typeof(ConjuredItemStrategy)],
        ];

        [Theory]
        [MemberData(nameof(ItemStrategyTestData))]
        public void GivenItemName_WhenCreatingItem_ThenShouldReturnCorrectItemType(string itemName, Type qualityUpdateStrategy)
        {
            var item = new Item { Name = itemName, SellIn = 0, Quality = 0 };

            var actualItemStrategy = ItemFactory.Create(item);

            Assert.IsType(qualityUpdateStrategy, actualItemStrategy);
        }
    }
}
