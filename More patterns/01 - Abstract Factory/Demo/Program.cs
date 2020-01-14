using System;
using System.Collections.Generic;
using Demo.Interfaces;
using Demo.Models;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            SpatialPlanner spatialPlanner = new SpatialPlanner();

            IDictionary<string, Producer> producerNameToProducer =
                new Dictionary<string, Producer>();

            Producer shinyCo = new Producer()
            {
                Name = "Shiny Co."
            };

            producerNameToProducer[shinyCo.Name] = shinyCo;

            ICleanerFactory cleanerFactory = new RobotFactory()
            {
                Planner = spatialPlanner,
                ProducerNameToProducer = producerNameToProducer
            };

            Hotel hotel = new Hotel(6)
            {
                CleanerFactory = cleanerFactory
            };

            hotel.CleanRooms();
            Console.ReadLine();
        }
    }
}
