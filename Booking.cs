using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelBookingSystem
{
    public enum PaymentStatus
    {
        Pending,
        Paid,
        Canceled
    }

    public class Booking
    {
        public int BookingID { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate, PaymentStatus paymentStatus = PaymentStatus.Pending)
        {
            BookingID = bookingID;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            PaymentStatus = paymentStatus;
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
        /// Confirms the booking by updating its payment status.
        /// </summary>
        public void ConfirmBooking()
        {
            if (PaymentStatus != PaymentStatus.Pending)
                throw new InvalidOperationException("Booking cannot be confirmed because it is not pending.");

            PaymentStatus = PaymentStatus.Paid;
        }

        /// <summary>
        /// Cancels the booking by updating its payment status.
        /// </summary>
        public void CancelBooking()
        {
            if (PaymentStatus != PaymentStatus.Pending && PaymentStatus != PaymentStatus.Paid)
                throw new InvalidOperationException("Booking cannot be canceled because it is not pending or paid.");

            PaymentStatus = PaymentStatus.Canceled;
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

        /// <summary>
        /// Saves the list of bookings to a file.
        /// </summary>
        public static void SaveBookingsToFile(string filePath, List<Booking> bookings)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var booking in bookings)
                    {
                        writer.WriteLine($"{booking.BookingID}|{booking.Guest.GuestID}|{booking.CheckInDate:yyyy-MM-dd}|{booking.CheckOutDate:yyyy-MM-dd}|{booking.PaymentStatus}");
                    }
                }
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
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 6)
                            {
                                int bookingID = int.Parse(parts[0]);
                                int roomNumber = int.Parse(parts[1]);
                                int guestID = int.Parse(parts[2]);
                                DateTime checkInDate = DateTime.Parse(parts[3]);
                                DateTime checkOutDate = DateTime.Parse(parts[4]);
                                PaymentStatus paymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), parts[5]);

                                var room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                                var guest = guests.FirstOrDefault(g => g.GuestID == guestID);

                                if (room != null && guest != null)
                                {
                                    var booking = new Booking(bookingID, room, guest, checkInDate, checkOutDate, paymentStatus);
                                    bookings.Add(booking);
                                }
                            }
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