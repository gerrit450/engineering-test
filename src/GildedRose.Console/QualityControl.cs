using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GildedRose.Console.Program;

namespace GildedRose.Console
{
    public class QualityControl
    {
        public void UpdateQuality(IList<Item> listOfItems)
        {
            for (var i = 0; i < listOfItems.Count; i++)
            {
                if (listOfItems[i].Name != "Aged Brie" && listOfItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (listOfItems[i].Quality > 0)
                    {
                        if (listOfItems[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            listOfItems[i].Quality = listOfItems[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (listOfItems[i].Quality < 50)
                    {
                        listOfItems[i].Quality = listOfItems[i].Quality + 1;

                        if (listOfItems[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (listOfItems[i].SellIn < 11)
                            {
                                if (listOfItems[i].Quality < 50)
                                {
                                    listOfItems[i].Quality = listOfItems[i].Quality + 1;
                                }
                            }

                            if (listOfItems[i].SellIn < 6)
                            {
                                if (listOfItems[i].Quality < 50)
                                {
                                    listOfItems[i].Quality = listOfItems[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (listOfItems[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    listOfItems[i].SellIn = listOfItems[i].SellIn - 1;
                }

                if (listOfItems[i].SellIn < 0)
                {
                    if (listOfItems[i].Name != "Aged Brie")
                    {
                        if (listOfItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (listOfItems[i].Quality > 0)
                            {
                                if (listOfItems[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    listOfItems[i].Quality = listOfItems[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            listOfItems[i].Quality = listOfItems[i].Quality - listOfItems[i].Quality;
                        }
                    }
                    else
                    {
                        if (listOfItems[i].Quality < 50)
                        {
                            listOfItems[i].Quality = listOfItems[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
