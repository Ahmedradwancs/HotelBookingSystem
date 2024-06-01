using System;

namespace HotelBookingSystem
{
    public class Guest
    {
        public int GuestID { get; private set; }
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }

        public Guest(int guestID, string name, string contactInfo)
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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            Name = name;
        }

        public string GetContactInfo()
        {
            return ContactInfo;
        }

        public void SetContactInfo(string contactInfo)
        {
            if (string.IsNullOrWhiteSpace(contactInfo))
            {
                throw new ArgumentException("Contact information cannot be null or empty.");
            }
            ContactInfo = contactInfo;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {GuestID})";
        }

        public void UpdateGuest(string name, string contactInfo)
        {
            SetName(name);
            SetContactInfo(contactInfo);
        }
    }
}