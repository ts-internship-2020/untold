using ConferencePlanner.Abstraction.Model;
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
using System.Net.Mail;
using System.Net;
using ConferencePlanner.Repository.Ado.Repository;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;


        private readonly IAttendeeButtonsRepository _attendeeButtons;
        private readonly ISpeakerRepository _speakerRepository;

        private int PageSize = 3;
        //public int CurrentPageIndex { get; set; } //1
        //public int TotalPage {get; set;} //0
        private int OrganizerCurrentPageIndex = 1;
        private int OrganizerTotalPage = 0;


        private int AttendeeCurrentPageIndex = 1;
        private int AttendeeTotalPage = 0;

        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository,
            IAttendeeButtonsRepository attendeeButtonsRepository, ISpeakerRepository speakerRepository)
        {
            _conferenceRepository = conferenceRepository;

            _countryRepository = countryRepository;

            _attendeeButtons = attendeeButtonsRepository;

            _speakerRepository = speakerRepository;

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

        int check = 0;
        int check2 = 0;

        private void AddConferenceButton_Click(object sender, EventArgs e)
        {
            var varAddConf = new AddConf(_conferenceRepository, _countryRepository, _speakerRepository);

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
        private void CheckNumberOfRowsAttendee(List<ConferenceModel> attendees)
        {
            if (attendees.Count() == 0)
            {
               AttendeeGridvw.Visible = false;
               //NoConferenceLabel.Visible = true;
            }
            else
            {
                AttendeeGridvw.Visible = true;
                AttendeeGridvw.DataSource = attendees.ToList();
                AttendeeGridvw.AutoGenerateColumns = false;

           }
        }



        private void TabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] dates = new string[2];
            if (check==0)
            {
                dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
            }
            else
            {
                dates = GetCurrentDateFilterSelection();
            }
            
            int PreviousPageOffSet = (this.OrganizerCurrentPageIndex - 1) * this.PageSize;

            var allConferences = _conferenceRepository.GetConferencesByOrganizer(Program.EnteredEmailAddress);
            
            var conferences = _conferenceRepository.GetConferencesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]);

            this.CheckPaginationButtonsVisibility();

            CalculateTotalPages(allConferences, this.TabControl.SelectedTab);

            CheckNumberOfRows(conferences);

        }

        private void CalculateTotalPages(List<ConferenceModel> allConferences, TabPage test)
        {
            int rowCount = allConferences.Count();

            if (test.Name == "TabOrganizer")
            {
                this.OrganizerTotalPage = rowCount / this.PageSize;
                
                if (rowCount % this.PageSize > 0)
                    this.OrganizerTotalPage += 1;

            }
            else if(test.Name== "TabAttendee")
            {

                this.AttendeeTotalPage = rowCount / this.PageSize;
                
                if (rowCount % this.PageSize > 0)
                    this.AttendeeTotalPage += 1;

            }

        }

        private void CheckPaginationButtonsVisibility()
        {
            if (this.OrganizerCurrentPageIndex == this.OrganizerTotalPage)
            {
                this.RightArrowPagButton.Visible = false;
            }
            if (this.OrganizerCurrentPageIndex == 1)
            {
                this.LeftArrowPagButton.Visible = false;
            }
            if (this.OrganizerCurrentPageIndex < this.OrganizerTotalPage)
            {
                this.RightArrowPagButton.Visible = true;
            }
            if (this.OrganizerCurrentPageIndex > 1)
            {
                this.LeftArrowPagButton.Visible = true;
            }
        }

        private void CheckPaginationButtonsVisibilityAttendee()
        {
            if (this.AttendeeCurrentPageIndex == this.AttendeeTotalPage)
            {
                this.RightArrowPagButton.Visible = false;
            }
            if (this.AttendeeCurrentPageIndex == 1)
            {
                this.LeftArrowPagButton.Visible = false;
            }
            if (this.AttendeeCurrentPageIndex < this.AttendeeTotalPage)
            {
                this.RightArrowPagButton.Visible = true;
            }
            if (this.AttendeeCurrentPageIndex > 1)
            {
                this.LeftArrowPagButton.Visible = true;
            }
        }

        private void CreatePage(){
             string[] dates = new string[2];
            if (check == 0)
            {
                dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
            }
            else
            {
                dates = GetCurrentDateFilterSelection();
            }
            
            this.CheckPaginationButtonsVisibility();

            int PreviousPageOffSet = (this.OrganizerCurrentPageIndex - 1) * this.PageSize;
            CheckNumberOfRows(_conferenceRepository.GetConferencesByPage(
                Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]));
            }

        private void CreateAttendeePage()
        {

            string[] dates;
            if (check2 == 0)
            {
                dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
            }
            else
            {
                dates = GetCurrentDateFilterSelection();
            }
            this.CheckPaginationButtonsVisibilityAttendee();

            int PreviousPageOffSet = (this.AttendeeCurrentPageIndex - 1) * this.PageSize;
            CheckNumberOfRowsAttendee(_conferenceRepository.GetAttendeesByPage(
                Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]));


        }


        private void RightArrowPagButton_MouseClick(object sender, EventArgs e)
        {
            if (this.TabControl.SelectedTab.Name == "TabOrganizer")
            {

                this.OrganizerCurrentPageIndex++;
                this.CreatePage();
            }
            else if(this.TabControl.SelectedTab.Name == "TabAttendee")
            {
                //listBox1.Items.Add(this.TabControl.SelectedTab.Name);
                this.AttendeeCurrentPageIndex++;
                this.CreateAttendeePage();
            }

           

         
        }

        private void LeftArrowPagButton_MouseClick(object sender, EventArgs e)
        {
            if (this.TabControl.SelectedTab.Name == "TabOrganizer")
            {
                this.OrganizerCurrentPageIndex--;
                this.CreatePage();
            }
            else if(this.TabControl.SelectedTab.Name == "TabAttendee")
            {
                this.AttendeeCurrentPageIndex--;
                this.CreateAttendeePage();
            }

        }


        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        int a = 0;

        private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            string[] dates = new string[2];
            if (check2 == 0)
            {
                dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
            }
            else
            {
                dates = GetCurrentDateFilterSelection();
            }
            //var x = _getDemoRepository.GetDemo()

            //var listattendee = _conferenceRepository.AttendeeConferences(Program.EnteredEmailAddress);
            //AttendeeGridvw.DataSource = listattendee.ToList();

            int PreviousPageOffSet = (this.AttendeeCurrentPageIndex - 1) * this.PageSize;

            var allConferences = _conferenceRepository.AttendeeConferences(Program.EnteredEmailAddress);
            //listBox1.Items.Add(PreviousPageOffSet);
            var attendees = _conferenceRepository.GetAttendeesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1,dates[0],dates[1]);

            //listBox1.Items.Add(attendees[0].);
            this.CheckPaginationButtonsVisibilityAttendee();

            CalculateTotalPages(allConferences, this.TabControl.SelectedTab);

            AttendeeGridvw.DataSource = attendees;
            //AttendeeGridvw.Columns[0].HeaderText = "row_num";
            //AttendeeGridvw.Columns[1].HeaderText = "StatusId";
            //AttendeeGridvw.Columns[2].HeaderText = "ConferenceId";
            AttendeeGridvw.Columns["RowNum"].Visible = false;
            AttendeeGridvw.Columns["StatusId"].Visible = false;
            AttendeeGridvw.Columns["ConferenceId"].Visible = false;

            //AttendeeGridvw.Columns[0].HeaderText = "RowNum";
            //AttendeeGridvw.Columns[1].HeaderText = "StatusId";
            //AttendeeGridvw.Columns[2].HeaderText = "ConferenceId";
            AttendeeGridvw.Columns[3].HeaderText = "Name";
            AttendeeGridvw.Columns[4].HeaderText = "Category";
            AttendeeGridvw.Columns[5].HeaderText = "Type";
            //AttendeeGridvw.Columns[6].HeaderText = "Category";
            //AttendeeGridvw.Columns[7].HeaderText = "Location";
           //AttendeeGridvw.Columns[8].HeaderText = "Speaker";


            //AttendeeGridvw.Columns["ConferenceName"].DisplayIndex = 3;
            //AttendeeGridvw.Columns["Period"].DisplayIndex = 4;
            //AttendeeGridvw.Columns["ConferenceTypeName"].DisplayIndex = 5;
            //AttendeeGridvw.Columns["ConferenceCategoryName"].DisplayIndex = 6;
            //AttendeeGridvw.Columns["Location"].DisplayIndex = 7;
            //AttendeeGridvw.Columns["Speaker"].DisplayIndex = 8;

            //AttendeeGridvw.Columns[9].HeaderText = "Period";
            //AttendeeGridvw.Columns[10].HeaderText = "Period";
            //AttendeeGridvw.Columns[11].HeaderText = "Period";
            //AttendeeGridvw.Columns["CategoryTypeName"].HeaderText = "Type";


            if (a == 0)
            {
                

                //AttendeeGridvw.AutoGenerateColumns = false;

                a++;
                DataGridViewButtonColumn attendButtonColumn = new DataGridViewButtonColumn();
                attendButtonColumn.Name = "attend_column";
                attendButtonColumn.Text = "Attend";
                attendButtonColumn.HeaderText = "Attend";
               // attendButtonColumn.DefaultCellStyle.BackColor = System.Drawing.Color.Black;

                int columnIndex = AttendeeGridvw.ColumnCount;

                
                AttendeeGridvw.Columns.Insert(columnIndex,attendButtonColumn);

                columnIndex = AttendeeGridvw.ColumnCount;
                DataGridViewButtonColumn withdrawButtonColumn = new DataGridViewButtonColumn();
                withdrawButtonColumn.Name = "withdraw_column";
                withdrawButtonColumn.Text = "Withdraw";
                withdrawButtonColumn.HeaderText = "Withdraw";
                AttendeeGridvw.Columns.Insert(columnIndex, withdrawButtonColumn);
                columnIndex = AttendeeGridvw.ColumnCount;

                DataGridViewButtonColumn joinButtonColumn = new DataGridViewButtonColumn();
                joinButtonColumn.Name = "join_column";
                joinButtonColumn.Text = "Join";
                joinButtonColumn.HeaderText = "Join";

                AttendeeGridvw.Columns["RowNum"].Visible = false;
                AttendeeGridvw.Columns["StatusId"].Visible = false;
                AttendeeGridvw.Columns["ConferenceId"].Visible = false;
                AttendeeGridvw.Columns.Insert(columnIndex, joinButtonColumn);
                
                AttendeeGridvw.CellClick += AttendeeGridvw_CellClick;
                //AttendeeGridvw.Columns[12].HeaderText = "Attend";
                // AttendeeGridvw.Columns[13].HeaderText = "Withdraw";
                // AttendeeGridvw.Columns[14].HeaderText = "Join";
                //AttendeeGridvw.Columns.Add("Column", "Test");
                //AttendeeGridvw.Columns["Column"].Visible = false;
                //AttendeeGridvw.Columns[7].Tag = "test";
               
            }

            AttendeeGridvw.AutoResizeColumns();

        }







        //    //AttendeeGridvw.Columns.Insert(columnIndex: columnIndex + 2, joinButtonColumn);

        //    //AttendeeGridvw.CellClick += AttendeeGridvw_CellClick;


        //}

        


        private void TabAttendee_Click(object sender, EventArgs e)
        {

        }

        private string[] GetCurrentDateFilterSelection()
        {
            string[] dates = new string[2];
            
            dates[0] = StartDatePicker.Value.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");
            dates[1] = EndDatePicker.Value.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss");

            return dates;
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            
            
            string[] dates = this.GetCurrentDateFilterSelection();

            if (TabControl.SelectedTab.Name == "TabOrganizer")
            {
                check = 1;
                OrganizerDataGrid.DataSource = null;
                this.OrganizerCurrentPageIndex = 1;
                var allConferences = _conferenceRepository.FilterConferencesByDate(Program.EnteredEmailAddress, dates[0], dates[1]);
              
                this.CalculateTotalPages(allConferences, TabControl.SelectedTab);
                var conferences = _conferenceRepository.GetConferencesByPage(Program.EnteredEmailAddress,1 ,this.PageSize+1, dates[0], dates[1]);

                this.CheckPaginationButtonsVisibility();
                CheckNumberOfRows(conferences);

            }
            else if (TabControl.SelectedTab.Name == "TabAttendee")
            {
                check2 = 1;
                AttendeeGridvw.DataSource = null;
                this.AttendeeCurrentPageIndex = 1;
                var allConferences = _conferenceRepository.FilterAttendeesByDate(Program.EnteredEmailAddress, dates[0], dates[1]);

                this.CalculateTotalPages(allConferences, TabControl.SelectedTab);
                var conferences = _conferenceRepository.GetAttendeesByPage(Program.EnteredEmailAddress, 1, this.PageSize + 1, dates[0], dates[1]);

                this.CheckPaginationButtonsVisibilityAttendee();
                CheckNumberOfRowsAttendee(conferences);

                //var allConferences = _conferenceRepository.FilterConfAttendeeByDate(Program.EnteredEmailAddress, dates[0], dates[1]);

                //var conferences = FilterAttendee(allConferences, StartDate, EndDate);

                //UpdateAttendee(FilterAttendee(allConferences, dates[0], dates[1]));

            }

        }

        private void UpdateAttendee(List<ConferenceModel> conf)
        {
            //AttendeeGridvw.DataSource = conf.ToList();
          

        }

        private List<ConferenceModel> FilterAttendee(List<ConferenceModel> allConferences, DateTime StartDate, DateTime EndDate)
        {
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            foreach (ConferenceModel conf in allConferences)
            {
                string[] aux = conf.Period.Split(" - ");
                DateTime sDate = DateTime.Parse(aux[0]);
                DateTime eDate = DateTime.Parse(aux[1]);
                
                if ( DateTime.Compare(StartDate.Date, sDate) <=0 && DateTime.Compare(eDate, EndDate.Date) <= 0)
                {
                    conferences.Append(conf);
                }
            }
            return conferences;
        }

        private void Attend_Click(int confId)
        {
            Program.qrCode = BarcodeGenerator();
            string copyqrCode = Program.qrCode;
            //qrCode = setMyQrCode(BarcodeGenerator());
            //BarcodeGenerator();
            _attendeeButtons.Attend(Program.EnteredEmailAddress, copyqrCode, confId);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Congratulation!";
            popup.ContentText = "You succesfully attended to this conference!";
            popup.Popup();
            //fillAttendeeGrid();
            var newForm = new QRCodeForm();
            newForm.ShowDialog();
        }

        private void Withdraw_Click(int confId)
        {
            _attendeeButtons.WithdrawnCommand(Program.EnteredEmailAddress, confId);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "You withdraw this conference!";
            popup.ContentText = "You can choose from the available ones";
            popup.Popup();
            //fillAttendeeGrid();
        }

        private void Join_Click(int statusId)
        {
            var newform = new WebviewForm();
            newform.ShowDialog();
            _attendeeButtons.JoinCommand(Program.EnteredEmailAddress, statusId);
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            
            
            
            //AttendeeGridvw.DataSource = null;

            string[] dates = GetCurrentDateFilterSelection();

            if (TabControl.SelectedTab.Name == "TabOrganizer")
            {
                OrganizerDataGrid.DataSource = null;
                check = 1;
                this.OrganizerCurrentPageIndex = 1;

                var allConferences = _conferenceRepository.FilterConferencesByDate(Program.EnteredEmailAddress, dates[0], dates[1]);
                this.CalculateTotalPages(allConferences, TabControl.SelectedTab);
                var conferences = _conferenceRepository.GetConferencesByPage(Program.EnteredEmailAddress, 1, this.PageSize+1, dates[0], dates[1]);

                this.CheckPaginationButtonsVisibility();
                CheckNumberOfRows(conferences);
            }
            else if (TabControl.SelectedTab.Name == "TabAttendee")
            {
                check2 = 1;
                AttendeeGridvw.DataSource = null;
                this.AttendeeCurrentPageIndex = 1;

                var allConferences = _conferenceRepository.FilterAttendeesByDate(Program.EnteredEmailAddress, dates[0], dates[1]);
                this.CalculateTotalPages(allConferences, TabControl.SelectedTab);
                var conferences = _conferenceRepository.GetAttendeesByPage(Program.EnteredEmailAddress, 1, this.PageSize + 1, dates[0], dates[1]);

                this.CheckPaginationButtonsVisibilityAttendee();
                CheckNumberOfRowsAttendee(conferences);
                //var allConferences = _conferenceRepository.FilterConfAttendeeByDate(Program.EnteredEmailAddress, dates[0],dates[1]);

                //var conferences = FilterAttendee(allConferences, dates[0], dates[1]);

                //UpdateAttendee(conferences);

            }
        }

        private void OrganizerDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (OrganizerDataGrid.Columns.Contains("ConferenceId") && OrganizerDataGrid.Columns["ConferenceId"].Visible)
            {
                OrganizerDataGrid.Columns["ConferenceId"].Visible = false;
                OrganizerDataGrid.Columns["RowNum"].Visible = false;
                OrganizerDataGrid.Columns["StatusId"].Visible = false;
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


            OrganizerDataGrid.Columns[0].HeaderText = "row_num";
            OrganizerDataGrid.Columns[1].HeaderText = "status";
            OrganizerDataGrid.Columns[2].HeaderText = "confId";
            OrganizerDataGrid.Columns[3].HeaderText = "Name";
            OrganizerDataGrid.Columns[4].HeaderText = "Category";
            OrganizerDataGrid.Columns[5].HeaderText = "Type";
            OrganizerDataGrid.Columns[6].HeaderText = "Location";
            OrganizerDataGrid.Columns[7].HeaderText = "Main Speaker Name";
            OrganizerDataGrid.Columns[8].HeaderText = "Period";

            OrganizerDataGrid.Columns["Period"].DisplayIndex = 4;
            OrganizerDataGrid.Columns["ConferenceCategoryName"].DisplayIndex = 5;
            OrganizerDataGrid.Columns["ConferenceTypeName"].DisplayIndex = 6;
            OrganizerDataGrid.Columns["Location"].DisplayIndex = 7;
            OrganizerDataGrid.Columns["Speaker"].DisplayIndex = 8;

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
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                Attend_Click(confid);
                AttendeeGridvw.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Red;
                // AttendeeGridvw.Rows[e.RowIndex].Cells[10].Value = "test";
                //  if (AttendeeGridvw.Rows[e.RowIndex].Cells[10].Value == "test")
                //{

                return;
                }

            
            //if (e.ColumnIndex == AttendeeGridvw.Columns["speaker_name"].Index)
            //{
            //    string[] names = AttendeeGridvw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(" ");
            //    SpeakerModel speaker = this._speakerRepository.GetSpeakerByName(names);

            //    var varSpeakerDetails = new SpeakerDetails(speaker);
            //    varSpeakerDetails.ShowDialog();

            //    //listBox1.Items.Add(speaker.Rating);
            //    //listBox1.Items.Add(speaker.ImagePath);
            //    //AttendeeGridvw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            //}

            if (e.ColumnIndex == AttendeeGridvw.Columns["withdraw_column"].Index)
            {
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                Withdraw_Click(confid);
                
            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["join_column"].Index)
            {
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                //int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[0].Value;
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

