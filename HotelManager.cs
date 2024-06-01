using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class HotelManager
    {
        public List<Room> Rooms { get; private set; }
        public List<Guest> Guests { get; private set; }
        public List<Booking> Bookings { get; private set; }

        private string name;
        private string location;
        private int totalRooms;

        public HotelManager(string name, string location, int totalRooms)
        {
            this.name = name;
            this.location = location;
            this.totalRooms = totalRooms;
            Rooms = new List<Room>();
            Guests = new List<Guest>();
            Bookings = new List<Booking>();
        }

        public HotelManager()
        {
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string location)
        {
            this.location = location;
        }

        public int GetTotalRooms()
        {
            return totalRooms;
        }

        public void SetTotalRooms(int totalRooms)
        {
            this.totalRooms = totalRooms;
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void RemoveRoom(int roomNumber)
        {
            var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (room != null)
            {
                Rooms.Remove(room);
            }
        }

        public void AddGuest(Guest guest)
        {
            Guests.Add(guest);
        }

        public void RemoveGuest(string name)
        {
            var guest = Guests.FirstOrDefault(g => g.GetName() == name);
            if (guest != null)
            {
                Guests.Remove(guest);
            }
        }

        public void MakeBooking(Booking booking)
        {
            Bookings.Add(booking);
            booking.Room.SetAvailability(false);
        }

        public void CancelBooking(int bookingID)
        {
            var booking = Bookings.FirstOrDefault(b => b.GetBookingID() == bookingID);
            if (booking != null)
            {
                booking.Room.SetAvailability(true);
                Bookings.Remove(booking);
            }
        }

        public List<Room> GetAvailableRooms()
        {
            return Rooms.Where(r => r.IsAvailable).ToList();
        }
    }
}