using System.Collections.Generic;
using GildedRoseKata.Model;
using GildedRoseKata.Model.Updaters;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private static readonly Dictionary<string, IUpdater> SpecialUpdaters = new Dictionary<string, IUpdater>
        {
            { Item.AgedBrie, new AgedBrieUpdater() },
            { Item.BackstagePasses, new BackstagePassesUpdater() },
            { Item.Sulfuras, new SulfurasUpdater() },
            { Item.Conjured, new ConjuredUpdater() },
        };

        private static readonly DefaultUpdater DefaultUpdater = new DefaultUpdater();

        ///// <summary>
        ///// Items to manipulate them.
        ///// </summary>
        //private readonly IList<Item> _items;

        public IList<Item> Items { get; }

        /// <summary>
        /// Ctor accepts items to manipulate with
        /// </summary>
        /// <param name="items">Items to manipulate with</param>
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        /// <summary>
        /// Updates all stored items
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                GetUpdater(item.Name).Update(item);
            }
        }

        private IUpdater GetUpdater(string itemName)
        {
            return SpecialUpdaters.ContainsKey(itemName)
                ? SpecialUpdaters[itemName]
                : DefaultUpdater;
        }
    }
}
