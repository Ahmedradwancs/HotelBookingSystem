using System;

namespace HotelBookingSystem
{
    public class Guest
    {
        public int GuestID { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public Guest(int guestID, string name, string phone, string email)
        {
            GuestID = guestID;
            SetName(name);
            SetPhone(phone);
            SetEmail(email);
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            Name = name;
        }

        public string GetPhone()
        {
            return Phone;
        }

        public void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone cannot be null or empty.", nameof(phone));
            }
            Phone = phone;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {GuestID})";
        }

        public void UpdateGuest(string name, string phone, string email)
        {
            SetName(name);
            SetPhone(phone);
            SetEmail(email);
        }

        public string GetContactInfo()
        {
            return $"{Phone}, {Email}";
        }

        public void SetContactInfo(string phone, string email)
        {
            SetPhone(phone);
            SetEmail(email);
        }
    }
}
