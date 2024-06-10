using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelBookingSystem
{
    /// <summary>
    /// Represents a booking made in the hotel.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets the booking ID.
        /// </summary>
        public int BookingID { get; private set; }

        /// <summary>
        /// Gets the check-in date for the booking.
        /// </summary>
        public DateTime CheckInDate { get; private set; }

        /// <summary>
        /// Gets the check-out date for the booking.
        /// </summary>
        public DateTime CheckOutDate { get; private set; }

        /// <summary>
        /// Gets the guest associated with the booking.
        /// </summary>
        public Guest Guest { get; private set; }

        /// <summary>
        /// Gets the room associated with the booking.
        /// </summary>
        public Room Room { get; private set; }

        /// <summary>
        /// Gets the name of the guest.
        /// </summary>
        public string GuestName { get; private set; }

        /// <summary>
        /// Gets the price of the room.
        /// </summary>
        public decimal RoomPrice { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        /// <param name="bookingID">The booking ID.</param>
        /// <param name="room">The room associated with the booking.</param>
        /// <param name="guest">The guest associated with the booking.</param>
        /// <param name="checkInDate">The check-in date for the booking.</param>
        /// <param name="checkOutDate">The check-out date for the booking.</param>
        /// <param name="guestName">The name of the guest.</param>
        /// <param name="roomPrice">The price of the room.</param>
        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate, string guestName, decimal roomPrice)
        {
            BookingID = bookingID;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            GuestName = guestName;
            RoomPrice = roomPrice;
        }

        /// <summary>
        /// Calculates the total price of the booking.
        /// </summary>
        /// <returns>The total price of the booking.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the room is null or the stay duration is invalid.</exception>
        public decimal CalculateTotalPrice()
        {
            try
            {
                if (Room == null)
                    throw new InvalidOperationException("Room object is null.");

                int stayDuration = GetStayDuration();
                if (stayDuration <= 0)
                    throw new InvalidOperationException("Invalid stay duration.");

                return Room.Price * stayDuration;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error calculating total price: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets the stay duration of the booking.
        /// </summary>
        /// <returns>The stay duration in days.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the check-out date is before the check-in date.</exception>
        private int GetStayDuration()
        {
            try
            {
                if (CheckOutDate < CheckInDate)
                    throw new InvalidOperationException("Check-out date cannot be before check-in date.");

                return (CheckOutDate - CheckInDate).Days;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error calculating stay duration: " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a string that represents the current booking.
        /// </summary>
        /// <returns>A string representation of the booking.</returns>
        public override string ToString()
        {
            return $"{BookingID}|{Room.RoomNumber}|{Guest.GuestID}|{CheckInDate:yyyy-MM-dd}|{CheckOutDate:yyyy-MM-dd}|{GuestName}|{RoomPrice}";
        }

        /// <summary>
        /// Creates a <see cref="Booking"/> object from a string representation.
        /// </summary>
        /// <param name="bookingString">The string representation of the booking.</param>
        /// <param name="rooms">The list of rooms.</param>
        /// <param name="guests">The list of guests.</param>
        /// <returns>A <see cref="Booking"/> object or null if parsing fails.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there is an error parsing the booking string.</exception>
        public static Booking FromString(string bookingString, List<Room> rooms, List<Guest> guests)
        {
            try
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
                        return new Booking(bookingID, room, guest, checkInDate, checkOutDate, guestName, roomPrice);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error parsing booking from string: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves the list of bookings to a file.
        /// </summary>
        /// <param name="filePath">The file path where the bookings will be saved.</param>
        /// <param name="bookings">The list of bookings to save.</param>
        /// <exception cref="IOException">Thrown when there is an error writing to the file.</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs while saving to the file.</exception>
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
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred while saving bookings to file: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads bookings from a file.
        /// </summary>
        /// <param name="filePath">The file path from which to load the bookings.</param>
        /// <param name="guests">The list of guests.</param>
        /// <param name="rooms">The list of rooms.</param>
        /// <returns>A list of loaded bookings.</returns>
        /// <exception cref="IOException">Thrown when there is an error reading the file.</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs while loading from the file.</exception>
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
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error occurred while loading bookings from file: {ex.Message}");
            }

            return bookings;
        }
    }
}
