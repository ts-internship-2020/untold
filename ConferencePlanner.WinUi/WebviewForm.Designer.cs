namespace ConferencePlanner.WinUi
{
    partial class WebviewForm
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
            this.webView1 = new Microsoft.Toolkit.Forms.UI.Controls.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).BeginInit();
            this.SuspendLayout();
            // 
            // webView1
            // 
            this.webView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView1.Location = new System.Drawing.Point(0, 0);
            this.webView1.Name = "webView1";
            this.webView1.Size = new System.Drawing.Size(800, 450);
            this.webView1.TabIndex = 0;
            this.webView1.DOMContentLoaded += new System.EventHandler<Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs>(this.webView1_DOMContentLoaded);
            // 
            // WebviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "WebviewForm";
            this.Text = "WebviewForm";
            this.Load += new System.EventHandler(this.WebviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Toolkit.Forms.UI.Controls.WebView webView1;
    }
}