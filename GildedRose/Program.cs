using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items { get; set; }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
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
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i] = ItemFactory.CreateItem(Items[i]);
            }
            foreach (IItem item in Items)
            {
                item.UpdateQualityInClass();
            }
        }

        public class Item
        {
            public string Name { get; set; }

            public int SellIn { get; set; }

            public int Quality { get; set; }
        }
        public interface IItem
        {
            public string Name { get; set; }

            public int SellIn { get; set; }

            public int Quality { get; set; }
            public void UpdateQualityInClass();
        }

        public class AgedBrie : Item, IItem
        {
            public void UpdateQualityInClass()
            {
                Quality = Quality < 50 ? Quality + 1 : Quality;
                Quality = SellIn < 0 && Quality < 50 ? Quality + 1 : Quality;
                SellIn--;
            }
        }
        public class LegendaryItem : Item, IItem
        {
            public void UpdateQualityInClass()
            {
                //None may change the quality of legendary items!
            }
        }
        public class NormalItem : Item, IItem
        {
            public void UpdateQualityInClass()
            {
                Quality = Quality > 0 ? Quality - 1 : Quality;
                Quality = SellIn < 0 && Quality > 0 ? Quality - 1 : Quality;
                SellIn--;

            }
        }
        
        public class TicketItem : Item, IItem
        {
            public void UpdateQualityInClass()
            {
                Quality = SellIn < 0 ? Quality = 0 : Quality;
                Quality = Quality < 50 ? Quality + 1 : Quality;
                Quality = SellIn < 11 && Quality < 50? Quality + 1 : Quality;
                Quality = SellIn < 6 && Quality < 50? Quality + 1 : Quality;
                SellIn--;


            }
        }
        
        public class ConjuredItem : Item, IItem
        {
            public void UpdateQualityInClass()
            {
                Quality = Quality > 2 ? Quality - 2 : Quality = (Quality == 1 ? Quality - 1 : Quality);
                SellIn--;

            }
        }

        public class ItemFactory
        {
            public static Item CreateItem(Item item)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        return new LegendaryItem() { Name = item.Name, Quality = item.Quality, SellIn = item.SellIn };

                    case "Aged Brie":
                        return new AgedBrie(){ Name = item.Name, Quality = item.Quality, SellIn = item.SellIn };
                    
                    case "Backstage passes to a TAFKAL80ETC concert":
                        return new TicketItem() { Name = item.Name, Quality = item.Quality, SellIn = item.SellIn };
                    
                    default:
                        if (item.Name.ToLowerInvariant().Contains("conjured"))
                        {
                            return new ConjuredItem(){ Name = item.Name, Quality = item.Quality, SellIn = item.SellIn };
                        }
                        return new NormalItem(){ Name = item.Name, Quality = item.Quality, SellIn = item.SellIn };
                }   
            }
        }
        
        

        
    }
}