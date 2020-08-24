using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class WebviewForm : Form
    {
        public WebviewForm()
        {
            InitializeComponent();
        }

        private void webView1_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs e)
        {

        }

        private void WebviewForm_Load(object sender, EventArgs e)
        {
            webView1.Navigate("http://www.google.com");
        }
    }
}
