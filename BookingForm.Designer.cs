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
        private Button btnDeleteBooking;


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
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.groupBoxGuest = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnUpdateBooking = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.cmbRoom.Size = new System.Drawing.Size(568, 24);
            this.cmbRoom.TabIndex = 0;
            // 
            // cmbGuest
            // 
            this.cmbGuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuest.FormattingEnabled = true;
            this.cmbGuest.Location = new System.Drawing.Point(191, 33);
            this.cmbGuest.Name = "cmbGuest";
            this.cmbGuest.Size = new System.Drawing.Size(479, 24);
            this.cmbGuest.TabIndex = 1;
            this.cmbGuest.SelectedIndexChanged += new System.EventHandler(this.cmbGuest_SelectedIndexChanged);
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(138, 248);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(568, 22);
            this.dtpCheckInDate.TabIndex = 2;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(138, 286);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(568, 22);
            this.dtpCheckOutDate.TabIndex = 3;
            // 
            // lstBookings
            // 
            this.lstBookings.FormattingEnabled = true;
            this.lstBookings.ItemHeight = 16;
            this.lstBookings.Location = new System.Drawing.Point(12, 591);
            this.lstBookings.Name = "lstBookings";
            this.lstBookings.Size = new System.Drawing.Size(621, 196);
            this.lstBookings.TabIndex = 4;
            // 
            // btnMakeBooking
            // 
            this.btnMakeBooking.Location = new System.Drawing.Point(406, 417);
            this.btnMakeBooking.Name = "btnMakeBooking";
            this.btnMakeBooking.Size = new System.Drawing.Size(215, 43);
            this.btnMakeBooking.TabIndex = 5;
            this.btnMakeBooking.Text = "Confirm Booking";
            this.btnMakeBooking.UseVisualStyleBackColor = true;
            this.btnMakeBooking.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBooking.Location = new System.Drawing.Point(639, 627);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(129, 43);
            this.btnDeleteBooking.TabIndex = 6;
            this.btnDeleteBooking.Text = "Delete Booking";
            this.btnDeleteBooking.UseVisualStyleBackColor = true;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Location = new System.Drawing.Point(50, 27);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(110, 37);
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
            this.btnName.Size = new System.Drawing.Size(700, 34);
            this.btnName.TabIndex = 11;
            this.btnName.Text = "Guest Name";
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // groupBoxGuest
            // 
            this.groupBoxGuest.Controls.Add(this.btnAddGuest);
            this.groupBoxGuest.Controls.Add(this.cmbGuest);
            this.groupBoxGuest.Location = new System.Drawing.Point(6, 50);
            this.groupBoxGuest.Name = "groupBoxGuest";
            this.groupBoxGuest.Size = new System.Drawing.Size(700, 76);
            this.groupBoxGuest.TabIndex = 12;
            this.groupBoxGuest.TabStop = false;
            this.groupBoxGuest.Text = "Choose from guests list or go back and register the guest if not found";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.lblMoney);
            this.groupBox1.Controls.Add(this.dtpCheckOutDate);
            this.groupBox1.Controls.Add(this.btnName);
            this.groupBox1.Controls.Add(this.groupBoxGuest);
            this.groupBox1.Controls.Add(this.cmbRoom);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.dtpCheckInDate);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnMakeBooking);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 502);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking details";
            // 
            // lblMoney
            // 
            this.lblMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoney.Location = new System.Drawing.Point(77, 341);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(544, 50);
            this.lblMoney.TabIndex = 13;
            this.lblMoney.Text = "Total amount to pay";
            this.lblMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 36);
            this.label1.TabIndex = 14;
            this.label1.Text = "Booking List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(98, 567);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 24);
            this.button4.TabIndex = 15;
            this.button4.Text = "Room No.";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(461, 567);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 22);
            this.button5.TabIndex = 16;
            this.button5.Text = "No. of nights";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(372, 567);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 23);
            this.button6.TabIndex = 17;
            this.button6.Text = "Check out";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(288, 568);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 22);
            this.button7.TabIndex = 18;
            this.button7.Text = "Check in";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(192, 567);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 24);
            this.button8.TabIndex = 19;
            this.button8.Text = "Guest Name";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 567);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(83, 24);
            this.button9.TabIndex = 20;
            this.button9.Text = "Booking ID";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(555, 567);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(78, 23);
            this.button10.TabIndex = 21;
            this.button10.Text = "Total cost";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnUpdateBooking
            // 
            this.btnUpdateBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBooking.Location = new System.Drawing.Point(639, 694);
            this.btnUpdateBooking.Name = "btnUpdateBooking";
            this.btnUpdateBooking.Size = new System.Drawing.Size(129, 43);
            this.btnUpdateBooking.TabIndex = 22;
            this.btnUpdateBooking.Text = "Update Booking";
            this.btnUpdateBooking.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(77, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(214, 43);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BookingForm
            // 
            this.ClientSize = new System.Drawing.Size(787, 799);
            this.Controls.Add(this.btnUpdateBooking);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstBookings);
            this.Controls.Add(this.btnDeleteBooking);
            this.Name = "BookingForm";
            this.Text = "Booking";
            this.Load += new System.EventHandler(this.BookingForm_Load);
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
        private GroupBox groupBox1;
        private Label label1;
        private Label lblMoney;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button btnUpdateBooking;
        private Button btnCancel;
    }
}
