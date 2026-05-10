namespace GildedRose.Console.Strategies
{
    public class ConjuredItemStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            item.Quality = item.SellIn < 0
                ? Math.Max(0, item.Quality - 4)
                : Math.Max(0, item.Quality - 2);
            item.SellIn--;
        }
    }
}