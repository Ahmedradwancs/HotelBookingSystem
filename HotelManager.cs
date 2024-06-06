using System;
using System.Collections.Generic;
using System.IO;
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
            InitializeRooms();
            LoadGuestsFromFile("guests.txt");
        }

        // Initialize rooms
        private void InitializeRooms()
        {
            Rooms.Add(new Room(101, RoomType.Single, true));
            Rooms.Add(new Room(102, RoomType.Single, true));
            Rooms.Add(new Room(201, RoomType.Double, true));
            Rooms.Add(new Room(202, RoomType.Double, true));
            Rooms.Add(new Room(301, RoomType.Suite, true));
        }

        // Get available rooms
        public IEnumerable<Room> GetAvailableRooms()
        {
            return Rooms.Where(room => room.IsAvailable);
        }

        // Get guests from guests.
        // Inside HotelManager class
        public void LoadGuestsFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var guest = new Guest(int.Parse(parts[0]), parts[1], parts[2], parts[3]);
                                Guests.Add(guest);
                            }
                        }
                    }
                    Console.WriteLine("Guests loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No existing guests file found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading guests from file: {ex.Message}");
            }
        }


        // Make booking
        public void MakeBooking(Booking booking)
        {
            Bookings.Add(booking);
            booking.Room.ToggleAvailability(); // Mark the room as unavailable
        }

        // Cancel booking
        public void CancelBooking(int bookingId)
        {
            var booking = Bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking != null)
            {
                Bookings.Remove(booking);
                booking.Room.ToggleAvailability(); // Mark the room as available
            }
        }

    }
}