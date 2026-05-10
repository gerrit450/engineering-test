namespace GildedRose.Console.Strategies
{
    public static class ItemFactory
    {
        public static IQualityUpdateStrategy Create(Item item) => item.Name switch
        {
            "Aged Brie" => new AgedBrieStrategy(),
            "Conjured Mana Cake" => new ConjuredItemStrategy(),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstageItemStrategy(),
            "Sulfuras, Hand of Ragnaros" => new LegendaryItemStrategy(),
            _ => new NormalItemStrategy()
        };
    }
}
