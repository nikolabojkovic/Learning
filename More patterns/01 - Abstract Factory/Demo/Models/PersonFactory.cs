using Demo.Interfaces;

namespace Demo.Models
{
    public class PersonFactory : ICleanerFactory
    {
        public ICleaner Create(string name1, string name2)
        {
            return new Person()
            {
                Name = name1,
                Surname = name2
            };
        }
    }
}
