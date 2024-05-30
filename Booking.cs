using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Booking
    {
        public int BookingID { get; private set; }
        public Room Room { get; private set; }
        public Guest Guest { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }

        public Booking(int bookingID, Room room, Guest guest, DateTime checkInDate, DateTime checkOutDate)
        {
            BookingID = bookingID;
            Room = room;
            Guest = guest;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public decimal CalculateTotalCost()
        {
            return Room.Price * GetStayDuration();
        }

        private int GetStayDuration()
        {
            return (CheckOutDate - CheckInDate).Days;
        }
    }

}
