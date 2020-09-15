using ConferencePlanner.Abstraction.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class EmailForm : Form
    {

        public readonly IServiceProvider _ServiceProvider;

        private static IConferenceRepository _conferenceRepository;

        private static ICountryRepository _countryRepository;
        private static ICountyRepository _countyRepository;
        private static ICityRepository _cityRepository;

        private static ITypeRepository _typeRepository;
        private static ISpeakerRepository _speakerRepository;
        private static ICategoryRepository _categoryRepository;
        private static IAttendeeButtonsRepository _attendeeButtonsRepository;

       // public EmailForm(IServiceProvider ServiceProvider)
       // {
       //     _ServiceProvider = ServiceProvider;
       //     InitializeComponent();
       // }

        public EmailForm(IServiceProvider ServiceProvider)
        {
            _ServiceProvider = ServiceProvider;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        public void init()
        {
            _conferenceRepository = _ServiceProvider.GetRequiredService<IConferenceRepository>();
            _countryRepository = _ServiceProvider.GetRequiredService<ICountryRepository>();
            _attendeeButtonsRepository = _ServiceProvider.GetRequiredService<IAttendeeButtonsRepository>();
            _speakerRepository = _ServiceProvider.GetRequiredService<ISpeakerRepository>();
            _countyRepository = _ServiceProvider.GetRequiredService<ICountyRepository>();
            _cityRepository = _ServiceProvider.GetRequiredService<ICityRepository>();
            _categoryRepository = _ServiceProvider.GetRequiredService<ICategoryRepository>();
            _typeRepository = _ServiceProvider.GetRequiredService<ITypeRepository>();
           
        }
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

            EmailTextBox.ForeColor = Color.White;
            ErrorLabel.Visible = false;
            ErrorLabel2.Visible = false;
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
                    EmailTextBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                ErrorLabel2.Visible = true;
                EmailTextBox.Focus();
                return false;
            }
        }
        public void NextPage()
        {
            init();
            Hide();
            Program.EnteredEmailAddress = EmailTextBox.Text;
            var NextPage = new MainPage(_conferenceRepository, _countryRepository, _attendeeButtonsRepository, _speakerRepository, _countyRepository, _cityRepository,_typeRepository, _categoryRepository);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
