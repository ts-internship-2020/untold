﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using Tulpep.NotificationWindow;
using System.Data.SqlClient;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;


        private readonly IAttendeeButtonsRepository _attendeeButtons;

        private int PageSize = 1;
        //public int CurrentPageIndex { get; set; } //1
        //public int TotalPage {get; set;} //0
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;



        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository,
            IAttendeeButtonsRepository attendeeButtonsRepository)
        {
            _conferenceRepository = conferenceRepository;

            _countryRepository = countryRepository;

            _attendeeButtons = attendeeButtonsRepository;

            InitializeComponent();

        }

        public MainPage()
        {

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
            int PreviousPageOffSet = (this.CurrentPageIndex - 1) * this.PageSize;

            var allConferences = _conferenceRepository.GetConferencesByOrganizer(Program.EnteredEmailAddress);
            var conferences = _conferenceRepository.GetConferencesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet+this.PageSize+1);
            
            this.CheckPaginationButtonsVisibility();
            
            CalculateTotalPages(allConferences);

            CheckNumberOfRows(conferences);

        }

        private void CalculateTotalPages(List<ConferenceModel> allConferences)
        {
            int rowCount = allConferences.Count();
            TotalPage = rowCount / PageSize;
            // if any row left after calculated pages, add one more page 
            if (rowCount % PageSize > 0)
                TotalPage += 1;
        }

        private void CheckPaginationButtonsVisibility()
        {
            if (this.CurrentPageIndex == this.TotalPage)
            {
                this.RightArrowPagButton.Visible = false;
            }
            if (this.CurrentPageIndex == 1)
            {
                this.LeftArrowPagButton.Visible = false;
            }
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.RightArrowPagButton.Visible = true;
            }
            if (this.CurrentPageIndex > 1)
            {
                this.LeftArrowPagButton.Visible = true;
            }
        }


        private void RightArrowPagButton_MouseClick(object sender, EventArgs e)
        {

            this.CurrentPageIndex++;
            this.CheckPaginationButtonsVisibility();

            int PreviousPageOffSet = (this.CurrentPageIndex - 1) * this.PageSize; 
            CheckNumberOfRows(_conferenceRepository.GetConferencesByPage(
                Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1));
         
        }

        private void LeftArrowPagButton_MouseClick(object sender, EventArgs e)
        {
            this.CurrentPageIndex--;
            this.CheckPaginationButtonsVisibility();

            int PresentPageOffSet = (this.CurrentPageIndex - 1) * this.PageSize;
            CheckNumberOfRows(_conferenceRepository.GetConferencesByPage(
                Program.EnteredEmailAddress, PresentPageOffSet + 1, PresentPageOffSet + this.PageSize + 1));

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.CurrentPageIndex = 1;

            //DisplayNumOfPages.DataBindings.Add("Text", this, "CurrentPageIndex");
        }

        int a = 0;

        private void fillAttendeeGrid()
        {
            var listattendee = _conferenceRepository.AttendeeConferences(Program.EnteredEmailAddress);
            AttendeeGridvw.DataSource = listattendee.ToList();
            AttendeeGridvw.AutoGenerateColumns = false;
            AttendeeGridvw.Columns["ConferenceId"].Visible = false;

            AttendeeGridvw.Columns[1].HeaderText = "Conference Name";
            AttendeeGridvw.Columns[2].HeaderText = "Category";
            AttendeeGridvw.Columns[3].HeaderText = "Type";
            AttendeeGridvw.Columns[4].HeaderText = "Location";
            AttendeeGridvw.Columns[5].HeaderText = "Speaker Name";
            AttendeeGridvw.Columns[6].HeaderText = "Period";


            if (a == 0)
            {

                a++;
                DataGridViewButtonColumn attendButtonColumn = new DataGridViewButtonColumn();
                attendButtonColumn.Name = "attend_column";
                attendButtonColumn.Text = "Attend";

                int columnIndex = AttendeeGridvw.ColumnCount;


                AttendeeGridvw.Columns.Insert(columnIndex, attendButtonColumn);

                columnIndex = AttendeeGridvw.ColumnCount;
                DataGridViewButtonColumn withdrawButtonColumn = new DataGridViewButtonColumn();
                withdrawButtonColumn.Name = "withdraw_column";
                withdrawButtonColumn.Text = "Withdraw";

                AttendeeGridvw.Columns.Insert(columnIndex, withdrawButtonColumn);
                columnIndex = AttendeeGridvw.ColumnCount;

                DataGridViewButtonColumn joinButtonColumn = new DataGridViewButtonColumn();
                joinButtonColumn.Name = "join_column";
                joinButtonColumn.Text = "Join";



                AttendeeGridvw.Columns.Insert(columnIndex, joinButtonColumn);

                AttendeeGridvw.CellClick += this.AttendeeGridvw_CellClick;
                AttendeeGridvw.Columns[7].HeaderText = "Attend";
                AttendeeGridvw.Columns[8].HeaderText = "Withdraw";
                AttendeeGridvw.Columns[9].HeaderText = "Join";
                AttendeeGridvw.Columns.Add("Column", "Test");
                AttendeeGridvw.Columns["Column"].Visible = false;
                AttendeeGridvw.Columns[7].Tag = "test";

            }
        }

            private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            //var x = _getDemoRepository.GetDemo()
            fillAttendeeGrid();
            }







        //    //AttendeeGridvw.Columns.Insert(columnIndex: columnIndex + 2, joinButtonColumn);

        //    //AttendeeGridvw.CellClick += AttendeeGridvw_CellClick;


        //}

        


        private void TabAttendee_Click(object sender, EventArgs e)
        {

        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {

            DateTime StartDate = StartDatePicker.Value;
            DateTime EndDate = EndDatePicker.Value;

            if (TabControl.SelectedTab.Name == "TabOrganizer")
            {
                OrganizerDataGrid.DataSource = null;
                var conferences = _conferenceRepository.FilterConferencesByDate(Program.EnteredEmailAddress, StartDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), EndDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));

                CheckNumberOfRows(conferences);

            }
            else
            {
                AttendeeGridvw.DataSource = null;
                var allConferences = _conferenceRepository.FilterConfAttendeeByDate(Program.EnteredEmailAddress, StartDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), EndDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));

                //var conferences = FilterAttendee(allConferences, StartDate, EndDate);

                UpdateAttendee(FilterAttendee(allConferences, StartDate, EndDate));

            }

        }

        private void UpdateAttendee(List<ConferenceModel> conf)
        {
            AttendeeGridvw.DataSource = conf.ToList();
            listBox1.Items.Add("been here");

        }

        private List<ConferenceModel> FilterAttendee(List<ConferenceModel> allConferences, DateTime StartDate, DateTime EndDate)
        {
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            foreach (ConferenceModel conf in allConferences)
            {
                string[] aux = conf.Period.Split(" - ");
                DateTime sDate = DateTime.Parse(aux[0]);
                DateTime eDate = DateTime.Parse(aux[1]);
                //listBox1.Items.Add(sDate);
                //listBox1.Items.Add(StartDate.Date);
                if ( DateTime.Compare(StartDate.Date, sDate) <=0 && DateTime.Compare(eDate, EndDate.Date) <= 0)
                {
                    listBox1.Items.Add(conf.ConferenceName);
                    conferences.Append(conf);
                }
            }
            return conferences;
        }
    

        private void Attend_Click(int confId)
        {
            string barcodeGenerator = BarcodeGenerator();
           _attendeeButtons.Attend(Program.EnteredEmailAddress, barcodeGenerator, confId);

            //var w = new Form();
            //Size = new Size(0, 0);
            //Task.Delay(TimeSpan.FromSeconds(3))
            //    .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

            //MessageBox.Show(w, "Felicitari, te-ai inscris cu succes!");
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Felicitari!";
            popup.ContentText = "Te-ai inscris cu succes!";
            popup.Popup();
            fillAttendeeGrid();
        }

        private void Withdraw_Click(int confId)
        {

            //a = statusul participantului
            _attendeeButtons.WithdrawnCommand(Program.EnteredEmailAddress, confId);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Ai renuntat la aceasta conferinta!";
            popup.ContentText = "Poti alege oricand din cele disponibile";
            popup.Popup();
            fillAttendeeGrid();
        }

            
        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OrganizerDataGrid.DataSource = null;

            DateTime StartDate = StartDatePicker.Value;
            DateTime EndDate = EndDatePicker.Value;

            if (TabControl.SelectedTab.Name == "TabOrganizer")
            {
                var conferences = _conferenceRepository.FilterConferencesByDate(Program.EnteredEmailAddress, StartDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), EndDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));

                CheckNumberOfRows(conferences);
            }
            else
            {
                var allConferences = _conferenceRepository.FilterConfAttendeeByDate(Program.EnteredEmailAddress, StartDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), EndDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"));

                var conferences = FilterAttendee(allConferences, StartDate, EndDate);

                UpdateAttendee(conferences);

            }
        }

        private void Join_Click(int statusId)
        {
            var newform = new WebviewForm();
            newform.ShowDialog();
            _attendeeButtons.JoinCommand(Program.EnteredEmailAddress, statusId);
        }


        private void OrganizerDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (OrganizerDataGrid.Columns.Contains("ConferenceId") && OrganizerDataGrid.Columns["ConferenceId"].Visible)
            {
                OrganizerDataGrid.Columns["ConferenceId"].Visible = false;
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
                editButtonColumn.UseColumnTextForButtonValue = true;
                editButtonColumn.Text = "Edit";
                editButtonColumn.Width = 25;
                editButtonColumn.HeaderText = "";
                editButtonColumn.Name = "edit_column";

                //editButtonColumn.Text.
                int columnIndex = OrganizerDataGrid.ColumnCount;

                OrganizerDataGrid.Columns.Insert(columnIndex, editButtonColumn);
                OrganizerDataGrid.CellClick += OrganizerDataGrid_CellClick;

            }


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
                var id = (int)OrganizerDataGrid.Rows[e.RowIndex].Cells[0].Value;

                ConferenceModel conference = _conferenceRepository.GetConferenceById(id);

                var varAddConf = new AddConf(conference, _conferenceRepository, _countryRepository);

                varAddConf.ShowDialog();

            }
        }
        private void AttendeeGridvw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == AttendeeGridvw.Columns["attend_column"].Index)
            {


                //AttendeeGridvw.Rows[e.RowIndex].Cells[7].ReadOnly = true;
                //AttendeeGridvw.Rows[e.RowIndex].Cells[7].Visible = false;
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[0].Value;
                Attend_Click(confid);
                AttendeeGridvw.Rows[e.RowIndex].Cells[10].Value = "test";
                if (AttendeeGridvw.Rows[e.RowIndex].Cells[10].Value == "test")
                {
                    
                    return;
                }

            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["withdraw_column"].Index)
            {
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[0].Value;
                Withdraw_Click(confid);
            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["join_column"].Index)
            {
               int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[0].Value;
               Join_Click(confid);
            }

        }

        private void TabAttendee_Click_1(object sender, EventArgs e)
        {

        }

        private void AttendeeGridvw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

