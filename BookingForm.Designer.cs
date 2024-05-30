using System.Drawing;
using System.Windows.Forms;
using System;


namespace HotelBookingSystem
{
    partial class BookingForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbRoom;
        private ComboBox cmbGuest;
        private DateTimePicker dtpCheckInDate;
        private DateTimePicker dtpCheckOutDate;
        private ListBox lstBookings;
        private Button btnMakeBooking;
        private Button btnCancelBooking;


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
            this.cmbRoom = new System.Windows.Forms.ComboBox();
            this.cmbGuest = new System.Windows.Forms.ComboBox();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.lstBookings = new System.Windows.Forms.ListBox();
            this.btnMakeBooking = new System.Windows.Forms.Button();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(12, 12);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(533, 24);
            this.cmbRoom.TabIndex = 0;
            // 
            // cmbGuest
            // 
            this.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuest.FormattingEnabled = true;
            this.cmbGuest.Location = new System.Drawing.Point(12, 39);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(533, 24);
            this.cmbGuest.TabIndex = 1;
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(12, 66);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(533, 22);
            this.dtpCheckInDate.TabIndex = 2;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(12, 92);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(533, 22);
            this.dtpCheckOutDate.TabIndex = 3;
            // 
            // lstBookings
            // 
            this.lstBookings.FormattingEnabled = true;
            this.lstBookings.ItemHeight = 16;
            this.lstBookings.Location = new System.Drawing.Point(12, 118);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(533, 100);
            this.lstBookings.TabIndex = 4;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(12, 224);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(242, 43);
            this.btnMakeBooking.TabIndex = 5;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(304, 224);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(241, 43);
            this.btnCancelBooking.TabIndex = 6;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // BookingForm
            // 
            this.ClientSize = new System.Drawing.Size(557, 413);
            this.Controls.Add(this.btnCancelBooking);
            this.Controls.Add(this.btnMakeBooking);
            this.Controls.Add(this.lstBookings);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.cmbGuest);
            this.Controls.Add(this.cmbRoom);
            this.Name = "BookingForm";
            this.Text = "Booking";
            this.ResumeLayout(false);

        }
    }
}
