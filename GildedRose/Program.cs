using System;
using System.Collections.Generic;

namespace GildedRose
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, UpdateMethod = ItemUpdateMethods.UpdateDefault},
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0, UpdateMethod = ItemUpdateMethods.UpdateBrie },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, UpdateMethod = ItemUpdateMethods.UpdateDefault },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, UpdateMethod = (item) => { }
                },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80,UpdateMethod = (item) => { } },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20,
                    UpdateMethod = ItemUpdateMethods.UpdateBackstage
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49,
                    UpdateMethod = ItemUpdateMethods.UpdateBackstage
                    
                    
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49,
                    UpdateMethod = ItemUpdateMethods.UpdateBackstage
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 10,UpdateMethod = ItemUpdateMethods.UpdateConjured }
                                          }

                          };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public UpdateItemQuality UpdateMethod { get; set; }
        
        public delegate void UpdateItemQuality(Item item);
        
        public void UpdateQuality()
        {
            UpdateMethod(this);
        }
    }

    public static class ItemUpdateMethods
    { 
        public static void UpdateDefault(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
                if (item.SellIn < 0 && item.Quality>0)
                {
                    item.Quality--;
                }
            }
            item.SellIn--;
        }
        
        
        public static void UpdateBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
            item.SellIn--;
        }
        
        public static void UpdateBackstage(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }
            if (item.Quality < 50)
            {
                item.Quality++;
                if (item.SellIn < 11 && item.Quality<50)
                {
                    item.Quality++;
                    if (item.SellIn < 6 && item.Quality<50)
                    {
                        item.Quality++;
                    }
                }
            }
            item.SellIn--;
        }
        
        public static void UpdateConjured(Item item)
        {
            if (item.Quality > 1)
            {
                item.Quality-=2;
                if (item.SellIn < 0)
                {
                    if (item.Quality > 1)
                    {
                        item.Quality-=2;
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
            }
            else
            {
                item.Quality = 0;
            }
            item.SellIn--;
        }  
    }
}