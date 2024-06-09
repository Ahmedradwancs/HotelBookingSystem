using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                    cmbRoomType.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                int roomNumber;
                if (!int.TryParse(txtRoomNumber.Text, out roomNumber))
                {
                    MessageBox.Show("Please enter a valid room number.");
                    return;
                }

                var room = new Room(
                    roomNumber,
                    (RoomType)cmbRoomType.SelectedItem,
                    chkIsAvailable.Checked
                );

                hotelManager.AddRoom(roomNumber, room.Type, room.IsAvailable);
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
                if (lstRooms.SelectedItem is Room selectedRoom && cmbRoomType.SelectedItem != null)
                {
                    int roomNumber;
                    if (!int.TryParse(txtRoomNumber.Text, out roomNumber))
                    {
                        MessageBox.Show("Please enter a valid room number.");
                        return;
                    }

                    RoomType newType = (RoomType)cmbRoomType.SelectedItem;
                    bool isAvailable = chkIsAvailable.Checked;

                    hotelManager.UpdateRoom(roomNumber, newType, isAvailable);
                    selectedRoom.Type = newType;
                    selectedRoom.IsAvailable = isAvailable;

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
        }

        private void SaveRoomsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(RoomsFilePath))
                {
                    foreach (var room in hotelManager.Rooms)
                    {
                        writer.WriteLine($"{room.RoomNumber}|{room.Type}|{room.IsAvailable}");
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
                            if (parts.Length == 3)
                            {
                                var roomNumber = int.Parse(parts[0]);
                                var roomType = (RoomType)Enum.Parse(typeof(RoomType), parts[1]);
                                var isAvailable = bool.Parse(parts[2]);

                                var room = new Room(roomNumber, roomType, isAvailable);
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
