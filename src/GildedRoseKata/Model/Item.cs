namespace GildedRoseKata.Model
{
    public class Item
    {
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Elixir = "Elixir of the Mongoose";
        public const string AgedBrie = "Aged Brie";
        public const string Dexterity = "+5 Dexterity Vest";
        public const string Conjured = "Conjured Mana Cake";

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public override string ToString() => $"{Name}, {SellIn}, {Quality}";
    }
}
