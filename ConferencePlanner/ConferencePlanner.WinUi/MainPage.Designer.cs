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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TabAttendee = new System.Windows.Forms.TabPage();
            this.TabOrganizer = new System.Windows.Forms.TabPage();
            this.NoConferenceLabel = new System.Windows.Forms.Label();
            this.OrganizerDataGrid = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AttendeeGridView = new System.Windows.Forms.DataGridView();
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.TabOrganizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).BeginInit();
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
            this.button3.Click += new System.EventHandler(this.Attend_Click);
            // 
            // TabAttendee
            // 
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
            this.TabOrganizer.Controls.Add(this.NoConferenceLabel);
            this.TabOrganizer.Controls.Add(this.OrganizerDataGrid);
            this.TabOrganizer.Location = new System.Drawing.Point(4, 24);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(724, 283);
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
            // organizerDataGrid
            // 
            this.OrganizerDataGrid.AllowUserToOrderColumns = true;
            this.OrganizerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizerDataGrid.Location = new System.Drawing.Point(3, 3);
            this.OrganizerDataGrid.Name = "organizerDataGrid";
            this.OrganizerDataGrid.Size = new System.Drawing.Size(718, 277);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Location = new System.Drawing.Point(42, 67);
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
            this.AddConferenceButton.Location = new System.Drawing.Point(666, 37);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(75, 23);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "AddConf";
            this.AddConferenceButton.UseVisualStyleBackColor = true;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddConferenceButton);
            this.Controls.Add(this.TabControl);
            this.Name = "MainPage";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabOrganizer.ResumeLayout(false);
            this.TabOrganizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).EndInit();
            this.TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView AttendeeGridView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private Label NoConferenceLabel;
    }
}