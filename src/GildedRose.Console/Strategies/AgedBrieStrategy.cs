namespace GildedRose.Console.Strategies
{
    public class AgedBrieStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            var qualityIncrease = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(50, item.Quality + qualityIncrease);
            item.SellIn--;
        }
    }
}
