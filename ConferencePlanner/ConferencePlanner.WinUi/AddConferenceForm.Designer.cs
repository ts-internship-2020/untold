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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.County = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.City = new System.Windows.Forms.TabPage();
            this.TypeTab = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.SpeakerTab = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.CategoryTab = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.NextBtnCountryTab = new System.Windows.Forms.Button();
            this.BackBtnCountyTab = new System.Windows.Forms.Button();
            this.ErrorName = new System.Windows.Forms.ErrorProvider(this.components);
            this.ErrorAddress = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.TabControlLocation.SuspendLayout();
            this.Country.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.County.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.City.SuspendLayout();
            this.TypeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SpeakerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.CategoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.SuspendLayout();
            // 
            // ConferenceNameLabel
            // 
            this.ConferenceNameLabel.AutoSize = true;
            this.ConferenceNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConferenceNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConferenceNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ConferenceNameLabel.Name = "ConferenceNameLabel";
            this.ConferenceNameLabel.Size = new System.Drawing.Size(211, 37);
            this.ConferenceNameLabel.TabIndex = 0;
            this.ConferenceNameLabel.Text = "Conference name:";
            this.ConferenceNameLabel.Click += new System.EventHandler(this.ConferenceNameLabel_Click);
            // 
            // ConfName
            // 
            this.ConfName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfName.Location = new System.Drawing.Point(220, 3);
            this.ConfName.Name = "ConfName";
            this.ConfName.Size = new System.Drawing.Size(620, 27);
            this.ConfName.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartDateLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartDateLabel.Location = new System.Drawing.Point(3, 76);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(211, 41);
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
            this.EmailAddress.Location = new System.Drawing.Point(3, 37);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(211, 39);
            this.EmailAddress.TabIndex = 4;
            this.EmailAddress.Text = "Organizer email address:";
            // 
            // ConfEmailAddress
            // 
            this.ConfEmailAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConfEmailAddress.Location = new System.Drawing.Point(220, 40);
            this.ConfEmailAddress.Name = "ConfEmailAddress";
            this.ConfEmailAddress.Size = new System.Drawing.Size(620, 27);
            this.ConfEmailAddress.TabIndex = 5;
            // 
            // EndDatelabel
            // 
            this.EndDatelabel.AutoSize = true;
            this.EndDatelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDatelabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EndDatelabel.Location = new System.Drawing.Point(3, 117);
            this.EndDatelabel.Name = "EndDatelabel";
            this.EndDatelabel.Size = new System.Drawing.Size(211, 38);
            this.EndDatelabel.TabIndex = 6;
            this.EndDatelabel.Text = "End Date";
            // 
            // TabControlLocation
            // 
            this.TabControlLocation.Controls.Add(this.Country);
            this.TabControlLocation.Controls.Add(this.County);
            this.TabControlLocation.Controls.Add(this.City);
            this.TabControlLocation.Controls.Add(this.TypeTab);
            this.TabControlLocation.Controls.Add(this.SpeakerTab);
            this.TabControlLocation.Controls.Add(this.CategoryTab);
            this.TabControlLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControlLocation.Location = new System.Drawing.Point(3, 168);
            this.TabControlLocation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.TabControlLocation.Name = "TabControlLocation";
            this.TabControlLocation.SelectedIndex = 6;
            this.TabControlLocation.Size = new System.Drawing.Size(1115, 250);
            this.TabControlLocation.TabIndex = 7;
            // 
            // Country
            // 
            this.Country.Controls.Add(this.dataGridView1);
            this.Country.Location = new System.Drawing.Point(4, 29);
            this.Country.Name = "Country";
            this.Country.Padding = new System.Windows.Forms.Padding(3);
            this.Country.Size = new System.Drawing.Size(1107, 217);
            this.Country.TabIndex = 0;
            this.Country.Text = "Country";
            this.Country.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1101, 211);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // County
            // 
            this.County.Controls.Add(this.dataGridView2);
            this.County.Location = new System.Drawing.Point(4, 29);
            this.County.Name = "County";
            this.County.Padding = new System.Windows.Forms.Padding(3);
            this.County.Size = new System.Drawing.Size(1107, 214);
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
            this.dataGridView2.Size = new System.Drawing.Size(1101, 208);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.Text = "dataGridView2";
            // 
            // City
            // 
            this.City.Controls.Add(this.dataGridView6);
            this.City.Location = new System.Drawing.Point(4, 29);
            this.City.Name = "City";
            this.City.Padding = new System.Windows.Forms.Padding(3);
            this.City.Size = new System.Drawing.Size(1107, 214);
            this.City.TabIndex = 2;
            this.City.Text = "City";
            this.City.UseVisualStyleBackColor = true;
            // 
            // TypeTab
            // 
            this.TypeTab.Controls.Add(this.dataGridView3);
            this.TypeTab.Location = new System.Drawing.Point(4, 29);
            this.TypeTab.Name = "TypeTab";
            this.TypeTab.Padding = new System.Windows.Forms.Padding(3);
            this.TypeTab.Size = new System.Drawing.Size(1107, 214);
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
            this.dataGridView3.Size = new System.Drawing.Size(1101, 208);
            this.dataGridView3.TabIndex = 0;
            this.dataGridView3.Text = "dataGridView3";
            // 
            // SpeakerTab
            // 
            this.SpeakerTab.Controls.Add(this.dataGridView4);
            this.SpeakerTab.Location = new System.Drawing.Point(4, 29);
            this.SpeakerTab.Name = "SpeakerTab";
            this.SpeakerTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpeakerTab.Size = new System.Drawing.Size(1107, 214);
            this.SpeakerTab.TabIndex = 5;
            this.SpeakerTab.Text = "Speaker";
            this.SpeakerTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1101, 208);
            this.dataGridView4.TabIndex = 0;
            this.dataGridView4.Text = "dataGridView4";
            // 
            // CategoryTab
            // 
            this.CategoryTab.Controls.Add(this.dataGridView5);
            this.CategoryTab.Location = new System.Drawing.Point(4, 29);
            this.CategoryTab.Name = "CategoryTab";
            this.CategoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.CategoryTab.Size = new System.Drawing.Size(1107, 217);
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
            this.dataGridView5.Size = new System.Drawing.Size(1101, 211);
            this.dataGridView5.TabIndex = 0;
            this.dataGridView5.Text = "dataGridView5";
            // 
            // NextBtnCountryTab
            // 
            this.NextBtnCountryTab.Dock = System.Windows.Forms.DockStyle.Left;
            this.NextBtnCountryTab.Enabled = false;
            this.NextBtnCountryTab.Location = new System.Drawing.Point(0, 0);
            this.NextBtnCountryTab.Name = "NextBtnCountryTab";
            this.NextBtnCountryTab.Size = new System.Drawing.Size(74, 34);
            this.NextBtnCountryTab.TabIndex = 0;
            this.NextBtnCountryTab.Text = "Next>>";
            this.NextBtnCountryTab.UseVisualStyleBackColor = true;
            this.NextBtnCountryTab.Click += new System.EventHandler(this.button1_Click);
            // 
            // BackBtnCountyTab
            // 
            this.BackBtnCountyTab.Dock = System.Windows.Forms.DockStyle.Right;
            this.BackBtnCountyTab.Location = new System.Drawing.Point(289, 0);
            this.BackBtnCountyTab.Name = "BackBtnCountyTab";
            this.BackBtnCountyTab.Size = new System.Drawing.Size(80, 34);
            this.BackBtnCountyTab.TabIndex = 1;
            this.BackBtnCountyTab.Text = "<<Back";
            this.BackBtnCountyTab.UseVisualStyleBackColor = true;
            this.BackBtnCountyTab.Click += new System.EventHandler(this.BackBtnCountyTab_Click);
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TabControlLocation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.88337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.64542F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.471208F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1121, 462);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.86002F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.13998F));
            this.tableLayoutPanel2.Controls.Add(this.ConfName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.EndDatelabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.StartDateLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.EmailAddress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ConferenceNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConfEmailAddress, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker2, 1, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.14815F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.85185F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(843, 155);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(220, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(220, 120);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 425);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BackBtnCountyTab);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.NextBtnCountryTab);
            this.splitContainer1.Size = new System.Drawing.Size(1115, 34);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.TabIndex = 8;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // dataGridView6
            // 
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView6.Location = new System.Drawing.Point(3, 3);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.Size = new System.Drawing.Size(1101, 208);
            this.dataGridView6.TabIndex = 0;
            this.dataGridView6.Text = "dataGridView6";
            // 
            // AddConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1121, 529);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddConf";
            this.Text = "AddConf";
            this.Load += new System.EventHandler(this.AddConf_Load);
            this.TabControlLocation.ResumeLayout(false);
            this.Country.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.County.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.City.ResumeLayout(false);
            this.TypeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.SpeakerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.CategoryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorAddress)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button NextBtnCountryTab;
        private System.Windows.Forms.Button BackBtnCountyTab;
        private System.Windows.Forms.ErrorProvider ErrorName;
        private System.Windows.Forms.ErrorProvider ErrorAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TabPage TypeTab;
        private System.Windows.Forms.TabPage SpeakerTab;
        private System.Windows.Forms.TabPage CategoryTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView6;
    }
}