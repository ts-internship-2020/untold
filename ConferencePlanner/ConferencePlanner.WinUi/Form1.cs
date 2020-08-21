using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConferencePlanner.Abstraction.Repository;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddConf_Load(object sender, EventArgs e)
        {
            var list = _countryRepository.GetListCountry();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConferenceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void County_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
