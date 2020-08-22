using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class EmailForm : Form
    {

        
        public EmailForm()
        {
            InitializeComponent();
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (EmailTextBox.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(EmailTextBox.Text.Trim()))
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text="Insert a valid email address like 'name @example.com' ";
                    EmailTextBox.Focus();
                }
                else
                {
                    SubmitBtnClick();
                }
               
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Insert an email adress";
            }
        }



        public void SubmitBtnClick()
        {
            Program.EnteredEmailAddress = EmailTextBox.Text;
            var NextPage = new MainPage();
            NextPage.ShowDialog();

        }
    }
}
