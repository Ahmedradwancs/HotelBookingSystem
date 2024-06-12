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

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            hotelManager = new HotelManager();
            label5.Text = hotelManager.GetTotalRooms().ToString();

        }

        /// <summary>
        /// Updates the hotel details on the form.
        /// </summary>
        private void UpdateHotelDetails()
        {
            lblHotelName.Text = hotelManager.HotelName;
            lblHotelLocation.Text = hotelManager.HotelLocation;
        }


        /// <summary>
        /// Sets the name of the hotel.
        /// </summary>
        /// <param name="name">The new name of the hotel.</param>
        public void SetHotelName(string name)
        {
            hotelManager.HotelName = name;
            lblHotelName.Text = name;
        }

        /// <summary>
        /// Sets the location of the hotel.
        /// </summary>
        /// <param name="location">The new location of the hotel.</param>
        public void SetHotelLocation(string location)
        {
            hotelManager.HotelLocation = location;
            lblHotelLocation.Text = location;
        }

        /// <summary>
        /// Event handler for the click event of the 'Update Details' button.
        /// Displays a form for updating hotel details and handles exceptions that may occur.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            try
            {
                using (var updateForm = new UpdateHotelDetailsForm(hotelManager))
                {
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateHotelDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

    }
}
