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
            try
            {
                LoadGuests();
                LoadAvailableRooms();
                UpdateBookingList();
                SetDefaultDates(); // Set default check-in and check-out dates to the same day
                LoadBookingsFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing booking form: " + ex.Message);
            }

            // Subscribe to the SelectedIndexChanged event of cmbGuest
            cmbGuest.SelectedIndexChanged += cmbGuest_SelectedIndexChanged;

            // Subscribe to the ValueChanged events of the date pickers
            dtpCheckInDate.ValueChanged += dtpCheckInDate_ValueChanged;
            dtpCheckOutDate.ValueChanged += dtpCheckOutDate_ValueChanged;

            // Subscribe to the SelectedIndexChanged event of cmbRoom
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
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
                MessageBox.Show($"Error updating guest name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadAvailableRooms()
        {
            cmbRoom.Items.Clear();
            try
            {
                foreach (var room in hotelManager.GetAvailableRooms())
                {
                    // Add room number and type and price to the combo box
                    cmbRoom.Items.Add($"{room.RoomNumber} - {room.Type} - {room.Price:C}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms: " + ex.Message);
            }
        }

        private void CalculatePrice()
        {
            try
            {
                if (cmbRoom.SelectedItem != null)
                {
                    var selectedRoom = cmbRoom.SelectedItem.ToString();
                    int roomNumber = int.Parse(selectedRoom.Split(' ')[0]);
                    var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                    if (room != null)
                    {
                        int nights = (dtpCheckOutDate.Value - dtpCheckInDate.Value).Days;
                        if (nights > 0) // Ensure the number of nights is positive
                        {
                            decimal totalPrice = room.Price * nights;
                            lblMoney.Text = $"Total amount to pay: {totalPrice}$";
                        }
                        else
                        {
                            lblMoney.Text = "Please select valid duration to show the total cost!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating price: " + ex.Message);
            }
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoom.SelectedItem != null && cmbGuest.SelectedItem != null)
                {
                    int roomNumber = int.Parse(cmbRoom.SelectedItem.ToString().Split(' ')[0]);
                    int guestID = int.Parse(cmbGuest.SelectedItem.ToString().Split(' ')[0]);
                    DateTime checkInDate = dtpCheckInDate.Value;
                    DateTime checkOutDate = dtpCheckOutDate.Value;

                    if (checkOutDate <= checkInDate)
                    {
                        MessageBox.Show("Check-out date must be after check-in date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var guest = hotelManager.Guests.FirstOrDefault(g => g.GuestID == guestID);
                    var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                    if (room != null && guest != null)
                    {
                        var booking = new Booking(hotelManager.Bookings.Count + 1, room, guest, checkInDate, checkOutDate, guest.GetName(), room.Price);
                        hotelManager.MakeBooking(booking);
                        UpdateBookingList(); // Ensure booking list is updated
                        SaveBookingsToFile();
                        MessageBox.Show("Booking successfully made!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Clear the fields after booking
                        LoadAvailableRooms(); // Update available rooms after making a booking
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
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBookings.SelectedItem != null)
                {
                    //get the booking ID from the selected item
                    int bookingID = int.Parse(lstBookings.SelectedItem.ToString().Split('\t')[0]);
                    hotelManager.CancelBooking(bookingID);
                    UpdateBookingList();
                    SaveBookingsToFile();
                    MessageBox.Show("Booking successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a booking to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting booking: " + ex.Message);
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
                // Adding the header line first
                lstBookings.Items.Add("Booking ID\tRoom Number\tGuest Name\tCheck-in Date\tCheck-out Date\tNights\tTotal Price");

                foreach (var booking in hotelManager.Bookings)
                {
                    int nights = (booking.CheckOutDate - booking.CheckInDate).Days;
                    decimal totalPrice = booking.CalculateTotalPrice();
                    string bookingDetails = $"{booking.BookingID}\t \t" +
                                            $"{booking.Room.RoomNumber}\t \t" +
                                            $"{booking.Guest.GetName()}\t \t" +
                                            $"{booking.CheckInDate:yyyy-MM-dd}\t " +
                                            $"{booking.CheckOutDate:yyyy-MM-dd}\t" +
                                            $"{nights}\t" +
                                            $"{totalPrice:C}";
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

        private void ClearFields()
        {
            try
            {
                cmbGuest.SelectedIndex = -1;
                cmbRoom.SelectedIndex = -1;
                dtpCheckInDate.Value = DateTime.Today;
                dtpCheckOutDate.Value = DateTime.Today;
                lblMoney.Text = "Total amount to pay: ";
                btnName.Text = "Guest Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing fields: " + ex.Message);
            }
        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculatePrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on check-in date change: " + ex.Message);
            }
        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculatePrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on check-out date change: " + ex.Message);
            }
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRoom.SelectedItem != null)
                {
                    CalculatePrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on room selection change: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }

        private void SetDefaultDates()
        {
            try
            {
                dtpCheckInDate.Value = DateTime.Today;
                dtpCheckOutDate.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting default dates: " + ex.Message);
            }
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message);
            }
        }
    }
}
