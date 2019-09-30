namespace GildedRoseKata.Model.Updaters
{
    public class AgedBrieUpdater : DefaultUpdater
    {
        protected override int GetNextQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                return item.Quality + 2;
            }

            return item.Quality + 1;
        }
    }
}