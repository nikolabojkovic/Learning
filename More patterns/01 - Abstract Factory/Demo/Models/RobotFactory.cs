using Demo.Interfaces;
using System.Collections.Generic;

namespace Demo.Models
{
    public class RobotFactory : ICleanerFactory
    {
        public SpatialPlanner Planner { get; set; }

        public IDictionary<string, Producer> ProducerNameToProducer { get; set; }

        public ICleaner Create(string name1, string name2)
        {
            return new Robot()
            {
                Producer = this.GetProducer(name1),
                Model = name2,
                Planner = this.Planner
            };
        }

        private Producer GetProducer(string name) =>
            this.ProducerNameToProducer[name];
    }
}
