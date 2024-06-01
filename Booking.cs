using System;
using System.Collections.Generic;
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

        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate, PaymentStatus paymentStatus)
        {
            BookingID = bookingID;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            PaymentStatus = paymentStatus;
        }

        // Constructor for bookings without a specified payment status
        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate)
            : this(bookingID, room, guest, checkInDate, checkOutDate, PaymentStatus.Pending)
        {
        }

        public decimal CalculateTotalPrice()
        {
            if (Room == null)
            {
                throw new InvalidOperationException("Room object is null.");
            }

            int stayDuration = GetStayDuration();
            if (stayDuration <= 0)
            {
                throw new InvalidOperationException("Invalid stay duration.");
            }

            return Room.Price * stayDuration;
        }

        public bool ConfirmBooking()
        {
            if (PaymentStatus != PaymentStatus.Pending)
            {
                throw new InvalidOperationException("Booking cannot be confirmed because it is not pending.");
            }

            PaymentStatus = PaymentStatus.Paid;
            return true;
        }

        public bool CancelBooking()
        {
            if (PaymentStatus != PaymentStatus.Pending && PaymentStatus != PaymentStatus.Paid)
            {
                throw new InvalidOperationException("Booking cannot be canceled because it is not pending or paid.");
            }

            PaymentStatus = PaymentStatus.Canceled;
            return true;
        }

        private int GetStayDuration()
        {
            if (CheckOutDate < CheckInDate)
            {
                throw new InvalidOperationException("Check-out date cannot be before check-in date.");
            }

            return (CheckOutDate - CheckInDate).Days;
        }

        internal int GetBookingID()
        {
            throw new NotImplementedException();
        }
    }
}
