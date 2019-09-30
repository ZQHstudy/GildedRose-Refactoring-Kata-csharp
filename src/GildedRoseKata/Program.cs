using System;
using System.Collections.Generic;
using GildedRoseKata.Model;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run(new GildedRose(new List<Item> {
                new Item {Name = Item.Dexterity, SellIn = 10, Quality = 20},
                new Item {Name = Item.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = Item.Elixir, SellIn = 5, Quality = 7},
                new Item {Name = Item.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = Item.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = Item.BackstagePasses, SellIn = 15, Quality = 20},
                new Item {Name = Item.BackstagePasses, SellIn = 10, Quality = 49},
                new Item {Name = Item.BackstagePasses, SellIn = 5, Quality = 49},
                new Item {Name = Item.Conjured, SellIn = 3, Quality = 6}
            }));
        }

        public static void Run(GildedRose gildedRose)
        {
            Console.WriteLine("OMGHAI!");

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine($"-------- day {i} --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in gildedRose.Items)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine(string.Empty);
                gildedRose.UpdateQuality();
            }
        }
    }
}
