namespace ConferencePlanner.WinUi
{
    partial class SpeakerDetails
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
            this.speakerPhoto = new System.Windows.Forms.PictureBox();
            this.speakerName = new System.Windows.Forms.TextBox();
            this.speakerNationality = new System.Windows.Forms.TextBox();
            this.speakerRating = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.speakerPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // speakerPhoto
            // 
            this.speakerPhoto.Location = new System.Drawing.Point(72, 54);
            this.speakerPhoto.Name = "speakerPhoto";
            this.speakerPhoto.Size = new System.Drawing.Size(120, 123);
            this.speakerPhoto.TabIndex = 0;
            this.speakerPhoto.TabStop = false;
            // 
            // speakerName
            // 
            this.speakerName.Location = new System.Drawing.Point(320, 54);
            this.speakerName.Name = "speakerName";
            this.speakerName.Size = new System.Drawing.Size(156, 23);
            this.speakerName.TabIndex = 1;
            this.speakerName.Text = "test";
            // 
            // speakerNationality
            // 
            this.speakerNationality.Location = new System.Drawing.Point(320, 107);
            this.speakerNationality.Name = "speakerNationality";
            this.speakerNationality.Size = new System.Drawing.Size(100, 23);
            this.speakerNationality.TabIndex = 2;
            // 
            // speakerRating
            // 
            this.speakerRating.Location = new System.Drawing.Point(320, 153);
            this.speakerRating.Name = "speakerRating";
            this.speakerRating.Size = new System.Drawing.Size(100, 23);
            this.speakerRating.TabIndex = 3;
            // 
            // SpeakerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 228);
            this.Controls.Add(this.speakerRating);
            this.Controls.Add(this.speakerNationality);
            this.Controls.Add(this.speakerName);
            this.Controls.Add(this.speakerPhoto);
            this.Name = "SpeakerDetails";
            this.Text = "SpeakerDetails";
            this.Load += new System.EventHandler(this.SpeakerDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speakerPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox speakerPhoto;
        private System.Windows.Forms.TextBox speakerName;
        private System.Windows.Forms.TextBox speakerNationality;
        private System.Windows.Forms.TextBox speakerRating;
    }
}