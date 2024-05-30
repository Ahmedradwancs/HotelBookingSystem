using System.Drawing;
using System.Windows.Forms;
using System;



namespace HotelBookingSystem
{
    partial class ManageGuestsForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtGuestID;
        private TextBox txtName;
        private TextBox txtContactInfo;
        private DateTimePicker dtpCheckInDate;
        private DateTimePicker dtpCheckOutDate;
        private ListBox lstGuests;
        private Button btnAddGuest;
        private Button btnRemoveGuest;
        private Button btnUpdateGuest;

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
            this.txtGuestID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContactInfo = new System.Windows.Forms.TextBox();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.lstGuests = new System.Windows.Forms.ListBox();
            this.btnAddGuest = new System.Windows.Forms.Button();
            this.btnRemoveGuest = new System.Windows.Forms.Button();
            this.btnUpdateGuest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtGuestID
            // 
            this.txtGuestID.Location = new System.Drawing.Point(12, 12);
            this.txtGuestID.Name = "txtGuestID";
            this.txtGuestID.Size = new System.Drawing.Size(269, 22);
            this.txtGuestID.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(269, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtContactInfo
            // 
            this.txtContactInfo.Location = new System.Drawing.Point(12, 64);
            this.txtContactInfo.Name = "txtContactInfo";
            this.txtContactInfo.Size = new System.Drawing.Size(269, 22);
            this.txtContactInfo.TabIndex = 2;
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.Location = new System.Drawing.Point(12, 90);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(369, 22);
            this.dtpCheckInDate.TabIndex = 3;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.Location = new System.Drawing.Point(12, 116);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(369, 22);
            this.dtpCheckOutDate.TabIndex = 4;
            // 
            // lstGuests
            // 
            this.lstGuests.FormattingEnabled = true;
            this.lstGuests.ItemHeight = 16;
            this.lstGuests.Location = new System.Drawing.Point(12, 142);
            this.lstGuests.Name = "lstGuests";
            this.lstGuests.Size = new System.Drawing.Size(369, 132);
            this.lstGuests.TabIndex = 5;
            // 
            // btnAddGuest
            // 
            this.btnAddGuest.Location = new System.Drawing.Point(306, 12);
            this.btnAddGuest.Name = "btnAddGuest";
            this.btnAddGuest.Size = new System.Drawing.Size(75, 23);
            this.btnAddGuest.TabIndex = 6;
            this.btnAddGuest.Text = "Add Guest";
            this.btnAddGuest.UseVisualStyleBackColor = true;
            this.btnAddGuest.Click += new System.EventHandler(this.btnAddGuest_Click);
            // 
            // btnRemoveGuest
            // 
            this.btnRemoveGuest.Location = new System.Drawing.Point(306, 38);
            this.btnRemoveGuest.Name = "btnRemoveGuest";
            this.btnRemoveGuest.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveGuest.TabIndex = 7;
            this.btnRemoveGuest.Text = "Remove Guest";
            this.btnRemoveGuest.UseVisualStyleBackColor = true;
            this.btnRemoveGuest.Click += new System.EventHandler(this.btnRemoveGuest_Click);
            // 
            // btnUpdateGuest
            // 
            this.btnUpdateGuest.Location = new System.Drawing.Point(306, 64);
            this.btnUpdateGuest.Name = "btnUpdateGuest";
            this.btnUpdateGuest.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateGuest.TabIndex = 8;
            this.btnUpdateGuest.Text = "Update Guest";
            this.btnUpdateGuest.UseVisualStyleBackColor = true;
            this.btnUpdateGuest.Click += new System.EventHandler(this.btnUpdateGuest_Click);
            // 
            // ManageGuestsForm
            // 
            this.ClientSize = new System.Drawing.Size(493, 401);
            this.Controls.Add(this.btnUpdateGuest);
            this.Controls.Add(this.btnRemoveGuest);
            this.Controls.Add(this.btnAddGuest);
            this.Controls.Add(this.lstGuests);
            this.Controls.Add(this.dtpCheckOutDate);
            this.Controls.Add(this.dtpCheckInDate);
            this.Controls.Add(this.txtContactInfo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtGuestID);
            this.Name = "ManageGuestsForm";
            this.Text = "Manage Guests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
