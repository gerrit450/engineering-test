namespace GildedRose.Console.Strategies
{
    public class BackstageItemStrategy : IQualityUpdateStrategy
    {
        public void Update(Item item)
        {
            switch (item.SellIn)
            {
                case <= 0:
                    item.Quality = 0;
                    break;
                case <= 5:
                    item.Quality = Math.Min(item.Quality + 3, 50);
                    break;
                case <= 10:
                    item.Quality = Math.Min(item.Quality + 2, 50);
                    break;
                default:
                    item.Quality = Math.Min(item.Quality + 1, 50);
                    break;
            }

            item.SellIn--;
        }
    }
}
