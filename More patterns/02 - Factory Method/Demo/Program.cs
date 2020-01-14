using System;
using Demo.Interfaces;
using Demo.Models;

namespace Demo
{
    static class CleanerFactories
    {
        public static ICleaner CreatePerson() =>
            new Person("Joe", "Janitor", 2M / 60M);

        public static Func<ICleaner> CreatePersonFactory(string a, string b) =>
            () => new Person(a, b, 2M / 60M);

        public static ICleaner CreateRobot() =>
            new Person("Joe", "Janitor", 2M / 60M);
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = "Joe";
            string surname = "Janitor";
            decimal hoursPerSquareMeter = 2M / 60M;

            Hotel hotel = new Hotel(6,
                () => new Person(name, surname,
                                 hoursPerSquareMeter));

            hotel.CleanRooms();
            Console.ReadLine();

        }
    }
}
