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

        public HotelManager()
        {
            Rooms = new List<Room>();
            Guests = new List<Guest>();
            Bookings = new List<Booking>();
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

        public void RemoveGuest(int guestID)
        {
            var guest = Guests.FirstOrDefault(g => g.GuestID == guestID);
            if (guest != null)
            {
                Guests.Remove(guest);
            }
        }

        public void MakeBooking(Booking booking)
        {
            Bookings.Add(booking);
            booking.Room.ToggleAvailability();
        }

        public void CancelBooking(int bookingID)
        {
            var booking = Bookings.FirstOrDefault(b => b.BookingID == bookingID);
            if (booking != null)
            {
                booking.Room.ToggleAvailability();
                Bookings.Remove(booking);
            }
        }

        public List<Room> GetAvailableRooms()
        {
            return Rooms.Where(r => r.IsAvailable).ToList();
        }
    }

}
