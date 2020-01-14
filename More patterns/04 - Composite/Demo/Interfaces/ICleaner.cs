namespace Demo.Interfaces
{
    public interface ICleaner
    {
        decimal EstimateCleaningHours(decimal area);
        decimal EstimateAreaFromHours(decimal hours);
        void Clean(decimal area);
    }
}
