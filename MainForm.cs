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
    /// <summary>
    /// Represents the main form of the hotel booking system application.
    /// </summary>
    public partial class MainForm : Form
    {
        private HotelManager hotelManager;
        private const string HotelDescription = "Welcome to our hotel booking system!";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            hotelManager = new HotelManager();
            lblHotelDescripion.Text = HotelDescription;
        }

        /// <summary>
        /// Handles the click event for the Manage Guests button.
        /// Opens the Manage Guests form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the click event for the Make Booking button.
        /// Opens the Booking form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the click event for the Manage Rooms button.
        /// Opens the Manage Rooms form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        private void btnUpdateDescription_Click(object sender, EventArgs e)
        {
            lblHotelDescripion.Text = "This is a new description!";
        }
    }
}
