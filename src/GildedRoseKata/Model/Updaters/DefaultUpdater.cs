namespace GildedRoseKata.Model.Updaters
{
    public class DefaultUpdater : IUpdater
    {
        private const int MinQuality = 0;
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            var nextQualityValue = GetNextQuality(item);
            nextQualityValue = IfInitialQualityLessThanMinThenDoNotDecreaseQualityEvenMore(item.Quality, nextQualityValue);
            nextQualityValue = IfInitialQualityMoreThanMinThenDoNotDecreaseQualityLessThanMin(item.Quality, nextQualityValue);
            nextQualityValue = IfInitialQualityLessThanMaxThenDoNotIncreaseQualityMoreThanMax(item.Quality, nextQualityValue);
            nextQualityValue = IfInitialQualityMoreThanMaxThenDoNotIncreaseQualityEvenMore(item.Quality, nextQualityValue);

            item.Quality = nextQualityValue;
            item.SellIn--;
        }

        private int IfInitialQualityLessThanMinThenDoNotDecreaseQualityEvenMore(int initialQuality, int nextQuality) =>
            initialQuality < MinQuality && nextQuality < initialQuality
                ? initialQuality
                : nextQuality;

        private int IfInitialQualityMoreThanMinThenDoNotDecreaseQualityLessThanMin (int initialQuality, int nextQuality) =>
            initialQuality >= MinQuality && nextQuality < MinQuality
                ? MinQuality
                : nextQuality;

        private int IfInitialQualityLessThanMaxThenDoNotIncreaseQualityMoreThanMax(int initialQuality, int nextQuality) =>
            initialQuality <= MaxQuality && nextQuality > MaxQuality
                ? MaxQuality
                : nextQuality;

        private int IfInitialQualityMoreThanMaxThenDoNotIncreaseQualityEvenMore(int initialQuality, int nextQuality) =>
            initialQuality > MaxQuality && initialQuality < nextQuality
                ? initialQuality
                : nextQuality;

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