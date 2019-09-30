namespace GildedRoseKata.Model.Updaters
{
    public class BackstagePassesUpdater : DefaultUpdater
    {
        protected override int GetNextQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                return item.Quality + 1;
            }

            if (item.SellIn <= 10 && item.SellIn > 5)
            {
                return item.Quality + 2;
            }

            if (item.SellIn <= 5 && item.SellIn > 0)
            {
                return item.Quality + 3;
            }

            return 0;
        }
    }
}