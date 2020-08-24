using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;

        private readonly IGetDemoRepository _getDemoRepository;

        private readonly IAttendeeButtonsRepository _attendeeButtons;

        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository, IGetDemoRepository getDemoRepository, IAttendeeButtonsRepository attendeeButtonsRepository)
        {
            _conferenceRepository = conferenceRepository;

            _countryRepository = countryRepository;

            _getDemoRepository = getDemoRepository;

            _attendeeButtons = attendeeButtonsRepository;

        InitializeComponent();
            
        }

        public MainPage() {

            InitializeComponent();
        }


        private void AddConferenceButton_Click(object sender, EventArgs e)
        {
            var varAddConf = new AddConf(_conferenceRepository, _countryRepository);

            //change tabControl to organizer if it's in atendee
            TabControl.SelectedTab = TabOrganizer;

            varAddConf.ShowDialog();
        }

        private void TabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        { //Program.EnteredEmailAddress
            var x = _conferenceRepository.GetConferencesByOrganizer(Program.EnteredEmailAddress);

            if (x.Count() == 0)
            {
                OrganizerDataGrid.Visible = false;
                NoConferenceLabel.Visible = true;
            }
            else
            {
                OrganizerDataGrid.DataSource = x.ToList();

                OrganizerDataGrid.AutoGenerateColumns = false;
                //if (OrganizerDataGrid.Columns.Remove("ConferenceId"))
                //{

                //}
                
                OrganizerDataGrid.Columns[0].HeaderText = "Name";
                OrganizerDataGrid.Columns[1].HeaderText = "Category";
                OrganizerDataGrid.Columns[2].HeaderText = "Type";

                //OrganizerDataGrid.Columns.Add("Location", "Location");
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            // var x = _getDemoRepository.GetDemo()
            
        }

       

        private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            //var x = _getDemoRepository.GetDemo()
            var x = _conferenceRepository.AttendeeConferences(Program.EnteredEmailAddress);
            AttendeeGridvw.DataSource = x.ToList();
            AttendeeGridvw.Columns.RemoveAt(0);
            AttendeeGridvw.Columns[0].HeaderText = "Conference Name";
            AttendeeGridvw.Columns[1].HeaderText = "Category";
            AttendeeGridvw.Columns[2].HeaderText = "Type";
            AttendeeGridvw.Columns[3].HeaderText = "Location";
            AttendeeGridvw.Columns[4].HeaderText = "Speaker Name";
        }

       


        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //WebView1.Navigate(new Uri(@"http://www.google.com"));
        }

        private void TabAttendee_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string StartDate = StartDatePicker.Value.ToString("yyyy-MM-dd");
            string EndDate = EndDatePicker.Value.ToString("yyyy-MM-dd");

            string test = TabControl.SelectedTab.Name;

            //var x = _conferenceRepository.FilterConferences(Program.EnteredEmailAddress, StartDate, EndDate);

        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string StartDate = StartDatePicker.Value.ToString("yyyy-MM-dd");
            string EndDate = EndDatePicker.Value.ToString("yyyy-MM-dd");
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            _attendeeButtons.AddEmail(Program.EnteredEmailAddress);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void AttendeeGridvw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AttendeeGridvw.Columns[e.ColumnIndex].Name == "OptionsButton")
            {
                MessageBox.Show("ok");
            }
        }
    }
}
