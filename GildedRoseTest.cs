using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace csharp
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

        [TestCase("foo", 1, 10, ExpectedResult = 9, TestName= "Regular Item(sellIn=1, quality=10): quality should degrade by 1")]
        [TestCase("foo", 0, 10, ExpectedResult = 8, TestName = "Regular Item(sellIn=0, quality=10): quality should degrade by 2")]
        [TestCase("foo", -1, 10, ExpectedResult = 8, TestName = "Regular Item(sellIn=-1, quality=10): quality should degrade by 2")]
        [TestCase("foo", 0, 0, ExpectedResult = 0, TestName = "Regular Item(sellIn=0, quality=0): quality can't degrade below zero")]
        [TestCase("foo", 0, 1, ExpectedResult = 0, TestName = "Regular Item(sellIn=0, quality=1): quality can't degrade below zero")]
        [TestCase("foo", 1, 0, ExpectedResult = 0, TestName = "Regular Item(sellIn=1, quality=0): quality can't degrade below zero")]
        [TestCase("foo", -1, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=-1, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 0, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=0, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 1, -1, ExpectedResult = -1, TestName = "Regular Item(sellIn=1, quality=-1): quality below zero should be the same after update")]
        [TestCase("foo", 1, 52, ExpectedResult = 51, TestName = "Regular Item(sellIn=1, quality=52): quality more than max quality should degrade normally")]
        [TestCase("foo", 0, 52, ExpectedResult = 50, TestName = "Regular Item(sellIn=0, quality=52): quality more than max quality should degrade normally")]
        [TestCase("foo", 0, 51, ExpectedResult = 49, TestName = "Regular Item(sellIn=0, quality=51): quality more than max quality should degrade normally")]
        public int UpdateQuality_RegularItem_QualityDegrades(string itemName, int sellIn, int initialQuality)
        {
            var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = initialQuality } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            return items[0].Quality;
        }
    }
}
