using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    public static class QualityControl
    {
        public static void UpdateQuality(IList<Item> listOfItems)
        {
            foreach (var item in listOfItems)
            {
                var itemStrategy = ItemFactory.Create(item);
                itemStrategy.Update(item);
            }
        }
    }
}
