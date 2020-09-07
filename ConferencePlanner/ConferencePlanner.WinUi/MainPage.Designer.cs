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
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabAttendee = new System.Windows.Forms.TabPage();
            this.AttendeeGridvw = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TabOrganizer = new System.Windows.Forms.TabPage();
            this.OrganizersPaginationSelector = new System.Windows.Forms.ComboBox();
            this.NoConferenceLabel = new System.Windows.Forms.Label();
            this.OrganizerDataGrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LeftArrowPagButton = new System.Windows.Forms.Button();
            this.RightArrowPagButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PanelFilter = new System.Windows.Forms.Panel();
            this.PanelAnc = new System.Windows.Forms.Panel();
            this.PanelOrganizer = new System.Windows.Forms.Panel();
            this.FilterByDate = new System.Windows.Forms.Button();
            this.OrganizerButton = new System.Windows.Forms.Button();
            this.PanelAttendee = new System.Windows.Forms.Panel();
            this.AttendeeButtonFP = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabControl.SuspendLayout();
            this.TabAttendee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).BeginInit();
            this.TabOrganizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(61, 42);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(99, 15);
            this.StartDateLabel.TabIndex = 8;
            this.StartDateLabel.Text = "Select a start date";
            this.StartDateLabel.Visible = false;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(3, 136);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(997, 518);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabOrganizer_SelectedIndexChanged);
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
            this.TabAttendee.Size = new System.Drawing.Size(989, 488);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
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
            this.AttendeeGridvw.Size = new System.Drawing.Size(983, 482);
            this.AttendeeGridvw.TabIndex = 3;
            this.AttendeeGridvw.Text = "dataGridView1";
            this.AttendeeGridvw.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AttendeeGridvw_DataBindingComplete);
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
            this.TabOrganizer.Size = new System.Drawing.Size(989, 488);
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
            this.OrganizerDataGrid.Size = new System.Drawing.Size(983, 360);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            this.OrganizerDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizerDataGrid_DataBindingComplete);
            this.OrganizerDataGrid.Layout += new System.Windows.Forms.LayoutEventHandler(this.OrganizerDataGrid_Layout);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.8421F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.1579F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.tableLayoutPanel3.Controls.Add(this.LeftArrowPagButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.RightArrowPagButton, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(117, 659);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(769, 57);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // LeftArrowPagButton
            // 
            this.LeftArrowPagButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LeftArrowPagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeftArrowPagButton.BackgroundImage")));
            this.LeftArrowPagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LeftArrowPagButton.FlatAppearance.BorderSize = 0;
            this.LeftArrowPagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftArrowPagButton.Location = new System.Drawing.Point(339, 8);
            this.LeftArrowPagButton.Name = "LeftArrowPagButton";
            this.LeftArrowPagButton.Size = new System.Drawing.Size(40, 40);
            this.LeftArrowPagButton.TabIndex = 7;
            this.LeftArrowPagButton.UseVisualStyleBackColor = true;
            this.LeftArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftArrowPagButton_MouseClick);
            this.LeftArrowPagButton.MouseEnter += new System.EventHandler(this.LeftArrowPagButton_MouseEnter);
            this.LeftArrowPagButton.MouseLeave += new System.EventHandler(this.LeftArrowPagButton_MouseLeave);
            // 
            // RightArrowPagButton
            // 
            this.RightArrowPagButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RightArrowPagButton.BackColor = System.Drawing.Color.Transparent;
            this.RightArrowPagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RightArrowPagButton.BackgroundImage")));
            this.RightArrowPagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RightArrowPagButton.FlatAppearance.BorderSize = 0;
            this.RightArrowPagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightArrowPagButton.Location = new System.Drawing.Point(383, 8);
            this.RightArrowPagButton.Margin = new System.Windows.Forms.Padding(1);
            this.RightArrowPagButton.Name = "RightArrowPagButton";
            this.RightArrowPagButton.Size = new System.Drawing.Size(40, 40);
            this.RightArrowPagButton.TabIndex = 8;
            this.RightArrowPagButton.UseCompatibleTextRendering = true;
            this.RightArrowPagButton.UseVisualStyleBackColor = false;
            this.RightArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightArrowPagButton_MouseClick);
            this.RightArrowPagButton.MouseEnter += new System.EventHandler(this.RightArrowPagButton_MouseEnter);
            this.RightArrowPagButton.MouseLeave += new System.EventHandler(this.RightArrowPagButton_MouseLeave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 377F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(999, 129);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // AddConferenceButton
            // 
            this.AddConferenceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddConferenceButton.BackColor = System.Drawing.Color.Transparent;
            this.AddConferenceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddConferenceButton.BackgroundImage")));
            this.AddConferenceButton.FlatAppearance.BorderSize = 0;
            this.AddConferenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddConferenceButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddConferenceButton.ForeColor = System.Drawing.Color.White;
            this.AddConferenceButton.Image = ((System.Drawing.Image)(resources.GetObject("AddConferenceButton.Image")));
            this.AddConferenceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddConferenceButton.Location = new System.Drawing.Point(47, 237);
            this.AddConferenceButton.Name = "AddConferenceButton";
            this.AddConferenceButton.Size = new System.Drawing.Size(237, 59);
            this.AddConferenceButton.TabIndex = 4;
            this.AddConferenceButton.Text = "      Add a new        conference";
            this.AddConferenceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddConferenceButton.UseVisualStyleBackColor = false;
            this.AddConferenceButton.Click += new System.EventHandler(this.AddConferenceButton_Click);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(81, 492);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(162, 25);
            this.EndDatePicker.TabIndex = 6;
            this.EndDatePicker.Visible = false;
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(81, 444);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(162, 25);
            this.StartDatePicker.TabIndex = 5;
            this.StartDatePicker.Visible = false;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TabControl, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(337, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.31746F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.68254F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 718);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(1345, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(74, 792);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.PanelFilter);
            this.panel2.Controls.Add(this.PanelAnc);
            this.panel2.Controls.Add(this.PanelOrganizer);
            this.panel2.Controls.Add(this.FilterByDate);
            this.panel2.Controls.Add(this.OrganizerButton);
            this.panel2.Controls.Add(this.PanelAttendee);
            this.panel2.Controls.Add(this.AddConferenceButton);
            this.panel2.Controls.Add(this.EndDatePicker);
            this.panel2.Controls.Add(this.AttendeeButtonFP);
            this.panel2.Controls.Add(this.StartDatePicker);
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 632);
            this.panel2.TabIndex = 12;
            // 
            // PanelFilter
            // 
            this.PanelFilter.BackColor = System.Drawing.Color.Indigo;
            this.PanelFilter.Location = new System.Drawing.Point(61, 417);
            this.PanelFilter.Name = "PanelFilter";
            this.PanelFilter.Size = new System.Drawing.Size(210, 10);
            this.PanelFilter.TabIndex = 7;
            this.PanelFilter.Visible = false;
            // 
            // PanelAnc
            // 
            this.PanelAnc.BackColor = System.Drawing.Color.Indigo;
            this.PanelAnc.Location = new System.Drawing.Point(61, 302);
            this.PanelAnc.Name = "PanelAnc";
            this.PanelAnc.Size = new System.Drawing.Size(210, 10);
            this.PanelAnc.TabIndex = 7;
            this.PanelAnc.Visible = false;
            // 
            // PanelOrganizer
            // 
            this.PanelOrganizer.BackColor = System.Drawing.Color.Indigo;
            this.PanelOrganizer.Location = new System.Drawing.Point(61, 195);
            this.PanelOrganizer.Name = "PanelOrganizer";
            this.PanelOrganizer.Size = new System.Drawing.Size(210, 10);
            this.PanelOrganizer.TabIndex = 7;
            this.PanelOrganizer.Visible = false;
            // 
            // FilterByDate
            // 
            this.FilterByDate.BackColor = System.Drawing.Color.Transparent;
            this.FilterByDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FilterByDate.BackgroundImage")));
            this.FilterByDate.FlatAppearance.BorderSize = 0;
            this.FilterByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterByDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterByDate.ForeColor = System.Drawing.Color.White;
            this.FilterByDate.Image = ((System.Drawing.Image)(resources.GetObject("FilterByDate.Image")));
            this.FilterByDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FilterByDate.Location = new System.Drawing.Point(47, 352);
            this.FilterByDate.Name = "FilterByDate";
            this.FilterByDate.Size = new System.Drawing.Size(237, 59);
            this.FilterByDate.TabIndex = 0;
            this.FilterByDate.Text = "      Filter by Date";
            this.FilterByDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FilterByDate.UseVisualStyleBackColor = false;
            this.FilterByDate.Click += new System.EventHandler(this.FIlterByDate_Click);
            // 
            // OrganizerButton
            // 
            this.OrganizerButton.BackColor = System.Drawing.Color.Transparent;
            this.OrganizerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OrganizerButton.BackgroundImage")));
            this.OrganizerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OrganizerButton.FlatAppearance.BorderSize = 0;
            this.OrganizerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrganizerButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrganizerButton.ForeColor = System.Drawing.Color.White;
            this.OrganizerButton.Image = ((System.Drawing.Image)(resources.GetObject("OrganizerButton.Image")));
            this.OrganizerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrganizerButton.Location = new System.Drawing.Point(47, 130);
            this.OrganizerButton.Name = "OrganizerButton";
            this.OrganizerButton.Size = new System.Drawing.Size(237, 59);
            this.OrganizerButton.TabIndex = 0;
            this.OrganizerButton.Text = "        Organizer";
            this.OrganizerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OrganizerButton.UseMnemonic = false;
            this.OrganizerButton.UseVisualStyleBackColor = false;
            this.OrganizerButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // PanelAttendee
            // 
            this.PanelAttendee.BackColor = System.Drawing.Color.Indigo;
            this.PanelAttendee.Location = new System.Drawing.Point(61, 86);
            this.PanelAttendee.Name = "PanelAttendee";
            this.PanelAttendee.Size = new System.Drawing.Size(210, 10);
            this.PanelAttendee.TabIndex = 7;
            // 
            // AttendeeButtonFP
            // 
            this.AttendeeButtonFP.BackColor = System.Drawing.Color.Transparent;
            this.AttendeeButtonFP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AttendeeButtonFP.BackgroundImage")));
            this.AttendeeButtonFP.FlatAppearance.BorderSize = 0;
            this.AttendeeButtonFP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AttendeeButtonFP.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AttendeeButtonFP.ForeColor = System.Drawing.Color.White;
            this.AttendeeButtonFP.Image = ((System.Drawing.Image)(resources.GetObject("AttendeeButtonFP.Image")));
            this.AttendeeButtonFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AttendeeButtonFP.Location = new System.Drawing.Point(47, 21);
            this.AttendeeButtonFP.Name = "AttendeeButtonFP";
            this.AttendeeButtonFP.Size = new System.Drawing.Size(237, 59);
            this.AttendeeButtonFP.TabIndex = 0;
            this.AttendeeButtonFP.Text = "         Attendee";
            this.AttendeeButtonFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AttendeeButtonFP.UseVisualStyleBackColor = false;
            this.AttendeeButtonFP.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 69);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1419, 792);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(915, 561);
            this.Name = "MainPage";
            this.Text = "MainForm";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.TabAttendee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).EndInit();
            this.TabOrganizer.ResumeLayout(false);
            this.TabOrganizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Label StartDateLabel;
        private TabControl TabControl;
        private TabPage TabAttendee;
        private DataGridView AttendeeGridvw;
        private Button button5;
        private Button button4;
        private Button button3;
        private TabPage TabOrganizer;
        private ComboBox OrganizersPaginationSelector;
        private Label NoConferenceLabel;
        private DataGridView OrganizerDataGrid;
        private TableLayoutPanel tableLayoutPanel3;
        private Button LeftArrowPagButton;
        private Button RightArrowPagButton;
        private TableLayoutPanel tableLayoutPanel2;
        private Button AddConferenceButton;
        private DateTimePicker EndDatePicker;
        private DateTimePicker StartDatePicker;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Button AttendeeButtonFP;
        private Panel PanelAttendee;
        private Button OrganizerButton;
        private Button FilterByDate;
        private Panel panel5;
        private Panel PanelAnc;
        private Panel PanelOrganizer;
        private Panel PanelFilter;
        private PictureBox pictureBox1;
    }
}