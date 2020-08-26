namespace ConferencePlanner.WinUi
{
    partial class AddConf
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConf));
            this.ConferenceNameLabel = new System.Windows.Forms.Label();
            this.ConfName = new System.Windows.Forms.TextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EmailAddress = new System.Windows.Forms.Label();
            this.ConfEmailAddress = new System.Windows.Forms.TextBox();
            this.EndDatelabel = new System.Windows.Forms.Label();
            this.TabControlLocation = new System.Windows.Forms.TabControl();
            this.Country = new System.Windows.Forms.TabPage();
            this.CountryListDataGridView = new System.Windows.Forms.DataGridView();
            this.County = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.City = new System.Windows.Forms.TabPage();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.TypeTab = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.SpeakerTab = new System.Windows.Forms.TabPage();
            this.SpeakerListDataGrid = new System.Windows.Forms.DataGridView();
            this.CategoryTab = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.BackTabBtn = new System.Windows.Forms.Button();
            this.NextTabBtn = new System.Windows.Forms.Button();
            this.ErrorName = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrorAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.StardDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveNew = new System.Windows.Forms.Button();
            this.TabControlLocation.SuspendLayout();
            this.Country.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountryListDataGridView)).BeginInit();
            this.County.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.City.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.TypeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SpeakerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerListDataGrid)).BeginInit();
            this.CategoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConferenceNameLabel
            // 
            this.ConferenceNameLabel.AutoSize = true;
            this.ConferenceNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConferenceNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConferenceNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ConferenceNameLabel.Name = "ConferenceNameLabel";
            this.ConferenceNameLabel.Size = new System.Drawing.Size(309, 29);
            this.ConferenceNameLabel.TabIndex = 0;
            this.ConferenceNameLabel.Text = "Conference name:";
            this.ConferenceNameLabel.Click += new System.EventHandler(this.ConferenceNameLabel_Click);
            // 
            // ConfName
            // 
            this.ConfName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(7)))), ((int)(((byte)(99)))));
            this.ConfName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfName.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConfName.ForeColor = System.Drawing.Color.Gold;
            this.ConfName.Location = new System.Drawing.Point(318, 3);
            this.ConfName.Name = "ConfName";
            this.ConfName.Size = new System.Drawing.Size(451, 27);
            this.ConfName.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartDateLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartDateLabel.Location = new System.Drawing.Point(3, 61);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(309, 32);
            this.StartDateLabel.TabIndex = 2;
            this.StartDateLabel.Text = "Start date";
            // 
            // EmailAddress
            // 
            this.EmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailAddress.AutoSize = true;
            this.EmailAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailAddress.Location = new System.Drawing.Point(3, 29);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(309, 32);
            this.EmailAddress.TabIndex = 4;
            this.EmailAddress.Text = "Organizer email address:";
            // 
            // ConfEmailAddress
            // 
            this.ConfEmailAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(7)))), ((int)(((byte)(99)))));
            this.ConfEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfEmailAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConfEmailAddress.ForeColor = System.Drawing.Color.Gold;
            this.ConfEmailAddress.Location = new System.Drawing.Point(318, 32);
            this.ConfEmailAddress.Name = "ConfEmailAddress";
            this.ConfEmailAddress.Size = new System.Drawing.Size(451, 27);
            this.ConfEmailAddress.TabIndex = 5;
            // 
            // EndDatelabel
            // 
            this.EndDatelabel.AutoSize = true;
            this.EndDatelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDatelabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EndDatelabel.Location = new System.Drawing.Point(3, 93);
            this.EndDatelabel.Name = "EndDatelabel";
            this.EndDatelabel.Size = new System.Drawing.Size(309, 33);
            this.EndDatelabel.TabIndex = 6;
            this.EndDatelabel.Text = "End Date";
            // 
            // TabControlLocation
            // 
            this.TabControlLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlLocation.Controls.Add(this.Country);
            this.TabControlLocation.Controls.Add(this.County);
            this.TabControlLocation.Controls.Add(this.City);
            this.TabControlLocation.Controls.Add(this.TypeTab);
            this.TabControlLocation.Controls.Add(this.SpeakerTab);
            this.TabControlLocation.Controls.Add(this.CategoryTab);
            this.TabControlLocation.Location = new System.Drawing.Point(3, 135);
            this.TabControlLocation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.TabControlLocation.Name = "TabControlLocation";
            this.TabControlLocation.SelectedIndex = 6;
            this.TabControlLocation.Size = new System.Drawing.Size(1221, 399);
            this.TabControlLocation.TabIndex = 7;
            this.TabControlLocation.SelectedIndexChanged += new System.EventHandler(this.TabControlLocation_SelectedIndexChanged);
            // 
            // Country
            // 
            this.Country.Controls.Add(this.CountryListDataGridView);
            this.Country.Location = new System.Drawing.Point(4, 29);
            this.Country.Name = "Country";
            this.Country.Padding = new System.Windows.Forms.Padding(3);
            this.Country.Size = new System.Drawing.Size(1213, 366);
            this.Country.TabIndex = 0;
            this.Country.Text = "Country";
            this.Country.UseVisualStyleBackColor = true;
            // 
            // CountryListDataGridView
            // 
            this.CountryListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountryListDataGridView.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.CountryListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CountryListDataGridView.GridColor = System.Drawing.Color.DarkBlue;
            this.CountryListDataGridView.Location = new System.Drawing.Point(1, 0);
            this.CountryListDataGridView.Name = "CountryListDataGridView";
            this.CountryListDataGridView.Size = new System.Drawing.Size(808, 298);
            this.CountryListDataGridView.TabIndex = 1;
            this.CountryListDataGridView.Text = "dataGridView1";
            this.CountryListDataGridView.Click += new System.EventHandler(this.CountryListDataGridView_Click);
            // 
            // County
            // 
            this.County.Controls.Add(this.dataGridView2);
            this.County.Location = new System.Drawing.Point(4, 29);
            this.County.Name = "County";
            this.County.Padding = new System.Windows.Forms.Padding(3);
            this.County.Size = new System.Drawing.Size(1213, 366);
            this.County.TabIndex = 1;
            this.County.Text = "County";
            this.County.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1207, 360);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.Text = "dataGridView2";
            // 
            // City
            // 
            this.City.Controls.Add(this.dataGridView6);
            this.City.Location = new System.Drawing.Point(4, 29);
            this.City.Name = "City";
            this.City.Padding = new System.Windows.Forms.Padding(3);
            this.City.Size = new System.Drawing.Size(1213, 366);
            this.City.TabIndex = 2;
            this.City.Text = "City";
            this.City.UseVisualStyleBackColor = true;
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView6.Location = new System.Drawing.Point(3, 3);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(1207, 360);
            this.dataGridView6.TabIndex = 0;
            this.dataGridView6.Text = "dataGridView6";
            // 
            // TypeTab
            // 
            this.TypeTab.Controls.Add(this.dataGridView3);
            this.TypeTab.Location = new System.Drawing.Point(4, 29);
            this.TypeTab.Name = "TypeTab";
            this.TypeTab.Padding = new System.Windows.Forms.Padding(3);
            this.TypeTab.Size = new System.Drawing.Size(1213, 366);
            this.TypeTab.TabIndex = 4;
            this.TypeTab.Text = "Type";
            this.TypeTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1207, 360);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.Text = "dataGridView3";
            // 
            // SpeakerTab
            // 
            this.SpeakerTab.Controls.Add(this.SpeakerListDataGrid);
            this.SpeakerTab.Location = new System.Drawing.Point(4, 29);
            this.SpeakerTab.Name = "SpeakerTab";
            this.SpeakerTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpeakerTab.Size = new System.Drawing.Size(1213, 366);
            this.SpeakerTab.TabIndex = 5;
            this.SpeakerTab.Text = "Speaker";
            this.SpeakerTab.UseVisualStyleBackColor = true;
            // 
            // SpeakerListDataGrid
            // 
            this.SpeakerListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SpeakerListDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.SpeakerListDataGrid.Location = new System.Drawing.Point(3, 3);
            this.SpeakerListDataGrid.Name = "SpeakerListDataGrid";
            this.SpeakerListDataGrid.Size = new System.Drawing.Size(1207, 309);
            this.SpeakerListDataGrid.TabIndex = 0;
            this.SpeakerListDataGrid.Text = "dataGridView4";
            // 
            // CategoryTab
            // 
            this.CategoryTab.Controls.Add(this.dataGridView5);
            this.CategoryTab.Location = new System.Drawing.Point(4, 29);
            this.CategoryTab.Name = "CategoryTab";
            this.CategoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.CategoryTab.Size = new System.Drawing.Size(1213, 366);
            this.CategoryTab.TabIndex = 6;
            this.CategoryTab.Text = "Category";
            this.CategoryTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(3, 3);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(1207, 360);
            this.dataGridView5.TabIndex = 0;
            this.dataGridView5.Text = "dataGridView5";
            // 
            // BackTabBtn
            // 
            this.BackTabBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.BackTabBtn.Enabled = false;
            this.BackTabBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BackTabBtn.Location = new System.Drawing.Point(493, 3);
            this.BackTabBtn.Name = "BackTabBtn";
            this.BackTabBtn.Size = new System.Drawing.Size(80, 34);
            this.BackTabBtn.TabIndex = 1;
            this.BackTabBtn.Text = "<<Back";
            this.BackTabBtn.UseVisualStyleBackColor = true;
            this.BackTabBtn.Click += new System.EventHandler(this.BackBtnTab_Click);
            // 
            // NextTabBtn
            // 
            this.NextTabBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextTabBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.NextTabBtn.Location = new System.Drawing.Point(579, 3);
            this.NextTabBtn.Name = "NextTabBtn";
            this.NextTabBtn.Size = new System.Drawing.Size(80, 34);
            this.NextTabBtn.TabIndex = 0;
            this.NextTabBtn.Text = "Next>>";
            this.NextTabBtn.UseVisualStyleBackColor = true;
            this.NextTabBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // ErrorName
            // 
            this.ErrorName.ContainerControl = this;
            // 
            // ErrorAddress
            // 
            this.ErrorAddress.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(54)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TabControlLocation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.60274F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.52055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.876712F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1227, 584);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(54)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.86002F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.13998F));
            this.tableLayoutPanel2.Controls.Add(this.ConfName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.EndDatelabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.StartDateLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.EmailAddress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ConferenceNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConfEmailAddress, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.StardDatePicker, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.EndDatePicker, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.14815F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.85185F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1221, 126);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // StardDatePicker
            // 
            this.StardDatePicker.CalendarForeColor = System.Drawing.Color.Gold;
            this.StardDatePicker.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(7)))), ((int)(((byte)(99)))));
            this.StardDatePicker.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(7)))), ((int)(((byte)(99)))));
            this.StardDatePicker.CalendarTitleForeColor = System.Drawing.Color.Gold;
            this.StardDatePicker.Location = new System.Drawing.Point(318, 64);
            this.StardDatePicker.Name = "StardDatePicker";
            this.StardDatePicker.Size = new System.Drawing.Size(200, 27);
            this.StardDatePicker.TabIndex = 7;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(318, 96);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 27);
            this.EndDatePicker.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(54)))));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.21933F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.612515F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.16816F));
            this.tableLayoutPanel3.Controls.Add(this.NextTabBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BackTabBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SaveNew, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 541);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1221, 40);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // SaveNew
            // 
            this.SaveNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SaveNew.Location = new System.Drawing.Point(671, 3);
            this.SaveNew.Name = "SaveNew";
            this.SaveNew.Size = new System.Drawing.Size(114, 34);
            this.SaveNew.TabIndex = 2;
            this.SaveNew.Text = "Save And New";
            this.SaveNew.UseVisualStyleBackColor = true;
            this.SaveNew.Visible = false;
            this.SaveNew.Click += new System.EventHandler(this.SaveNew_Click);
            // 
            // AddConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1227, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddConf";
            this.Text = "AddConf";
            this.Load += new System.EventHandler(this.AddConf_Load);
            this.TabControlLocation.ResumeLayout(false);
            this.Country.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CountryListDataGridView)).EndInit();
            this.County.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.City.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.TypeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.SpeakerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpeakerListDataGrid)).EndInit();
            this.CategoryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConferenceNameLabel;
        private System.Windows.Forms.TextBox ConfName;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EmailAddress;
        private System.Windows.Forms.TextBox ConfEmailAddress;
        private System.Windows.Forms.Label EndDatelabel;
        private System.Windows.Forms.TabControl TabControlLocation;
        private System.Windows.Forms.TabPage Country;
        private System.Windows.Forms.TabPage County;
        private System.Windows.Forms.TabPage City;
        private System.Windows.Forms.Button NextTabBtn;
        private System.Windows.Forms.Button BackTabBtn;
        private System.Windows.Forms.ErrorProvider ErrorName;
        private System.Windows.Forms.ErrorProvider ErrorAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker StardDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.TabPage TypeTab;
        private System.Windows.Forms.TabPage SpeakerTab;
        private System.Windows.Forms.TabPage CategoryTab;
        private System.Windows.Forms.DataGridView CountryListDataGridView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView SpeakerListDataGrid;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button SaveNew;
    }
}