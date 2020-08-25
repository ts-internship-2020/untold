﻿using System;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabAttendee = new System.Windows.Forms.TabPage();
            this.AttendeeGridvw = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TabOrganizer = new System.Windows.Forms.TabPage();
            this.NoConferenceLabel = new System.Windows.Forms.Label();
            this.OrganizerDataGrid = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLable = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLable = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.TabAttendee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).BeginInit();
            this.TabOrganizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).BeginInit();
            this.TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabAttendee
            // 
            this.TabAttendee.Controls.Add(this.AttendeeGridvw);
            this.TabAttendee.Controls.Add(this.button5);
            this.TabAttendee.Controls.Add(this.button4);
            this.TabAttendee.Controls.Add(this.button3);
            this.TabAttendee.Location = new System.Drawing.Point(4, 24);
            this.TabAttendee.Name = "TabAttendee";
            this.TabAttendee.Padding = new System.Windows.Forms.Padding(3);
            this.TabAttendee.Size = new System.Drawing.Size(792, 310);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
            this.TabAttendee.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // AttendeeGridvw
            // 
            this.AttendeeGridvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttendeeGridvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeGridvw.Location = new System.Drawing.Point(3, 65);
            this.AttendeeGridvw.Name = "AttendeeGridvw";
            this.AttendeeGridvw.Size = new System.Drawing.Size(786, 242);
            this.AttendeeGridvw.TabIndex = 3;
            this.AttendeeGridvw.Text = "dataGridView1";
            this.AttendeeGridvw.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(619, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Join";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Join_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Withdraw";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Withdraw_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(456, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Attend";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Attend_Click);
            // 
            // TabOrganizer
            // 
            this.TabOrganizer.Controls.Add(this.NoConferenceLabel);
            this.TabOrganizer.Controls.Add(this.OrganizerDataGrid);
            this.TabOrganizer.Location = new System.Drawing.Point(4, 24);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(792, 310);
            this.TabOrganizer.TabIndex = 1;
            this.TabOrganizer.Text = "Organizer";
            this.TabOrganizer.UseVisualStyleBackColor = true;
            // 
            // NoConferenceLabel
            // 
            this.NoConferenceLabel.AutoSize = true;
            this.NoConferenceLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoConferenceLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.NoConferenceLabel.Location = new System.Drawing.Point(201, 94);
            this.NoConferenceLabel.Name = "NoConferenceLabel";
            this.NoConferenceLabel.Size = new System.Drawing.Size(310, 54);
            this.NoConferenceLabel.TabIndex = 1;
            this.NoConferenceLabel.Text = "No conferences ";
            this.NoConferenceLabel.Visible = false;
            // 
            // OrganizerDataGrid
            // 
            this.OrganizerDataGrid.AllowUserToOrderColumns = true;
            this.OrganizerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizerDataGrid.Location = new System.Drawing.Point(3, 3);
            this.OrganizerDataGrid.Name = "OrganizerDataGrid";
            this.OrganizerDataGrid.Size = new System.Drawing.Size(786, 304);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            this.OrganizerDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizerDataGrid_DataBindingComplete);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Location = new System.Drawing.Point(179, 130);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(800, 338);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabOrganizer_SelectedIndexChanged);
            // 
            // AddConferenceButton
            // 
            this.AddConferenceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddConferenceButton.Location = new System.Drawing.Point(814, 51);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(87, 47);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "Add a new conference";
            this.AddConferenceButton.UseVisualStyleBackColor = true;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.StartDateTimePicker.TabIndex = 0;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.EndDateTimePicker.TabIndex = 0;
            // 
            // StartDateLable
            // 
            this.StartDateLable.AutoSize = true;
            this.StartDateLable.Location = new System.Drawing.Point(50, 36);
            this.StartDateLable.Name = "StartDateLable";
            this.StartDateLable.Size = new System.Drawing.Size(92, 15);
            this.StartDateLable.TabIndex = 7;
            this.StartDateLable.Text = "Select Start Date";
            this.StartDateLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(255, 36);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(88, 15);
            this.EndDateLabel.TabIndex = 8;
            this.EndDateLabel.Text = "Select End Date";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(179, 75);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(202, 23);
            this.StartDatePicker.TabIndex = 5;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EndDatePicker.Location = new System.Drawing.Point(425, 75);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(202, 23);
            this.EndDatePicker.TabIndex = 6;
            // 
            // EndDateLable
            // 
            this.EndDateLable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EndDateLable.AutoSize = true;
            this.EndDateLable.Location = new System.Drawing.Point(425, 51);
            this.EndDateLable.Name = "EndDateLable";
            this.EndDateLable.Size = new System.Drawing.Size(103, 15);
            this.EndDateLable.TabIndex = 7;
            this.EndDateLable.Text = "Select an end date";
            this.EndDateLable.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(179, 51);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(99, 15);
            this.StartDateLabel.TabIndex = 8;
            this.StartDateLabel.Text = "Select a start date";
            this.StartDateLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 479);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.EndDateLable);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.AddConferenceButton);
            this.Controls.Add(this.TabControl);
            this.MinimumSize = new System.Drawing.Size(915, 500);
            this.Name = "MainPage";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabAttendee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).EndInit();
            this.TabOrganizer.ResumeLayout(false);
            this.TabOrganizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabAttendee;
        private System.Windows.Forms.TabPage TabOrganizer;
        private System.Windows.Forms.Button AddConferenceButton;
        private System.Windows.Forms.DataGridView OrganizerDataGrid;
        //private System.Windows.Forms.DataGridView AttendeeGridView;
        private DateTimePicker StartDateTimePicker;
        private DateTimePicker EndDateTimePicker;
        private Label StartDateLable;
        private Label EndDateLabel;
       // private Button button6;
        //private Button button2;
        //private Button button1;
        private Label NoConferenceLabel;
        private DateTimePicker StartDatePicker;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label StartDateLabel;
        private DateTimePicker EndDatePicker;
        private Label EndDateLable;
        private DataGridView AttendeeGridvw;
        private Button button5;
        private Button button4;
        private Button button3;
    }
}