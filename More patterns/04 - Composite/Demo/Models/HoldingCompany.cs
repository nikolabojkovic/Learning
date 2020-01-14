using System;
using System.Collections.Generic;
using Demo.Interfaces;

namespace Demo.Models
{

    class HoldingCompany : CompositeCleanerBase<Company>
    {
        private string Name { get; }

        public HoldingCompany(string name, IEnumerable<Company> employees) :
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
