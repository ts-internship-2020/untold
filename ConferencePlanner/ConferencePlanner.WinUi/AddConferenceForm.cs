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
using System.Threading.Tasks;

namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        private readonly IConferenceRepository _conferenceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ISpeakerRepository _speakerRepository;

        private int PageSize = 4;

        private int SelectedCountryId;
        private int SelectedCountyId;
        private int SelectedCityId;

        private BindingList<CountryModel> Countries;
        private BindingList<CountyModel> Counties;
        
        private BindingList<SpeakerModel> Speakers;
        private BindingList<SpeakerModel> SpeakersForSearchBar = new BindingList<SpeakerModel>();
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

        private void ConferenceNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void BackBtnTab_Click(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex--;
        }

        public int selectedRow;

        private bool IndexChange(string TabName, DataGridView CurrentDataGrid)
        {
            string PopUpTitle = "Warning", PopUpMessage;

            int selectedSpeakersCount = 0;
            if (CurrentDataGrid == this.SpeakerListDataGrid)
            {
                CurrentDataGrid.EndEdit();
                int col_idx = CurrentDataGrid.Columns["main_speaker"].Index;
                foreach (DataGridViewRow row in CurrentDataGrid.Rows)
                {
                    
                    if (Convert.ToBoolean(row.Cells[col_idx].Value) == true)
                    {
                        selectedSpeakersCount++;
                    }
                }
            }
            if ((CurrentDataGrid != this.SpeakerListDataGrid && CurrentDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1) || 
                (CurrentDataGrid == this.SpeakerListDataGrid && selectedSpeakersCount <1))
            {
                PopUpMessage = "Select a " + TabName;
                popUpMethod(PopUpTitle, PopUpMessage);
                return false;
            } else if ((CurrentDataGrid != this.SpeakerListDataGrid && CurrentDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1) || 
                (CurrentDataGrid == this.SpeakerListDataGrid && selectedSpeakersCount > 1))
            {
                PopUpMessage = "Select just a " + TabName;
                popUpMethod(PopUpTitle, PopUpMessage);
                return false;
            }
            return true;
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            //int selectedRowCount = CountryListDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            Point StartPtn = new Point(3, 43);
        
            DataGridView CurrentGridView = (DataGridView)TabControlLocation.SelectedTab.GetChildAtPoint(StartPtn);
            string Text = TabControlLocation.SelectedTab.Text;

            if (NextTabBtn.Text=="Next>>")
            {
                if(IndexChange(Text, CurrentGridView))
                {
                    var SelectedRowIndex = 0;
                    if(CurrentGridView == this.SpeakerListDataGrid)
                    {
                        int col_idx = CurrentGridView.Columns["main_speaker"].Index;
                        foreach (DataGridViewRow row in CurrentGridView.Rows)
                        {

                            if (Convert.ToBoolean(row.Cells[col_idx].Value) == true)
                            {
                                SelectedRowIndex = row.Index;
                            }
                        }
                    }
                    else
                    {
                        SelectedRowIndex = CurrentGridView.SelectedRows[0].Index;
                    }
                    

                    if (TabControlLocation.SelectedIndex == 0)
                    {
                        SelectedCountryId = (int)CurrentGridView.Rows[SelectedRowIndex].Cells["DictionaryCountryId"].Value;
                    }
                    if (TabControlLocation.SelectedIndex == 1)
                    {
                        SelectedCountyId = (int)CurrentGridView.Rows[SelectedRowIndex].Cells["CountyId"].Value;
                    }
                    if (TabControlLocation.SelectedIndex == 2)
                    {
                        // SelectedCityId = (int)CurrentGridView.Rows[SelectedRowIndex].Cells["DictionaryCytiId"].Value;
                    }

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
            
            if(TabControlLocation.SelectedTab == this.SpeakerTab)
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
            //BindingList<SpeakerModel> result2 = new BindingList<SpeakerModel>();

            int PreviousPageOffSet = (this.SpeakersCurrentPage - 1) * this.PageSize;
            
            int aux = Math.Min(PreviousPageOffSet+this.PageSize, lst.Count);

     
            for (int i= PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.SpeakerListDataGrid.DataSource = result;
        }


        private void LoadSpeakersTab()
        {
            this.Speakers = _speakerRepository.GetAllSpeakers();
            this.SpeakersForSearchBar = this.Speakers;
            
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
            if (SpeakerListDataGrid.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                SpeakerListDataGrid.Columns.Add(deleteButtonColumn);
                
            }

            this.SpeakerListDataGrid.Columns["FirstName"].HeaderText = "First Name";
            this.SpeakerListDataGrid.Columns["LastName"].HeaderText = "Last Name";

            //this.SpeakerListDataGrid.CurrentCell = null;
            this.SpeakerListDataGrid.Rows[0].Selected = false;


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
            this.SpeakerListDataGrid.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;
            
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

        }

        private void SpeakerEndEditLayout(string str1popup, string str2popup)
        {
            this.SpeakerUserMessagesBox.Visible = false;
            this.SpeakerSaveButton.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.SpeakerListDataGrid.Columns["main_speaker"].ReadOnly = false;
            this.SpeakerListDataGrid.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.White;
            this.SpeakerListDataGrid.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.White;
            this.SpeakerListDataGrid.Columns["delete_column"].Visible = true;
            this.SearchBar.Enabled = true;

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
            foreach(DataGridViewCell cell in SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells)
            {
                cell.Style.BackColor = Color.White;
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

            if (e.ColumnIndex == this.SpeakerListDataGrid.Columns["main_speaker"].Index)
            {
                return;
            }
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
            //if(this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Rating"].Value.GetType() != "float")
            //{
            //    speaker.Rating = 
            //}
            //float rating;
            //if (float.TryParse((string)this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Rating"].Value, out rating))
            //{
            //    speaker.Rating = (float)this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Rating"].Value;
            //}
            //else
            //{
            //    this.popUpMethod("Warning", "Rating must be a number! The value you inserted won't be saved");
            //    speaker.Rating = 0;
            //}
            speaker.FirstName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
            speaker.LastName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
            speaker.Nationality = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["Nationality"].Value.ToString();
          
            speaker.SpeakerId = (int)this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["SpeakerId"].Value;

            return speaker;
        }

        private void SpeakerSaveButton_Click(object sender, EventArgs e)
        {
            this.SpeakerListDataGrid.EndEdit();
            if ((this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow) || (this.UpdateSpeakerRow == this.PageSize))
            {
                SpeakerModel newSpeaker = GetSpeaker();
                _speakerRepository.InsertSpeaker(newSpeaker);
                this.Speakers.Add(newSpeaker);
                this.SpeakersForSearchBar = this.Speakers;
                int[] aux = this.CalculateTotalPages(this.Speakers.Count);
                this.SpeakersTotalPages = aux[0];
                this.SpeakersLastPageLastRow = aux[1];
                this.SpeakersCurrentPage = 1;
                this.SpeakerCreatePage(this.SpeakersForSearchBar);
                SpeakerEndEditLayout("Done", "You can see the speaker you just added on the last page.");
                //this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;
            }
            else
            {
                SpeakerModel speaker = this.GetSpeaker();
                _speakerRepository.UpdateSpeaker(speaker);
                SpeakerEndEditLayout("Done", "Speaker modified succesfully");
                this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;
                this.UpdateSpeakerArray(speaker);

            }
            this.SpeakerListDataGrid.CurrentCell = null;
        }  

        private void UpdateSpeakerArray(SpeakerModel speaker)
        {
            foreach (SpeakerModel s in this.Speakers)
            {
                if (s.SpeakerId == speaker.SpeakerId)
                {
                    this.Speakers[this.Speakers.IndexOf(s)].FirstName = speaker.FirstName;
                    this.Speakers[this.Speakers.IndexOf(s)].LastName = speaker.LastName;
                    this.Speakers[this.Speakers.IndexOf(s)].Nationality = speaker.Nationality;
                    this.Speakers[this.Speakers.IndexOf(s)].Rating = speaker.Rating;
                }
            }
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
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if(this.SpeakerListDataGrid.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if((e.RowIndex == this.PageSize) || (this.SpeakersLastPageLastRow>0 && this.SpeakersCurrentPage ==this.SpeakersTotalPages && e.RowIndex == this.SpeakersLastPageLastRow))
                {
                    return;
                }
                
                int id = (int) this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["SpeakerId"].Value;
                var newDeleteForm = new AreYouSure(_speakerRepository, id);

                Task t = Task.Run(() => { newDeleteForm.ShowDialog();  } );
                t.Wait();
                this.LoadSpeakersTab();
                
            }

        }

        private void SpeakerListDataGrid_Layout(object sender, LayoutEventArgs e)
        {
            
            this.SpeakerListDataGrid.CurrentCell = null;
            
            this.SpeakerListDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }


        private void SpeakersNextBtn_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage++;
            if (this.SpeakersForSearchBar.Count > 0)
            {
                this.SpeakerCreatePage(this.SpeakersForSearchBar);
               
            }
            else
            {
                this.SpeakerCreatePage(this.Speakers);
            }
            this.SpeakerListDataGrid.Rows[0].Selected = false;
        }

        private void SpeakersLastPage_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage = this.SpeakersTotalPages;
            if (this.SpeakersForSearchBar.Count > 0)
            {
                this.SpeakerCreatePage(this.SpeakersForSearchBar);

            }
            else
            {
                this.SpeakerCreatePage(this.Speakers);
            }
            this.SpeakerListDataGrid.Rows[0].Selected = false;

        }

        private void SpeakersBackBtn_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage--;
            if (this.SpeakersForSearchBar.Count > 0)
            {
                this.SpeakerCreatePage(this.SpeakersForSearchBar);

            }
            else
            {
                this.SpeakerCreatePage(this.Speakers);
            }
            this.SpeakerListDataGrid.Rows[0].Selected = false;
        }

        private void SpeakersFirstPage_Click(object sender, EventArgs e)
        {
            this.SpeakersCurrentPage = 1;
            if (this.SpeakersForSearchBar.Count > 0)
            {
                this.SpeakerCreatePage(this.SpeakersForSearchBar);

            }
            else
            {
                this.SpeakerCreatePage(this.Speakers);
            }
            this.SpeakerListDataGrid.Rows[0].Selected = false;
        }

        private void SpeakerListDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.ColumnIndex == this.SpeakerListDataGrid.Columns["Rating"].Index)
            {
                float rating;
                if (float.TryParse((string)this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["Rating"].Value, out rating))
                {
                    return;
                }
                else
                {
                    this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["Rating"].Value = 0;
                    this.popUpMethod("Warning", "Rating must be a number! The value you inserted won't be saved");
      
                }
            }
            
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if(this.TabControlLocation.SelectedTab.Name == "SpeakerTab")
            {
                this.SpeakersCurrentPage = 1;
                BindingList<SpeakerModel> result = new BindingList<SpeakerModel>();
                foreach (SpeakerModel speaker in this.Speakers)
                {
                    if (speaker.FirstName.ToLower().Contains(this.SearchBar.Text.ToLower()) || speaker.LastName.ToLower().Contains(this.SearchBar.Text.ToLower()))
                    {
                        result.Add(speaker);
                    }
            }
                int[] aux = this.CalculateTotalPages(result.Count);
                this.SpeakersTotalPages = aux[0];
                this.SpeakersLastPageLastRow = aux[1];
                this.SpeakersForSearchBar = result;
                this.SpeakerCreatePage(this.SpeakersForSearchBar);

            }
            
        }

        private void SearchBar_Enter(object sender, EventArgs e)
        {
            this.SearchBar.Text = "";
        }
    }
}
