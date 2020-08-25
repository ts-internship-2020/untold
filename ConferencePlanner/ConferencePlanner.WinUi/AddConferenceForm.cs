using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;

        public AddConf(IConferenceRepository conferenceRepository, ICountryRepository  countryRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            InitializeComponent();

        }

        public AddConf()
        {

            InitializeComponent();
        }
        public AddConf(ConferenceModel conference, IConferenceRepository conferenceRepository, ICountryRepository countryRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;

            InitializeComponent();

            this.ConfName.Text = conference.ConferenceName;
            
            string[] dates = conference.Period.Split(" - ");
            this.MonthCalendar.SetSelectionRange(DateTime.Parse(dates[0]), DateTime.Parse(dates[1]));

            string[] places = conference.LocationName.Split(", ");

            this.ConfAddress.Text = conference.LocationName;

            this.CountryComboBox.Text = places[0];
            

        }

        private void AddConf_Load(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequiredFields();
            Close();
        }

        private void RequiredFields()
        {
           // if (ConfName.Text == string.Empty)
           // {
           //     errorProvider1.SetError(ConfName, "Insert conference name!");
           // }
           // else
           // {
           //     errorProvider1.Clear();
           // }

            /*  if (textBox1.Text == string.Empty)
              {
                  MessageBox.Show("Please enter a value to textBox1!");
                  return;
              }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NextBtnCountryTab.Enabled = true;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var list = _countryRepository.GetListCountry();
            CountryComboBox.DataSource = list;
        }
    }
}
