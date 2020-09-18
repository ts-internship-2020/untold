using System.Drawing;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpeakerDetails));
            this.speakerPhoto = new System.Windows.Forms.PictureBox();
            this.speakerName = new System.Windows.Forms.TextBox();
            this.speakerNationality = new System.Windows.Forms.TextBox();
            this.speakerRating = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.speakerPhoto)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // speakerPhoto
            // 
            this.speakerPhoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speakerPhoto.Location = new System.Drawing.Point(71, 61);
            this.speakerPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.speakerPhoto.Name = "speakerPhoto";
            this.speakerPhoto.Size = new System.Drawing.Size(178, 172);
            this.speakerPhoto.TabIndex = 0;
            this.speakerPhoto.TabStop = false;
            // 
            // speakerName
            // 
            this.speakerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speakerName.BackColor = System.Drawing.Color.Indigo;
            this.speakerName.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.speakerName.ForeColor = System.Drawing.SystemColors.Window;
            this.speakerName.Location = new System.Drawing.Point(4, 61);
            this.speakerName.Margin = new System.Windows.Forms.Padding(4);
            this.speakerName.Name = "speakerName";
            this.speakerName.ReadOnly = true;
            this.speakerName.Size = new System.Drawing.Size(199, 29);
            this.speakerName.TabIndex = 1;
            // 
            // speakerNationality
            // 
            this.speakerNationality.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.speakerNationality.BackColor = System.Drawing.Color.Indigo;
            this.speakerNationality.ForeColor = System.Drawing.Color.White;
            this.speakerNationality.Location = new System.Drawing.Point(4, 126);
            this.speakerNationality.Margin = new System.Windows.Forms.Padding(4);
            this.speakerNationality.Name = "speakerNationality";
            this.speakerNationality.ReadOnly = true;
            this.speakerNationality.Size = new System.Drawing.Size(199, 29);
            this.speakerNationality.TabIndex = 2;
            // 
            // speakerRating
            // 
            this.speakerRating.BackColor = System.Drawing.Color.Indigo;
            this.speakerRating.ForeColor = System.Drawing.Color.White;
            this.speakerRating.Location = new System.Drawing.Point(4, 192);
            this.speakerRating.Margin = new System.Windows.Forms.Padding(4);
            this.speakerRating.Name = "speakerRating";
            this.speakerRating.ReadOnly = true;
            this.speakerRating.Size = new System.Drawing.Size(69, 29);
            this.speakerRating.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.speakerPhoto, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 52);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 294);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.speakerName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.speakerNationality, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.speakerRating, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(325, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 286);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(700, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // SpeakerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(735, 389);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpeakerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SpeakerDetails";
            this.Load += new System.EventHandler(this.SpeakerDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speakerPhoto)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox speakerPhoto;
        private System.Windows.Forms.TextBox speakerName;
        private System.Windows.Forms.TextBox speakerNationality;
        private System.Windows.Forms.TextBox speakerRating;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}