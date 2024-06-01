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
        public object RoomType { get; internal set; }

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
            RoomType = roomType;
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

        public RoomType Type1 { get => Type; set => Type = value; }

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