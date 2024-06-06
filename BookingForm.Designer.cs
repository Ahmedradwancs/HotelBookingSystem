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
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.groupBoxGuest = new System.Windows.Forms.GroupBox();
            this.btnCreateGuest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.money = new System.Windows.Forms.Button();
            this.groupBoxGuest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRoom
            // 
            this.cmbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoom.FormattingEnabled = true;
            this.cmbRoom.Location = new System.Drawing.Point(138, 212);
            this.cmbRoom.Name = "cmbRoom";
            this.cmbRoom.Size = new System.Drawing.Size(374, 24);
            this.cmbRoom.TabIndex = 0;
            // 
            // cmbGuest
            // 
            this.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuest.FormattingEnabled = true;
            this.cmbGuest.Location = new System.Drawing.Point(117, 33);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(204, 24);
            this.cmbGuest.TabIndex = 1;
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(138, 248);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(374, 22);
            this.dtpCheckInDate.TabIndex = 2;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(138, 286);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(374, 22);
            this.dtpCheckOutDate.TabIndex = 3;
            // 
            // lstBookings
            // 
            this.lstBookings.FormattingEnabled = true;
            this.lstBookings.ItemHeight = 16;
            this.lstBookings.Location = new System.Drawing.Point(618, 24);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(428, 420);
            this.lstBookings.TabIndex = 4;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(6, 421);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(242, 43);
            this.btnMakeBooking.TabIndex = 5;
            this.btnMakeBooking.Text = "Make Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(271, 421);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(241, 43);
            this.btnCancelBooking.TabIndex = 6;
            this.btnCancelBooking.Text = "Cancel Booking";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Location = new System.Drawing.Point(16, 33);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(95, 23);
            this.btnAddGuest.TabIndex = 7;
            this.btnAddGuest.Text = "Guests list";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Check Out date";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "Check In date";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 33);
            this.button3.TabIndex = 10;
            this.button3.Text = "Room Type";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(6, 155);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(506, 34);
            this.btnName.TabIndex = 11;
            this.btnName.Text = "Guest Name";
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // groupBoxGuest
            // 
            this.groupBoxGuest.Controls.Add(this.btnCreateGuest);
            this.groupBoxGuest.Controls.Add(this.btnAddGuest);
            this.groupBoxGuest.Controls.Add(this.cmbGuest);
            this.groupBoxGuest.Location = new System.Drawing.Point(6, 50);
            this.groupBoxGuest.Name = "groupBoxGuest";
            this.groupBoxGuest.Size = new System.Drawing.Size(506, 76);
            this.groupBoxGuest.TabIndex = 12;
            this.groupBoxGuest.TabStop = false;
            this.groupBoxGuest.Text = "Choose from guests list or click manage guests create a new guest";
            // 
            // btnCreateGuest
            // 
            this.btnCreateGuest.Location = new System.Drawing.Point(336, 33);
            this.btnCreateGuest.Name = "btnCreateGuest";
            this.btnCreateGuest.Size = new System.Drawing.Size(167, 24);
            this.btnCreateGuest.TabIndex = 13;
            this.btnCreateGuest.Text = "Manage guests";
            this.btnCreateGuest.UseVisualStyleBackColor = true;
            this.btnCreateGuest.Click += new System.EventHandler(this.btnCreateGuest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.money);
            this.groupBox1.Controls.Add(this.dtpCheckOutDate);
            this.groupBox1.Controls.Add(this.btnName);
            this.groupBox1.Controls.Add(this.groupBoxGuest);
            this.groupBox1.Controls.Add(this.cmbRoom);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.dtpCheckInDate);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnMakeBooking);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnCancelBooking);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 502);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking details";
            // 
            // money
            // 
            this.money.Location = new System.Drawing.Point(6, 347);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(506, 30);
            this.money.TabIndex = 13;
            this.money.Text = "Total amount to pay";
            this.money.UseVisualStyleBackColor = true;
            // 
            // BookingForm
            // 
            this.ClientSize = new System.Drawing.Size(1146, 579);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstBookings);
            this.Name = "BookingForm";
            this.Text = "Booking";
            this.groupBoxGuest.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Button btnAddGuest;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btnName;
        private GroupBox groupBoxGuest;
        private Button btnCreateGuest;
        private GroupBox groupBox1;
        private Button money;
    }
}
