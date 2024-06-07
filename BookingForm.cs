using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class BookingForm : Form
    {
        private HotelManager hotelManager;

        public BookingForm(HotelManager manager)
        {
            InitializeComponent();
            hotelManager = manager;
            LoadGuests();
            LoadAvailableRooms();
            UpdateBookingList();
            SetDefaultCheckoutDate();
            LoadBookingsFromFile();

            // Subscribe to the SelectedIndexChanged event of cmbGuest
            cmbGuest.SelectedIndexChanged += cmbGuest_SelectedIndexChanged;
        }

        private void LoadGuests()
        {
            cmbGuest.Items.Clear();
            try
            {
                foreach (var guest in hotelManager.Guests)
                {
                    cmbGuest.Items.Add($"{guest.GuestID} - {guest.GetName()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading guests: " + ex.Message);
            }
        }

        private void cmbGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbGuest.SelectedItem != null)
                {
                    string[] selectedItemParts = cmbGuest.SelectedItem.ToString().Split(' ');
                    if (selectedItemParts.Length >= 3) // Ensure there are at least 3 parts (GuestID, "-", GuestName)
                    {
                        string guestName = string.Join(" ", selectedItemParts.Skip(2)); // Join remaining parts to get the guest name
                        btnName.Text = guestName;
                    }
                    else
                    {
                        throw new FormatException("Invalid format for selected guest.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating guest name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableRooms()
        {
            cmbRoom.Items.Clear();
            try
            {
                foreach (var room in hotelManager.GetAvailableRooms())
                {
                    cmbRoom.Items.Add(room);  // Add room objects directly
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms: " + ex.Message);
            }
        }


        private void CalculatePrice()
        {
            if (cmbRoom.SelectedItem != null)
            {
                int roomNumber = int.Parse(cmbRoom.SelectedItem.ToString().Split(' ')[1]);
                var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                if (room != null)
                {
                    int nights = (dtpCheckOutDate.Value - dtpCheckInDate.Value).Days;
                    if (nights > 0) // Ensure the number of nights is positive
                    {
                        decimal totalPrice = room.Price * nights;
                        lblMoney.Text = $"Total amount to pay: {totalPrice:C}$";
                    }
                    else
                    {
                        lblMoney.Text = "Invalid stay duration.";
                    }
                }
            }
        }


        private void SetDefaultCheckoutDate()
        {
            dtpCheckOutDate.Value = dtpCheckInDate.Value.AddDays(1);
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoom.SelectedItem != null && cmbGuest.SelectedItem != null)
                {
                    int roomNumber = int.Parse(cmbRoom.SelectedItem.ToString().Split(' ')[1]);
                    int guestID = int.Parse(cmbGuest.SelectedItem.ToString().Split(' ')[0]);
                    DateTime checkInDate = dtpCheckInDate.Value;
                    DateTime checkOutDate = dtpCheckOutDate.Value;

                    if (checkOutDate <= checkInDate)
                    {
                        MessageBox.Show("Check-out date must be after check-in date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var guest = hotelManager.Guests.FirstOrDefault(g => g.GuestID == guestID);
                    var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                    if (room != null && guest != null)
                    {
                        var booking = new Booking(hotelManager.Bookings.Count + 1, room, guest, checkInDate, checkOutDate, guest.GetName(), room.Price);
                        hotelManager.MakeBooking(booking);
                        UpdateBookingList();
                        SaveBookingsToFile();
                        MessageBox.Show("Booking successfully made!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Selected room or guest not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select both a room and a guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making booking: " + ex.Message);
            }
            LoadAvailableRooms();
        }


        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBookings.SelectedItem != null)
                {
                    int bookingID = int.Parse(lstBookings.SelectedItem.ToString().Split(' ')[2]); // Adjust index as needed
                    hotelManager.CancelBooking(bookingID);
                    UpdateBookingList();
                    SaveBookingsToFile();
                    MessageBox.Show("Booking successfully canceled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a booking to cancel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error canceling booking: " + ex.Message);
            }
            LoadAvailableRooms();
        }

        private void LoadBookingsFromFile()
        {
            try
            {
                if (File.Exists("bookings.txt"))
                {
                    hotelManager.Bookings.Clear();
                    string[] lines = File.ReadAllLines("bookings.txt");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 7)
                        {
                            int bookingID = int.Parse(parts[0]);
                            int roomNumber = int.Parse(parts[1]);
                            int guestID = int.Parse(parts[2]);
                            DateTime checkInDate = DateTime.Parse(parts[3]);
                            DateTime checkOutDate = DateTime.Parse(parts[4]);
                            string guestName = parts[5];
                            decimal roomPrice = decimal.Parse(parts[6]);

                            var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                            var guest = hotelManager.Guests.FirstOrDefault(g => g.GuestID == guestID);

                            if (room != null && guest != null)
                            {
                                var booking = new Booking(bookingID, room, guest, checkInDate, checkOutDate, guestName, roomPrice);
                                hotelManager.Bookings.Add(booking);
                            }
                        }
                    }
                    MessageBox.Show("Bookings loaded successfully.");
                    UpdateBookingList(); // Update the booking list after loading bookings
                }
                else
                {
                    MessageBox.Show("No existing bookings file found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings from file: {ex.Message}");
            }
        }

        private void UpdateBookingList()
        {
            lstBookings.Items.Clear();
            try
            {
                foreach (var booking in hotelManager.Bookings)
                {
                    int nights = (booking.CheckOutDate - booking.CheckInDate).Days;
                    decimal totalPrice = booking.CalculateTotalPrice();
                    string bookingDetails = $"Booking ID: {booking.BookingID} - " +
                                            $"Room Number: {booking.Room.RoomNumber} - " +
                                            $"Guest: {booking.Guest.GetName()} - " +
                                            $"Check-in Date: {booking.CheckInDate:yyyy-MM-dd} - " +
                                            $"Check-out Date: {booking.CheckOutDate:yyyy-MM-dd} - " +
                                            $"Nights: {nights} - " +
                                            $"Total Price: {totalPrice:C}";
                    lstBookings.Items.Add(bookingDetails);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking list: " + ex.Message);
            }
        }

        private void SaveBookingsToFile()
        {
            try
            {
                Booking.SaveBookingsToFile("bookings.txt", hotelManager.Bookings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving bookings to file: " + ex.Message);
            }
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            SetDefaultCheckoutDate();
            CalculatePrice();
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

    }
}