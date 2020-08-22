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
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EmailTextBox.Location = new System.Drawing.Point(110, 44);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(260, 23);
            this.EmailTextBox.TabIndex = 0;
            this.EmailTextBox.Text = "Type an email";
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            this.EmailTextBox.Leave += new System.EventHandler(this.EmailTextBox_Leave);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SubmitBtn.Location = new System.Drawing.Point(199, 98);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(91, 28);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "OK";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SubmitBtn_KeyUp);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(86, 70);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Padding = new System.Windows.Forms.Padding(5);
            this.ErrorLabel.Size = new System.Drawing.Size(305, 25);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Insert a valid email address like \"name@example.com\"";
            this.ErrorLabel.Visible = false;
            // 
            // EmailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 191);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.EmailTextBox);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "EmailForm";
            this.Text = "Conference Planner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label ErrorLabel;
    }
}