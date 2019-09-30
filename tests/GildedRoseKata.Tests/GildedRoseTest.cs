using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRoseKata.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_WhenCalled_ShouldNotChangeNameOfItem()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [TestCase(Items.Sulfuras, -1, 80, ExpectedResult = 80, TestName = "Sulfuras(sellIn=-1, quality=80): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 0, 80, ExpectedResult = 80, TestName = "Sulfuras(sellIn=0, quality=80): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 1, 80, ExpectedResult = 80, TestName = "Sulfuras(sellIn=1, quality=80): legendary item just never changed")]
        [TestCase(Items.Sulfuras, -1, 10, ExpectedResult = 10, TestName = "Sulfuras(sellIn=-1, quality=10): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 0, 10, ExpectedResult = 10, TestName = "Sulfuras(sellIn=0, quality=10): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 1, 10, ExpectedResult = 10, TestName = "Sulfuras(sellIn=1, quality=10): legendary item just never changed")]
        [TestCase(Items.Sulfuras, -1, -1, ExpectedResult = -1, TestName = "Sulfuras(sellIn=-1, quality=-1): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 0, -1, ExpectedResult = -1, TestName = "Sulfuras(sellIn=0, quality=-1): legendary item just never changed")]
        [TestCase(Items.Sulfuras, 1, -1, ExpectedResult = -1, TestName = "Sulfuras(sellIn=1, quality=-1): legendary item just never changed")]

        [TestCase(Items.BackstagePasses, 0, 51, ExpectedResult = 0, TestName = "BackstagePasses(sellIn=0, quality=0): if initially quality more than maximum than it should not be changed")]
        [TestCase(Items.BackstagePasses, 1, 51, ExpectedResult = 51, TestName = "BackstagePasses(sellIn=1, quality=51): if initially quality more than maximum than it should not be changed")]
        [TestCase(Items.BackstagePasses, 5, 50, ExpectedResult = 50, TestName = "BackstagePasses(sellIn=5, quality=50): should not be more than maximum 50")]
        [TestCase(Items.BackstagePasses, 10, 50, ExpectedResult = 50, TestName = "BackstagePasses(sellIn=10, quality=50): should not be more than maximum 50")]
        [TestCase(Items.BackstagePasses, 11, 50, ExpectedResult = 50, TestName = "BackstagePasses(sellIn=11, quality=50): should not be more than maximum 50")]
        [TestCase(Items.BackstagePasses, 11, 0, ExpectedResult = 1, TestName = "BackstagePasses(sellIn=11, quality=0): sellIn > 10 then quality should increased by 1")]
        [TestCase(Items.BackstagePasses, 10, 0, ExpectedResult = 2, TestName = "BackstagePasses(sellIn=10, quality=0): sellIn is in 6..10 then quality should increased by 2")]
        [TestCase(Items.BackstagePasses, 6, 0, ExpectedResult = 2, TestName = "BackstagePasses(sellIn=6, quality=0): sellIn is in 6..10 then quality should increased by 2")]
        [TestCase(Items.BackstagePasses, 5, 0, ExpectedResult = 3, TestName = "BackstagePasses(sellIn=5, quality=0): sellIn is in 1..5  then quality should increased by 3")]
        [TestCase(Items.BackstagePasses, 1, 0, ExpectedResult = 3, TestName = "BackstagePasses(sellIn=1, quality=0): sellIn is in 1..5  then quality should increased by 3")]
        [TestCase(Items.BackstagePasses, 0, 10, ExpectedResult = 0, TestName = "BackstagePasses(sellIn=0, quality=10): sellIn is 0 then quality should dropped to 0")]
        [TestCase(Items.BackstagePasses, 0, -10, ExpectedResult = 0, TestName = "BackstagePasses(sellIn=0, quality=-10): sellIn is 0 then quality should dropped to 0")]
        [TestCase(Items.BackstagePasses, -1, 10, ExpectedResult = 0, TestName = "BackstagePasses(sellIn=-1, quality=10): sellIn is 0 then quality should dropped to 0")]
        [TestCase(Items.BackstagePasses, -1, -10, ExpectedResult = 0, TestName = "BackstagePasses(sellIn=-1, quality=-10): sellIn is 0 then quality should dropped to 0")]

        [TestCase(Items.AgedBrie, -1, 51, ExpectedResult = 51, TestName = "AgedBrie(sellIn=-1, quality=51): if initially quality more than maximum than it should not be changed at all")]
        [TestCase(Items.AgedBrie, 0, 51, ExpectedResult = 51, TestName = "AgedBrie(sellIn=0, quality=51): if initially quality more than maximum than it should not be changed at all")]
        [TestCase(Items.AgedBrie, 1, 51, ExpectedResult = 51, TestName = "AgedBrie(sellIn=1, quality=51): if initially quality more than maximum than it should not be changed at all")]
        [TestCase(Items.AgedBrie, 0, 50, ExpectedResult = 50, TestName = "AgedBrie(sellIn=0, quality=50): should not be more than maximum 50")]
        [TestCase(Items.AgedBrie, 1, 50, ExpectedResult = 50, TestName = "AgedBrie(sellIn=1, quality=50): should not be more than maximum 50")]
        [TestCase(Items.AgedBrie, 0, 49, ExpectedResult = 50, TestName = "AgedBrie(sellIn=0, quality=49): should not be more than maximum 50")]
        [TestCase(Items.AgedBrie, 1, 49, ExpectedResult = 50, TestName = "AgedBrie(sellIn=1, quality=49): should not be more than maximum 50")]
        [TestCase(Items.AgedBrie, 1, 10, ExpectedResult = 11, TestName = "AgedBrie(sellIn=1, quality=10): sellIn > 0 then quality should increased by 1")]
        [TestCase(Items.AgedBrie, 1, -2, ExpectedResult = -1, TestName = "AgedBrie(sellIn=1, quality=-2): sellIn > 0 then quality should increased by 1")]
        [TestCase(Items.AgedBrie, 1, -1, ExpectedResult = 0, TestName = "AgedBrie(sellIn=1, quality=-1): sellIn > 0 then quality should increased by 1")]
        [TestCase(Items.AgedBrie, 0, 10, ExpectedResult = 12, TestName = "AgedBrie(sellIn=0, quality=10): sellIn <= 0 then quality should increased by 2")]
        [TestCase(Items.AgedBrie, -1, 10, ExpectedResult = 12, TestName = "AgedBrie(sellIn=-1, quality=10): sellIn <= 0 then quality should increased by 2")]
        [TestCase(Items.AgedBrie, 0, -2, ExpectedResult = 0, TestName = "AgedBrie(sellIn=0, quality=-2): sellIn > 0 then quality should increased by 2")]
        [TestCase(Items.AgedBrie, 0, -1, ExpectedResult = 1, TestName = "AgedBrie(sellIn=0, quality=-1): sellIn > 0 then quality should increased by 2")]

        [TestCase(Items.Elixir, 1, 10, ExpectedResult = 9, TestName = "Elixir(sellIn=1, quality=10): sellIn > 0 then quality should degrade by 1")]
        [TestCase(Items.Elixir, 0, 10, ExpectedResult = 8, TestName = "Elixir(sellIn=0, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase(Items.Elixir, -1, 10, ExpectedResult = 8, TestName = "Elixir(sellIn=-1, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase(Items.Elixir, 0, 0, ExpectedResult = 0, TestName = "Elixir(sellIn=0, quality=0): quality can't degrade below zero")]
        [TestCase(Items.Elixir, 0, 1, ExpectedResult = 0, TestName = "Elixir(sellIn=0, quality=1): quality can't degrade below zero")]
        [TestCase(Items.Elixir, 1, 0, ExpectedResult = 0, TestName = "Elixir(sellIn=1, quality=0): quality can't degrade below zero")]
        [TestCase(Items.Elixir, -1, -1, ExpectedResult = -1, TestName = "Elixir(sellIn=-1, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Elixir, 0, -1, ExpectedResult = -1, TestName = "Elixir(sellIn=0, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Elixir, 1, -1, ExpectedResult = -1, TestName = "Elixir(sellIn=1, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Elixir, 1, 52, ExpectedResult = 51, TestName = "Elixir(sellIn=1, quality=52): quality more than max quality should degrade normally")]
        [TestCase(Items.Elixir, 0, 52, ExpectedResult = 50, TestName = "Elixir(sellIn=0, quality=52): quality more than max quality should degrade normally")]
        [TestCase(Items.Elixir, 0, 51, ExpectedResult = 49, TestName = "Elixir(sellIn=0, quality=51): quality more than max quality should degrade normally")]

        [TestCase(Items.Dexterity, 1, 10, ExpectedResult = 9, TestName = "Dexterity(sellIn=1, quality=10): sellIn > 0 then quality should degrade by 1")]
        [TestCase(Items.Dexterity, 0, 10, ExpectedResult = 8, TestName = "Dexterity(sellIn=0, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase(Items.Dexterity, -1, 10, ExpectedResult = 8, TestName = "Dexterity(sellIn=-1, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase(Items.Dexterity, 0, 0, ExpectedResult = 0, TestName = "Dexterity(sellIn=0, quality=0): quality can't degrade below zero")]
        [TestCase(Items.Dexterity, 0, 1, ExpectedResult = 0, TestName = "Dexterity(sellIn=0, quality=1): quality can't degrade below zero")]
        [TestCase(Items.Dexterity, 1, 0, ExpectedResult = 0, TestName = "Dexterity(sellIn=1, quality=0): quality can't degrade below zero")]
        [TestCase(Items.Dexterity, -1, -1, ExpectedResult = -1, TestName = "Dexterity(sellIn=-1, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Dexterity, 0, -1, ExpectedResult = -1, TestName = "Dexterity(sellIn=0, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Dexterity, 1, -1, ExpectedResult = -1, TestName = "Dexterity(sellIn=1, quality=-1): quality below zero should be the same after update")]
        [TestCase(Items.Dexterity, 1, 52, ExpectedResult = 51, TestName = "Dexterity(sellIn=1, quality=52): quality more than max quality should degrade normally")]
        [TestCase(Items.Dexterity, 0, 52, ExpectedResult = 50, TestName = "Dexterity(sellIn=0, quality=52): quality more than max quality should degrade normally")]
        [TestCase(Items.Dexterity, 0, 51, ExpectedResult = 49, TestName = "Dexterity(sellIn=0, quality=51): quality more than max quality should degrade normally")]

        [TestCase("foo", 1, 10, ExpectedResult = 9, TestName= "Regular Item(sellIn=1, quality=10): sellIn > 0 then quality should degrade by 1")]
        [TestCase("foo", 0, 10, ExpectedResult = 8, TestName = "Regular Item(sellIn=0, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase("foo", -1, 10, ExpectedResult = 8, TestName = "Regular Item(sellIn=-1, quality=10): sellIn <= 0 then quality should degrade by 2")]
        [TestCase("foo", 0, 0, ExpectedResult = 0, TestName = "Regular Item(sellIn=0, quality=0): quality can't degrade below zero")]
        [TestCase("foo", 0, 1, ExpectedResult = 0, TestName = "Regular Item(sellIn=0, quality=1): quality can't degrade below zero")]
        [TestCase("foo", 1, 0, ExpectedResult = 0, TestName = "Regular Item(sellIn=1, quality=0): quality can't degrade below zero")]
        [TestCase("foo", -1, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=-1, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 0, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=0, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 1, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=1, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 1, 52, ExpectedResult = 51, TestName = "Regular Item(sellIn=1, quality=52): quality more than max quality should degrade normally")]
        [TestCase("foo", 0, 52, ExpectedResult = 50, TestName = "Regular Item(sellIn=0, quality=52): quality more than max quality should degrade normally")]
        [TestCase("foo", 0, 51, ExpectedResult = 49, TestName = "Regular Item(sellIn=0, quality=51): quality more than max quality should degrade normally")]
        public int UpdateQuality_Item_QualityShouldBeChangedProperly(string itemName, int sellIn, int initialQuality)
        {
            var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = initialQuality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            return items[0].Quality;
        }
    }
}
