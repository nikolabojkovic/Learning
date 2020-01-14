using System;
using Demo.Interfaces;

namespace Demo.Models
{
    public class Person : ICleaner
    {
        private string Name { get; }
        private string Surname { get; }
        private decimal HoursPerSquareMeter { get; }

        public Person(string name, string surname, decimal hoursPerSquareMeter)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name must be non-empty.");
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("Surname must be non-empty");
            if (hoursPerSquareMeter <= 0)
                throw new ArgumentException("Time to clean must be positive.");

            this.Name = name;
            this.Surname = surname;
            this.HoursPerSquareMeter = hoursPerSquareMeter;

        }

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
            $"{this.Name} {this.Surname} ({1 / this.HoursPerSquareMeter:0} m2/hour)";
    }
}
