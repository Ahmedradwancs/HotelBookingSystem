using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelBookingSystem
{
    /// <summary>
    /// Manages the operations of the hotel, including rooms, guests, and bookings.
    /// </summary>
    public class HotelManager
    {
        /// <summary>
        /// Gets the list of rooms in the hotel.
        /// </summary>
        public List<Room> Rooms { get; private set; }

        /// <summary>
        /// Gets the list of guests in the hotel.
        /// </summary>
        public List<Guest> Guests { get; private set; }

        /// <summary>
        /// Gets the list of bookings in the hotel.
        /// </summary>
        public List<Booking> Bookings { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelManager"/> class.
        /// </summary>
        public HotelManager()
        {
            Rooms = new List<Room>();
            Guests = new List<Guest>();
            Bookings = new List<Booking>();

            try
            {
                LoadRoomsFromFile("rooms.txt");
                LoadGuestsFromFile("guests.txt");
                LoadRoomAvailabilityFromFile("room_availability.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing hotel manager: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads rooms from a file.
        /// </summary>
        /// <param name="filePath">The path to the file containing room data.</param>
        private void LoadRoomsFromFile(string filePath)
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
                                int roomNumber = int.Parse(parts[0]);
                                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), parts[1]);
                                bool isAvailable = bool.Parse(parts[2]);
                                decimal price = decimal.Parse(parts[3]);

                                var room = new Room(roomNumber, roomType, isAvailable, price);
                                Rooms.Add(room);
                            }
                        }
                    }
                    Console.WriteLine("Rooms loaded successfully.");
                }
                else
                {
                    Console.WriteLine("No existing rooms file found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading rooms from file: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the list of available rooms.
        /// </summary>
        /// <returns>A list of available rooms.</returns>
        public List<Room> GetAvailableRooms()
        {
            try
            {
                return Rooms.Where(room => room.IsAvailable).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting available rooms: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Loads guests from a file.
        /// </summary>
        /// <param name="filePath">The path to the file containing guest data.</param>
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

        /// <summary>
        /// Makes a booking and marks the room as unavailable.
        /// </summary>
        /// <param name="booking">The booking to be made.</param>
        public void MakeBooking(Booking booking)
        {
            try
            {
                Bookings.Add(booking);
                booking.Room.IsAvailable = false;
                SaveRoomAvailabilityToFile("room_availability.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error making booking: {ex.Message}");
            }
        }

        /// <summary>
        /// Cancels a booking and marks the room as available.
        /// </summary>
        /// <param name="bookingId">The ID of the booking to be canceled.</param>
        public void CancelBooking(int bookingId)
        {
            try
            {
                var booking = Bookings.FirstOrDefault(b => b.BookingID == bookingId);
                if (booking != null)
                {
                    Bookings.Remove(booking);
                    booking.Room.IsAvailable = true;
                    SaveRoomAvailabilityToFile("room_availability.txt");
                }
                else
                {
                    Console.WriteLine("Booking not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error canceling booking: {ex.Message}");
            }
        }

        /// <summary>
        /// Saves room availability to a file.
        /// </summary>
        /// <param name="filePath">The path to the file where room availability data will be saved.</param>
        private void SaveRoomAvailabilityToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var room in Rooms)
                    {
                        writer.WriteLine($"{room.RoomNumber}|{room.IsAvailable}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving room availability to file: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads room availability from a file.
        /// </summary>
        /// <param name="filePath">The path to the file containing room availability data.</param>
        private void LoadRoomAvailabilityFromFile(string filePath)
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
                            if (parts.Length == 2)
                            {
                                int roomNumber = int.Parse(parts[0]);
                                bool isAvailable = bool.Parse(parts[1]);
                                var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                                if (room != null)
                                {
                                    room.IsAvailable = isAvailable;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading room availability from file: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new room to the hotel.
        /// </summary>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="type">The type of the room.</param>
        /// <param name="isAvailable">Indicates whether the room is available.</param>
        /// <param name="price">The price of the room.</param>
        public void AddRoom(int roomNumber, RoomType type, bool isAvailable, decimal price)
        {
            try
            {
                if (Rooms.Any(r => r.RoomNumber == roomNumber))
                {
                    Console.WriteLine("Room with this number already exists.");
                    return;
                }

                var newRoom = new Room(roomNumber, type, isAvailable, price);
                Rooms.Add(newRoom);
                SaveRoomAvailabilityToFile("room_availability.txt");
                Console.WriteLine($"Room {roomNumber} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding room: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes a room from the hotel.
        /// </summary>
        /// <param name="roomNumber">The room number of the room to be removed.</param>
        public void RemoveRoom(int roomNumber)
        {
            try
            {
                var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room == null)
                {
                    Console.WriteLine("Room not found.");
                    return;
                }

                if (!room.IsAvailable)
                {
                    Console.WriteLine("Cannot remove a room that is currently booked.");
                    return;
                }

                Rooms.Remove(room);
                SaveRoomAvailabilityToFile("room_availability.txt");
                Console.WriteLine($"Room {roomNumber} removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing room: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of an existing room.
        /// </summary>
        /// <param name="roomNumber">The room number of the room to be updated.</param>
        /// <param name="newType">The new type of the room.</param>
        /// <param name="isAvailable">Indicates whether the room is available.</param>
        /// <param name="price">The new price of the room.</param>
        public void UpdateRoom(int roomNumber, RoomType newType, bool isAvailable, decimal price)
        {
            try
            {
                var room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room == null)
                {
                    Console.WriteLine("Room not found.");
                    return;
                }

                room.Type = newType;
                room.IsAvailable = isAvailable;
                room.Price = price;
                SaveRoomAvailabilityToFile("room_availability.txt");
                Console.WriteLine($"Room {roomNumber} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating room: {ex.Message}");
            }
        }
    }
}
