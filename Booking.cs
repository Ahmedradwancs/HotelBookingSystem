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
        private int v;

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

        public Booking(int v, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate)
        {
            this.v = v;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public int GetBookingID()
        {
            return BookingID;
        }

        public void SetBookingID(int bookingID)
        {
            BookingID = bookingID;
        }

        public DateTime GetCheckInDate()
        {
            return CheckInDate;
        }

        public void SetCheckInDate(DateTime checkInDate)
        {
            CheckInDate = checkInDate;
        }

        public DateTime GetCheckOutDate()
        {
            return CheckOutDate;
        }

        public void SetCheckOutDate(DateTime checkOutDate)
        {
            CheckOutDate = checkOutDate;
        }

        public Guest GetGuest()
        {
            return Guest;
        }

        public void SetGuest(Guest guest)
        {
            Guest = guest;
        }

        public Room GetRoom()
        {
            return Room;
        }

        public void SetRoom(Room room)
        {
            Room = room;
        }

        public PaymentStatus GetPaymentStatus()
        {
            return PaymentStatus;
        }

        public void SetPaymentStatus(PaymentStatus paymentStatus)
        {
            PaymentStatus = paymentStatus;
        }

        public decimal CalculateTotalPrice()
        {
            return Room.Price * GetStayDuration();
        }

        public bool ConfirmBooking()
        {
            if (PaymentStatus == PaymentStatus.Pending)
            {
                PaymentStatus = PaymentStatus.Paid;
                return true;
            }
            return false;
        }

        public bool CancelBooking()
        {
            if (PaymentStatus == PaymentStatus.Pending || PaymentStatus == PaymentStatus.Paid)
            {
                PaymentStatus = PaymentStatus.Canceled;
                return true;
            }
            return false;
        }

        private int GetStayDuration()
        {
            return (CheckOutDate - CheckInDate).Days;
        }
    }
}
