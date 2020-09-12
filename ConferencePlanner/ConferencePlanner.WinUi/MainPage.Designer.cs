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
            this.AddConferenceButton = new System.Windows.Forms.Button();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelFilter = new System.Windows.Forms.Panel();
            this.PanelAnc = new System.Windows.Forms.Panel();
            this.PanelOrganizer = new System.Windows.Forms.Panel();
            this.FilterByDate = new System.Windows.Forms.Button();
            this.OrganizerButton = new System.Windows.Forms.Button();
            this.PanelAttendee = new System.Windows.Forms.Panel();
            this.AttendeeButtonFP = new System.Windows.Forms.Button();
            this.AttendeeGridvw = new System.Windows.Forms.DataGridView();
            this.OrganizersPaginationSelector = new System.Windows.Forms.ComboBox();
            this.OrganizerDataGrid = new System.Windows.Forms.DataGridView();
            this.RightArrowPagButton = new System.Windows.Forms.Button();
            this.LeftArrowPagButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            // AddConferenceButton
            // 
            this.AddConferenceButton.BackColor = System.Drawing.Color.Transparent;
            this.AddConferenceButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddConferenceButton.BackgroundImage")));
            this.AddConferenceButton.FlatAppearance.BorderSize = 0;
            this.AddConferenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddConferenceButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddConferenceButton.ForeColor = System.Drawing.Color.White;
            this.AddConferenceButton.Image = ((System.Drawing.Image)(resources.GetObject("AddConferenceButton.Image")));
            this.AddConferenceButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddConferenceButton.Location = new System.Drawing.Point(47, 385);
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
            this.EndDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.EndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDatePicker.Location = new System.Drawing.Point(83, 629);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(162, 25);
            this.EndDatePicker.TabIndex = 6;
            this.EndDatePicker.Visible = false;
            this.EndDatePicker.ValueChanged += new System.EventHandler(this.EndDatePicker_ValueChanged);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.StartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDatePicker.Location = new System.Drawing.Point(83, 598);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(162, 25);
            this.StartDatePicker.TabIndex = 5;
            this.StartDatePicker.Visible = false;
            this.StartDatePicker.ValueChanged += new System.EventHandler(this.StartDatePicker_ValueChanged);
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
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
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
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 792);
            this.panel2.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 79);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // PanelFilter
            // 
            this.PanelFilter.BackColor = System.Drawing.Color.Indigo;
            this.PanelFilter.Location = new System.Drawing.Point(61, 567);
            this.PanelFilter.Name = "PanelFilter";
            this.PanelFilter.Size = new System.Drawing.Size(210, 10);
            this.PanelFilter.TabIndex = 7;
            this.PanelFilter.Visible = false;
            // 
            // PanelAnc
            // 
            this.PanelAnc.BackColor = System.Drawing.Color.Indigo;
            this.PanelAnc.Location = new System.Drawing.Point(61, 450);
            this.PanelAnc.Name = "PanelAnc";
            this.PanelAnc.Size = new System.Drawing.Size(210, 10);
            this.PanelAnc.TabIndex = 7;
            this.PanelAnc.Visible = false;
            // 
            // PanelOrganizer
            // 
            this.PanelOrganizer.BackColor = System.Drawing.Color.Indigo;
            this.PanelOrganizer.Location = new System.Drawing.Point(61, 333);
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
            this.FilterByDate.Location = new System.Drawing.Point(47, 502);
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
            this.OrganizerButton.Location = new System.Drawing.Point(47, 268);
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
            this.PanelAttendee.Location = new System.Drawing.Point(61, 218);
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
            this.AttendeeButtonFP.Location = new System.Drawing.Point(47, 153);
            this.AttendeeButtonFP.Name = "AttendeeButtonFP";
            this.AttendeeButtonFP.Size = new System.Drawing.Size(237, 59);
            this.AttendeeButtonFP.TabIndex = 0;
            this.AttendeeButtonFP.Text = "         Attendee";
            this.AttendeeButtonFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AttendeeButtonFP.UseVisualStyleBackColor = false;
            this.AttendeeButtonFP.Click += new System.EventHandler(this.button1_Click_1);
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
            this.AttendeeGridvw.Location = new System.Drawing.Point(0, 0);
            this.AttendeeGridvw.Name = "AttendeeGridvw";
            this.AttendeeGridvw.ReadOnly = true;
            this.AttendeeGridvw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.AttendeeGridvw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.AttendeeGridvw.Size = new System.Drawing.Size(1001, 561);
            this.AttendeeGridvw.TabIndex = 3;
            this.AttendeeGridvw.Text = "dataGridView1";
            this.AttendeeGridvw.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AttendeeGridvw_DataBindingComplete);
            this.AttendeeGridvw.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // OrganizersPaginationSelector
            // 
            this.OrganizersPaginationSelector.FormattingEnabled = true;
            this.OrganizersPaginationSelector.Items.AddRange(new object[] {
            "5",
            "10",
            "25"});
            this.OrganizersPaginationSelector.Location = new System.Drawing.Point(766, 92);
            this.OrganizersPaginationSelector.Name = "OrganizersPaginationSelector";
            this.OrganizersPaginationSelector.Size = new System.Drawing.Size(121, 25);
            this.OrganizersPaginationSelector.TabIndex = 2;
            this.OrganizersPaginationSelector.DropDownClosed += new System.EventHandler(this.OrganizersPaginationSelector_DropDownClosed);
            // 
            // OrganizerDataGrid
            // 
            this.OrganizerDataGrid.AllowUserToAddRows = false;
            this.OrganizerDataGrid.AllowUserToDeleteRows = false;
            this.OrganizerDataGrid.AllowUserToResizeRows = false;
            this.OrganizerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrganizerDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.OrganizerDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.OrganizerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrganizerDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrganizerDataGrid.Location = new System.Drawing.Point(0, 0);
            this.OrganizerDataGrid.Name = "OrganizerDataGrid";
            this.OrganizerDataGrid.ReadOnly = true;
            this.OrganizerDataGrid.Size = new System.Drawing.Size(1001, 561);
            this.OrganizerDataGrid.TabIndex = 0;
            this.OrganizerDataGrid.Text = "organizerDataGrid";
            this.OrganizerDataGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OrganizerDataGrid_DataBindingComplete);
            this.OrganizerDataGrid.Layout += new System.Windows.Forms.LayoutEventHandler(this.OrganizerDataGrid_Layout);
            // 
            // RightArrowPagButton
            // 
            this.RightArrowPagButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RightArrowPagButton.BackColor = System.Drawing.Color.Transparent;
            this.RightArrowPagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RightArrowPagButton.BackgroundImage")));
            this.RightArrowPagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RightArrowPagButton.FlatAppearance.BorderSize = 0;
            this.RightArrowPagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightArrowPagButton.Location = new System.Drawing.Point(863, 30);
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
            // LeftArrowPagButton
            // 
            this.LeftArrowPagButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LeftArrowPagButton.BackColor = System.Drawing.Color.Transparent;
            this.LeftArrowPagButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeftArrowPagButton.BackgroundImage")));
            this.LeftArrowPagButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LeftArrowPagButton.FlatAppearance.BorderSize = 0;
            this.LeftArrowPagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftArrowPagButton.Location = new System.Drawing.Point(819, 30);
            this.LeftArrowPagButton.Name = "LeftArrowPagButton";
            this.LeftArrowPagButton.Size = new System.Drawing.Size(40, 40);
            this.LeftArrowPagButton.TabIndex = 7;
            this.LeftArrowPagButton.UseVisualStyleBackColor = false;
            this.LeftArrowPagButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftArrowPagButton_MouseClick);
            this.LeftArrowPagButton.MouseEnter += new System.EventHandler(this.LeftArrowPagButton_MouseEnter);
            this.LeftArrowPagButton.MouseLeave += new System.EventHandler(this.LeftArrowPagButton_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.OrganizersPaginationSelector);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1419, 119);
            this.panel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.53527F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.46473F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
            this.tableLayoutPanel1.Controls.Add(this.LeftArrowPagButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightArrowPagButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 692);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1419, 100);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.AttendeeGridvw);
            this.panel4.Controls.Add(this.OrganizerDataGrid);
            this.panel4.Location = new System.Drawing.Point(338, 125);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1001, 561);
            this.panel4.TabIndex = 16;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1419, 792);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(915, 561);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.TransparencyKey = System.Drawing.Color.NavajoWhite;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridvw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrganizerDataGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private Label StartDateLabel;
        private Button AddConferenceButton;
        private DateTimePicker EndDatePicker;
        private DateTimePicker StartDatePicker;
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
        private DataGridView AttendeeGridvw;
        private ComboBox OrganizersPaginationSelector;
        private DataGridView OrganizerDataGrid;
        private Button RightArrowPagButton;
        private Button LeftArrowPagButton;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
    }
}