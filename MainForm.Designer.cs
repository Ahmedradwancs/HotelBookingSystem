using System.Drawing;
using System.Windows.Forms;
using System;


namespace HotelBookingSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnManageRooms;
        private Button btnManageGuests;
        private Button btnMakeBooking;


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
            this.btnManageRooms = new System.Windows.Forms.Button();
            this.btnManageGuests = new System.Windows.Forms.Button();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.Location = new System.Drawing.Point(151, 97);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Size = new System.Drawing.Size(200, 98);
            this.btnManageRooms.TabIndex = 0;
            this.btnManageRooms.Text = "Manage Rooms";
            this.btnManageRooms.UseVisualStyleBackColor = true;
            this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
            // 
            // btnManageGuests
            // 
            this.btnManageGuests.Location = new System.Drawing.Point(151, 224);
            this.btnManageGuests.Name = "btnManageGuests";
            this.btnManageGuests.Size = new System.Drawing.Size(200, 98);
            this.btnManageGuests.TabIndex = 1;
            this.btnManageGuests.Text = "Manage Guests";
            this.btnManageGuests.UseVisualStyleBackColor = true;
            this.btnManageGuests.Click += new System.EventHandler(this.btnManageGuests_Click);
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(151, 352);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(200, 98);
            this.btnMakeBooking.TabIndex = 2;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(488, 525);
            this.Controls.Add(this.btnManageRooms);
            this.Controls.Add(this.btnManageGuests);
            this.Controls.Add(this.btnMakeBooking);
            this.Name = "MainForm";
            this.Text = "Hotel Booking System";
            this.ResumeLayout(false);

        }
    }
}

