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
            this.btnManageGuests = new System.Windows.Forms.Button();
            this.btnManageBookings = new System.Windows.Forms.Button();
            this.btnManageRoom = new System.Windows.Forms.Button();
            this.lblHotelDescripion = new System.Windows.Forms.Label();
            this.btnUpdateDescription = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // lblHotelDescripion
            // 
            this.lblHotelDescripion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHotelDescripion.Location = new System.Drawing.Point(25, 32);
            this.lblHotelDescripion.Name = "lblHotelDescripion";
            this.lblHotelDescripion.Size = new System.Drawing.Size(462, 109);
            this.lblHotelDescripion.TabIndex = 5;
            this.lblHotelDescripion.Text = "label1";
            this.lblHotelDescripion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdateDescription
            // 
            this.btnUpdateDescription.Location = new System.Drawing.Point(345, 154);
            this.btnUpdateDescription.Name = "btnUpdateDescription";
            this.btnUpdateDescription.Size = new System.Drawing.Size(148, 41);
            this.btnUpdateDescription.TabIndex = 6;
            this.btnUpdateDescription.Text = "Update description";
            this.btnUpdateDescription.UseVisualStyleBackColor = true;
            this.btnUpdateDescription.Click += new System.EventHandler(this.btnUpdateDescription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblHotelDescripion);
            this.groupBox1.Controls.Add(this.btnUpdateDescription);
            this.groupBox1.Location = new System.Drawing.Point(107, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 216);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotel Description";
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
            this.ClientSize = new System.Drawing.Size(707, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "Hotel Booking System by Ahmed Radwan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private Button btnManageRoom;
        private Label lblHotelDescripion;
        private Button btnUpdateDescription;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}

