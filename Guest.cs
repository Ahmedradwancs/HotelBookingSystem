using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class Guest
    {
        public int GuestID { get; private set; }
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }

        public Guest(int guestID, string name, string contactInfo, DateTime checkInDate, DateTime checkOutDate)
        {
            GuestID = guestID;
            Name = name;
            ContactInfo = contactInfo;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public void UpdateGuest(string name, string contactInfo, DateTime checkInDate, DateTime checkOutDate)
        {
            Name = name;
            ContactInfo = contactInfo;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public int GetStayDuration()
        {
            return (CheckOutDate - CheckInDate).Days;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {GuestID})";
        }
    }

}
