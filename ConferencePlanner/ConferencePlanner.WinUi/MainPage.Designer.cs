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
            this.OrganizersPaginationSelector = new System.Windows.Forms.ComboBox();
            this.NoConferenceLabel = new System.Windows.Forms.Label();
            this.OrganizerDataGrid = new System.Windows.Forms.DataGridView();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.LeftArrowPagButton = new System.Windows.Forms.Button();
            this.RightArrowPagButton = new System.Windows.Forms.Button();
            this.button_woc1 = new ePOSOne.btnProduct.Button_WOC();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.TabAttendee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).BeginInit();
            this.TabOrganizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).BeginInit();
            this.TabControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabAttendee
            // 
            this.TabAttendee.Controls.Add(this.AttendeeGridvw);
            this.TabAttendee.Controls.Add(this.button5);
            this.TabAttendee.Controls.Add(this.button4);
            this.TabAttendee.Controls.Add(this.button3);
            this.TabAttendee.Location = new System.Drawing.Point(4, 26);
            this.TabAttendee.Name = "TabAttendee";
            this.TabAttendee.Padding = new System.Windows.Forms.Padding(3);
            this.TabAttendee.Size = new System.Drawing.Size(1052, 396);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
            //this.TabAttendee.Click += new System.EventHandler(this.TabAttendee_Click_1);
            this.TabAttendee.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // AttendeeGridvw
            // 
            this.AttendeeGridvw.AllowUserToAddRows = false;
            this.AttendeeGridvw.AllowUserToDeleteRows = false;
            this.AttendeeGridvw.AllowUserToResizeRows = false;
            this.AttendeeGridvw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AttendeeGridvw.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.AttendeeGridvw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AttendeeGridvw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeGridvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttendeeGridvw.Location = new System.Drawing.Point(3, 3);
            this.AttendeeGridvw.Name = "AttendeeGridvw";
            this.AttendeeGridvw.ReadOnly = true;
            this.AttendeeGridvw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.AttendeeGridvw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AttendeeGridvw.Size = new System.Drawing.Size(1046, 390);
            this.AttendeeGridvw.TabIndex = 3;
            this.AttendeeGridvw.Text = "dataGridView1";
            this.AttendeeGridvw.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(619, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 26);
            this.button5.TabIndex = 5;
            this.button5.Text = "Join";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "Withdraw";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(456, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 3;
            this.button3.Text = "Attend";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TabOrganizer
            // 
            this.TabOrganizer.Controls.Add(this.OrganizersPaginationSelector);
            this.TabOrganizer.Controls.Add(this.NoConferenceLabel);
            this.TabOrganizer.Controls.Add(this.OrganizerDataGrid);
            this.TabOrganizer.Location = new System.Drawing.Point(4, 26);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(1052, 396);
            this.TabOrganizer.TabIndex = 1;
            this.TabOrganizer.Text = "Organizer";
            this.TabOrganizer.UseVisualStyleBackColor = true;
            // 
            // OrganizersPaginationSelector
            // 
            this.OrganizersPaginationSelector.FormattingEnabled = true;
            this.OrganizersPaginationSelector.Items.AddRange(new object[] {
            "5",
            "10",
            "25"});
            this.OrganizersPaginationSelector.Location = new System.Drawing.Point(495, 369);
            this.OrganizersPaginationSelector.Name = "OrganizersPaginationSelector";
            this.OrganizersPaginationSelector.Size = new System.Drawing.Size(121, 25);
            this.OrganizersPaginationSelector.TabIndex = 2;
            this.OrganizersPaginationSelector.DropDownClosed += new System.EventHandler(this.OrganizersPaginationSelector_DropDownClosed);
            // 
            // NoConferenceLabel
            // 
            this.NoConferenceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NoConferenceLabel.AutoSize = true;
            this.NoConferenceLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NoConferenceLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.NoConferenceLabel.Location = new System.Drawing.Point(367, 114);
            this.NoConferenceLabel.Name = "NoConferenceLabel";
            this.NoConferenceLabel.Size = new System.Drawing.Size(310, 54);
            this.NoConferenceLabel.TabIndex = 1;
            this.NoConferenceLabel.Text = "No conferences ";
            this.NoConferenceLabel.Visible = false;
            // 
            // OrganizerDataGrid
            // 
            this.OrganizerDataGrid.AllowUserToAddRows = false;
            this.OrganizerDataGrid.AllowUserToDeleteRows = false;
            this.OrganizerDataGrid.AllowUserToResizeRows = false;
            this.OrganizerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrganizerDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.OrganizerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizerDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.OrganizerDataGrid.Location = new System.Drawing.Point(3, 3);
            this.OrganizerDataGrid.Name = "OrganizerDataGrid";
            this.OrganizerDataGrid.ReadOnly = true;
            this.OrganizerDataGrid.Size = new System.Drawing.Size(1046, 360);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            this.OrganizerDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizerDataGrid_DataBindingComplete);
            this.OrganizerDataGrid.Layout += new System.Windows.Forms.LayoutEventHandler(this.OrganizerDataGrid_Layout);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(3, 113);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1060, 426);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabOrganizer_SelectedIndexChanged);
            // 
            // AddConferenceButton
            // 
            this.AddConferenceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddConferenceButton.Location = new System.Drawing.Point(832, 26);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(85, 53);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "Add a new conference";
            this.AddConferenceButton.UseVisualStyleBackColor = true;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(203, 78);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(138, 25);
            this.StartDatePicker.TabIndex = 5;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(347, 78);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(162, 25);
            this.EndDatePicker.TabIndex = 6;
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
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
            this.LeftArrowPagButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.LeftArrowPagButton.Location = new System.Drawing.Point(537, 3);
            this.LeftArrowPagButton.Name = "LeftArrowPagButton";
            this.LeftArrowPagButton.Size = new System.Drawing.Size(35, 31);
            this.LeftArrowPagButton.TabIndex = 7;
            this.LeftArrowPagButton.Text = "<";
            this.LeftArrowPagButton.UseVisualStyleBackColor = true;
            this.LeftArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftArrowPagButton_MouseClick);
            // 
            // RightArrowPagButton
            // 
            this.RightArrowPagButton.BackColor = System.Drawing.Color.Transparent;
            this.RightArrowPagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RightArrowPagButton.BackgroundImage")));
            this.RightArrowPagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RightArrowPagButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.RightArrowPagButton.FlatAppearance.BorderSize = 0;
            this.RightArrowPagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightArrowPagButton.Location = new System.Drawing.Point(576, 1);
            this.RightArrowPagButton.Margin = new System.Windows.Forms.Padding(1);
            this.RightArrowPagButton.Name = "RightArrowPagButton";
            this.RightArrowPagButton.Size = new System.Drawing.Size(30, 35);
            this.RightArrowPagButton.TabIndex = 8;
            this.RightArrowPagButton.UseCompatibleTextRendering = true;
            this.RightArrowPagButton.UseVisualStyleBackColor = false;
            this.RightArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightArrowPagButton_MouseClick);
            // 
            // button_woc1
            // 
            this.button_woc1.BackColor = System.Drawing.Color.Transparent;
            this.button_woc1.BorderColor = System.Drawing.Color.Red;
            this.button_woc1.ButtonColor = System.Drawing.Color.Red;
            this.button_woc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_woc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_woc1.Location = new System.Drawing.Point(634, 680);
            this.button_woc1.Name = "button_woc1";
            this.button_woc1.OnHoverBorderColor = System.Drawing.Color.Red;
            this.button_woc1.OnHoverButtonColor = System.Drawing.Color.Transparent;
            this.button_woc1.OnHoverTextColor = System.Drawing.Color.Snow;
            this.button_woc1.Size = new System.Drawing.Size(75, 26);
            this.button_woc1.TabIndex = 9;
            this.button_woc1.Text = "button_woc1";
            this.button_woc1.TextColor = System.Drawing.Color.White;
            this.button_woc1.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TabControl, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.31746F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.68254F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 583);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 374F));
            this.tableLayoutPanel2.Controls.Add(this.AddConferenceButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.EndDatePicker, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.StartDatePicker, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1062, 106);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.00928F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.99071F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 415F));
            this.tableLayoutPanel3.Controls.Add(this.LeftArrowPagButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.RightArrowPagButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 544);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1062, 37);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1066, 583);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_woc1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(915, 561);
            this.Name = "MainPage";
            this.Text = "MainForm";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            //this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabAttendee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).EndInit();
            this.TabOrganizer.ResumeLayout(false);
            this.TabOrganizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
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
        private DataGridView AttendeeGridvw;
        private Button button5;
        private Button button4;
        private Button button3;

        private Button LeftArrowPagButton;
        private Button RightArrowPagButton;
        private ePOSOne.btnProduct.Button_WOC button_woc1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox OrganizersPaginationSelector;
    }
}