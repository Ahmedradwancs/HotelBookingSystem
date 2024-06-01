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
    public partial class ManageRoomsForm : Form
    {
        private HotelManager hotelManager;

        public ManageRoomsForm(HotelManager manager)
        {
            InitializeComponent();
            hotelManager = manager;
            UpdateRoomList();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                int roomNumber = int.Parse(txtRoomNumber.Text);
                string roomType = txtRoomType.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                bool isAvailable = chkIsAvailable.Checked;

                var room = new Room(roomNumber, roomType, price, isAvailable);
                hotelManager.AddRoom(room);
                UpdateRoomList();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid room number or price format. Please enter valid numeric values.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}");
            }
        }

        private void UpdateRoomList()
        {
            lstRooms.Items.Clear();
            foreach (var room in hotelManager.Rooms)
            {
                lstRooms.Items.Add($"{room.RoomNumber} - {room.RoomType}");
            }
        }
    }
}