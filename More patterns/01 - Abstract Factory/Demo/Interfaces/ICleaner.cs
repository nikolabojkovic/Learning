namespace Demo.Interfaces
{
    public interface ICleaner
    {
        decimal EstimateCleaningHours(decimal area);
        void Clean(decimal area);
    }
}
