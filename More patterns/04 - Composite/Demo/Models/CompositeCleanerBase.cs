using System.Collections.Generic;
using System.Linq;
using Demo.Interfaces;

namespace Demo.Models
{
    public class CompositeCleanerBase<T> : ICleaner
        where T : ICleaner
    {

        private CompositeCleaner ContainedCleaners { get; }

        protected CompositeCleanerBase(IEnumerable<T> containedCleaners)
        {
            this.ContainedCleaners =
            new CompositeCleaner(containedCleaners.Cast<ICleaner>());
        }

        public decimal EstimateCleaningHours(decimal area) =>
            this.ContainedCleaners.EstimateCleaningHours(area);

        public decimal EstimateAreaFromHours(decimal hours) =>
            this.ContainedCleaners.EstimateAreaFromHours(hours);

        public void Clean(decimal area) =>
            this.ContainedCleaners.Clean(area);

    }
}
