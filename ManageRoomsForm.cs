using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class ManageRoomsForm : Form
    {
        private HotelManager hotelManager;
        private const string RoomsFilePath = "rooms.txt";

        public ManageRoomsForm(HotelManager hotelManager)
        {
            InitializeComponent();
            this.hotelManager = hotelManager;
            LoadRoomsFromFile();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) ||
                    cmbRoomType.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (!int.TryParse(txtRoomNumber.Text, out int roomNumber))
                {
                    MessageBox.Show("Please enter a valid room number.");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}");
            }
        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (lstRooms.SelectedItem is Room selectedRoom)
            {
                hotelManager.RemoveRoom(selectedRoom.RoomNumber);
                lstRooms.Items.Remove(selectedRoom);
                SaveRoomsToFile();
            }
        }

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
                        MessageBox.Show("Please enter a valid room number.");
                        return;
                    }

                    if (!decimal.TryParse(txtPrice.Text, out decimal price))
                    {
                        MessageBox.Show("Please enter a valid price.");
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}");
            }
        }

        private void lstRooms_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ClearRoomInputFields()
        {
            txtRoomNumber.Clear();
            cmbRoomType.SelectedIndex = -1;
            chkIsAvailable.Checked = false;
            txtPrice.Clear();
        }

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
                MessageBox.Show("Rooms saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving rooms to file: {ex.Message}");
            }
        }

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
                                lstRooms.Items.Add(room);
                            }
                        }
                    }
                    MessageBox.Show("Rooms loaded successfully.");
                }
                else
                {
                    MessageBox.Show("No existing rooms file found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms from file: {ex.Message}");
            }
        }
    }
}
