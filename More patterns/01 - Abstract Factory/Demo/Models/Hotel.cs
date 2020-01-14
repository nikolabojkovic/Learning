using Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Models
{
    public class Hotel
    {
        public ICleanerFactory CleanerFactory { get; set; }

        private IEnumerable<Room> Rooms { get; }

        public Hotel(int roomsCount)
        {
            this.Rooms =
                Enumerable
                    .Range(1, roomsCount)
                    .Select(roomNo => new Room()
                    {
                        Area = 6 + ((1731 + roomNo*723)%329)/(decimal) 10,
                        Label = roomNo.ToString()
                    })
                    .ToList();
        }

        public void CleanRooms()
        {

            ICleaner cleaner = this.CleanerFactory
                .Create("Shiny Co.", "Vacubot 9400S(TM)");

            foreach (Room room in this.Rooms)
                this.Clean(room, cleaner);

        }

        private void Clean(Room room, ICleaner cleaner)
        {
            decimal hours = cleaner.EstimateCleaningHours(room.Area);
            Console.WriteLine("\n{0} cleans {1} for {2:0.0} hours.",
                              cleaner, room, hours);
            cleaner.Clean(room.Area);
        }
    }
}
