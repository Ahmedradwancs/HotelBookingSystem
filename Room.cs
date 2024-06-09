using System;

namespace HotelBookingSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Family,
        Suite,
    }

    public class Room
    {
        public int RoomNumber { get; }
        public RoomType Type { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }

        public Room(int roomNumber, RoomType type, bool isAvailable, decimal price)
        {
            RoomNumber = roomNumber;
            Type = type;
            IsAvailable = isAvailable;
            Price = price;
        }

        public override string ToString()
        {
            return $"{RoomNumber} - {Type} - {(IsAvailable ? "Available" : "Not Available")} - ${Price}";
        }
    }
}
