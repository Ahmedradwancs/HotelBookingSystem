using System;

namespace HotelBookingSystem
{
    /// <summary>
    /// Represents a guest in the hotel booking system.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// Gets the guest ID.
        /// </summary>
        public int GuestID { get; private set; }

        /// <summary>
        /// Gets the name of the guest.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the phone number of the guest.
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// Gets the email address of the guest.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guest"/> class.
        /// </summary>
        /// <param name="guestID">The guest ID.</param>
        /// <param name="name">The name of the guest.</param>
        /// <param name="phone">The phone number of the guest.</param>
        /// <param name="email">The email address of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when name, phone, or email is null or empty.</exception>
        public Guest(int guestID, string name, string phone, string email)
        {
            GuestID = guestID;
            SetName(name);
            SetPhone(phone);
            SetEmail(email);
        }

        /// <summary>
        /// Gets the name of the guest.
        /// </summary>
        /// <returns>The name of the guest.</returns>
        public string GetName()
        {
            return Name;
        }

        /// <summary>
        /// Sets the name of the guest.
        /// </summary>
        /// <param name="name">The name of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty.</exception>
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            Name = name;
        }

        /// <summary>
        /// Gets the phone number of the guest.
        /// </summary>
        /// <returns>The phone number of the guest.</returns>
        public string GetPhone()
        {
            return Phone;
        }

        /// <summary>
        /// Sets the phone number of the guest.
        /// </summary>
        /// <param name="phone">The phone number of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when phone is null or empty.</exception>
        public void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone cannot be null or empty.", nameof(phone));
            }
            Phone = phone;
        }

        /// <summary>
        /// Gets the email address of the guest.
        /// </summary>
        /// <returns>The email address of the guest.</returns>
        public string GetEmail()
        {
            return Email;
        }

        /// <summary>
        /// Sets the email address of the guest.
        /// </summary>
        /// <param name="email">The email address of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when email is null or empty.</exception>
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            Email = email;
        }

        /// <summary>
        /// Returns a string that represents the current guest.
        /// </summary>
        /// <returns>A string representation of the guest.</returns>
        public override string ToString()
        {
            return $"{Name} (ID: {GuestID})";
        }

        /// <summary>
        /// Updates the guest's information.
        /// </summary>
        /// <param name="name">The name of the guest.</param>
        /// <param name="phone">The phone number of the guest.</param>
        /// <param name="email">The email address of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when name, phone, or email is null or empty.</exception>
        public void UpdateGuest(string name, string phone, string email)
        {
            SetName(name);
            SetPhone(phone);
            SetEmail(email);
        }

        /// <summary>
        /// Gets the contact information of the guest.
        /// </summary>
        /// <returns>The contact information of the guest.</returns>
        public string GetContactInfo()
        {
            return $"{Phone}, {Email}";
        }

        /// <summary>
        /// Sets the contact information of the guest.
        /// </summary>
        /// <param name="phone">The phone number of the guest.</param>
        /// <param name="email">The email address of the guest.</param>
        /// <exception cref="ArgumentException">Thrown when phone or email is null or empty.</exception>
        public void SetContactInfo(string phone, string email)
        {
            SetPhone(phone);
            SetEmail(email);
        }
    }
}
