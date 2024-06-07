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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.btnManageGuests.Location = new System.Drawing.Point(74, 300);
            this.btnManageGuests.Name = "btnManageGuests";
            this.btnManageGuests.Size = new System.Drawing.Size(200, 98);
            this.btnManageGuests.TabIndex = 1;
            this.btnManageGuests.Text = "Manage Guests";
            this.btnManageGuests.UseVisualStyleBackColor = true;
            this.btnManageGuests.Click += new System.EventHandler(this.btnManageGuests_Click);
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(350, 300);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(200, 98);
            this.btnMakeBooking.TabIndex = 2;
            this.btnMakeBooking.Text = "Manage Bookings";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(124, 74);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(382, 207);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Welcome to the Hotel Booking System";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(707, 525);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnManageRooms);
            this.Controls.Add(this.btnManageGuests);
            this.Controls.Add(this.btnMakeBooking);
            this.Name = "MainForm";
            this.Text = "Hotel Booking System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        private RichTextBox richTextBox1;
    }
}

