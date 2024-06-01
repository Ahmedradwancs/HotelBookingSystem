using System;

namespace HotelBookingSystem
{
    public class Guest
    {
        public int GuestID { get; private set; }
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }

        public Guest(int guestID, string name, string contactInfo, System.DateTime value, System.DateTime value1)
        {
            GuestID = guestID;
            Name = name;
            ContactInfo = contactInfo;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetContactInfo()
        {
            return ContactInfo;
        }

        public void SetContactInfo(string contactInfo)
        {
            ContactInfo = contactInfo;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {GuestID})";
        }

        internal void UpdateGuest(string text1, string text2, DateTime value1, DateTime value2)
        {
            throw new NotImplementedException();
        }
    }
}