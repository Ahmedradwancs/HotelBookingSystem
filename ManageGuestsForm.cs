using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class ManageGuestsForm : Form
    {
        private HotelManager hotelManager;
        private const string GuestsFilePath = "guests.txt";

        public ManageGuestsForm(HotelManager hotelManager)
        {
            InitializeComponent();
            this.hotelManager = hotelManager;
            LoadGuestsFromFile();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var guest = new Guest(
                    hotelManager.Guests.Count + 1,
                    txtName.Text,
                    txtPhone.Text,
                    txtEmail.Text
                );

                hotelManager.Guests.Add(guest);
                lstGuests.Items.Add(guest);
                ClearGuestInputFields();
                SaveGuestsToFile();
                MessageBox.Show("Guest added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGuests.SelectedItem is Guest selectedGuest)
                {
                    hotelManager.Guests.Remove(selectedGuest);
                    lstGuests.Items.Remove(selectedGuest);
                    SaveGuestsToFile();
                    MessageBox.Show("Guest removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a guest to remove.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstGuests.SelectedItem is Guest selectedGuest)
                {
                    selectedGuest.SetName(txtName.Text);
                    selectedGuest.SetPhone(txtPhone.Text);
                    selectedGuest.SetEmail(txtEmail.Text);
                    lstGuests.Items[lstGuests.SelectedIndex] = selectedGuest; // Refresh the listbox
                    ClearGuestInputFields();
                    SaveGuestsToFile();
                    MessageBox.Show("Guest updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a guest to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstGuests_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstGuests.SelectedItem is Guest selectedGuest)
                {
                    txtName.Text = selectedGuest.GetName();
                    txtPhone.Text = selectedGuest.GetPhone();
                    txtEmail.Text = selectedGuest.GetEmail();
                    btnUpdateGuest.Enabled = true;
                    btnRemoveGuest.Enabled = true;
                }
                else
                {
                    btnUpdateGuest.Enabled = false;
                    btnRemoveGuest.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearGuestInputFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }

        private void SaveGuestsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(GuestsFilePath))
                {
                    foreach (var guest in hotelManager.Guests)
                    {
                        writer.WriteLine($"{guest.GuestID}|{guest.GetName()}|{guest.GetPhone()}|{guest.GetEmail()}");
                    }
                }
                MessageBox.Show("Guests saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error saving guests to file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGuestsFromFile()
        {
            try
            {
                hotelManager.Guests.Clear();
                lstGuests.Items.Clear();
                if (File.Exists(GuestsFilePath))
                {
                    using (StreamReader reader = new StreamReader(GuestsFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var guest = new Guest(int.Parse(parts[0]), parts[1], parts[2], parts[3]);
                                hotelManager.Guests.Add(guest);
                                lstGuests.Items.Add(guest);
                            }
                        }
                    }
                    MessageBox.Show("Guests loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No existing guests file found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error loading guests from file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
