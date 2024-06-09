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


        private void btnManageGuests_Click(object sender, EventArgs e)
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

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            try
            {
                var bookingForm = new BookingForm(hotelManager);
                bookingForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening booking form: " + ex.Message);
            }
        }

        private void btnManageRoom_Click(object sender, EventArgs e)
        {
            try
            {
                var manageRoomsForm = new ManageRoomsForm(hotelManager);
                manageRoomsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening manage rooms form: " + ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}