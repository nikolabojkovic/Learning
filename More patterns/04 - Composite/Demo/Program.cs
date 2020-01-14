using System;
using System.Collections.Generic;
using Demo.Interfaces;
using Demo.Models;

namespace Demo
{
    class Program
    {

        static Company CleanCo =>
            new Company(
                "Clean Co.",
                new[]
                {
                    new Person("Joe", "Janitor", 2M / 60M),
                    new Person("Jack", "Janitor", 7M / 60M),
                    new Person("Jill", "Janitor", 1.3M / 60M)
                });

        static Company FastCo =>
            new Company(
                "Fast Co.",
                new[]
                {
                    new Person("Jim", "Runner", 16M / 60M),
                    new Person("Jane", "Runner", 21M / 60M),
                });

        static ICleaner CleanerFactory() =>
            new HoldingCompany(
                "There can be only one Co.",
                new[] { CleanCo, FastCo });

        static void Main(string[] args)
        {
            Hotel hotel = new Hotel(6, CleanerFactory);

            hotel.CleanRooms();

            Console.ReadLine();
        }
    }
}
