using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_PassItem_NameShouldNotBeChanged()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void UpdateQuality_SellByDatePassed_QualityDegradesTwice()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(18, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_SellByDatePassed_QualityDegradesTwice()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(18, items[0].Quality);
        }
    }
}
