using ConferencePlanner.Abstraction.Repository;
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

        public readonly IServiceProvider _ServiceProvider;

        private static IConferenceRepository _conferenceRepository;

        private static ICountryRepository _countryRepository;

        private static IGetDemoRepository _getDemoRepository;

        private static IAttendeeButtonsRepository _attendeeButtonsRepository;

        public EmailForm(IServiceProvider ServiceProvider)
        {
            _ServiceProvider = ServiceProvider;
            InitializeComponent();
        }

        public void init()
        {
            _conferenceRepository = _ServiceProvider.GetRequiredService<IConferenceRepository>();
            _countryRepository = _ServiceProvider.GetRequiredService<ICountryRepository>();
            _attendeeButtonsRepository = _ServiceProvider.GetRequiredService<IAttendeeButtonsRepository>();

        }
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            EmailTextBox.ForeColor = Color.Black;
            ErrorLabel.Visible = false;
        }

        private bool CheckEmail()
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
                    return false;
                }
                else
                { 
                    return true;
                }
               
            }
            return false;
        }
        public void NextPage()
        {
            init();
            Hide();
            Program.EnteredEmailAddress = EmailTextBox.Text;
            var NextPage = new MainPage(_conferenceRepository, _countryRepository, _getDemoRepository, _attendeeButtonsRepository);
            NextPage.ShowDialog();
        }

        private void EmailTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckEmail())
            {
                NextPage();
            }
        }

        private void EmailTextBox_Click(object sender, EventArgs e)
        {
            EmailTextBox.Text = "";
            EmailTextBox.ForeColor = Color.Black;
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            CheckEmail();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (CheckEmail())
            {
                NextPage();
            }
        }
    }
}
