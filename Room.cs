using System;

namespace HotelBookingSystem
{
    /// <summary>
    /// Represents the type of a room.
    /// </summary>
    public enum RoomType
    {
        /// <summary>
        /// Single room type.
        /// </summary>
        Single,

        /// <summary>
        /// Double room type.
        /// </summary>
        Double,

        /// <summary>
        /// Family room type.
        /// </summary>
        Family,

        /// <summary>
        /// Suite room type.
        /// </summary>
        Suite,
    }

    /// <summary>
    /// Represents a room in a hotel.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Gets the room number.
        /// </summary>
        public int RoomNumber { get; }

        /// <summary>
        /// Gets or sets the type of the room.
        /// </summary>
        public RoomType Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room is available.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the price of the room.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="roomNumber">The room number.</param>
        /// <param name="type">The type of the room.</param>
        /// <param name="isAvailable">A value indicating whether the room is available.</param>
        /// <param name="price">The price of the room.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when roomNumber is less than or equal to 0, or when price is negative.</exception>
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
        /// Returns a string that represents the current room.
        /// </summary>
        /// <returns>A string that represents the current room.</returns>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs while generating the string representation.</exception>
        public override string ToString()
        {
            try
            {
                return $"{RoomNumber} - {Type} - {(IsAvailable ? "Available" : "Not Available")} - ${Price}";
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating string representation of Room: " + ex.Message);
            }
        }
    }
}
