using System;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
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
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.LeftArrowPagButton = new System.Windows.Forms.Button();
            this.RightArrowPagButton = new System.Windows.Forms.Button();
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
            this.TabAttendee.Size = new System.Drawing.Size(1321, 510);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
            this.TabAttendee.Click += new System.EventHandler(this.TabAttendee_Click_1);
            this.TabAttendee.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // AttendeeGridvw
            // 
            this.AttendeeGridvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttendeeGridvw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AttendeeGridvw.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.AttendeeGridvw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AttendeeGridvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeGridvw.Location = new System.Drawing.Point(3, 3);
            this.AttendeeGridvw.Name = "AttendeeGridvw";
            this.AttendeeGridvw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.AttendeeGridvw.Size = new System.Drawing.Size(1315, 504);
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
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Withdraw";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(456, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Attend";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TabOrganizer
            // 
            this.TabOrganizer.Controls.Add(this.NoConferenceLabel);
            this.TabOrganizer.Controls.Add(this.OrganizerDataGrid);
            this.TabOrganizer.Location = new System.Drawing.Point(4, 24);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(1321, 510);
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
            this.OrganizerDataGrid.Size = new System.Drawing.Size(1315, 504);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            this.OrganizerDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizerDataGrid_DataBindingComplete);
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Location = new System.Drawing.Point(12, 41);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1329, 538);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabOrganizer_SelectedIndexChanged);
            // 
            // AddConferenceButton
            // 
            this.AddConferenceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddConferenceButton.Location = new System.Drawing.Point(1188, 12);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(87, 47);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "Add a new conference";
            this.AddConferenceButton.UseVisualStyleBackColor = true;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(16, 12);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 23);
            this.StartDatePicker.TabIndex = 5;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.EndDatePicker.Location = new System.Drawing.Point(222, 12);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 23);
            this.EndDatePicker.TabIndex = 6;
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.Location = new System.Drawing.Point(0, 0);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(100, 23);
            this.EndDateLabel.TabIndex = 8;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(61, 42);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(99, 15);
            this.StartDateLabel.TabIndex = 8;
            this.StartDateLabel.Text = "Select a start date";
            // 
            // LeftArrowPagButton
            // 
            this.LeftArrowPagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftArrowPagButton.Location = new System.Drawing.Point(185, 585);
            this.LeftArrowPagButton.Name = "LeftArrowPagButton";
            this.LeftArrowPagButton.Size = new System.Drawing.Size(35, 39);
            this.LeftArrowPagButton.TabIndex = 7;
            this.LeftArrowPagButton.Text = "<";
            this.LeftArrowPagButton.UseVisualStyleBackColor = true;
            this.LeftArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftArrowPagButton_MouseClick);
            // 
            // RightArrowPagButton
            // 
            this.RightArrowPagButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RightArrowPagButton.Location = new System.Drawing.Point(1100, 585);
            this.RightArrowPagButton.Name = "RightArrowPagButton";
            this.RightArrowPagButton.Size = new System.Drawing.Size(34, 34);
            this.RightArrowPagButton.TabIndex = 8;
            this.RightArrowPagButton.Text = ">";
            this.RightArrowPagButton.UseVisualStyleBackColor = true;
            this.RightArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightArrowPagButton_MouseClick);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1353, 646);
            this.Controls.Add(this.RightArrowPagButton);
            this.Controls.Add(this.LeftArrowPagButton);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.AddConferenceButton);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        
 
       // private Button button6;
        //private Button button2;
        //private Button button1;
        private Label NoConferenceLabel;
        private DateTimePicker StartDatePicker;
        private Label StartDateLabel;
        private DateTimePicker EndDatePicker;
        private Label EndDateLabel;
        private DataGridView AttendeeGridvw;
        private Button button5;
        private Button button4;
        private Button button3;
        private ListBox listBox1;
        private Button LeftArrowPagButton;
        private Button RightArrowPagButton;
    }
}