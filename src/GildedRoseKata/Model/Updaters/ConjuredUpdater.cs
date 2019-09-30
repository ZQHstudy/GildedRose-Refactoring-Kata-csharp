namespace GildedRoseKata.Model.Updaters
{
    public class ConjuredUpdater : DefaultUpdater
    {
        protected override int GetNextQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                return item.Quality - 4;
            }

            return item.Quality - 2;
        }
    }
}