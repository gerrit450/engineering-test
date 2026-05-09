namespace GildedRose.Console.Strategies
{
    public class AgedBrieStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            item.Quality = item.SellIn < 0
                ? Math.Min(50, item.Quality + 2)
                : Math.Min(50, item.Quality + 1);
            item.SellIn--;
        }
    }
}
