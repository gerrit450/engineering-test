namespace GildedRose.Console.Strategies
{
    public class ConjuredItemStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            var qualityDegradation = item.SellIn < 0 ? 4 : 2;
            item.Quality = Math.Max(0, item.Quality - qualityDegradation);
            item.SellIn--;
        }
    }
}