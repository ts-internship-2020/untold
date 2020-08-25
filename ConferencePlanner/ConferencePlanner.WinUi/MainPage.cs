using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;

        private readonly IGetDemoRepository _getDemoRepository;

        private readonly IAttendeeButtonsRepository _attendeeButtons;

        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository, IGetDemoRepository getDemoRepository, 
            IAttendeeButtonsRepository attendeeButtonsRepository)
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
        //metoda de generat codul de bare.

        public String BarcodeGenerator()
        {
            Random random = new Random();
            int length = 10;
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append((char)(random.Next(1, 26) + 64)).ToString();
            }
            return sb.ToString().ToLower();
        }

        private void AddConferenceButton_Click(object sender, EventArgs e)
        {
            var varAddConf = new AddConf(_conferenceRepository, _countryRepository);

            TabControl.SelectedIndex = 1;
            varAddConf.ShowDialog();



        }

        private void CheckNumberOfRows(List<ConferenceModel> conferences)
        {
            if (conferences.Count() == 0)
            {
                OrganizerDataGrid.Visible = false;
                NoConferenceLabel.Visible = true;
            }
            else
            {
                OrganizerDataGrid.DataSource = conferences.ToList();
                OrganizerDataGrid.AutoGenerateColumns = false;

            }
        }

        private void TabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        { 
            var x = _conferenceRepository.GetConferencesByOrganizer(Program.EnteredEmailAddress);

            CheckNumberOfRows(x);

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

       


        private void TabAttendee_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OrganizerDataGrid.DataSource = null;

            DateTime StartDate = StartDatePicker.Value;
            DateTime EndDate = EndDatePicker.Value;
            //DateTime EndDate = EndDatePicker.Value;

            //listBox1.Items.Add(StartDate);

            //string test = System.Windows.Forms.TabControl.SelectedTab.Name;
            var conferences = _conferenceRepository.FilterConferences(Program.EnteredEmailAddress, StartDate, EndDate);

            CheckNumberOfRows(conferences);
        }

        private void Attend_Click(object sender, EventArgs e)
        {
            string barcodeGenerator = BarcodeGenerator();
            _attendeeButtons.Attend(Program.EnteredEmailAddress, barcodeGenerator);
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {

            //a = statusul participantului
            int a = 1;
            _attendeeButtons.WithdrawnCommand(Program.EnteredEmailAddress, a);
            

        }

            
        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OrganizerDataGrid.DataSource = null;

            DateTime StartDate = StartDatePicker.Value;
            DateTime EndDate = EndDatePicker.Value;
            //DateTime EndDate = EndDatePicker.Value;

            //listBox1.Items.Add(StartDate);

            //string test = System.Windows.Forms.TabControl.SelectedTab.Name;
            var conferences = _conferenceRepository.FilterConferences(Program.EnteredEmailAddress, StartDate, EndDate);

            CheckNumberOfRows(conferences);
        }

        private void Join_Click(object sender, EventArgs e)
        {
            int statusId = 2;
            var newform = new WebviewForm();
            newform.ShowDialog();
            _attendeeButtons.JoinCommand(Program.EnteredEmailAddress, statusId);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void OrganizerDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (OrganizerDataGrid.Columns.Contains("ConferenceId") && OrganizerDataGrid.Columns["ConferenceId"].Visible)
            {
                OrganizerDataGrid.Columns["ConferenceId"].Visible = false;
            }

            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "edit_column";
            editButtonColumn.Text = "Edit";
            int columnIndex = OrganizerDataGrid.ColumnCount;

            OrganizerDataGrid.Columns.Insert(columnIndex, editButtonColumn);
            OrganizerDataGrid.CellClick += OrganizerDataGrid_CellClick;

            OrganizerDataGrid.Columns[0].HeaderText = "Id";
            OrganizerDataGrid.Columns[1].HeaderText = "Name";
            OrganizerDataGrid.Columns[2].HeaderText = "Category";
            OrganizerDataGrid.Columns[3].HeaderText = "Type";
            OrganizerDataGrid.Columns[4].HeaderText = "Location";
            OrganizerDataGrid.Columns[5].HeaderText = "Main Speaker Name";
            OrganizerDataGrid.Columns[6].HeaderText = "Period";

            OrganizerDataGrid.Columns["Period"].DisplayIndex = 2;
            OrganizerDataGrid.Columns["ConferenceCategoryName"].DisplayIndex = 3;
            OrganizerDataGrid.Columns["ConferenceTypeName"].DisplayIndex = 4;
            OrganizerDataGrid.Columns["LocationName"].DisplayIndex = 5;
            OrganizerDataGrid.Columns["SpeakerName"].DisplayIndex = 6;

            OrganizerDataGrid.AutoResizeColumns();
            //OrganizerDataGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //OrganizerDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void OrganizerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //listBox1.Items.Add(e.ToString());
            if (e.ColumnIndex == OrganizerDataGrid.Columns["edit_column"].Index)
            {
                var id = (int) OrganizerDataGrid.Rows[e.RowIndex].Cells[0].Value;

                ConferenceModel conference = _conferenceRepository.GetConferenceById(id);

                var varAddConf = new AddConf(conference, _conferenceRepository, _countryRepository);

                varAddConf.ShowDialog();


            }
        }
    }
}
