namespace GildedRose.Console.Strategies
{
    public class NormalItemStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            item.Quality = item.SellIn < 0 && item.Quality != 0 ? item.Quality - 1 : item.Quality;
            item.Quality = item.Quality > 0 ? item.Quality - 1 : 0;
            item.SellIn--;
        }
    }
}
