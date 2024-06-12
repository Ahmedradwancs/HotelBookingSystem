using System.Drawing;
using System.Windows.Forms;
using System;


namespace HotelBookingSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnManageGuests = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.btnManageRoom = new System.Windows.Forms.Button();
            this.lblHotelName = new System.Windows.Forms.Label();
            this.btnUpdateDetails = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.loc = new System.Windows.Forms.Label();
            this.lblHotelLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManageGuests
            // 
            this.btnManageGuests.Location = new System.Drawing.Point(31, 37);
            this.btnManageGuests.Name = "btnManageGuests";
            this.btnManageGuests.Size = new System.Drawing.Size(200, 98);
            this.btnManageGuests.TabIndex = 1;
            this.btnManageGuests.Text = "Manage Guests";
            this.btnManageGuests.UseVisualStyleBackColor = true;
            this.btnManageGuests.Click += new System.EventHandler(this.btnManageGuests_Click);
            // 
            // btnManageBookings
            // 
            this.btnManageBookings.Location = new System.Drawing.Point(293, 37);
            this.btnManageBookings.Name = "btnManageBookings";
            this.btnManageBookings.Size = new System.Drawing.Size(200, 98);
            this.btnManageBookings.TabIndex = 2;
            this.btnManageBookings.Text = "Manage Bookings";
            this.btnManageBookings.UseVisualStyleBackColor = true;
            this.btnManageBookings.Click += new System.EventHandler(this.btnMakeBooking_Click);
            // 
            // btnManageRoom
            // 
            this.btnManageRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRoom.Location = new System.Drawing.Point(163, 150);
            this.btnManageRoom.Name = "btnManageRoom";
            this.btnManageRoom.Size = new System.Drawing.Size(200, 98);
            this.btnManageRoom.TabIndex = 4;
            this.btnManageRoom.Text = "Manage Rooms";
            this.btnManageRoom.UseVisualStyleBackColor = true;
            this.btnManageRoom.Click += new System.EventHandler(this.btnManageRoom_Click);
            // 
            // lblHotelName
            // 
            this.lblHotelName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHotelName.Location = new System.Drawing.Point(241, 49);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Size = new System.Drawing.Size(252, 33);
            this.lblHotelName.TabIndex = 5;
            this.lblHotelName.Text = "Hotel Name";
            this.lblHotelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdateDetails
            // 
            this.btnUpdateDetails.Location = new System.Drawing.Point(345, 189);
            this.btnUpdateDetails.Name = "btnUpdateDetails";
            this.btnUpdateDetails.Size = new System.Drawing.Size(148, 41);
            this.btnUpdateDetails.TabIndex = 6;
            this.btnUpdateDetails.Text = "Update details";
            this.btnUpdateDetails.UseVisualStyleBackColor = true;
            this.btnUpdateDetails.Click += new System.EventHandler(this.btnUpdateDetails_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.loc);
            this.groupBox1.Controls.Add(this.lblHotelLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblHotelName);
            this.groupBox1.Controls.Add(this.btnUpdateDetails);
            this.groupBox1.Location = new System.Drawing.Point(107, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 236);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotel Details";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(51, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Number of rooms:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(241, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 33);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number of Rooms";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loc
            // 
            this.loc.BackColor = System.Drawing.SystemColors.Control;
            this.loc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.loc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loc.Location = new System.Drawing.Point(51, 96);
            this.loc.Name = "loc";
            this.loc.Size = new System.Drawing.Size(162, 33);
            this.loc.TabIndex = 9;
            this.loc.Text = "Location:";
            this.loc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHotelLocation
            // 
            this.lblHotelLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHotelLocation.Location = new System.Drawing.Point(241, 96);
            this.lblHotelLocation.Name = "lblHotelLocation";
            this.lblHotelLocation.Size = new System.Drawing.Size(252, 33);
            this.lblHotelLocation.TabIndex = 8;
            this.lblHotelLocation.Text = "Hotel Location";
            this.lblHotelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(51, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnManageGuests);
            this.groupBox2.Controls.Add(this.btnManageBookings);
            this.groupBox2.Controls.Add(this.btnManageRoom);
            this.groupBox2.Location = new System.Drawing.Point(107, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 263);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hotel Management";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(702, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Hotel Booking System by Ahmed Radwan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Button btnManageRoom;
        private Label lblHotelName;
        private Button btnUpdateDetails;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label4;
        private Label label5;
        private Label loc;
        private Label lblHotelLocation;
    }
}

