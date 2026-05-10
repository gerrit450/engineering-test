namespace GildedRose.Console.Strategies
{
    public class NormalItemStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            var qualityDegradation = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Max(0, item.Quality - qualityDegradation);
            item.SellIn--;
        }
    }
}
