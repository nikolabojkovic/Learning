using Demo.Interfaces;
using System;

namespace Demo.Models
{
    public class Robot : ICleaner
    {
        public Producer Producer { get; set; }
        public string Model { get; set; }
        private readonly decimal HoursPerSquareMeter = 1M / 92M;
        public SpatialPlanner Planner { get; set; }

        public decimal EstimateCleaningHours(decimal area)
        {
            decimal planningHours = this.Planner.EstimatePlanningHoursFor(area);
            decimal workingHours = this.HoursPerSquareMeter * area;
            return planningHours + workingHours;
        }

        public void Clean(decimal area)
        {
            Console.WriteLine("{0} cleaning {1} square meters.",
                              this.Model, area);
        }

        public override string ToString() =>
            $"{this.Producer} {this.Model}";
    }
}
