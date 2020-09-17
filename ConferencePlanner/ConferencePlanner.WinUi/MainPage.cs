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
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {

        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ITypeRepository _typeRepository;

        private readonly IAttendeeButtonsRepository _attendeeButtons;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICategoryRepository _categoryRepository;

        private int PageSize = 5;
        private int OrganizerCurrentPageIndex = 1;
        private int OrganizerTotalPage = 0;
        private int remainingTime = 6;
        private int AttendeeCurrentPageIndex = 1;
        private int AttendeeTotalPage = 0;
        private static int confId = 0;
        private String gridName = "a";
        string sDate= "1990-01-01 12:00:00";
        string eDate= "3000-12-30 12:00:00";
       


        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository,
            IAttendeeButtonsRepository attendeeButtonsRepository, ISpeakerRepository speakerRepository, ICountyRepository
            countyRepository, ICityRepository cityRepository, ITypeRepository typeRepository, ICategoryRepository categoryRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _attendeeButtons = attendeeButtonsRepository;
            _speakerRepository = speakerRepository;
            _countyRepository = countyRepository;
            _cityRepository = cityRepository;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
            InitializeComponent();
            this.ShowDialog();

        }
        public MainPage() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RightArrowPagButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            RightArrowPagButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            LeftArrowPagButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            LeftArrowPagButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
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
            var newAddConf = new Form1(_conferenceRepository, _countryRepository, _countyRepository, _speakerRepository, _typeRepository, _cityRepository, _categoryRepository);
            OrganizerDataGrid.Visible = true;
            AttendeeGridvw.Visible = false;
            gridName = "o";
            
            this.popUpMethod("Context Changed", "You are now an organizer!");

            newAddConf.ShowDialog();

            Organizer_SelectedIndexChangedRemake("o");
            PanelAttendee.Visible = false;
            PanelOrganizer.Visible = false;
            PanelAnc.Visible = true;
            PanelFilter.Visible = false;

        }

        private void CheckNumberOfRows(List<ConferenceModel> conferences)
        {
            if (conferences.Count() == 0)
            {
                this.OrganizerDataGrid.Visible = false;
                this.OrganizersPaginationSelector.Visible = false;
                this.RightArrowPagButton.Visible = false;
            }
            else
            {
                OrganizerDataGrid.Visible = true;
                
                this.OrganizersPaginationSelector.Visible = true;
                //this.RightArrowPagButton.Visible = true;
                OrganizerDataGrid.DataSource = conferences.ToList();
                OrganizerDataGrid.AutoGenerateColumns = false;
            }
        }
        private void CheckNumberOfRowsAttendee(List<ConferenceModel> attendees)
        {
            if (attendees.Count() == 0)
            {
                AttendeeGridvw.Visible = false;
                this.OrganizersPaginationSelector.Visible = false;
                this.RightArrowPagButton.Visible = false;
            }
            else
            {
                AttendeeGridvw.Visible = true;
                AttendeeGridvw.DataSource = attendees;
                AttendeeGridvw.AutoGenerateColumns = false;
                this.OrganizersPaginationSelector.Visible = true;
                this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
            }
        }

        public void Organizer_SelectedIndexChangedRemake(String gridName)
        {
            if (gridName.Equals("o"))
            {
                string[] dates = new string[2];
                if (check == 0)
                {
                    dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
                }
                else
                {
                    dates = GetCurrentDateFilterSelection();
                }

                int PreviousPageOffSet = (this.OrganizerCurrentPageIndex - 1) * this.PageSize;

                var t = Task.Run(() => GetConferenceByOrganizer(Program.EnteredEmailAddress));
                t.Wait();
                int numberOfConferences = t.Result.Count();

                var t2 = Task.Run(() => GetConferencesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]));
                t2.Wait();
                var conferences = t2.Result;

                CalculateTotalPages(numberOfConferences, "o");
                this.CheckPaginationButtonsVisibility(this.OrganizerCurrentPageIndex, this.OrganizerTotalPage);
                this.MainPagePaginationTextBox.Text = "Page " + this.OrganizerCurrentPageIndex + " of " + this.OrganizerTotalPage;
                CheckNumberOfRows(conferences);
   
            }
        }

        //genereaza layout organizer asta se sterge si se apeleaza la clik-ul de organizer
        private void TabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTotalPages(List<ConferenceModel> allConferences, string gridName)
        {
            int rowCount = allConferences.Count();
            CalculateTotalPages(rowCount, gridName);
        }

        private void CalculateTotalPages(int rowCount, string gridName)
        {
            if (gridName.Equals("o"))
            {
                this.OrganizerTotalPage = rowCount / this.PageSize;

                if (rowCount % this.PageSize > 0)
                    this.OrganizerTotalPage += 1;

            }
            else if (gridName.Equals("a"))
            {

                this.AttendeeTotalPage = rowCount / this.PageSize;

                if (rowCount % this.PageSize > 0)
                    this.AttendeeTotalPage += 1;
            }
        }

        private void CheckPaginationButtonsVisibility(int currentIndex, int totalPage)
        {
            if (currentIndex == totalPage)
            {
                this.RightArrowPagButton.Visible = false;
            }
            if (currentIndex == 1)
            {
                this.LeftArrowPagButton.Visible = false;
            }
            if (currentIndex < totalPage)
            {
                this.RightArrowPagButton.Visible = true;
            }
            if (currentIndex > 1)
            {
                this.LeftArrowPagButton.Visible = true;
            }
        }



        private void CreatePage()
        {
            string[] dates = new string[2];
            if (check == 0)
            {
                dates = new string[] { DateTime.Parse("1900-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), DateTime.Parse("2050-01-01 00:00:00").ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss") };
            }
            else
            {
                dates = GetCurrentDateFilterSelection();
            }

            this.CheckPaginationButtonsVisibility(this.OrganizerCurrentPageIndex,this.OrganizerTotalPage);

            int PreviousPageOffSet = (this.OrganizerCurrentPageIndex - 1) * this.PageSize;
            
            var t = Task.Run(() => GetConferencesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]));
            t.Wait();
            var conferences = t.Result;
            this.MainPagePaginationTextBox.Text = "Page " + this.OrganizerCurrentPageIndex + " of " + this.OrganizerTotalPage;
            CheckNumberOfRows(conferences);
        }

        private void CreateAttendeePage()
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
            this.CheckPaginationButtonsVisibility(this.AttendeeCurrentPageIndex, this.AttendeeTotalPage);

            int PreviousPageOffSet = (this.AttendeeCurrentPageIndex - 1) * this.PageSize;
            
            var t = Task.Run(() => GetAttendeesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]));
            t.Wait();

            this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
            CheckNumberOfRowsAttendee(t.Result);
      
        }


        private void RightArrowPagButton_MouseClick(object sender, EventArgs e)
        {
            if (gridName.Equals("o"))
            {
                this.OrganizerCurrentPageIndex++;
                this.CreatePage();

            }
            else if (gridName.Equals("a"))
            {
                this.AttendeeCurrentPageIndex++;
                this.CreateAttendeePage();
                //ConditionsForButtons();
            }
        }

        private void LeftArrowPagButton_MouseClick(object sender, EventArgs e)
        {
            if (gridName.Equals("o"))
            {
                this.OrganizerCurrentPageIndex--;
                this.CreatePage();
            }
            else if (gridName.Equals("a"))
            {
                this.AttendeeCurrentPageIndex--;
                this.CreateAttendeePage();
                //ConditionsForButtons();
            }
        }

        int a = 0;
        private void TabAttendee_Layout(object sender, LayoutEventArgs e)
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

            int PreviousPageOffSet = (this.AttendeeCurrentPageIndex - 1) * this.PageSize;

            Task t = Task.Run(async () =>
            {
                var count = await GetAttendeesCount(Program.EnteredEmailAddress, dates[0], dates[1]);
                CalculateTotalPages(count, "a");
                var conferences = await GetAttendeesByPage(Program.EnteredEmailAddress, PreviousPageOffSet + 1, PreviousPageOffSet + this.PageSize + 1, dates[0], dates[1]);

                AttendeeGridvw.Invoke((MethodInvoker)delegate
                {
                    CheckPaginationButtonsVisibility(this.AttendeeCurrentPageIndex, this.AttendeeTotalPage);
                    AttendeeGridvw.DataSource = conferences; // runs on UI thread
                });
            });
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
            sDate = dates[0];
            eDate = dates[1];

            if (gridName.Equals("o"))
            {
                check = 1;
                OrganizerDataGrid.DataSource = null;
                this.OrganizerCurrentPageIndex = 1;

                var t = Task.Run(() => GetAttendeesCount(Program.EnteredEmailAddress, dates[0], dates[1]));
                t.Wait();
                var count = t.Result;
                CalculateTotalPages(count, "o");

                var t2 = Task.Run(() => GetConferencesByPage(Program.EnteredEmailAddress, 1, this.PageSize + 1, dates[0], dates[1]));
                t2.Wait();
                var conferences = t2.Result;
                this.CheckPaginationButtonsVisibility(this.OrganizerCurrentPageIndex, this.OrganizerTotalPage);
                CheckNumberOfRows(conferences);

            }
            else if (gridName.Equals("a"))
            {
                check2 = 1;
                AttendeeGridvw.DataSource = null;
                this.AttendeeCurrentPageIndex = 1;

                var t = Task.Run(() => FilterAttendeesByDate(Program.EnteredEmailAddress, dates[0], dates[1]));
                t.Wait();
                int numberOfConferences = t.Result.Count();

                this.CalculateTotalPages(numberOfConferences, "a");

                var t2 = Task.Run(() => GetAttendeesByPage(Program.EnteredEmailAddress,1,this.PageSize + 1, dates[0], dates[1]));
                t2.Wait();
                var conferences = t2.Result;
                //this.ConditionsForButtons();
                this.CheckPaginationButtonsVisibility(this.AttendeeCurrentPageIndex, this.AttendeeTotalPage);
                this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
                CheckNumberOfRowsAttendee(conferences);
            }

        }

        private List<ConferenceModel> FilterAttendee(List<ConferenceModel> allConferences, DateTime StartDate, DateTime EndDate)
        {
            List<ConferenceModel> conferences = new List<ConferenceModel>();

            foreach (ConferenceModel conf in allConferences)
            {
                string[] aux = conf.Period.Split(" - ");
                DateTime sDate = DateTime.Parse(aux[0]);
                DateTime eDate = DateTime.Parse(aux[1]);

                if (DateTime.Compare(StartDate.Date, sDate) <= 0 && DateTime.Compare(eDate, EndDate.Date) <= 0)
                {
                    conferences.Append(conf);
                }
            }
            return conferences;
        }

        public void popUpMethod(String titleText, String contentText)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();

        }

        static async Task AttendAsync(ButtonModel buttonModel)
        {
            var json = JsonConvert.SerializeObject(buttonModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/api/Attendee/Attend", httpContent);
        }

        static async Task WithdrawnAsync(ButtonModel buttonModel)
        {
            var json = JsonConvert.SerializeObject(buttonModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/api/Attendee/WithdrawnButton", httpContent);
        }

        static async Task JoinAsync(ButtonModel buttonModel)
        {
            var json = JsonConvert.SerializeObject(buttonModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/api/Attendee/JoinButton", httpContent);
        }

        private void Attend_Click(int confId)
        {
            Program.qrCode = BarcodeGenerator();
            string copyqrCode = Program.qrCode;
            ButtonModel buttonModel = new ButtonModel();
            buttonModel.email = Program.EnteredEmailAddress;
            buttonModel.barcode = copyqrCode;
            buttonModel.confId = confId;
            buttonModel.statusId = 1;

            var t = Task.Run(() => AttendAsync(buttonModel));
            t.Wait();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = "Congratulation!";
            popup.ContentText = "You succesfully attended to this conference!";
            popup.Popup();
            CreateAttendeePage();
            ConditionsForButtons();
            var newForm = new QRCodeForm();
            newForm.ShowDialog();
        }

        private void Withdraw_Click(int confId)
        {
            PopupNotifier popup = new PopupNotifier();
            ButtonModel buttonModel = new ButtonModel();
            buttonModel.email = Program.EnteredEmailAddress;
            buttonModel.confId = confId;
            buttonModel.statusId = 1;
            popup.Image = Properties.Resources.info;
            popup.TitleText = "You withdraw this conference!";
            popup.ContentText = "You can choose from the available ones";
            popup.Popup();
            var t = Task.Run(() => WithdrawnAsync(buttonModel));
            t.Wait();
            CreateAttendeePage();
            ConditionsForButtons();
        }

        private void Join_Click(int confId)
        {
            ButtonModel buttonModel = new ButtonModel();
            buttonModel.email = Program.EnteredEmailAddress;
            buttonModel.statusId = 2;
            buttonModel.confId = confId;
            var newform = new WebviewForm();
            newform.ShowDialog();
            var t = Task.Run(() => JoinAsync(buttonModel));
            t.Wait();
            //_attendeeButtons.JoinCommand(Program.EnteredEmailAddress, confId);
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            string[] dates = GetCurrentDateFilterSelection();

            if (gridName.Equals("o"))
            {
                OrganizerDataGrid.DataSource = null;
                check = 1;
                this.OrganizerCurrentPageIndex = 1;

                var t = Task.Run(() => GetAttendeesCount(Program.EnteredEmailAddress, dates[0], dates[1])); t.Wait();
                int numberOfConferences = t.Result;
                this.CalculateTotalPages(numberOfConferences, "o");

                var t2 = Task.Run(() => GetConferencesByPage(Program.EnteredEmailAddress, 1, this.PageSize + 1, dates[0], dates[1]));
                t2.Wait();
                var conferences = t2.Result;
                this.CheckPaginationButtonsVisibility(this.OrganizerCurrentPageIndex, this.OrganizerTotalPage);
                this.MainPagePaginationTextBox.Text = "Page " + this.OrganizerCurrentPageIndex + " of " + this.OrganizerTotalPage;
                this.CheckNumberOfRows(conferences);

            }
            else if (gridName.Equals("a"))
            {
                check2 = 1;
                AttendeeGridvw.DataSource = null;
                this.AttendeeCurrentPageIndex = 1;

                var t = Task.Run(() => FilterAttendeesByDate(Program.EnteredEmailAddress, dates[0], dates[1]));
                t.Wait();
                int numberOfConferences = t.Result.Count();
                this.CalculateTotalPages(numberOfConferences, "a");

                var t2 = Task.Run(() => GetAttendeesByPage(Program.EnteredEmailAddress, 1, this.PageSize + 1, dates[0], dates[1]));
                t2.Wait();
                var conferences = t2.Result;
                //this.ConditionsForButtons();
                this.CheckPaginationButtonsVisibility(this.AttendeeCurrentPageIndex, this.AttendeeTotalPage);
                this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
                CheckNumberOfRowsAttendee(conferences);
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
                int columnIndex = OrganizerDataGrid.ColumnCount;

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                OrganizerDataGrid.Columns.Insert(columnIndex, editButtonColumn);

                columnIndex++;

                OrganizerDataGrid.Columns.Insert(columnIndex, deleteButtonColumn);
                OrganizerDataGrid.CellClick += OrganizerDataGrid_CellClick;
            }

            OrganizerDataGrid.Columns["RowNum"].HeaderText = "row_num";
            OrganizerDataGrid.Columns["StatusId"].HeaderText = "status";
            OrganizerDataGrid.Columns["ConferenceId"].HeaderText = "confId";
            OrganizerDataGrid.Columns["ConferenceName"].HeaderText = "Name";
            OrganizerDataGrid.Columns["ConferenceCategoryName"].HeaderText = "Category";
            OrganizerDataGrid.Columns["ConferenceTypeName"].HeaderText = "Type";
            OrganizerDataGrid.Columns["Location"].HeaderText = "Location";
            OrganizerDataGrid.Columns["Speaker"].HeaderText = "Main Speaker Name";
            OrganizerDataGrid.Columns["Period"].HeaderText = "Period";

            OrganizerDataGrid.Columns["Period"].DisplayIndex = 4;
            OrganizerDataGrid.Columns["ConferenceCategoryName"].DisplayIndex = 5;
            OrganizerDataGrid.Columns["ConferenceTypeName"].DisplayIndex = 6;
            OrganizerDataGrid.Columns["Location"].DisplayIndex = 7;
            OrganizerDataGrid.Columns["Speaker"].DisplayIndex = 8;

            OrganizerDataGrid.AutoResizeColumns();
            
        }

        private void OrganizerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == OrganizerDataGrid.Columns["edit_column"].Index)
            {
                int id = (int)OrganizerDataGrid.Rows[e.RowIndex].Cells["ConferenceId"].Value;
                
                var t = Task.Run(() => GetConferenceById(id));
                t.Wait();
                ConferenceModel conference = t.Result;

                var varAddConf = new AddConf(conference, _conferenceRepository, _countryRepository, _countyRepository, _speakerRepository, _typeRepository, _cityRepository, _categoryRepository);

                varAddConf.ShowDialog();

            }

            if (e.ColumnIndex == OrganizerDataGrid.Columns["delete_column"].Index)
            {
                int id = (int)OrganizerDataGrid.Rows[e.RowIndex].Cells["ConferenceId"].Value;

                var varDeleteConference = new AreYouSure(_conferenceRepository, id);
                varDeleteConference.ShowDialog();
            }
            if (e.ColumnIndex == this.OrganizerDataGrid.Columns["Speaker"].Index && (string)OrganizerDataGrid.Rows[e.RowIndex].Cells["Speaker"].Value != "Not Mentioned")
            {
                int conferenceId= (int)this.OrganizerDataGrid.Rows[e.RowIndex].Cells["ConferenceId"].Value;

                var varSpeakerDetails = new SpeakerDetails(conferenceId);
                varSpeakerDetails.ShowDialog();
            }
        }

        public void ConditionsForButtons()
        {
            for (int i = 0; i < AttendeeGridvw.Rows.Count; i++)
            {
                var e = AttendeeGridvw.Rows[i].Cells[4].Value;
                var time = AttendeeGridvw.Rows[i].Cells["Period"].Value;
                time = time.ToString().Split(" - ")[0];
                time = DateTime.Parse((string)time);
                time = time.ToString();
                string[] timeToCompare = time.ToString().Split(" ");
                string[] currentTime = DateTime.Now.ToString("M/dd/yyyy h:mm:ss tt").Split(" ");

                if (e.Equals(0))
                {
                    AttendeeGridvw.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Green;
                    AttendeeGridvw.Rows[i].Cells[0].Style.ForeColor = System.Drawing.Color.Green;
                    AttendeeGridvw.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[2].Style.ForeColor = System.Drawing.Color.Red;
                }
                else if (e.Equals(1))
                {
                    AttendeeGridvw.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[0].Style.ForeColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Green;
                    AttendeeGridvw.Rows[i].Cells[1].Style.ForeColor = System.Drawing.Color.Green;
                    AttendeeGridvw.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Red;
                    AttendeeGridvw.Rows[i].Cells[2].Style.ForeColor = System.Drawing.Color.Red;
                    if (timeToCompare[0].Equals(currentTime[0]) && timeToCompare[2].Equals(currentTime[2]))
                    {
                        string[] times1 = currentTime[1].Split(":");
                        int hour1 = Int32.Parse(times1[0]);
                        int minutes1 = Int32.Parse(times1[1]);
                        string[] times2 = timeToCompare[1].Split(":");
                        int hour2 = Int32.Parse(times2[0]);
                        int minutes2 = Int32.Parse(times2[1]);
                        if (hour2 == hour1 && (minutes2 - minutes1 <= 5) || (hour2 - hour1 == 1) && (minutes2 - minutes1 <= 5))
                        {
                            AttendeeGridvw.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.Green;
                            AttendeeGridvw.Rows[i].Cells[2].Style.ForeColor = System.Drawing.Color.Green;
                            AttendeeGridvw.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.Red;
                            AttendeeGridvw.Rows[i].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                            remainingTime = minutes2 - minutes1;
                        }
                    }
                }
            }
        }

        private void AttendeeGridvw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ConditionsForButtons();
                return;
            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["attend_column"].Index)
            {
                confId = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                int statusId = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[4].Value;
                if (statusId == 0)
                {
                    Attend_Click(confId);

                }
                else if (statusId == 1)
                {
                    AttendeeGridvw.Rows[e.RowIndex].Cells["attend_column"].ReadOnly = true;

                    PopupNotifier popup = new PopupNotifier();
                    popup.ContentText = "You already attended to this conference";
                    popup.Popup();
                }

                return;
            }


            if (e.ColumnIndex == AttendeeGridvw.Columns["Speaker"].Index && (string)AttendeeGridvw.Rows[e.RowIndex].Cells["Speaker"].Value != "Not Mentioned")
            {
                int conferenceId = (int)AttendeeGridvw.Rows[e.RowIndex].Cells["ConferenceId"].Value;

                var varSpeakerDetails = new SpeakerDetails(conferenceId);
                varSpeakerDetails.ShowDialog();
            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["withdraw_column"].Index)
            {
                int statusid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[4].Value;
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                if (statusid == 1 && remainingTime > 5)
                {
                    Withdraw_Click(confid);
                }
                else
                {
                    popUpMethod("You can't withdrwan. The conference will start in less than 5 minutes", "");
                }
            }

            if (e.ColumnIndex == AttendeeGridvw.Columns["join_column"].Index)
            {
                int statusId = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[4].Value;
                int confid = (int)AttendeeGridvw.Rows[e.RowIndex].Cells[5].Value;
                if (statusId != 1)
                {
                    popUpMethod("You're not attending to this conference", "");
                }
                else if ((statusId == 1 && remainingTime > 5))
                {
                    popUpMethod("You can join to this conference only with 5 minutes before start", "");
                }
                else
                {
                    Join_Click(confid);
                }
            }
        }
        private void OrganizerDataGrid_Layout(object sender, LayoutEventArgs e)
        {
            this.OrganizerDataGrid.ReadOnly = true;
        }

        private void OrganizersPaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            int idx = this.OrganizersPaginationSelector.SelectedIndex;
            if (idx < 0)
                return;
            
            if ("o".Equals(gridName))
            {
                this.PageSize = int.Parse(this.OrganizersPaginationSelector.Items[idx].ToString());

                var t = Task.Run(() => GetConferenceByOrganizer(Program.EnteredEmailAddress));
                t.Wait();
                int numberOfConferences = t.Result.Count();

                this.CalculateTotalPages(numberOfConferences, "o");
                this.OrganizerCurrentPageIndex = 1;
                this.MainPagePaginationTextBox.Text = "Page " + this.OrganizerCurrentPageIndex + " of " + this.OrganizerTotalPage;
                this.CreatePage();
            }
            if("a".Equals(gridName))
            {
                this.PageSize = int.Parse(this.OrganizersPaginationSelector.Items[idx].ToString());

                var t = Task.Run(() => GetAttendeesCount(Program.EnteredEmailAddress, sDate, eDate));
                t.Wait();
                int numberOfConferences = t.Result;

                this.CalculateTotalPages(numberOfConferences, "a");
                this.AttendeeCurrentPageIndex = 1;
                this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
                this.CreateAttendeePage();
            }
        }
        private async Task<List<ConferenceModel>> GetConferenceByOrganizer(string email)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/conferences_by_organizer/email=" + email);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ConferenceModel>>(json);
                return t;
            }
            else
            {
                return new List<ConferenceModel>();
            }
        }
        private async Task<ConferenceModel> GetConferenceById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/conference_by_id/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<ConferenceModel>(json);
                return t;
            }
            else
            {
                return new ConferenceModel();
            }
        }
        private async Task<int> GetAttendeesCount(string email, string sDate, string eDate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/get_attendees_count/email=" + email + "&sDate=" + sDate + "&eDate=" + eDate);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<int>(json);
                return t;
            }
            else
            {
                return default;
            }
        }
        private async Task<List<ConferenceModel>> GetConferencesByPage(string email, int sIndex, int eIndex, string sDate, string eDate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/conferences_by_page/email=" + email +"&sIndex="+ sIndex + "&eIndex=" + eIndex+"&sDate=" + sDate + "&eDate=" + eDate);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ConferenceModel>>(json);
                return t;
            }
            else
            {
                popUpMethod("Error", "Something went wrong");
                return new List<ConferenceModel>();
            }
        }
        
        private async Task<List<ConferenceModel>> GetAttendeesByEmail(string email)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/attendees_by_email/email=" + email);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ConferenceModel>>(json);
                return t;
            }
            else
            {
                return new List<ConferenceModel>();
            }
        }
        private async Task<List<ConferenceModel>> FilterAttendeesByDate(string email, string sDate, string eDate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/filter_attendees_by_date/email=" + email + "&sDate=" + sDate + "&eDate=" + eDate);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ConferenceModel>>(json);
                return t;
            }
            else
            {
                return new List<ConferenceModel>();
            }
        }
        private async Task<List<ConferenceModel>> GetAttendeesByPage(string email, int sIndex, int eIndex, string sDate, string eDate)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Conference/attendees_by_page/email=" + email + "&sIndex=" + sIndex + "&eIndex=" + eIndex + "&sDate=" + sDate + "&eDate=" + eDate);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ConferenceModel>>(json);
                return t;
            }
            else
            {
                popUpMethod("Error", "Something went wrong");
                return new List<ConferenceModel>();
            }
        }

        private void AttendeeGridvw_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AttendeeGridvw.Columns["RowNum"].Visible = false;
            AttendeeGridvw.Columns["StatusId"].Visible = false;
            AttendeeGridvw.Columns["ConferenceId"].Visible = false;
            AttendeeGridvw.AutoResizeColumns();

            AttendeeGridvw.Columns[3].HeaderText = "Name";
            AttendeeGridvw.Columns[4].HeaderText = "Category";
            AttendeeGridvw.Columns[5].HeaderText = "Type";

            if (a == 0)
            {
                a++;
                DataGridViewButtonColumn attendButtonColumn = new DataGridViewButtonColumn();
                attendButtonColumn.Name = "attend_column";
                attendButtonColumn.Text = "Attend";
                attendButtonColumn.HeaderText = "Attend";
                attendButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                attendButtonColumn.DefaultCellStyle.Padding = new Padding(22);
                attendButtonColumn.FlatStyle = FlatStyle.Flat;

                int columnIndex = AttendeeGridvw.ColumnCount;

                AttendeeGridvw.Columns.Insert(columnIndex, attendButtonColumn);

                columnIndex = AttendeeGridvw.ColumnCount;
                DataGridViewButtonColumn withdrawButtonColumn = new DataGridViewButtonColumn();
                withdrawButtonColumn.Name = "withdraw_column";
                withdrawButtonColumn.Text = "Withdraw";
                withdrawButtonColumn.HeaderText = "Withdraw";
                withdrawButtonColumn.FlatStyle = FlatStyle.Flat;
                withdrawButtonColumn.DefaultCellStyle.Padding = new Padding(20);

                withdrawButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                AttendeeGridvw.Columns.Insert(columnIndex, withdrawButtonColumn);
                columnIndex = AttendeeGridvw.ColumnCount;

                DataGridViewButtonColumn joinButtonColumn = new DataGridViewButtonColumn();
                joinButtonColumn.Name = "join_column";
                joinButtonColumn.Text = "Join";
                joinButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                joinButtonColumn.DefaultCellStyle.Padding = new Padding(20);
                joinButtonColumn.HeaderText = "Join";
                joinButtonColumn.FlatStyle = FlatStyle.Flat;

                DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();

                AttendeeGridvw.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                AttendeeGridvw.Columns["RowNum"].Visible = false;
                AttendeeGridvw.Columns["StatusId"].Visible = false;
                AttendeeGridvw.Columns["ConferenceId"].Visible = false;
                AttendeeGridvw.Columns.Insert(columnIndex, joinButtonColumn);

                AttendeeGridvw.CellClick += AttendeeGridvw_CellClick;
                
            }
            ConditionsForButtons();
            this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
        }
        private void RightArrowPagButton_MouseEnter(object sender, EventArgs e)
        {
            RightArrowPagButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RightArrowPagButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void RightArrowPagButton_MouseLeave(object sender, EventArgs e)
        {
            RightArrowPagButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            RightArrowPagButton.BackgroundImageLayout = ImageLayout.Center;
        }
        private void LeftArrowPagButton_MouseEnter(object sender, EventArgs e)
        {
            RightArrowPagButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LeftArrowPagButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LeftArrowPagButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void LeftArrowPagButton_MouseLeave(object sender, EventArgs e)
        {
            LeftArrowPagButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LeftArrowPagButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LeftArrowPagButton.BackgroundImageLayout = ImageLayout.Center;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PanelAttendee.Visible = true;
            PanelOrganizer.Visible = false;
            PanelAnc.Visible = false;
            PanelFilter.Visible = false;
            AttendeeGridvw.Visible = true;
            OrganizerDataGrid.Visible = false;
            gridName = "a";
            this.CheckPaginationButtonsVisibility(this.AttendeeCurrentPageIndex, this.AttendeeTotalPage);
            this.MainPagePaginationTextBox.Text = "Page " + this.AttendeeCurrentPageIndex + " of " + this.AttendeeTotalPage;
            //Organizer_SelectedIndexChangedRemake("a");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelAttendee.Visible = false;
            PanelOrganizer.Visible = true;
            PanelAnc.Visible = false;
            PanelFilter.Visible = false;
            //tmpForOrganizer();
            AttendeeGridvw.Visible = false;
            OrganizerDataGrid.Visible = true;
            gridName = "o";
            Organizer_SelectedIndexChangedRemake("o");
        }
        public int tmp = 0;
        private void FIlterByDate_Click(object sender, EventArgs e)
        {
            PanelAttendee.Visible = false;
            PanelOrganizer.Visible = false;
            PanelAnc.Visible = false;
            PanelFilter.Visible = true;
            if (tmp == 0)
            {
                StartDatePicker.Visible = true;
                EndDatePicker.Visible = true;
                tmp = 1;
            } else if (tmp == 1)
            {
                StartDatePicker.Visible = false;
                EndDatePicker.Visible = false;
                tmp = 0;
            }
            ;
        }
    }
}

