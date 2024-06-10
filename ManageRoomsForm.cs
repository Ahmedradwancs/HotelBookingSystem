using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    /// <summary>
    /// Represents the form for managing rooms in the hotel booking system.
    /// </summary>
    public partial class ManageRoomsForm : Form
    {
        private HotelManager hotelManager;
        private const string RoomsFilePath = "rooms.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageRoomsForm"/> class.
        /// </summary>
        /// <param name="hotelManager">The <see cref="HotelManager"/> instance managing the hotel operations.</param>
        public ManageRoomsForm(HotelManager hotelManager)
        {
            InitializeComponent();
            this.hotelManager = hotelManager;
            LoadRoomsFromFile();
        }

        /// <summary>
        /// Handles the click event for the Add Room button.
        /// Adds a new room to the system.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) ||
                    cmbRoomType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtRoomNumber.Text, out int roomNumber))
                {
                    MessageBox.Show("Please enter a valid room number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var room = new Room(
                    roomNumber,
                    (RoomType)cmbRoomType.SelectedItem,
                    chkIsAvailable.Checked,
                    price
                );

                hotelManager.AddRoom(roomNumber, room.Type, room.IsAvailable, room.Price);
                lstRooms.Items.Add(room);
                ClearRoomInputFields();
                SaveRoomsToFile();
                MessageBox.Show("Room added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the click event for the Remove Room button.
        /// Removes the selected room from the system.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRooms.SelectedItem is Room selectedRoom)
                {
                    hotelManager.RemoveRoom(selectedRoom.RoomNumber);
                    lstRooms.Items.Remove(selectedRoom);
                    SaveRoomsToFile();
                    MessageBox.Show("Room removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a room to remove.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the click event for the Update Room button.
        /// Updates the selected room's information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRooms.SelectedItem is Room selectedRoom &&
                    cmbRoomType.SelectedItem != null &&
                    !string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    if (!int.TryParse(txtRoomNumber.Text, out int roomNumber))
                    {
                        MessageBox.Show("Please enter a valid room number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        MessageBox.Show("Please enter a valid price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    RoomType newType = (RoomType)cmbRoomType.SelectedItem;
                    bool isAvailable = chkIsAvailable.Checked;

                    hotelManager.UpdateRoom(roomNumber, newType, isAvailable, price);
                    selectedRoom.Type = newType;
                    selectedRoom.IsAvailable = isAvailable;
                    selectedRoom.Price = price;

                    lstRooms.Items[lstRooms.SelectedIndex] = selectedRoom; // Refresh the listbox
                    ClearRoomInputFields();
                    SaveRoomsToFile();
                    MessageBox.Show("Room updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a room and ensure all fields are filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the selected index changed event for the rooms list.
        /// Populates the input fields with the selected room's information.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstRooms.SelectedItem is Room selectedRoom)
                {
                    txtRoomNumber.Text = selectedRoom.RoomNumber.ToString();
                    cmbRoomType.SelectedItem = selectedRoom.Type;
                    chkIsAvailable.Checked = selectedRoom.IsAvailable;
                    txtPrice.Text = selectedRoom.Price.ToString();
                    btnUpdateRoom.Enabled = true;
                    btnRemoveRoom.Enabled = true;
                }
                else
                {
                    btnUpdateRoom.Enabled = false;
                    btnRemoveRoom.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears the input fields for room information.
        /// </summary>
        private void ClearRoomInputFields()
        {
            txtRoomNumber.Clear();
            cmbRoomType.SelectedIndex = -1;
            chkIsAvailable.Checked = false;
            txtPrice.Clear();
        }

        /// <summary>
        /// Saves the rooms to the file.
        /// </summary>
        private void SaveRoomsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(RoomsFilePath))
                {
                    foreach (var room in hotelManager.Rooms)
                    {
                        writer.WriteLine($"{room.RoomNumber}|{room.Type}|{room.IsAvailable}|{room.Price}");
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error saving rooms to file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the rooms from the file.
        /// </summary>
        private void LoadRoomsFromFile()
        {
            try
            {
                hotelManager.Rooms.Clear();
                lstRooms.Items.Clear();
                if (File.Exists(RoomsFilePath))
                {
                    using (StreamReader reader = new StreamReader(RoomsFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                var roomNumber = int.Parse(parts[0]);
                                var roomType = (RoomType)Enum.Parse(typeof(RoomType), parts[1]);
                                var isAvailable = bool.Parse(parts[2]);
                                var price = decimal.Parse(parts[3]);

                                var room = new Room(roomNumber, roomType, isAvailable, price);
                                hotelManager.Rooms.Add(room);
                                // Add formatted string to the list box
                                string formattedRoom = $"{roomNumber,-5} {roomType,-10} {(isAvailable ? "Available" : "Not Available"),-15} ${price,6}";
                                lstRooms.Items.Add(formattedRoom);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existing rooms file found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error loading rooms from file: {ex.Message}", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
