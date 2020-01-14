using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{
    public class Company : CompositeCleanerBase<Person>
    {

        private string Name { get; }

        public Company(string name, IEnumerable<Person> employees) :
            base(employees)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Company name must be non-empty.");
            this.Name = name;
        }

        public override string ToString() =>
            this.Name;

    }
}
