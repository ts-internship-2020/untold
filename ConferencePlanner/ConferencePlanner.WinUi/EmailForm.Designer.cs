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
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.AcceptsReturn = true;
            this.EmailTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailTextBox.ForeColor = System.Drawing.Color.Silver;
            this.EmailTextBox.Location = new System.Drawing.Point(104, 41);
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
            this.SubmitBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.Info;
            this.SubmitBtn.FlatAppearance.BorderSize = 0;
            this.SubmitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.SubmitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SubmitBtn.Location = new System.Drawing.Point(186, 104);
            this.SubmitBtn.MaximumSize = new System.Drawing.Size(90, 30);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(90, 30);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "OK";
            this.SubmitBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(48, 71);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ErrorLabel.Size = new System.Drawing.Size(382, 30);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Insert a valid email address like \"name@example.com\"";
            this.ErrorLabel.Visible = false;
            // 
            // ErrorLabel2
            // 
            this.ErrorLabel2.AutoSize = true;
            this.ErrorLabel2.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ErrorLabel2.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel2.Location = new System.Drawing.Point(154, 81);
            this.ErrorLabel2.Name = "ErrorLabel2";
            this.ErrorLabel2.Size = new System.Drawing.Size(157, 20);
            this.ErrorLabel2.TabIndex = 3;
            this.ErrorLabel2.Text = "Insert a email address!";
            this.ErrorLabel2.Visible = false;
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 200);
            this.Controls.Add(this.ErrorLabel2);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.EmailTextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "EmailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conference Planner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label ErrorLabel2;
    }
}