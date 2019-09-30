namespace GildedRoseKata.Model.Updaters
{
    public class DefaultUpdater : IUpdater
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            var nextQualityValue = GetNextQuality(item);

            // if current quality less than min, then do not allow it to be decreased even more
            if (item.Quality < MinQuality && nextQualityValue < item.Quality)
            {
                nextQualityValue = item.Quality;
            }

            // if current quality more than min, then next value should not be less than min
            if (item.Quality >= MinQuality && nextQualityValue < MinQuality)
            {
                nextQualityValue = MinQuality;
            }

            // if current quality less than max, then next value should not be more than max
            if (item.Quality <= MaxQuality && nextQualityValue > MaxQuality)
            {
                nextQualityValue = MaxQuality;
            }

            // if current quality more than max, then next value should not be increased even more
            if (item.Quality > MaxQuality && item.Quality < nextQualityValue)
            {
                nextQualityValue = item.Quality;
            }

            item.Quality = nextQualityValue;
            item.SellIn--;
        }

        protected virtual int GetNextQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                return item.Quality - 2;
            }

            return item.Quality - 1;
        }
    }
}