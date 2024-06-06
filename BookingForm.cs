using System;
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
            LoadAvailableRooms();
            LoadGuests();
            UpdateBookingList();
            SetDefaultCheckoutDate();

            // Subscribe to the SelectedIndexChanged event of cmbGuest
            cmbGuest.SelectedIndexChanged += cmbGuest_SelectedIndexChanged;
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
                    cmbRoom.Items.Add(room.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms: " + ex.Message);
            }
        }

        private void LoadGuests()
        {
            cmbGuest.Items.Clear();
            try
            {
                foreach (var guest in hotelManager.Guests)
                {
                    cmbGuest.Items.Add($"{guest.GuestID} - {guest.Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading guests: " + ex.Message);
            }
        }

        private void SetDefaultCheckoutDate()
        {
            dtpCheckOutDate.Value = dtpCheckInDate.Value.AddDays(1);
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
                    decimal totalPrice = room.Price * nights;
                    money.Text = $"Total Price: {totalPrice:C}$";
                }
            }
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

                    var guest = hotelManager.Guests.FirstOrDefault(g => g.GuestID == guestID);
                    var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

                    if (room != null && guest != null)
                    {
                        var booking = new Booking(hotelManager.Bookings.Count + 1, room, guest, checkInDate, checkOutDate);
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
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBookings.SelectedItem != null)
                {
                    int bookingID = int.Parse(lstBookings.SelectedItem.ToString().Split(' ')[0]);
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
                    lstBookings.Items.Add($"{booking.BookingID} - Room {booking.Room.RoomNumber} - Guest {booking.Guest.Name} - Check-in: {booking.CheckInDate:yyyy-MM-dd} - Check-out: {booking.CheckOutDate:yyyy-MM-dd} - Nights: {nights} - Total Price: {totalPrice:C}");
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

        private void btnManageGuests_Click(object sender, EventArgs e)
        {
            using (var manageGuestsForm = new ManageGuestsForm(hotelManager))
            {
                if (manageGuestsForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuests(); // Reload guests after managing
                }
            }
        }

        private void btnCreateGuest_Click(object sender, EventArgs e)
        {
            try
            {
                var manageGuestsForm = new ManageGuestsForm(hotelManager);
                manageGuestsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening manage guests form: " + ex.Message);
            }
        }
    }
}
