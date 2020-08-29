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
using ConferencePlanner.Repository.Ado.Repository;
using System.Transactions;
using Tulpep.NotificationWindow;
using System.Windows.Controls;

namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        private readonly IConferenceRepository _conferenceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ISpeakerRepository _speakerRepository;

        private int PageSize = 4;

        private int SelectedCountryId = 70;

        private BindingList<CountryModel> Countries;
        private BindingList<CountyModel> Counties;
        private BindingList<SpeakerModel> Speakers;
        private int SpeakersTotalPages;
        private int SpeakersCurrentPage = 1;
        private int SpeakersLastPageLastRow = 0;
        private int UpdateSpeakerRow;
        
        //lista de ce facem

        public AddConf(IConferenceRepository conferenceRepository, ICountryRepository  countryRepository, ICountyRepository countyRepository, ISpeakerRepository speakerRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _countyRepository = countyRepository;
            _speakerRepository = speakerRepository;
            InitializeComponent();

        }

        public AddConf()
        {
          
            InitializeComponent();
        }
        public AddConf(ConferenceModel conference, IConferenceRepository conferenceRepository, ICountryRepository countryRepository, ISpeakerRepository speakerRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _speakerRepository = speakerRepository;

            InitializeComponent();

            this.PopulateForm(conference);

        }
        private void PopulateForm(ConferenceModel conference)
        {
            this.ConfName.Text = conference.ConferenceName;

            string[] dates = conference.Period.Split(" - ");
            this.StardDatePicker.Value = DateTime.Parse(dates[0]);
            this.EndDatePicker.Value = DateTime.Parse(dates[1]);


            int selectedCountryId = this._countryRepository.GetCountryIdByConferenceId(conference.ConferenceId);
            int selectedRowId = this.SearchIdInDataGrid(selectedCountryId, "DictionaryCountryId", this.CountryListDataGridView);
           // this.ConfName.Text = selectedRowId.ToString();

            if (selectedRowId > 0)
            {
                this.CountryListDataGridView.Rows[selectedRowId].Selected = true;
            }


            string[] places = conference.Location.Split(", ");

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
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CityComboBox.Enabled = true;
           
            Close();
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
            if (TabControlLocation.SelectedIndex == 1)
            {
                this.LoadCountyTab();
                
            }
            
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
            StardDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
        }

        private int[] CalculateTotalPages(int NumOfObjects)
        {  
            int TotalPages = NumOfObjects / this.PageSize;
            int LastPageLastRow = NumOfObjects % this.PageSize;

            if (LastPageLastRow > 0)
            {
                TotalPages += 1;
             
            }
            return new int[] { TotalPages, LastPageLastRow };

        }
        private void CheckPaginationButtonsVisibility(int currentPage, int totalPages, System.Windows.Forms.Button next, 
            System.Windows.Forms.Button prev, System.Windows.Forms.Button last, System.Windows.Forms.Button first)
        {
            if (currentPage == totalPages)
            {
                next.Visible = false;
                last.Visible = false;
            }
            if (currentPage == 1)
            {
                prev.Visible = false;
                first.Visible = false;
            }
            if (currentPage < totalPages)
            {
                next.Visible = true;
                last.Visible = true;
            }
            if (currentPage > 1)
            {
                prev.Visible = true;
                first.Visible = true;
            }
        }

        private void SpeakerCreatePage(BindingList<SpeakerModel> lst)
        {
            this.CheckPaginationButtonsVisibility(this.SpeakersCurrentPage, this.SpeakersTotalPages,
                this.SpeakersNextBtn, this.SpeakersBackBtn, this.SpeakersLastPage, this.SpeakersFirstPage);
            BindingList<SpeakerModel> result = new BindingList<SpeakerModel>();
            
            int PreviousPageOffSet = (this.SpeakersCurrentPage - 1) * this.PageSize;
            
            int aux = Math.Min(PreviousPageOffSet+this.PageSize, this.Speakers.Count);
           
            for (int i= PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.SpeakerListDataGrid.DataSource = result;
        }


        private void LoadSpeakersTab()
        {
            this.Speakers = _speakerRepository.GetAllSpeakers();
            int[] aux = this.CalculateTotalPages(this.Speakers.Count);
            this.SpeakersTotalPages = aux[0];
            this.SpeakersLastPageLastRow = aux[1]; 
                
            this.SpeakerCreatePage(this.Speakers);
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

            this.SpeakerListDataGrid.CurrentCell = null;
            this.SpeakerListDataGrid.Rows[0].Selected = false;


        }
        private void SpeakerListDataGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
        private void AddConf_Load(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 0;

            LoadContryTab();


        }

        private void LoadContryTab()
        {
            CountryListDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            this.Countries = _countryRepository.GetCountriesList();
            CountryListDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountryListDataGridView.DataSource = this.Countries;

        }

        private void CountryListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(CountryListDataGridView.Columns.Contains("DictionaryCountryId") && CountryListDataGridView.Columns["DictionaryCountryId"].Visible)
            {
                CountryListDataGridView.Columns["DictionaryCountryId"].Visible = false;
            }
            CountryListDataGridView.Columns["CountryCode"].HeaderText = "Country Code";
            CountryListDataGridView.Columns["CountryName"].HeaderText = "Country Name";
            

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadCountyTab()
        {
            CountiesListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CountiesListGridView.AllowUserToOrderColumns = true;
            this.Counties = _countyRepository.GetCountyListBind(this.SelectedCountryId);
            CountiesListGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountiesListGridView.DataSource = this.Counties;


        }
        private void AddInsertMessage()
        {
            this.SpeakerUserMessagesBox.ForeColor = Color.MediumSeaGreen;
            this.SpeakerUserMessagesBox.Text = "You are now adding a new speaker. Press the button to Save.";
            this.SpeakerUserMessagesBox.Visible = true;
            this.SpeakerSaveButton.Visible = true;
        }

        private void AddUpdateMessage(string fName, string lName)
        {
            this.SpeakerUserMessagesBox.ForeColor = Color.MediumSeaGreen;
            string sName = fName +" "+ lName;
            this.SpeakerUserMessagesBox.Text = "You are now editing speaker " + sName + "'s informations. Press the button to Save.";
            this.SpeakerUserMessagesBox.Visible = true;
            this.SpeakerSaveButton.Visible = true;
        }


        private void SpeakerBeginEditLayout(string opType)
        {
            this.SpeakerListDataGrid.Columns["main_speaker"].ReadOnly = true;
            this.SpeakerListDataGrid.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.LightGray;
            
            foreach (DataGridViewRow row in SpeakerListDataGrid.Rows)
            {
                if (row.Index != this.UpdateSpeakerRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.SpeakersNextBtn.Enabled = false;
            this.SpeakersBackBtn.Enabled = false;
            this.SpeakersFirstPage.Enabled = false;
            this.SpeakersLastPage.Enabled = false;
            
            if (opType == "u")
            {
                this.SpeakerListDataGrid.AllowUserToAddRows = false;
            }
            foreach (TabPage tab in TabControlLocation.TabPages)
            {
                if (tab.Name != this.TabControlLocation.SelectedTab.Name)
                {
                    tab.SuspendLayout();
                }
            }

        }

        private void SpeakerEndEditLayout(string str1popup, string str2popup)
        {
            this.SpeakerUserMessagesBox.Visible = false;
            this.SpeakerSaveButton.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.SpeakerListDataGrid.Columns["main_speaker"].ReadOnly = false;
            this.SpeakerListDataGrid.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.White;
            this.SpeakerListDataGrid.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.White;
            foreach (DataGridViewRow row in SpeakerListDataGrid.Rows)
            {
                if (row.Index != this.UpdateSpeakerRow)
                {
                    row.ReadOnly = false;
                }
            }
            this.SpeakersNextBtn.Enabled = true;    
            this.SpeakersBackBtn.Enabled = true;
            this.SpeakersFirstPage.Enabled = true;
            this.SpeakersLastPage.Enabled = true;
            if (this.SpeakerListDataGrid.AllowUserToAddRows == false)
            {
                this.SpeakerListDataGrid.AllowUserToAddRows = true;
            }
           
        }

        private void popUpMethod(String titleText, String contentText)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();
        }

        private void SpeakerListDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateSpeakerRow = e.RowIndex;


            if (SpeakerUserMessagesBox.Visible == false)
            {
                if (this.UpdateSpeakerRow >= this.PageSize || 
                    (this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow ==this.SpeakersLastPageLastRow))
                {
                    this.AddInsertMessage();
                    this.SpeakerBeginEditLayout("i");
                }
                else
                {
                    string fName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
                    string lName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
                    this.AddUpdateMessage(fName, lName);
                    this.SpeakerBeginEditLayout("u");
                }
            }
            else if (this.UpdateSpeakerRow != e.RowIndex) 
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }


        }

        private SpeakerModel GetSpeaker()
        {
            SpeakerModel speaker = new SpeakerModel();
            //validari
            speaker.FirstName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
            speaker.LastName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
            speaker.Nationality = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Nationality"].Value.ToString();
            speaker.Rating = (float) this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Rating"].Value;
            speaker.SpeakerId = (int)this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["SpeakerId"].Value;

            return speaker;
        }

        private void SpeakerSaveButton_Click(object sender, EventArgs e)
        {
            if ((this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow) || (this.UpdateSpeakerRow == this.PageSize))
            {
                SpeakerModel newSpeaker = GetSpeaker();
                _speakerRepository.InsertSpeaker(newSpeaker);
                this.Speakers.Add(newSpeaker);
                int[] aux = this.CalculateTotalPages(this.Speakers.Count);
                this.SpeakersTotalPages = aux[0];
                this.SpeakersLastPageLastRow = aux[1];
                this.SpeakersCurrentPage = 1;
                this.SpeakerCreatePage(this.Speakers);
                SpeakerEndEditLayout("Done", "You can see the speaker you just added on the last page.");
                this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;
            }
            else
            {
                
                _speakerRepository.UpdateSpeaker(this.GetSpeaker());
                SpeakerEndEditLayout("Done", "Speaker modified succesfully");
                this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;

            }
            this.SpeakerListDataGrid.CurrentCell = null;
        }  

        private void CountiesListGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CountiesListGridView.Columns.Contains("CountyId") && CountiesListGridView.Columns["CountyId"].Visible)
            {
                CountiesListGridView.Columns["CountyId"].Visible = false;
            }
            if (CountiesListGridView.Columns.Contains("CountryId") && CountiesListGridView.Columns["CountryId"].Visible)
            {
                CountiesListGridView.Columns["CountryId"].Visible = false;
            }
            CountiesListGridView.Columns["CountyName"].HeaderText = "County Name";
            
        }

        private void SpeakerListDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.ColumnIndex == this.SpeakerListDataGrid.Columns["main_speaker"].Index && this.SpeakerUserMessagesBox.Visible == true)
            {
                this.popUpMethod("Notice", "You can't select the conference main speaker when in edit mode.");
            }
            if (e.RowIndex < 0)
            {
                return;
            }
        }

        private void SpeakerListDataGrid_Layout(object sender, LayoutEventArgs e)
        {
            //ToolStripButton test = new ToolStripButton();
            //ToolStripCollection context = new ToolStripCollection();
            //test.Text = "test";
            //context.Click += ContextMenuStrip_Click;
            //context.ItemAdded//
            this.SpeakerListDataGrid.CurrentCell = null;
            ContextMenuStrip test = new ContextMenuStrip();
            test.Items.Add("Delete");
            test.Click += new System.EventHandler(this.ContextMenuStrip_Click);
            this.SpeakerListDataGrid.ContextMenuStrip = test;
            
            //this.SpeakerListDataGrid.ContextMenuStrip = new ContextMenuStrip();
            //this.SpeakerListDataGrid.ContextMenuStrip.Items.Add("Delete");
            //this.SpeakerListDataGrid.ContextMenuStrip.Click += ContextMenuStrip_Click;
            this.SpeakerListDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }


        private void ContextMenuStrip_Click(object sender, EventArgs e)
        {
            var test = SpeakerListDataGrid.HitTest(Location.X, Location.Y).RowIndex;
            var id = (int) this.SpeakerListDataGrid.Rows[test].Cells["SpeakerId"].Value;

            var varDeleteSpeaker = new AreYouSure(_speakerRepository, id);

            varDeleteSpeaker.ShowDialog();
        }

        private void SpeakersNextBtn_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage++;
            this.SpeakerCreatePage(this.Speakers);
            this.SpeakerListDataGrid.Rows[0].Selected = false;
        }

        private void SpeakersLastPage_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage = this.SpeakersTotalPages;
            this.SpeakerCreatePage(this.Speakers);
        }

        private void SpeakersBackBtn_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage--;
            this.SpeakerCreatePage(this.Speakers);
        }

        private void SpeakersFirstPage_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage = 1;
            this.SpeakerCreatePage(this.Speakers);
        }

        private void SpeakerListDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //return;
            //this.SpeakerListDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
        }
    }
}
