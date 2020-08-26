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
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;

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
            //this.MonthCalendar.SetSelectionRange(DateTime.Parse(dates[0]), DateTime.Parse(dates[1]));

            string[] places = conference.LocationName.Split(", ");

            this.ConfEmailAddress.Text = conference.LocationName;

            //this.CountryComboBox.Text = places[0];
            //this.CountyComboBox.Text = places[1];
            //this.CityComboBox.Text = places[2];


        }

        private void AddConf_Load(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 0;

            // dataGridViewCountryTab.ColumnCount = 2;
            // dataGridViewCountryTab.Columns[0].Name = "Country Code";
            // dataGridViewCountryTab.Columns[1].Name = "Country Name";

            var list = _countryRepository.GetListCountry();
            CountryListDataGridView.DataSource = list.ToList();
            CountryListDataGridView.AutoGenerateColumns = false;

            CountryListDataGridView.Columns["DictionaryCountryId"].Visible = false;
            CountryListDataGridView.Columns["CountryCode"].HeaderText = "Country Code";
            CountryListDataGridView.Columns["CountryName"].HeaderText = "Country Name";
            CountryListDataGridView.DefaultCellStyle.ForeColor = Color.Black;


        }

       



        private void button2_Click(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(ConfName.Text == string.Empty)
            {
                ErrorName.SetError(ConfName, "Please enter a value in the conference name fild!");
                return;
            }
            else if(ConfEmailAddress.Text == string.Empty)
            {
                ErrorAddress.SetError(ConfEmailAddress, "Please enter a value in the conference address fild!");
                return;
            }
            else
            TabControlLocation.SelectedIndex = 1;
            ErrorName.Clear();
            ErrorAddress.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CityComboBox.Enabled = true;
           
            Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NextTabBtn.Enabled = true;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }
        

        private void BackBtnCountyTab_Click(object sender, EventArgs e)
        {

        }

        //private void BackBtnCityTab_Click(object sender, EventArgs e)
        //{
        //    TabControlLocation.SelectedIndex = 1;
        //}

        private void SaveAndNewBtnCityTab_Click(object sender, EventArgs e)
        {
            //SaveAndNewBtnCityTab.Enabled = true;
            
            //CountryComboBox.SelectedItem = string.Empty;
            //CountyComboBox.SelectedItem = string.Empty;
            //CityComboBox.SelectedItem = string.Empty;
        }

        private void ComboBoxCountyTab_SelectedIndexChanged(object sender, EventArgs e)
        {
           // NextBtnCountyTab.Enabled = true;
        }

        private void ConferenceNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void BackBtnTab_Click(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex--;
        }

        public int selectedRow;


        private void NextBtn_Click(object sender, EventArgs e)
        {
            int selectedRowCount = CountryListDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (NextTabBtn.Text=="Next>>")
            {
                if(selectedRowCount == 1)
                {

                    //  selectedRow = CountryListDataGridView.ColumnCount;
                    //  CountryListDataGridView.Columns.Insert(DictionaryCountryId);

                    //selectedRow = CountryListDataGridView.SelectedRows.Index.ToString();

                        //sb.Append(dataGridView1.SelectedRows[i].Index.ToString());

                    TabControlLocation.SelectedIndex++;

                }

                else
                {
                    //label cu mesaj
                }
            }
            else 
            {
                //save       
                

            }
        }

        private void TabControlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TabControlLocation.SelectedIndex > 0)
            {
                BackTabBtn.Enabled = true;
            }
            else
            {
                BackTabBtn.Enabled = false;
            }
            if(TabControlLocation.SelectedIndex >= 5)
            {
                SaveNew.Visible = true; 
                NextTabBtn.Text = "Save";
            }
            else
            {
                SaveNew.Visible = false;
                NextTabBtn.Text = "Next>>";
            }
        }

        //private void save care face insert in baza de date
        //si pe care o apelez mai jos si la else next btn




        private void SaveNew_Click(object sender, EventArgs e)
        {
            ConfName.Text = string.Empty;
            ConfEmailAddress.Text = string.Empty;
            StardDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
        }

        private void CountryListDataGridView_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void CountryListDataGridView_Click(object sender, EventArgs e)
        {
            
        }
    }
}
