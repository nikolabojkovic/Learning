using Demo.Interfaces;
using System;

namespace Demo.Models
{
    public class Person : ICleaner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        private readonly decimal HoursPerSquareMeter = 2M / 60M;

        public decimal EstimateCleaningHours(decimal area)
        {
            return this.HoursPerSquareMeter * area;
        }

        public void Clean(decimal area)
        {
            Console.WriteLine("{0} {1} cleaning {2} square meters.",
                              this.Name, this.Surname, area);
        }

        public override string ToString() =>
            $"{this.Name} {this.Surname}";
    }
}
