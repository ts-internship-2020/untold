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
            this.ConferenceNameLabel = new System.Windows.Forms.Label();
            this.ConfName = new System.Windows.Forms.TextBox();
            this.ConferencePeriodLabel = new System.Windows.Forms.Label();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.ConferenceAdressLabel = new System.Windows.Forms.Label();
            this.ConfAddress = new System.Windows.Forms.TextBox();
            this.ConfLocationLabel = new System.Windows.Forms.Label();
            this.TabControlLocation = new System.Windows.Forms.TabControl();
            this.Country = new System.Windows.Forms.TabPage();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.NextBtnCountryTab = new System.Windows.Forms.Button();
            this.County = new System.Windows.Forms.TabPage();
            this.ComboBoxCountyTab = new System.Windows.Forms.ComboBox();
            this.BackBtnCountyTab = new System.Windows.Forms.Button();
            this.NextBtnCountyTab = new System.Windows.Forms.Button();
            this.City = new System.Windows.Forms.TabPage();
            this.ComboBoxCityTab = new System.Windows.Forms.ComboBox();
            this.BackBtnCityTab = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveAndNewBtnCityTab = new System.Windows.Forms.Button();
            this.SaveBtnCityTab = new System.Windows.Forms.Button();
            this.ErrorName = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrorAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.TabControlLocation.SuspendLayout();
            this.Country.SuspendLayout();
            this.County.SuspendLayout();
            this.City.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // ConferenceNameLabel
            // 
            this.ConferenceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConferenceNameLabel.AutoSize = true;
            this.ConferenceNameLabel.Location = new System.Drawing.Point(0, 0);
            this.ConferenceNameLabel.Name = "ConferenceNameLabel";
            this.ConferenceNameLabel.Size = new System.Drawing.Size(104, 15);
            this.ConferenceNameLabel.TabIndex = 0;
            this.ConferenceNameLabel.Text = "Conference name:";
            // 
            // ConfName
            // 
            this.ConfName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfName.Location = new System.Drawing.Point(130, 0);
            this.ConfName.Name = "ConfName";
            this.ConfName.Size = new System.Drawing.Size(219, 23);
            this.ConfName.TabIndex = 1;
            // 
            // ConferencePeriodLabel
            // 
            this.ConferencePeriodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConferencePeriodLabel.AutoSize = true;
            this.ConferencePeriodLabel.Location = new System.Drawing.Point(0, 47);
            this.ConferencePeriodLabel.Name = "ConferencePeriodLabel";
            this.ConferencePeriodLabel.Size = new System.Drawing.Size(108, 15);
            this.ConferencePeriodLabel.TabIndex = 2;
            this.ConferencePeriodLabel.Text = "Conference period:";
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.MonthCalendar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MonthCalendar.Location = new System.Drawing.Point(130, 40);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 3;
            // 
            // ConferenceAdressLabel
            // 
            this.ConferenceAdressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConferenceAdressLabel.AutoSize = true;
            this.ConferenceAdressLabel.Location = new System.Drawing.Point(0, 217);
            this.ConferenceAdressLabel.Name = "ConferenceAdressLabel";
            this.ConferenceAdressLabel.Size = new System.Drawing.Size(114, 15);
            this.ConferenceAdressLabel.TabIndex = 4;
            this.ConferenceAdressLabel.Text = "Conference address:";
            // 
            // ConfAddress
            // 
            this.ConfAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfAddress.Location = new System.Drawing.Point(130, 214);
            this.ConfAddress.Name = "ConfAddress";
            this.ConfAddress.Size = new System.Drawing.Size(242, 23);
            this.ConfAddress.TabIndex = 5;
            // 
            // ConfLocationLabel
            // 
            this.ConfLocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfLocationLabel.AutoSize = true;
            this.ConfLocationLabel.Location = new System.Drawing.Point(0, 265);
            this.ConfLocationLabel.Name = "ConfLocationLabel";
            this.ConfLocationLabel.Size = new System.Drawing.Size(56, 15);
            this.ConfLocationLabel.TabIndex = 6;
            this.ConfLocationLabel.Text = "Location:";
            // 
            // TabControlLocation
            // 
            this.TabControlLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlLocation.Controls.Add(this.Country);
            this.TabControlLocation.Controls.Add(this.County);
            this.TabControlLocation.Controls.Add(this.City);
            this.TabControlLocation.Location = new System.Drawing.Point(96, 243);
            this.TabControlLocation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.TabControlLocation.Name = "TabControlLocation";
            this.TabControlLocation.SelectedIndex = 2;
            this.TabControlLocation.Size = new System.Drawing.Size(365, 128);
            this.TabControlLocation.TabIndex = 7;
            // 
            // Country
            // 
            this.Country.Controls.Add(this.CountryComboBox);
            this.Country.Controls.Add(this.NextBtnCountryTab);
            this.Country.Location = new System.Drawing.Point(4, 24);
            this.Country.Name = "Country";
            this.Country.Padding = new System.Windows.Forms.Padding(3);
            this.Country.Size = new System.Drawing.Size(357, 100);
            this.Country.TabIndex = 0;
            this.Country.Text = "Country";
            this.Country.UseVisualStyleBackColor = true;
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(3, 27);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(183, 23);
            this.CountryComboBox.TabIndex = 1;
            this.CountryComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.CountryComboBox.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // NextBtnCountryTab
            // 
            this.NextBtnCountryTab.Enabled = false;
            this.NextBtnCountryTab.Location = new System.Drawing.Point(281, 28);
            this.NextBtnCountryTab.Name = "NextBtnCountryTab";
            this.NextBtnCountryTab.Size = new System.Drawing.Size(65, 22);
            this.NextBtnCountryTab.TabIndex = 0;
            this.NextBtnCountryTab.Text = "Next>>";
            this.NextBtnCountryTab.UseVisualStyleBackColor = true;
            this.NextBtnCountryTab.Click += new System.EventHandler(this.button1_Click);
            // 
            // County
            // 
            this.County.Controls.Add(this.ComboBoxCountyTab);
            this.County.Controls.Add(this.BackBtnCountyTab);
            this.County.Controls.Add(this.NextBtnCountyTab);
            this.County.Location = new System.Drawing.Point(4, 24);
            this.County.Name = "County";
            this.County.Padding = new System.Windows.Forms.Padding(3);
            this.County.Size = new System.Drawing.Size(357, 100);
            this.County.TabIndex = 1;
            this.County.Text = "County";
            this.County.UseVisualStyleBackColor = true;
            // 
            // ComboBoxCountyTab
            // 
            this.ComboBoxCountyTab.FormattingEnabled = true;
            this.ComboBoxCountyTab.Location = new System.Drawing.Point(3, 27);
            this.ComboBoxCountyTab.Name = "ComboBoxCountyTab";
            this.ComboBoxCountyTab.Size = new System.Drawing.Size(183, 23);
            this.ComboBoxCountyTab.TabIndex = 2;
            this.ComboBoxCountyTab.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCountyTab_SelectedIndexChanged);
            // 
            // BackBtnCountyTab
            // 
            this.BackBtnCountyTab.Location = new System.Drawing.Point(197, 27);
            this.BackBtnCountyTab.Name = "BackBtnCountyTab";
            this.BackBtnCountyTab.Size = new System.Drawing.Size(75, 23);
            this.BackBtnCountyTab.TabIndex = 1;
            this.BackBtnCountyTab.Text = "<<Back";
            this.BackBtnCountyTab.UseVisualStyleBackColor = true;
            this.BackBtnCountyTab.Click += new System.EventHandler(this.BackBtnCountyTab_Click);
            // 
            // NextBtnCountyTab
            // 
            this.NextBtnCountyTab.Location = new System.Drawing.Point(281, 28);
            this.NextBtnCountyTab.Name = "NextBtnCountyTab";
            this.NextBtnCountyTab.Size = new System.Drawing.Size(65, 22);
            this.NextBtnCountyTab.TabIndex = 0;
            this.NextBtnCountyTab.Text = "Next>>";
            this.NextBtnCountyTab.UseVisualStyleBackColor = true;
            this.NextBtnCountyTab.Click += new System.EventHandler(this.button2_Click);
            // 
            // City
            // 
            this.City.Controls.Add(this.ComboBoxCityTab);
            this.City.Controls.Add(this.BackBtnCityTab);
            this.City.Controls.Add(this.button1);
            this.City.Controls.Add(this.SaveAndNewBtnCityTab);
            this.City.Controls.Add(this.SaveBtnCityTab);
            this.City.Location = new System.Drawing.Point(4, 24);
            this.City.Name = "City";
            this.City.Padding = new System.Windows.Forms.Padding(3);
            this.City.Size = new System.Drawing.Size(357, 100);
            this.City.TabIndex = 2;
            this.City.Text = "City";
            this.City.UseVisualStyleBackColor = true;
            // 
            // ComboBoxCityTab
            // 
            this.ComboBoxCityTab.FormattingEnabled = true;
            this.ComboBoxCityTab.Location = new System.Drawing.Point(3, 27);
            this.ComboBoxCityTab.Name = "ComboBoxCityTab";
            this.ComboBoxCityTab.Size = new System.Drawing.Size(183, 23);
            this.ComboBoxCityTab.TabIndex = 4;
            // 
            // BackBtnCityTab
            // 
            this.BackBtnCityTab.Location = new System.Drawing.Point(220, 27);
            this.BackBtnCityTab.Name = "BackBtnCityTab";
            this.BackBtnCityTab.Size = new System.Drawing.Size(75, 23);
            this.BackBtnCityTab.TabIndex = 3;
            this.BackBtnCityTab.Text = "<<Back";
            this.BackBtnCityTab.UseVisualStyleBackColor = true;
            this.BackBtnCityTab.Click += new System.EventHandler(this.BackBtnCityTab_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SaveAndNewBtnCityTab
            // 
            this.SaveAndNewBtnCityTab.Location = new System.Drawing.Point(237, 64);
            this.SaveAndNewBtnCityTab.Name = "SaveAndNewBtnCityTab";
            this.SaveAndNewBtnCityTab.Size = new System.Drawing.Size(105, 23);
            this.SaveAndNewBtnCityTab.TabIndex = 1;
            this.SaveAndNewBtnCityTab.Text = "Save and New";
            this.SaveAndNewBtnCityTab.UseVisualStyleBackColor = true;
            this.SaveAndNewBtnCityTab.Click += new System.EventHandler(this.SaveAndNewBtnCityTab_Click);
            // 
            // SaveBtnCityTab
            // 
            this.SaveBtnCityTab.Location = new System.Drawing.Point(143, 64);
            this.SaveBtnCityTab.Name = "SaveBtnCityTab";
            this.SaveBtnCityTab.Size = new System.Drawing.Size(75, 23);
            this.SaveBtnCityTab.TabIndex = 0;
            this.SaveBtnCityTab.Text = "Save";
            this.SaveBtnCityTab.UseVisualStyleBackColor = true;
            this.SaveBtnCityTab.Click += new System.EventHandler(this.button3_Click);
            // 
            // ErrorName
            // 
            this.ErrorName.ContainerControl = this;
            // 
            // ErrorAddress
            // 
            this.ErrorAddress.ContainerControl = this;
            // 
            // AddConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 437);
            this.Controls.Add(this.TabControlLocation);
            this.Controls.Add(this.ConfLocationLabel);
            this.Controls.Add(this.ConfAddress);
            this.Controls.Add(this.ConferenceAdressLabel);
            this.Controls.Add(this.MonthCalendar);
            this.Controls.Add(this.ConferencePeriodLabel);
            this.Controls.Add(this.ConfName);
            this.Controls.Add(this.ConferenceNameLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "AddConf";
            this.Text = "AddConf";
            this.Load += new System.EventHandler(this.AddConf_Load);
            this.TabControlLocation.ResumeLayout(false);
            this.Country.ResumeLayout(false);
            this.County.ResumeLayout(false);
            this.City.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConferenceNameLabel;
        private System.Windows.Forms.TextBox ConfName;
        private System.Windows.Forms.Label ConferencePeriodLabel;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.Label ConferenceAdressLabel;
        private System.Windows.Forms.TextBox ConfAddress;
        private System.Windows.Forms.Label ConfLocationLabel;
        private System.Windows.Forms.TabControl TabControlLocation;
        private System.Windows.Forms.TabPage Country;
        private System.Windows.Forms.TabPage County;
        private System.Windows.Forms.TabPage City;
        private System.Windows.Forms.Button NextBtnCountryTab;
        private System.Windows.Forms.Button NextBtnCountyTab;
        private System.Windows.Forms.Button SaveBtnCityTab;
        private System.Windows.Forms.Button SaveAndNewBtnCityTab;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.Button BackBtnCountyTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ComboBoxCountyTab;
        private System.Windows.Forms.Button BackBtnCityTab;
        private System.Windows.Forms.ComboBox ComboBoxCityTab;
        private System.Windows.Forms.ErrorProvider ErrorName;
        private System.Windows.Forms.ErrorProvider ErrorAddress;
    }
}