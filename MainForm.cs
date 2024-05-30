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
    public partial class MainForm : Form
    {
        private HotelManager hotelManager;

        public MainForm()
        {
            InitializeComponent();
            hotelManager = new HotelManager();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            var manageRoomsForm = new ManageRoomsForm(hotelManager);
            manageRoomsForm.Show();
        }

        private void btnManageGuests_Click(object sender, EventArgs e)
        {
            var manageGuestsForm = new ManageGuestsForm(hotelManager);
            manageGuestsForm.Show();
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            var bookingForm = new BookingForm(hotelManager);
            bookingForm.Show();
        }
    }

}
