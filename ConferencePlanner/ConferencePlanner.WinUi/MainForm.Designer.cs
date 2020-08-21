namespace ConferencePlanner.WinUi
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabAttendee = new System.Windows.Forms.TabPage();
            this.AttendeeGridView = new System.Windows.Forms.DataGridView();
            this.TabOrganizer = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TabAttendee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(29, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(219, 49);
            this.listBox1.TabIndex = 2;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabAttendee);
            this.TabControl.Controls.Add(this.TabOrganizer);
            this.TabControl.Location = new System.Drawing.Point(42, 67);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(732, 311);
            this.TabControl.TabIndex = 3;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TabAttendee
            // 
            this.TabAttendee.Controls.Add(this.AttendeeGridView);
            this.TabAttendee.Location = new System.Drawing.Point(4, 24);
            this.TabAttendee.Name = "TabAttendee";
            this.TabAttendee.Padding = new System.Windows.Forms.Padding(3);
            this.TabAttendee.Size = new System.Drawing.Size(724, 283);
            this.TabAttendee.TabIndex = 0;
            this.TabAttendee.Text = "Attendee";
            this.TabAttendee.UseVisualStyleBackColor = true;
            this.TabAttendee.Layout += new System.Windows.Forms.LayoutEventHandler(this.tabPage1_Layout);
            // 
            // TabOrganizer
            // 
            this.TabOrganizer.Location = new System.Drawing.Point(4, 24);
            this.TabOrganizer.Name = "TabOrganizer";
            this.TabOrganizer.Padding = new System.Windows.Forms.Padding(3);
            this.TabOrganizer.Size = new System.Drawing.Size(724, 283);
            this.TabOrganizer.TabIndex = 1;
            this.TabOrganizer.Text = "Organizer";
            this.TabOrganizer.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "AddConf";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.TabControl.ResumeLayout(false);
            this.TabAttendee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttendeeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            // 
            // AttendeeGridView
            // 
            this.AttendeeGridView.AllowUserToOrderColumns = true;
            this.AttendeeGridView.BackgroundColor = System.Drawing.Color.Azure;
            this.AttendeeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttendeeGridView.GridColor = System.Drawing.SystemColors.MenuText;
            this.AttendeeGridView.Location = new System.Drawing.Point(3, 3);
            this.AttendeeGridView.Name = "AttendeeGridView";
            this.AttendeeGridView.Size = new System.Drawing.Size(645, 277);
            this.AttendeeGridView.TabIndex = 0;
            this.AttendeeGridView.Text = "AttendeeGridView";

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabAttendee;
        private System.Windows.Forms.TabPage TabOrganizer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView AttendeeGridView;
    }
}