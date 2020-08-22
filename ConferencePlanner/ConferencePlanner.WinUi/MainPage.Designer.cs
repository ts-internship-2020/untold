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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TabAttendee = new System.Windows.Forms.TabPage();
            this.TabOrganizer = new System.Windows.Forms.TabPage();
            this.organizerDataGrid = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AttendeeGridView = new System.Windows.Forms.DataGridView();
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLable = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TabAttendee.SuspendLayout();
            this.TabOrganizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.organizerDataGrid)).BeginInit();
            this.TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(646, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Withdrawn";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(548, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Join";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Attend";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TabAttendee
            // 
            this.TabAttendee.Controls.Add(this.button6);
            this.TabAttendee.Controls.Add(this.button2);
            this.TabAttendee.Controls.Add(this.button1);
            this.TabAttendee.Location = new System.Drawing.Point(4, 24);
            this.TabAttendee.Name = "TabAttendee";
            this.TabAttendee.Padding = new System.Windows.Forms.Padding(3);
            this.TabAttendee.Size = new System.Drawing.Size(724, 283);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
            // 
            // TabOrganizer
            // 
            this.TabOrganizer.Controls.Add(this.organizerDataGrid);
            this.TabOrganizer.Location = new System.Drawing.Point(4, 24);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(724, 283);
            this.TabOrganizer.TabIndex = 1;
            this.TabOrganizer.Text = "Organizer";
            this.TabOrganizer.UseVisualStyleBackColor = true;
            // 
            // organizerDataGrid
            // 
            this.organizerDataGrid.AllowUserToOrderColumns = true;
            this.organizerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.organizerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.organizerDataGrid.Location = new System.Drawing.Point(3, 3);
            this.organizerDataGrid.Name = "organizerDataGrid";
            this.organizerDataGrid.Size = new System.Drawing.Size(718, 277);
            this.organizerDataGrid.TabIndex = 0;
            this.organizerDataGrid.Text = "organizerDataGrid";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Location = new System.Drawing.Point(46, 135);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(732, 311);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabOrganizer_SelectedIndexChanged);
            // 
            // AttendeeGridView
            // 
            this.AttendeeGridView.AllowUserToOrderColumns = true;
            this.AttendeeGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.AttendeeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeGridView.GridColor = System.Drawing.SystemColors.MenuText;
            this.AttendeeGridView.Location = new System.Drawing.Point(3, 3);
            this.AttendeeGridView.Name = "AttendeeGridView";
            this.AttendeeGridView.Size = new System.Drawing.Size(645, 277);
            this.AttendeeGridView.TabIndex = 0;
            this.AttendeeGridView.Text = "AttendeeGridView";
            // 
            // AddConferenceButton
            // 
            this.AddConferenceButton.Location = new System.Drawing.Point(691, 69);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(83, 48);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "Add New Conference";
            this.AddConferenceButton.UseVisualStyleBackColor = true;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(50, 69);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(199, 23);
            this.StartDateTimePicker.TabIndex = 5;
            this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(255, 69);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.EndDateTimePicker.TabIndex = 6;
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
            // AttendButton
            // 
            this.button1.Location = new System.Drawing.Point(458, 39);
            this.button1.Name = "AttendButton";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Attend";
            this.button1.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // 
            // JoinButton
            // 
            this.button2.Location = new System.Drawing.Point(539, 39);
            this.button2.Name = "Join";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Join";
            this.button2.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.JoinButton_Click);

            // 
            // WithdrawnButton
            // 
            this.button6.Location = new System.Drawing.Point(621, 39);
            this.button6.Name = "Withdrawn";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Withdrawn";
            this.button6.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);

            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 482);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLable);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.AddConferenceButton);
            this.Controls.Add(this.TabControl);
            this.Name = "MainPage";
            this.Text = "Conference Planner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabAttendee.ResumeLayout(false);
            this.TabOrganizer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.organizerDataGrid)).EndInit();
            this.TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabAttendee;
        private System.Windows.Forms.TabPage TabOrganizer;
        private System.Windows.Forms.Button AddConferenceButton;
        private System.Windows.Forms.DataGridView organizerDataGrid;
        private System.Windows.Forms.DataGridView AttendeeGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private DateTimePicker StartDateTimePicker;
        private DateTimePicker EndDateTimePicker;
        private Label StartDateLable;
        private Label EndDateLabel;
        private Button button6;
        private Button button2;
        private Button button1;
    }
}