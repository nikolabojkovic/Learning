using System;
using System.Linq;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{

    public class CompositeCleaner : ICleaner
    {
        private IEnumerable<ICleaner> Cleaners { get; }

        public CompositeCleaner(IEnumerable<ICleaner> cleaners)
        {
            if (cleaners == null)
                throw new ArgumentNullException(nameof(cleaners));
            if (cleaners.Any(cleaner => cleaner == null))
                throw new ArgumentException("All cleaners must be non-null.");

            this.Cleaners = new List<ICleaner>(cleaners);

            ICleaner fastest =
                this.Cleaners
                    .Select(x => new
                    {
                        Cleaner = x,
                        Estimate = x.EstimateAreaFromHours(10)
                    })
                    .Aggregate(
                        (best, next) =>
                            next.Estimate > best.Estimate
                            ? next
                            : best).Cleaner;
        }

        public void Clean(decimal area)
        {
            decimal groupHpm = this.CalculateHpm2();
            decimal hours = area * groupHpm;

            foreach (ICleaner cleaner in this.Cleaners)
            {
                decimal partialArea = cleaner.EstimateAreaFromHours(hours);
                cleaner.Clean(partialArea);
            }

        }

        private decimal CalculateHpm2() =>
            1 /
            this.Cleaners
                .Select(cleaner => cleaner.EstimateCleaningHours(1))
                .Select(hpm => 1 / hpm)
                .Sum();

        public decimal EstimateAreaFromHours(decimal hours) =>
            hours / this.CalculateHpm2();

        public decimal EstimateCleaningHours(decimal area) =>
            area * this.CalculateHpm2();
    }
}
