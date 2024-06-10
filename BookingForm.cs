using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    /// <summary>
    /// Represents the booking form for the hotel booking system.
    /// </summary>
    public partial class BookingForm : Form
    {
        private HotelManager hotelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingForm"/> class.
        /// </summary>
        /// <param name="manager">The hotel manager instance.</param>
        public BookingForm(HotelManager manager)
        {
            InitializeComponent();
            hotelManager = manager;
            try
            {
                LoadGuests();
                LoadAvailableRooms();
                UpdateBookingList();
                SetDefaultDates();
                LoadBookingsFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing booking form: " + ex.Message);
            }

            cmbGuest.SelectedIndexChanged += cmbGuest_SelectedIndexChanged;
            dtpCheckInDate.ValueChanged += dtpCheckInDate_ValueChanged;
            dtpCheckOutDate.ValueChanged += dtpCheckOutDate_ValueChanged;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
        }

        /// <summary>
        /// Loads the list of guests into the guest combo box.
        /// </summary>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the guest combo box.
        /// Updates the guest name button with the selected guest's name.
        /// </summary>
        private void cmbGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbGuest.SelectedItem != null)
                {
                    string[] selectedItemParts = cmbGuest.SelectedItem.ToString().Split(' ');
                    if (selectedItemParts.Length >= 3)
                    {
                        string guestName = string.Join(" ", selectedItemParts.Skip(2));
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

        /// <summary>
        /// Loads the list of available rooms into the room combo box.
        /// </summary>
        private void LoadAvailableRooms()
        {
            cmbRoom.Items.Clear();
            try
            {
                foreach (var room in hotelManager.GetAvailableRooms())
                {
                    cmbRoom.Items.Add($"{room.RoomNumber} - {room.Type} - {room.Price:C}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms: " + ex.Message);
            }
        }

        /// <summary>
        /// Calculates the total price for the selected room and dates.
        /// </summary>
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
                        if (nights > 0)
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

        /// <summary>
        /// Handles the Click event of the make booking button.
        /// Makes a booking with the selected room, guest, and dates.
        /// </summary>
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
                        UpdateBookingList();
                        SaveBookingsToFile();
                        MessageBox.Show("Booking successfully made!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadAvailableRooms();
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

        /// <summary>
        /// Handles the Click event of the delete booking button.
        /// Deletes the selected booking.
        /// </summary>
        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBookings.SelectedItem != null)
                {
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

        /// <summary>
        /// Loads bookings from a file and populates the booking list.
        /// </summary>
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
                    UpdateBookingList();
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

        /// <summary>
        /// Updates the booking list display with the current bookings.
        /// </summary>
        private void UpdateBookingList()
        {
            lstBookings.Items.Clear();
            try
            {
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

        /// <summary>
        /// Saves the current bookings to a file.
        /// </summary>
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

        /// <summary>
        /// Clears the fields in the booking form.
        /// </summary>
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

        /// <summary>
        /// Handles the ValueChanged event of the check-in date picker.
        /// Calculates the price based on the new check-in date.
        /// </summary>
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

        /// <summary>
        /// Handles the ValueChanged event of the check-out date picker.
        /// Calculates the price based on the new check-out date.
        /// </summary>
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

        /// <summary>
        /// Handles the SelectedIndexChanged event of the room combo box.
        /// Calculates the price based on the selected room.
        /// </summary>
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

        /// <summary>
        /// Sets the default dates for check-in and check-out to today's date.
        /// </summary>
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
 

        /// <summary>
        /// Handles the Click event of the cancel button.
        /// Clears the booking form fields.
        /// </summary>
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
