using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void LoadAvailableRooms()
        {
            cmbRoom.Items.Clear();
            try
            {
                foreach (var room in hotelManager.GetAvailableRooms())
                {
                    cmbRoom.Items.Add($"{room.RoomNumber} - {room.RoomType}");
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

                    var room = hotelManager.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                    var guest = hotelManager.Guests.FirstOrDefault(g => g.GuestID == guestID);

                    if (room != null && guest != null)
                    {
                        var booking = new Booking(hotelManager.Bookings.Count + 1, room, guest, checkInDate, checkOutDate);
                        hotelManager.MakeBooking(booking);
                        UpdateBookingList();
                    }
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
                    lstBookings.Items.Add($"{booking.BookingID} - Room {booking.Room.RoomNumber} - Guest {booking.Guest.Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking list: " + ex.Message);
            }
        }
    }
}
