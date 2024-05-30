using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Room
    {
        public int RoomNumber { get; private set; }
        public string RoomType { get; private set; }
        public decimal Price { get; private set; }
        public bool IsAvailable { get; private set; }

        public Room(int roomNumber, string roomType, decimal price, bool isAvailable)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            Price = price;
            IsAvailable = isAvailable;
        }

        public void ToggleAvailability()
        {
            IsAvailable = !IsAvailable;
        }
    }

}
