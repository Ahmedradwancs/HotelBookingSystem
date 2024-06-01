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
        public int RoomNumber { get; private set; }
        public RoomType Type { get; private set; }
        public bool IsAvailable { get; private set; }
        public decimal Price { get; private set; }
        public int Capacity { get; private set; }

        public Room(int roomNumber, RoomType type, bool isAvailable, decimal price, int capacity)
        {
            RoomNumber = roomNumber;
            Type = type;
            IsAvailable = isAvailable;
            Price = price;
            Capacity = capacity;
        }

        public Room(int roomNumber, string roomType, decimal price, bool isAvailable)
        {
            RoomNumber = roomNumber;
            SetRoomType(roomType); // Set RoomType instead of RoomType property directly
            Price = price;
            IsAvailable = isAvailable;
        }

        public int GetRoomNumber()
        {
            return RoomNumber;
        }

        public void SetRoomNumber(int roomNumber)
        {
            RoomNumber = roomNumber;
        }

        public RoomType GetRoomType()
        {
            return Type;
        }

        public void SetRoomType(RoomType type)
        {
            Type = type;
        }

        public void SetRoomType(string roomType)
        {
            if (!Enum.TryParse(roomType, out RoomType type))
            {
                throw new ArgumentException("Invalid room type.");
            }
            Type = type;
        }

        public bool GetAvailability()
        {
            return IsAvailable;
        }

        public void SetAvailability(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public void SetPrice(decimal price)
        {
            Price = price;
        }

        public int GetCapacity()
        {
            return Capacity;
        }

        public void SetCapacity(int capacity)
        {
            Capacity = capacity;
        }

        public void ToggleAvailability()
        {
            IsAvailable = !IsAvailable;
        }
    }
}