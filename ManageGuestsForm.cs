using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelBookingSystem
{
    public partial class ManageGuestsForm : Form
    {
        private List<Guest> guests = new List<Guest>();
        private HotelManager hotelManager;

        public ManageGuestsForm()
        {
            InitializeComponent();
        }

        public ManageGuestsForm(HotelManager hotelManager)
        {
            this.hotelManager = hotelManager;
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            try
            {
                var guest = new Guest(
                    int.Parse(txtGuestID.Text),
                    txtName.Text,
                    txtContactInfo.Text
                );

                guests.Add(guest);
                lstGuests.Items.Add(guest);
                ClearGuestInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid guest ID format. Please enter a valid integer value.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error adding guest: {ex.Message}");
            }
        }

        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
            if (lstGuests.SelectedItem is Guest selectedGuest)
            {
                guests.Remove(selectedGuest);
                lstGuests.Items.Remove(selectedGuest);
            }
        }

        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGuests.SelectedItem is Guest selectedGuest)
                {
                    selectedGuest.UpdateGuest(
                        txtName.Text,
                        txtContactInfo.Text
                    );
                    lstGuests.Items[lstGuests.SelectedIndex] = selectedGuest;  // Refresh the listbox
                    ClearGuestInputFields();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error updating guest: {ex.Message}");
            }
        }

        private void ClearGuestInputFields()
        {
            txtGuestID.Clear();
            txtName.Clear();
            txtContactInfo.Clear();
        }
    }
}
