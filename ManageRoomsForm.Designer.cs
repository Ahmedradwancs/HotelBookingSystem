using System.Drawing;
using System.Windows.Forms;
using System;

namespace HotelBookingSystem
{
    partial class ManageRoomsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtRoomNumber;
        private ComboBox cmbRoomType;
        private CheckBox chkIsAvailable;
        private ListBox lstRooms;
        private Button btnAddRoom;
        private Button btnRemoveRoom;
        private Button btnUpdateRoom;
        private Label lblRoomNumber;
        private Label lblRoomType;
        private Label lblIsAvailable;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRoomNumber = new System.Windows.Forms.TextBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblIsAvailable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(96, 12);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(200, 22);
            this.txtRoomNumber.TabIndex = 0;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Items.AddRange(new object[] {
                RoomType.Single,
                RoomType.Double,
                RoomType.Suite,
                RoomType.Family
            });
            this.cmbRoomType.Location = new System.Drawing.Point(96, 38);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(200, 24);
            this.cmbRoomType.TabIndex = 1;
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Location = new System.Drawing.Point(96, 68);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(104, 21);
            this.chkIsAvailable.TabIndex = 2;
            this.chkIsAvailable.Text = "Is Available";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.ItemHeight = 16;
            this.lstRooms.Location = new System.Drawing.Point(12, 116);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(284, 180);
            this.lstRooms.TabIndex = 3;
            this.lstRooms.SelectedIndexChanged += new System.EventHandler(this.lstRooms_SelectedIndexChanged);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(221, 92);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 4;
            this.btnAddRoom.Text = "Add";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Location = new System.Drawing.Point(302, 150);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRoom.TabIndex = 5;
            this.btnRemoveRoom.Text = "Remove";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.Location = new System.Drawing.Point(302, 179);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRoom.TabIndex = 6;
            this.btnUpdateRoom.Text = "Update";
            this.btnUpdateRoom.UseVisualStyleBackColor = true;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Location = new System.Drawing.Point(12, 15);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(65, 16);
            this.lblRoomNumber.TabIndex = 7;
            this.lblRoomNumber.Text = "Room #:";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(12, 41);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(79, 16);
            this.lblRoomType.TabIndex = 8;
            this.lblRoomType.Text = "Room Type:";
            // 
            // lblIsAvailable
            // 
            this.lblIsAvailable.AutoSize = true;
            this.lblIsAvailable.Location = new System.Drawing.Point(12, 68);
            this.lblIsAvailable.Name = "lblIsAvailable";
            this.lblIsAvailable.Size = new System.Drawing.Size(78, 16);
            this.lblIsAvailable.TabIndex = 9;
            this.lblIsAvailable.Text = "Is Available:";
            // 
            // ManageRoomsForm
            // 
            this.ClientSize = new System.Drawing.Size(402, 340);
            this.Controls.Add(this.lblIsAvailable);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.lblRoomNumber);
            this.Controls.Add(this.btnUpdateRoom);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.lstRooms);
            this.Controls.Add(this.chkIsAvailable);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.txtRoomNumber);
            this.Name = "ManageRoomsForm";
            this.Text = "Manage Rooms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
