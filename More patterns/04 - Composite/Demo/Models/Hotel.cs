using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Interfaces;

namespace Demo.Models
{
    public class Hotel
    {

        private IEnumerable<Room> Rooms { get; }

        private Func<ICleaner> CleanerFactory { get; }

        public Hotel(int roomsCount, Func<ICleaner> cleanerFactory)
        {
            if (roomsCount < 1)
                throw new ArgumentException("Hotel must contain at least one room.");
            if (cleanerFactory == null)
                throw new ArgumentNullException(nameof(cleanerFactory));

            this.Rooms =
                Enumerable
                    .Range(1, roomsCount)
                    .Select(roomNo => new Room()
                    {
                        Area = 6 + ((1731 + roomNo * 723) % 329) / (decimal)10,
                        Label = roomNo.ToString()
                    })
                    .ToList();

            this.CleanerFactory = cleanerFactory;
        }

        public void CleanRooms()
        {
            ICleaner cleaner = this.CleanerFactory();

            foreach (Room room in this.Rooms)
            {
                this.Clean(room, cleaner);
            }
            
        }

        private void Clean(Room room, ICleaner cleaner)
        {
            decimal hours = cleaner.EstimateCleaningHours(room.Area);
            Console.WriteLine("\n{0} cleaning {1:0.0} hours.",
                              room, hours);
            cleaner.Clean(room.Area);
        }
    }
}
