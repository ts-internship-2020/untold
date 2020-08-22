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
            this.label1 = new System.Windows.Forms.Label();
            this.ConfName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Country = new System.Windows.Forms.TabPage();
            this.County = new System.Windows.Forms.TabPage();
            this.City = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.Country.SuspendLayout();
            this.County.SuspendLayout();
            this.City.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conference name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ConfName
            // 
            this.ConfName.Location = new System.Drawing.Point(130, 0);
            this.ConfName.Name = "ConfName";
            this.ConfName.Size = new System.Drawing.Size(153, 23);
            this.ConfName.TabIndex = 1;
            this.ConfName.TextChanged += new System.EventHandler(this.ConferenceName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conference period:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MonthCalendar
            // 
            this.MonthCalendar.Location = new System.Drawing.Point(130, 35);
            this.MonthCalendar.Name = "MonthCalendar";
            this.MonthCalendar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Conference address:";
            // 
            // ConfAddress
            // 
            this.ConfAddress.Location = new System.Drawing.Point(130, 214);
            this.ConfAddress.Name = "ConfAddress";
            this.ConfAddress.Size = new System.Drawing.Size(100, 23);
            this.ConfAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Location:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Country);
            this.tabControl1.Controls.Add(this.County);
            this.tabControl1.Controls.Add(this.City);
            this.tabControl1.Location = new System.Drawing.Point(96, 243);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(295, 109);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Country
            // 
            this.Country.Controls.Add(this.comboBox3);
            this.Country.Controls.Add(this.button1);
            this.Country.Location = new System.Drawing.Point(4, 24);
            this.Country.Name = "Country";
            this.Country.Padding = new System.Windows.Forms.Padding(3);
            this.Country.Size = new System.Drawing.Size(287, 81);
            this.Country.TabIndex = 0;
            this.Country.Text = "Country";
            this.Country.UseVisualStyleBackColor = true;
            this.Country.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // County
            // 
            this.County.Controls.Add(this.comboBox2);
            this.County.Controls.Add(this.button2);
            this.County.Location = new System.Drawing.Point(4, 24);
            this.County.Name = "County";
            this.County.Padding = new System.Windows.Forms.Padding(3);
            this.County.Size = new System.Drawing.Size(287, 81);
            this.County.TabIndex = 1;
            this.County.Text = "County";
            this.County.UseVisualStyleBackColor = true;
            this.County.Click += new System.EventHandler(this.County_Click);
            // 
            // City
            // 
            this.City.Controls.Add(this.comboBox1);
            this.City.Controls.Add(this.button3);
            this.City.Location = new System.Drawing.Point(4, 24);
            this.City.Name = "City";
            this.City.Padding = new System.Windows.Forms.Padding(3);
            this.City.Size = new System.Drawing.Size(287, 81);
            this.City.TabIndex = 2;
            this.City.Text = "City";
            this.City.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(186, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(30, 27);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(30, 26);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // AddConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ConfAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MonthCalendar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConfName);
            this.Controls.Add(this.label1);
            this.Name = "AddConf";
            this.Text = "AddConf";
            this.Load += new System.EventHandler(this.AddConf_Load);
            this.tabControl1.ResumeLayout(false);
            this.Country.ResumeLayout(false);
            this.County.ResumeLayout(false);
            this.City.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConfName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar MonthCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConfAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Country;
        private System.Windows.Forms.TabPage County;
        private System.Windows.Forms.TabPage City;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
    }
}