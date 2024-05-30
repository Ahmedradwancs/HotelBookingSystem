using System.Drawing;
using System.Windows.Forms;
using System;



namespace HotelBookingSystem
{
    partial class ManageRoomsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtRoomNumber;
        private TextBox txtRoomType;
        private TextBox txtPrice;
        private CheckBox chkIsAvailable;
        private ListBox lstRooms;
        private Button btnAddRoom;
        private Button btnRemoveRoom;
        private Button btnUpdateRoom;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.chkIsAvailable = new System.Windows.Forms.CheckBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRoomNumber
            // 
            this.txtRoomNumber.Location = new System.Drawing.Point(12, 12);
            this.txtRoomNumber.Name = "txtRoomNumber";
            this.txtRoomNumber.Size = new System.Drawing.Size(288, 22);
            this.txtRoomNumber.TabIndex = 0;
            // 
            // txtRoomType
            // 
            this.txtRoomType.Location = new System.Drawing.Point(12, 38);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(288, 22);
            this.txtRoomType.TabIndex = 1;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(12, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(288, 22);
            this.txtPrice.TabIndex = 2;
            // 
            // chkIsAvailable
            // 
            this.chkIsAvailable.AutoSize = true;
            this.chkIsAvailable.Location = new System.Drawing.Point(12, 90);
            this.chkIsAvailable.Name = "chkIsAvailable";
            this.chkIsAvailable.Size = new System.Drawing.Size(86, 20);
            this.chkIsAvailable.TabIndex = 3;
            this.chkIsAvailable.Text = "Available";
            this.chkIsAvailable.UseVisualStyleBackColor = true;
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.ItemHeight = 16;
            this.lstRooms.Location = new System.Drawing.Point(12, 113);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(379, 116);
            this.lstRooms.TabIndex = 4;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(316, 12);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 5;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Location = new System.Drawing.Point(316, 38);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRoom.TabIndex = 6;
            this.btnRemoveRoom.Text = "Remove Room";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.btnRemoveRoom_Click);
            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.Location = new System.Drawing.Point(316, 64);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateRoom.TabIndex = 7;
            this.btnUpdateRoom.Text = "Update Room";
            this.btnUpdateRoom.UseVisualStyleBackColor = true;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);
            // 
            // ManageRoomsForm
            // 
            this.ClientSize = new System.Drawing.Size(403, 450);
            this.Controls.Add(this.btnUpdateRoom);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.lstRooms);
            this.Controls.Add(this.chkIsAvailable);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtRoomType);
            this.Controls.Add(this.txtRoomNumber);
            this.Name = "ManageRoomsForm";
            this.Text = "Manage Rooms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
