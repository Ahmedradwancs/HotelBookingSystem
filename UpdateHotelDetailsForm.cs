using System;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class UpdateHotelDetailsForm : Form
    {
        private HotelManager hotelManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateHotelDetailsForm"/> class.
        /// </summary>
        /// <param name="hotelManager">The <see cref="HotelManager"/> instance managing the hotel operations.</param>
        public UpdateHotelDetailsForm(HotelManager hotelManager)
        {
            InitializeComponent();
            this.hotelManager = hotelManager;
            txtHotelName.Text = hotelManager.HotelName;
            txtHotelLocation.Text = hotelManager.HotelLocation;
        }

        /// <summary>
        /// Handles the click event for the Save button.
        /// Saves the updated hotel details.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                hotelManager.HotelName = txtHotelName.Text;
                hotelManager.HotelLocation = txtHotelLocation.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving hotel details: " + ex.Message);
            }
        }
    }
}
