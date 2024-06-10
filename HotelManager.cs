using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            try
            {
                LoadRoomsFromFile("rooms.txt");
                LoadGuestsFromFile("guests.txt");
                LoadRoomAvailabilityFromFile("room_availability.txt"); // Load room availability when the manager is created
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing hotel manager: {ex.Message}");
            }
        }

        // Initialize rooms by loading from file
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

        public List<Room> GetAvailableRooms()
        {
            try
            {
                // Ensure this method only returns rooms that are available
                return Rooms.Where(room => room.IsAvailable).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting available rooms: {ex.Message}");
                return new List<Room>();
            }
        }

        // Get guests from guests file
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
            try
            {
                Bookings.Add(booking);
                booking.Room.IsAvailable = false;  // Mark the room as unavailable
                SaveRoomAvailabilityToFile("room_availability.txt"); // Save room availability after making a new booking
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error making booking: {ex.Message}");
            }
        }

        // Cancel booking
        public void CancelBooking(int bookingId)
        {
            try
            {
                var booking = Bookings.FirstOrDefault(b => b.BookingID == bookingId);
                if (booking != null)
                {
                    Bookings.Remove(booking);
                    booking.Room.IsAvailable = true;  // Mark the room as available
                    SaveRoomAvailabilityToFile("room_availability.txt"); // Save room availability after canceling a booking
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

        // Add a new room
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

        // Remove an existing room
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

        // Update an existing room's type and price
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
