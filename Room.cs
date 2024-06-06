using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite,
        Other
    }

    public class Room
    {
        public int RoomNumber { get; }
        public RoomType Type { get; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; }


        // Constructor with default prices for each room type
        public Room(int roomNumber, RoomType type, bool isAvailable)
        {
            RoomNumber = roomNumber;
            Type = type;
            IsAvailable = isAvailable;
            Price = GetDefaultPrice(type);
        }

        // Method to get the default price based on room type
        private decimal GetDefaultPrice(RoomType type)
        {
            switch (type)
            {
                case RoomType.Single:
                    return 100; // Example price for Single room
                case RoomType.Double:
                    return 150; // Example price for Double room
                case RoomType.Suite:
                    return 250; // Example price for Suite room
                default:
                    return 0; // Default price
            }
        }



        // Method to toggle room availability
        public void ToggleAvailability()
        {
            IsAvailable = !IsAvailable;
        }


        // Override ToString method for easier room information display
        public override string ToString()
        {
            return $"Room {RoomNumber} - {Type} - ${Price}";
        }
    }
}