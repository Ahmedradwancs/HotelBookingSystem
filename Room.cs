using System;

namespace HotelBookingSystem
{
    /// <summary>
    /// Specifies the type of a room in the hotel.
    /// </summary>
    public enum RoomType
    {
        /// <summary>
        /// A room with a single bed.
        /// </summary>
        Single,

        /// <summary>
        /// A room with a double bed.
        /// </summary>
        Double,

        /// <summary>
        /// A room suitable for a family.
        /// </summary>
        Family,

        /// <summary>
        /// A luxurious suite room.
        /// </summary>
        Suite,
    }

    /// <summary>
    /// Represents a room in the hotel, including its number, type, availability status, and price.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Gets the number assigned to the room.
        /// </summary>
        public int RoomNumber { get; }

        /// <summary>
        /// Gets or sets the type of the room.
        /// </summary>
        public RoomType Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room is available for booking.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the price per night for the room.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class with the specified room number, type, availability status, and price.
        /// </summary>
        /// <param name="roomNumber">The number assigned to the room. Must be greater than zero.</param>
        /// <param name="type">The type of the room, specified by <see cref="RoomType"/>.</param>
        /// <param name="isAvailable">A value indicating whether the room is available for booking.</param>
        /// <param name="price">The price per night for the room. Must not be negative.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="roomNumber"/> is less than or equal to zero, or when <paramref name="price"/> is negative.</exception>
        public Room(int roomNumber, RoomType type, bool isAvailable, decimal price)
        {
            if (roomNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(roomNumber), "Room number must be greater than zero.");
            }

            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
            }

            RoomNumber = roomNumber;
            Type = type;
            IsAvailable = isAvailable;
            Price = price;
        }

        /// <summary>
        /// Returns a string representation of the current room.
        /// </summary>
        /// <returns>A string that includes the room number, type, availability status, and price.</returns>
        /// <exception cref="InvalidOperationException">Thrown if an error occurs while generating the string representation.</exception>
        public override string ToString()
        {
            try
            {
                return $"{RoomNumber} - {Type} - {(IsAvailable ? "Available" : "Not Available")} - ${Price:F2}";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating string representation of Room: " + ex.Message);
            }
        }
    }
}
