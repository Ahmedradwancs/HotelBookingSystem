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
            if (roomNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            }

            RoomNumber = roomNumber;
            Type = type;
            IsAvailable = isAvailable;
            Price = price;
        }

        public override string ToString()
        {
            try
            {
                return $"{RoomNumber} - {Type} - {(IsAvailable ? "Available" : "Not Available")} - ${Price}";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating string representation of Room: " + ex.Message);
            }
        }
    }
}
