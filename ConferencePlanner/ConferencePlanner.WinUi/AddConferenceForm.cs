﻿using System;
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
using ConferencePlanner.Repository.Ado.Repository;
using System.Transactions;

namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;
        private readonly ISpeakerRepository _speakerRepository;

        private int PageSize;

        private BindingList<SpeakerModel> Speakers;
        private int SpeakersTotalPages;
        private int SpeakersCurrentPage;
        private int UpdateSpeakerRow;
        
        //lista de ce facem

        public AddConf(IConferenceRepository conferenceRepository, ICountryRepository  countryRepository, ISpeakerRepository speakerRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _speakerRepository = speakerRepository;
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

            //this.PopulateForm(conference);

        }
        private void PopulateForm(ConferenceModel conference)
        {
            this.ConfName.Text = conference.ConferenceName;

            string[] dates = conference.Period.Split(" - ");
            this.StardDatePicker.Value = DateTime.Parse(dates[0]);
            this.EndDatePicker.Value = DateTime.Parse(dates[1]);

            this.ConfName.Text = conference.ConferenceId.ToString();


            int selectedCountryId = this._countryRepository.GetCountryIdByConferenceId(conference.ConferenceId);
            int selectedRowId = this.SearchIdInDataGrid(selectedCountryId, "DictionaryCountryId", this.CountryListDataGridView);
            this.ConfName.Text = selectedRowId.ToString();

            if (selectedRowId > 0)
            {
                this.CountryListDataGridView.Rows[selectedRowId].Selected = true;
            }


            string[] places = conference.Location.Split(", ");

            this.ConfEmailAddress.Text = conference.Location;
        }

        private int SearchIdInDataGrid(int value, string col_name, DataGridView dgv)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)row.Cells[col_name].Value == value)
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            return rowIndex;
        }

        private void AddConf_Load(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 0;

            // dataGridViewCountryTab.ColumnCount = 2;
            // dataGridViewCountryTab.Columns[0].Name = "Country Code";
            // dataGridViewCountryTab.Columns[1].Name = "Country Name";

            var countryList = _countryRepository.GetListCountry();

            CountryListDataGridView.DataSource = countryList.ToList();
            CountryListDataGridView.AutoGenerateColumns = false;

            CountryListDataGridView.Columns["DictionaryCountryId"].Visible = false;
            CountryListDataGridView.Columns["CountryCode"].HeaderText = "Country Code";
            CountryListDataGridView.Columns["CountryName"].HeaderText = "Country Name";
            CountryListDataGridView.DefaultCellStyle.ForeColor = Color.Black;

            //functie load country tab


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
                //aici face save   
                

            }
        }

        private void TabControlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if(TabControlLocation.SelectedTab.Name == "SpeakerTab")
            {
                this.LoadSpeakersTab();
            }
            
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

        private void SaveInDataBase()
        {
            
            
            //insert in bd
            //o sa fie apelata si la else in next btn
        }



        private void SaveNew_Click(object sender, EventArgs e)
        {

            ConfName.Text = string.Empty;
            ConfEmailAddress.Text = string.Empty;
            StardDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
        }

        private void FormatSpeakersDataGrid()
        {

        }


        private void LoadSpeakersTab()
        {
            this.Speakers = _speakerRepository.GetAllSpeakers();
            SpeakerListDataGrid.DefaultCellStyle.ForeColor = Color.Black;
            SpeakerListDataGrid.DataSource = this.Speakers;
        }

        private void SpeakerListDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (SpeakerListDataGrid.Columns.Contains("ImagePath"))
            {
                this.SpeakerListDataGrid.Columns.Remove("ImagePath");
            }
            if(SpeakerListDataGrid.Columns.Contains("SpeakerId") && SpeakerListDataGrid.Columns["SpeakerId"].Visible)
            {
                SpeakerListDataGrid.Columns["SpeakerId"].Visible = false;
            }
            if (SpeakerListDataGrid.Columns.Contains("main_speaker")==false)
            {
                DataGridViewCheckBoxColumn MainSpeaker = new DataGridViewCheckBoxColumn();
                MainSpeaker.ValueType = typeof(bool);
                MainSpeaker.Name = "main_speaker";
                MainSpeaker.HeaderText = "Main Speaker";
                SpeakerListDataGrid.Columns.Add(MainSpeaker);
            }

            this.SpeakerListDataGrid.Columns["FirstName"].HeaderText = "First Name";
            this.SpeakerListDataGrid.Columns["LastName"].HeaderText = "Last Name";





        }

        private void SpeakerListDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void SpeakerListDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
           // this.SpeakerListDataGrid.ContextMenuStrip.

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddUpdateMessage(string fName, string lName)
        {
            this.SpeakerUserMessagesBox.ForeColor = Color.MediumSeaGreen;
            string sName = fName +" "+ lName;
            this.SpeakerUserMessagesBox.Text = "You are now editing speaker " + sName + "'s informations. Press Enter to Save.";
            this.SpeakerUserMessagesBox.Visible = true;
            this.SpeakerSaveButton.Visible = true;
        }

        private void SpeakerListDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (SpeakerUserMessagesBox.Visible == false)
            {
                this.UpdateSpeakerRow = e.RowIndex;
                string fName = this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lName = this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                this.AddUpdateMessage(fName, lName);
            }
            //else ()
            




        }
        System.Windows.Forms.Timer timerHideLabel = new System.Windows.Forms.Timer();
        private void DisplayMessage()
        {

            timerHideLabel.Interval = 3000; // Five seconds.
            timerHideLabel.Tick += TimerHideLabel_Tick;
            timerHideLabel.Start();
        }
        private void TimerHideLabel_Tick(object sender, EventArgs e)
        {
            this.SpeakerUserMessagesBox.Visible = false;
            timerHideLabel.Stop();
        }

        private SpeakerModel GetSpeakerToUpdate()
        {
            SpeakerModel speaker = new SpeakerModel();
            speaker.FirstName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
            speaker.LastName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
            speaker.Nationality = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Nationality"].Value.ToString();
            speaker.Rating = (float) this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Rating"].Value;
            speaker.SpeakerId = (int)this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["SpeakerId"].Value;

            return speaker;
        }

        private void SpeakerSaveButton_Click(object sender, EventArgs e)
        {
            _speakerRepository.UpdateSpeaker(GetSpeakerToUpdate());
            this.SpeakerUserMessagesBox.Text = "Succesfully modified speaker :)";
            
            DisplayMessage();
            this.SpeakerSaveButton.Visible = false;
           
        }
    }
}
