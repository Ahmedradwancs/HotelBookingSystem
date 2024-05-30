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

        public ManageGuestsForm()
        {
            InitializeComponent();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            var guest = new Guest(
                int.Parse(txtGuestID.Text),
                txtName.Text,
                txtContactInfo.Text,
                dtpCheckInDate.Value,
                dtpCheckOutDate.Value
            );

            guests.Add(guest);
            lstGuests.Items.Add(guest);
            ClearGuestInputFields();
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
            if (lstGuests.SelectedItem is Guest selectedGuest)
            {
                selectedGuest.UpdateGuest(
                    txtName.Text,
                    txtContactInfo.Text,
                    dtpCheckInDate.Value,
                    dtpCheckOutDate.Value
                );
                lstGuests.Items[lstGuests.SelectedIndex] = selectedGuest;  // Refresh the listbox
                ClearGuestInputFields();
            }
        }

        private void ClearGuestInputFields()
        {
            txtGuestID.Clear();
            txtName.Clear();
            txtContactInfo.Clear();
            dtpCheckInDate.Value = DateTime.Now;
            dtpCheckOutDate.Value = DateTime.Now;
        }
    }

}
