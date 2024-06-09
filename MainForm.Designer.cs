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
        private Button btnManageBookings;


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
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnManageRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.Location = new System.Drawing.Point(0, 0);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Size = new System.Drawing.Size(75, 23);
            this.btnManageRooms.TabIndex = 0;
            // 
            // btnManageGuests
            // 
            this.btnManageGuests.Location = new System.Drawing.Point(80, 269);
            this.btnManageGuests.Name = "btnManageGuests";
            this.btnManageGuests.Size = new System.Drawing.Size(200, 98);
            this.btnManageGuests.TabIndex = 1;
            this.btnManageGuests.Text = "Manage Guests";
            this.btnManageGuests.UseVisualStyleBackColor = true;
            this.btnManageGuests.Click += new System.EventHandler(this.btnManageGuests_Click);
            // 
            // btnManageBookings
            // 
            this.btnManageBookings.Location = new System.Drawing.Point(375, 269);
            this.btnManageBookings.Name = "btnManageBookings";
            this.btnManageBookings.Size = new System.Drawing.Size(200, 98);
            this.btnManageBookings.TabIndex = 2;
            this.btnManageBookings.Text = "Manage Bookings";
            this.btnManageBookings.UseVisualStyleBackColor = true;
            this.btnManageBookings.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(124, 74);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(382, 133);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Welcome to the Hotel Booking System";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnManageRoom
            // 
            this.btnManageRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRoom.Location = new System.Drawing.Point(226, 402);
            this.btnManageRoom.Name = "btnManageRoom";
            this.btnManageRoom.Size = new System.Drawing.Size(200, 98);
            this.btnManageRoom.TabIndex = 4;
            this.btnManageRoom.Text = "Manage Rooms";
            this.btnManageRoom.UseVisualStyleBackColor = true;
            this.btnManageRoom.Click += new System.EventHandler(this.btnManageRoom_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(707, 525);
            this.Controls.Add(this.btnManageRoom);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnManageRooms);
            this.Controls.Add(this.btnManageGuests);
            this.Controls.Add(this.btnManageBookings);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Hotel Booking System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private RichTextBox richTextBox1;
        private Button btnManageRoom;
    }
}

