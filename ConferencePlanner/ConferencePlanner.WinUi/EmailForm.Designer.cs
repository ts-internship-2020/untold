namespace ConferencePlanner.WinUi
{
    partial class EmailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ErrorLabel2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.AcceptsReturn = true;
            this.EmailTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailTextBox.BackColor = System.Drawing.Color.Indigo;
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailTextBox.ForeColor = System.Drawing.Color.Silver;
            this.EmailTextBox.Location = new System.Drawing.Point(121, 381);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(260, 27);
            this.EmailTextBox.TabIndex = 0;
            this.EmailTextBox.Text = "Type an email...";
            this.EmailTextBox.Click += new System.EventHandler(this.EmailTextBox_Click);
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            this.EmailTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EmailTextBox_KeyUp);
            this.EmailTextBox.Leave += new System.EventHandler(this.EmailTextBox_Leave);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubmitBtn.BackColor = System.Drawing.Color.Indigo;
            this.SubmitBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Info;
            this.SubmitBtn.FlatAppearance.BorderSize = 0;
            this.SubmitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.SubmitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubmitBtn.ForeColor = System.Drawing.Color.White;
            this.SubmitBtn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SubmitBtn.Location = new System.Drawing.Point(202, 464);
            this.SubmitBtn.MaximumSize = new System.Drawing.Size(90, 30);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(90, 30);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Indigo;
            this.ErrorLabel.Location = new System.Drawing.Point(10, 421);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ErrorLabel.Size = new System.Drawing.Size(479, 35);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Insert a valid email address like \"name@example.com\"";
            this.ErrorLabel.Visible = false;
            // 
            // ErrorLabel2
            // 
            this.ErrorLabel2.AutoSize = true;
            this.ErrorLabel2.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrorLabel2.ForeColor = System.Drawing.Color.Indigo;
            this.ErrorLabel2.Location = new System.Drawing.Point(149, 421);
            this.ErrorLabel2.Name = "ErrorLabel2";
            this.ErrorLabel2.Size = new System.Drawing.Size(200, 25);
            this.ErrorLabel2.TabIndex = 3;
            this.ErrorLabel2.Text = "Insert a email address!";
            this.ErrorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 351);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(121, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "CONFERENCES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(193, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "WELCOME TO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(98, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EmailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(501, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ErrorLabel2);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.EmailTextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "EmailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conference Planner";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label ErrorLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}