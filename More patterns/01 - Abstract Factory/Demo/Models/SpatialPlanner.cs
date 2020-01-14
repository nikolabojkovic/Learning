namespace Demo.Models
{
    public class SpatialPlanner
    {
        private readonly decimal PreparationHours = .1M;
        private readonly decimal HoursPerSquareMeter = 1M / 250M;

        public decimal EstimatePlanningHoursFor(decimal area) =>
            this.PreparationHours + this.HoursPerSquareMeter * area;
    }
}
