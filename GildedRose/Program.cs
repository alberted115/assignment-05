using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GildedRose.ItemUpdates;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items { get; set; }


        static void Main(string[] args)
        {
            /*System.Console.WriteLine("OMGHAI!");

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
            }*/

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        UpdateItemLegendary.UpdateItemQuality(item);
                        break;
                    
                    case "Aged Brie":
                        UpdateItemBrie.UpdateItemQuality(item);
                        break;
                    
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateItemTickets.UpdateItemQuality(item);
                        break;
                    
                    default:
                        if (item.Name.ToLowerInvariant().Contains("conjured"))
                        {
                            UpdateItemConjured.UpdateItemQuality(item);
                            break;
                        }
                        
                        UpdateItemNormal.UpdateItemQuality(item);
                        break;
                }   
            }
        }

        public class Item
        {
            public string Name { get; set; }

            public int SellIn { get; set; }

            public int Quality { get; set; }
        }

    }
}