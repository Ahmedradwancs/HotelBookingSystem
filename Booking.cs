using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelBookingSystem
{
    public class Booking
    {
        public int BookingID { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate)
        {
            BookingID = bookingID;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        /// <summary>
        /// Calculates the total price of the booking.
        /// </summary>
        public decimal CalculateTotalPrice()
        {
            if (Room == null)
                throw new InvalidOperationException("Room object is null.");

            int stayDuration = GetStayDuration();
            if (stayDuration <= 0)
                throw new InvalidOperationException("Invalid stay duration.");

            return Room.Price * stayDuration;
        }

        /// <summary>
        /// Gets the stay duration of the booking.
        /// </summary>
        private int GetStayDuration()
        {
            if (CheckOutDate < CheckInDate)
                throw new InvalidOperationException("Check-out date cannot be before check-in date.");

            return (CheckOutDate - CheckInDate).Days;
        }

        public override string ToString()
        {
            return $"{BookingID}|{Room.RoomNumber}|{Guest.GuestID}|{CheckInDate:yyyy-MM-dd}|{CheckOutDate:yyyy-MM-dd}|{Guest.Name}|{Room.Price}";
        }

        /// <summary>
        /// Converts a string to a Booking instance.
        /// </summary>
        public static Booking FromString(string bookingString, List<Room> rooms, List<Guest> guests)
        {
            var parts = bookingString.Split('|');
            if (parts.Length == 7)
            {
                int bookingID = int.Parse(parts[0]);
                int roomNumber = int.Parse(parts[1]);
                int guestID = int.Parse(parts[2]);
                DateTime checkInDate = DateTime.Parse(parts[3]);
                DateTime checkOutDate = DateTime.Parse(parts[4]);
                string guestName = parts[5];
                decimal roomPrice = decimal.Parse(parts[6]);

                var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                var guest = guests.FirstOrDefault(g => g.GuestID == guestID);

                if (room != null && guest != null)
                {
                    return new Booking(bookingID, room, guest, checkInDate, checkOutDate);
                }
            }
            return null;
        }

        /// <summary>
        /// Saves the list of bookings to a file.
        /// </summary>
        public static void SaveBookingsToFile(string filePath, List<Booking> bookings)
        {
            try
            {
                var lines = bookings.Select(b => b.ToString()).ToArray();
                File.WriteAllLines(filePath, lines);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error occurred while saving bookings to file: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads bookings from a file.
        /// </summary>
        public static List<Booking> LoadBookingsFromFile(string filePath, List<Guest> guests, List<Room> rooms)
        {
            List<Booking> bookings = new List<Booking>();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        var booking = FromString(line, rooms, guests);
                        if (booking != null)
                        {
                            bookings.Add(booking);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new IOException($"Error occurred while loading bookings from file: {ex.Message}");
            }

            return bookings;
        }
    }
}
