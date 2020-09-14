using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;


namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        private readonly IConferenceRepository _conferenceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICategoryRepository _categoryRepository;

        private int PageSize = 4;

        private int SelectedCountryId;
        private int SelectedCountyId;
        private int SelectedCityId;
        private int SelectedSpeakerId = -1;
        private int SelectedTypeId;
        private int DictionaryCityId;
        private int SelectedCategoryId;
        private DataGridView CurrentGridView;
        private BindingList<CountryModel> Countries;
        private BindingList<CountryModel> CountriesFromSearchBar = new BindingList<CountryModel>();
        private int CountriesTotalPages;
        private int CountriesCurrentPage = 1;
        private int CountriesLastPageLastRow = 0;
        private int UpdateCountriesRow;

        private BindingList<CountyModel> Counties;
        private BindingList<CountyModel> CountiesFromSearchBar = new BindingList<CountyModel>();
        private int CountiesTotalPages;
        private int CountiesCurrentPage = 1;
        private int CountiesLastPageLastRow = 0;
        private int UpdateCountyRow;
        private BindingList<CityModel> Cities;
        private BindingList<CityModel> CitiesFromSearchBar = new BindingList<CityModel>();
        private BindingList<SpeakerModel> Speakers;
        private BindingList<SpeakerModel> SpeakersForSearchBar = new BindingList<SpeakerModel>();
        private BindingList<TypeModel> Types;
        private BindingList<TypeModel> TypesForSearchBar = new BindingList<TypeModel>();
        private int CityTotalPages;
        private int CityCurrentPage = 1;
        private int CityLastPageLastRow = 0;
        private int SpeakersTotalPages;
        private int TypesTotalPages;
        private int TypesCurrentPage = 1;
        private int UpdateTypeRow;
        private int TypesLastPageLastRow = 0;
        private int SpeakersCurrentPage = 1;
        private int SpeakersLastPageLastRow = 0;
        private int UpdateSpeakerRow;
        private int UpdateCityRow;

        private BindingList<CategoryModel> Categories;
        private BindingList<CategoryModel> CategoriesFromSearch = new BindingList<CategoryModel>();
        private int CategoriesToatlPages;
        private int CategoriesCurrentPage = 1;
        private int CategoriesLastPageLastRow = 0;
        private int UpdateCategoryRow;

        private bool isEditingConference = false;
        public AddConf(IConferenceRepository conferenceRepository, ICountryRepository countryRepository, ICountyRepository countyRepository, ISpeakerRepository speakerRepository, ITypeRepository typeRepository, ICityRepository cityRepository, ICategoryRepository categoryRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _countyRepository = countyRepository;
            _cityRepository = cityRepository;
            _speakerRepository = speakerRepository;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
            InitializeComponent();

        }



        public AddConf()
        {

            InitializeComponent();
        }
        public AddConf(ConferenceModel conference, IConferenceRepository conferenceRepository, ICountryRepository countryRepository, ICountyRepository countyRepository, ISpeakerRepository speakerRepository, ITypeRepository typeRepository, ICityRepository cityRepository, ICategoryRepository categoryRepository)
        {
            _conferenceRepository = conferenceRepository;
            _countryRepository = countryRepository;
            _countyRepository = countyRepository;
            _cityRepository = cityRepository;
            _speakerRepository = speakerRepository;
            _typeRepository = typeRepository;
            _categoryRepository = categoryRepository;
            InitializeComponent();

            this.isEditingConference = true;
            this.PopulateForm(conference);

        }
        private void PopulateForm(ConferenceModel conference)
        {

            //this.CountryListDataGridView.Rows[0].Selected = false;
            //this.CountiesListGridView.Rows[0].Selected = false;

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
            if (ConfName.Text == string.Empty)
            {
                ErrorName.SetError(ConfName, "Please enter a value in the conference name fild!");
                return;
            }


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
                (CurrentDataGrid == this.SpeakerListDataGrid && selectedSpeakersCount < 1))
            {
                PopUpMessage = "Select a " + TabName;
                popUpMethod(PopUpTitle, PopUpMessage);
                return false;
            }
            else if ((CurrentDataGrid != this.SpeakerListDataGrid && CurrentDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1) ||
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
            var SelectedRowIndex = 0;

            string Text = TabControlLocation.SelectedTab.Text;

            if (NextTabBtn.Text == "Next>>")
            {

                if (TabControlLocation.SelectedTab == this.Country)
                {
                    CurrentGridView = CountryListDataGridView;

                    if (IndexChange(Text, CurrentGridView))
                    {
                        SelectedCountryId = (int)CurrentGridView.SelectedRows[0].Cells["DictionaryCountryId"].Value;
                        TabControlLocation.SelectedIndex++;

                    }

                }
                if (TabControlLocation.SelectedTab == this.County)
                {
                    CurrentGridView = CountiesListGridView;
                    if (IndexChange(Text, CurrentGridView))
                    {
                        SelectedCountyId = (int)CurrentGridView.SelectedRows[0].Cells["CountyId"].Value;
                        TabControlLocation.SelectedIndex++;

                    }
                }
                if (TabControlLocation.SelectedTab == this.City)
                {
                    CurrentGridView = CityListDataGridView;
                    if (IndexChange(Text, CurrentGridView))
                    {
                        SelectedCityId = (int)CurrentGridView.SelectedRows[0].Cells["DictionaryCityId"].Value;
                        TabControlLocation.SelectedIndex++;

                    }
                }
                if (TabControlLocation.SelectedTab == this.TypeTab)
                {
                    CurrentGridView = TypeDataGrid;
                    if (IndexChange(Text, CurrentGridView))
                    {
                        SelectedTypeId = (int)CurrentGridView.SelectedRows[0].Cells["TypeId"].Value;
                        TabControlLocation.SelectedIndex++;

                    }
                }

                if (TabControlLocation.SelectedTab == this.SpeakerTab)
                {
                    CurrentGridView = SpeakerListDataGrid;
                    if (IndexChange(Text, CurrentGridView))
                    {
                        if (CurrentGridView == this.SpeakerListDataGrid)
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

                        SelectedSpeakerId = (int)CurrentGridView.Rows[SelectedRowIndex].Cells["SpeakerId"].Value;
                        TabControlLocation.SelectedIndex++;

                    }
                }

                if (TabControlLocation.SelectedTab == CategoryTab)
                {
                    CurrentGridView = CategoryDataGridView;
                    if (IndexChange(Text, CurrentGridView))
                    {
                        SelectedCategoryId = (int)CurrentGridView.SelectedRows[0].Cells["CategoryId"].Value;
                        TabControlLocation.SelectedIndex++;
                    }
                }
            }
            else
            {
                //aici face save   
                if (this.isEditingConference)
                {
                    ConferenceModelWithEmail newConference = CreateConferenceForInsert();

                    var t = Task.Run(() => UpdateConference(newConference));
                    t.Wait();

                    this.Close();
                }
                else
                {
                    ConferenceModelWithEmail newConference = CreateConferenceForInsert();

                    var t = Task.Run(() => InsertConference(newConference));
                    t.Wait();

                    this.Close();
                }
            }
        }

        private void TabControlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage tab in this.TabControlLocation.TabPages)
            {
                if (TabControlLocation.SelectedTab != tab)
                    tab.Enabled = false;
                else
                {
                    tab.Enabled = true;
                }
            }


            if (TabControlLocation.SelectedIndex == 0)
            {
                this.LoadCountryTab();
            }
            if (TabControlLocation.SelectedTab == County)
            {
                this.LoadCountyTab();

            }
            if (TabControlLocation.SelectedTab == this.City)
            {
                this.LoadCityTab();
            }

            if (TabControlLocation.SelectedTab == this.SpeakerTab)
            {
                this.LoadSpeakersTab();
            }

            if (TabControlLocation.SelectedTab == this.TypeTab)
            {
                this.LoadTypesTab();
            }
            if (TabControlLocation.SelectedTab == CategoryTab)
            {
                LoadCategoryTab();
            }

            if (TabControlLocation.SelectedIndex > 0)
            {
                BackTabBtn.Enabled = true;
            }
            else
            {
                BackTabBtn.Enabled = false;
            }
            if (TabControlLocation.SelectedIndex >= 5)
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
        public void ResetForm()
        {
            ConfName.Text = string.Empty;
            StardDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
            this.StartHour.Value = DateTime.Today;
            this.EndHour.Value = DateTime.Today;

            //mai trebuie niste variabile 

        }
        public ConferenceModelWithEmail CreateConferenceForInsert()
        {
            ConferenceModelWithEmail newConference = new ConferenceModelWithEmail();

            DateTime ConferenceStartDate = this.StardDatePicker.Value;
            DateTime ConferenceEndDate = this.EndDatePicker.Value;
            DateTime ConferenceStartHour = this.StartHour.Value;
            DateTime ConferenceEndHour = this.EndHour.Value;

            DateTime startDate = ConferenceStartDate.Date + ConferenceStartHour.TimeOfDay;
            DateTime endDate = ConferenceEndDate.Date + ConferenceEndHour.TimeOfDay;
            //string startDate = ConferenceStartDate.ToString("yyyy-MM-dd hh:mm:ss").Split(" ")[0] + " " + ConferenceStartHour.ToString().Split(" ")[1];
            //string endDate = ConferenceEndDate.ToString("yyyy-MM-dd hh:mm:ss").Split(" ")[0] + " " + ConferenceEndHour.ToString().Split(" ")[1];

            newConference.Email = Program.EnteredEmailAddress;
            newConference.ConferenceName = this.ConfName.Text;
            newConference.ConferenceCategoryId = this.SelectedCategoryId;
            newConference.ConferenceTypeId = this.SelectedTypeId;
            newConference.MainSpeakerId = this.SelectedSpeakerId;
            newConference.LocationId = this.SelectedCityId;
            //newConference.Period = startDate + " - " + endDate;
            newConference.StartDate = startDate;
            newConference.StartDate = endDate;
            return newConference;
        }
        private void SaveNew_Click(object sender, EventArgs e)
        {
            ConferenceModelWithEmail newConference = CreateConferenceForInsert(); 

            var t = Task.Run(() => InsertConference(newConference));
            t.Wait();

            ResetForm();
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

        private void CountriesCreatePage(BindingList<CountryModel> list)
        {
            this.CountriesPages.Text = "Page" + this.CountriesCurrentPage + " of " + this.CountriesTotalPages;
            CheckPaginationButtonsVisibility(CountriesCurrentPage, CountriesTotalPages, CountriesNextBtn, CountriesBackBtn, CountriesFirstPageBtn, CountriesFirstPageBtn);
            BindingList<CountryModel> CountriesList = new BindingList<CountryModel>();
            int PreviousPageOffSet = (CountriesCurrentPage - 1) * PageSize;
            int min = Math.Min(PreviousPageOffSet + PageSize, list.Count);
            for (int i = PreviousPageOffSet; i < min; i++)
            {
                CountriesList.Add(list[i]);
            }
            this.CountryListDataGridView.DataSource = CountriesList;
        }

        private void CountiesCreatePage(BindingList<CountyModel> list)
        {
            this.CountriesPages.Text = "Page" + this.CountiesCurrentPage + " of " + this.CountiesTotalPages;
            CheckPaginationButtonsVisibility(CountiesCurrentPage, CountiesTotalPages, CountiesNextBtn, CountiesBackBtn, CountiesFirstPage, CountiesFirstPage);
            BindingList<CountyModel> CountiesList = new BindingList<CountyModel>();
            int PreviousPageOffSet = (CountiesCurrentPage - 1) * PageSize;
            int min = Math.Min(PreviousPageOffSet + PageSize, list.Count);
            for (int i = PreviousPageOffSet; i < min; i++)
            {
                CountiesList.Add(list[i]);
            }
            this.CountiesListGridView.DataSource = CountiesList;
        }

        private void SpeakerCreatePage(BindingList<SpeakerModel> lst)
        {
            this.SpeakersPages.Text = "Page" + this.SpeakersCurrentPage + " of " + this.SpeakersTotalPages;

            this.CheckPaginationButtonsVisibility(this.SpeakersCurrentPage, this.SpeakersTotalPages,
                this.SpeakersNextBtn, this.SpeakersBackBtn, this.SpeakersLastPage, this.SpeakersFirstPage);

            BindingList<SpeakerModel> result = new BindingList<SpeakerModel>();

            int PreviousPageOffSet = (this.SpeakersCurrentPage - 1) * this.PageSize;

            int aux = Math.Min(PreviousPageOffSet + this.PageSize, lst.Count);


            for (int i = PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.SpeakerListDataGrid.DataSource = result;


        }

        private void TypeCreatePage(BindingList<TypeModel> lst)
        {
            this.TypesPages.Text = "Page" + this.TypesCurrentPage+ " of " + this.TypesTotalPages;

            this.CheckPaginationButtonsVisibility(this.TypesCurrentPage, this.TypesTotalPages,
                this.TypesNextBtn, this.TypesBackBtn, this.TypesLastPage, this.TypesFirstPage);
            BindingList<TypeModel> result = new BindingList<TypeModel>();
            //BindingList<SpeakerModel> result2 = new BindingList<SpeakerModel>();

            int PreviousPageOffSet = (this.TypesCurrentPage - 1) * this.PageSize;

            int aux = Math.Min(PreviousPageOffSet + this.PageSize, lst.Count);


            for (int i = PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.TypeDataGrid.DataSource = result;
        }


        private void CategoryCreatePage(BindingList<CategoryModel> list)
        {
            this.CategoriesPages.Text = "Page" + this.CategoriesCurrentPage + " of " + this.CategoriesToatlPages;
            CheckPaginationButtonsVisibility(CategoriesCurrentPage, CategoriesToatlPages, CategoriesNextBtn, CategoriesBackBtn, CategoriesLastPage, CategoriesFirstPage);
            BindingList<CategoryModel> categoryModels = new BindingList<CategoryModel>();

            int PreviosPageOffSet = (CategoriesCurrentPage - 1) * PageSize;
            int temp = Math.Min(PreviosPageOffSet + PageSize, list.Count);

            for (int i = PreviosPageOffSet; i < temp; i++)
            {
                categoryModels.Add(list[i]);

            }

            CategoryDataGridView.DataSource = categoryModels;



        }


        private void LoadSpeakersTab()
        {

            var t = Task.Run(() => GetAllSpeakers());
            t.Wait();

            this.SpeakersForSearchBar = this.Speakers;
         
            int[] aux = this.CalculateTotalPages(this.Speakers.Count);
            this.SpeakersTotalPages = aux[0];
            this.SpeakersLastPageLastRow = aux[1];

            this.SpeakerCreatePage(this.Speakers);
        }


        private void LoadCategoryTab()
        {

            var t = Task.Run(() => GetConferenceCategories());
            t.Wait();


            CategoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Categories = _categoryRepository.GetConferenceCategories();
            CategoriesFromSearch = Categories;
            int[] temp = CalculateTotalPages(Categories.Count);
            CategoriesToatlPages = temp[0];
            CategoriesLastPageLastRow = temp[1];

            CategoryCreatePage(Categories);




        }

        private void CitiesBeginEditLayout(string opType)
        {
            this.CityListDataGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;

            foreach (DataGridViewRow row in CityListDataGridView.Rows)
            {
                if (row.Index != this.UpdateCityRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.CitiesNextBtn.Enabled = false;
            this.CitiesBackBtn.Enabled = false;
            this.CitiesFirstPage.Enabled = false;
            this.CitiesLastPage.Enabled = false;

            if (opType == "update")
            {
                this.CityListDataGridView.AllowUserToAddRows = false;
            }

        }
        private void CityEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            CitySaveMessageBox.Visible = false;
            SaveCityButton.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CityListDataGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CityListDataGridView.Rows)
            {
                if (row.Index != UpdateCityRow)
                {
                    row.ReadOnly = false;
                }
            }

            this.CitiesNextBtn.Enabled = true;
            this.CitiesBackBtn.Enabled = true;
            this.CitiesFirstPage.Enabled = true;
            this.CitiesLastPage.Enabled = true;

            if (!CityListDataGridView.AllowUserToAddRows)
            {
                CityListDataGridView.AllowUserToAddRows = true;
            }
        }


        private void CitiesListDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateCityRow = e.RowIndex;

            if (CitySaveMessageBox.Visible == false)
            {
                if (this.UpdateCityRow >= this.PageSize ||
                    (this.CityLastPageLastRow > 0 && this.CityCurrentPage == this.CityTotalPages && this.UpdateCityRow == this.CityLastPageLastRow))
                {
                    this.AddInsertMessageCity();
                    this.CitiesBeginEditLayout("insert");
                }
                else
                {
                    string city = this.CityListDataGridView.Rows[this.UpdateCityRow].Cells["CityName"].Value.ToString();
                    this.AddUpdateMessageCity(city);
                    this.CitiesBeginEditLayout("update");
                }
            }
            else if (this.UpdateCityRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void AddInsertMessageCity()
        {
            this.CitySaveMessageBox.ForeColor = Color.MediumSeaGreen;
            this.CitySaveMessageBox.Text = "You are now adding a new city. Press the button to Save.";
            this.CitySaveMessageBox.Visible = true;
            this.SaveCityButton.Visible = true;
        }

        private void AddUpdateMessageCity(string cityName)
        {
            this.CitySaveMessageBox.ForeColor = Color.MediumSeaGreen;
            this.CitySaveMessageBox.Text = "You are now editing city " + cityName + "'s informations. Press the button to Save.";
            this.CitySaveMessageBox.Visible = true;
            this.SaveCityButton.Visible = true;
        }

        private void CityListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CityListDataGridView.Columns.Contains("DictionaryCityId") && CityListDataGridView.Columns["DictionaryCityId"].Visible)
            {
                CityListDataGridView.Columns["DictionaryCityId"].Visible = false;
            }

            CityListDataGridView.Columns["CityName"].HeaderText = "City Name";

            if (CityListDataGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 5;
                deleteButtonColumn.DividerWidth = 10;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";
                CityListDataGridView.Columns.Add(deleteButtonColumn);
            }
            this.CityListDataGridView.Rows[0].Selected = false;
        }

        private void CityListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (this.CityListDataGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                int id = (int)this.CityListDataGridView.Rows[e.RowIndex].Cells["DictionaryCityId"].Value;
                var newDeleteForm = new AreYouSure(_cityRepository, id);
                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadCityTab();
            }

        }

        public void getLastDictionaryCityId()
        {

        }

        private CityModel GetCity()
        {
            CityModel cityModel = new CityModel();
            cityModel.DictionaryCityId = (int)this.CityListDataGridView.Rows[this.UpdateCityRow].Cells["DictionaryCityId"].Value;
            cityModel.CityName = this.CityListDataGridView.Rows[this.UpdateCityRow].Cells["CityName"].Value.ToString();
            cityModel.CountyId = SelectedCountyId;
            return cityModel;
        }

        private async Task GetCityAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("http://localhost:2794/api/City/getAllCitiesByCountyId=" + id);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string json = await httpResponseMessage.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<BindingList<CityModel>>(json);
                this.Cities = t;
            }
            else
            {
                this.Cities = new BindingList<CityModel>();
            }
        }

        private void LoadCityTab()
        {
            CityListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var t = Task.Run(() => GetCityAsync(SelectedCountyId));
            t.Wait();
            //_cityRepository.GetCitiesByCountyId(SelectedCountyId);
            int[] pages = CalculateTotalPages(Cities.Count);
            CityListDataGridView.AllowUserToOrderColumns = true;
            CityListDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            CityListDataGridView.DataSource = this.Cities;
            CityTotalPages = pages[0];
            CityLastPageLastRow = pages[1];
            CitiesCreatePage(Cities);
        }

        private async Task InsertCityAsync(CityModel cityModel)
        {
            var json = JsonConvert.SerializeObject(cityModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/City/InsertCity", httpContent);
            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You added the city succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }


        private async Task UpdateCityAsync(CityModel cityModel)
        {
            var json = JsonConvert.SerializeObject(cityModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/City/UpdateCity", httpContent);


            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You updated the city succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }

        private void SaveCityButton_Click(object sender, EventArgs e)
        {
            this.CityListDataGridView.EndEdit(); // de facut endedit
            if ((CityLastPageLastRow > 0 && CityCurrentPage == CityTotalPages && UpdateCityRow == CityLastPageLastRow) || UpdateCityRow == PageSize)
            {

                CityModel newCity = GetCity();
                newCity.DictionaryCityId = _cityRepository.LastDictionaryCityId() + 1;
                //_cityRepository.InsertCity(newCity);
                var t = Task.Run(() => InsertCityAsync(newCity));
                t.Wait();
                this.Cities.Add(newCity);
                this.CitiesFromSearchBar = this.Cities;
                int[] aux = this.CalculateTotalPages(this.Cities.Count);
                this.CityTotalPages = aux[0];
                this.CityLastPageLastRow = aux[1];
                this.CityCurrentPage = 1;
                this.CitiesCreatePage(this.CitiesFromSearchBar);
                CityEndEditLayout("Done", "You can see the city you just added on the last page.");
                //this.SpeakerListDataGrid.CurrentCell = null;
                this.CityListDataGridView.Rows[0].Selected = false;

            }
            else
            {
                CityModel city = GetCity();
                //city.DictionaryCityId = CityListDataGridView.Columns["DictionaryCityId"]
                //_cityRepository.UpdateCity(city);
                var t = Task.Run(() => UpdateCityAsync(city));
                t.Wait();
                CityEndEditLayout("Done", "City modified succesfully");
                this.CityListDataGridView.CurrentCell = null;
                this.CityListDataGridView.Rows[0].Selected = false;
                this.UpdateInCityList(city);

            }
            this.CityListDataGridView.CurrentCell = null;
        }

        private void UpdateInCityList(CityModel cityModel)
        {
            foreach (CityModel c in this.Cities)
            {
                if (c.DictionaryCityId == cityModel.DictionaryCityId)
                {
                    this.Cities[this.Cities.IndexOf(c)].CityName = cityModel.CityName;
                }
            }
        }



        private void CitiesCreatePage(BindingList<CityModel> cityModels)
        {
            this.CitiesPages.Text = "Page" + this.CityCurrentPage + " of " + this.CityTotalPages;
            this.CheckPaginationButtonsVisibility(this.CityCurrentPage, this.CityTotalPages,
                this.CitiesNextBtn, this.CitiesBackBtn, this.CitiesLastPage, this.CitiesFirstPage);

            BindingList<CityModel> cities = new BindingList<CityModel>();
            int PreviousPageOffSet = (this.CityCurrentPage - 1) * this.PageSize;

            int min = Math.Min(PreviousPageOffSet + this.PageSize, cityModels.Count);


            for (int i = PreviousPageOffSet; i < min; i++)
            {
                if (i < 0)
                {
                    return;
                }
                else
                {
                    cities.Add(cityModels[i]);

                }
            }

            this.CityListDataGridView.DataSource = cities;


        }

        private void CitiesNextBtn_Click(object sender, EventArgs e)
        {
            this.CityCurrentPage++;
            if (this.CitiesFromSearchBar.Count > 0)
            {
                this.CitiesCreatePage(this.CitiesFromSearchBar);

            }
            else
            {
                this.CitiesCreatePage(this.Cities);
            }
            this.CityListDataGridView.Rows[0].Selected = false;
        }

        private void CitiesLastPage_Click(object sender, EventArgs e)
        {
            this.CityCurrentPage = this.CityTotalPages;
            if (this.CitiesFromSearchBar.Count > 0)
            {
                this.CitiesCreatePage(this.CitiesFromSearchBar);

            }
            else
            {
                this.CitiesCreatePage(this.Cities);
            }
            this.CityListDataGridView.Rows[0].Selected = false;

        }

        private void CitiesBackBtn_Click(object sender, EventArgs e)
        {
            this.CityCurrentPage--;
            if (this.CitiesFromSearchBar.Count > 0)
            {
                this.CitiesCreatePage(this.CitiesFromSearchBar);

            }
            else
            {
                this.CitiesCreatePage(this.Cities);
            }
            this.CityListDataGridView.Rows[0].Selected = false;
        }

        private void CitiesFirstPage_Click(object sender, EventArgs e)
        {
            this.CityCurrentPage = 1;
            if (this.CitiesFromSearchBar.Count > 0)
            {
                this.CitiesCreatePage(this.CitiesFromSearchBar);

            }
            else
            {
                this.CitiesCreatePage(this.Cities);
            }
            this.CityListDataGridView.Rows[0].Selected = false;
        }





        private void LoadTypesTab()
        {
            //this.Types = _typeRepository.GetConferenceType();
            var t = Task.Run(() => GetTypes());
            t.Wait();

            this.TypesForSearchBar = this.Types;
            int[] aux = this.CalculateTotalPages(this.Types.Count);
            this.TypesTotalPages = aux[0];
            this.TypesLastPageLastRow = aux[1];

            this.TypeCreatePage(this.Types);
        }

        private void SpeakerListDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (SpeakerListDataGrid.Columns.Contains("ImagePath"))
            {
                this.SpeakerListDataGrid.Columns.Remove("ImagePath");
            }
            if (SpeakerListDataGrid.Columns.Contains("SpeakerId") && SpeakerListDataGrid.Columns["SpeakerId"].Visible)
            {
                SpeakerListDataGrid.Columns["SpeakerId"].Visible = false;
            }
            if (SpeakerListDataGrid.Columns.Contains("main_speaker") == false)
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

            this.SpeakerListDataGrid.Controls[1].Enabled = true;


            //this.SpeakerListDataGrid.PerformLayout();

        }



        private void AddConf_Load(object sender, EventArgs e)
        {
            TabControlLocation.SelectedIndex = 0;

            LoadCountryTab();
        }



        private void LoadCountryTab()
        {
            this.Countries = _countryRepository.GetCountriesList();
            CountriesFromSearchBar = Countries;
            int[] pages = CalculateTotalPages(Countries.Count);
            CountryListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CountryListDataGridView.AllowUserToOrderColumns = true;
            CountryListDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountriesTotalPages = pages[0];
            CountriesLastPageLastRow = pages[1];

            CountriesCreatePage(Countries);
        }



        private void CountryListDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CountryListDataGridView.Columns.Contains("DictionaryCountryId") && CountryListDataGridView.Columns["DictionaryCountryId"].Visible)
            {
                CountryListDataGridView.Columns["DictionaryCountryId"].Visible = false;
            }

            if (CountryListDataGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CountryListDataGridView.Columns.Add(deleteButtonColumn);

            }
            CountryListDataGridView.Columns["CountryName"].HeaderText = "Country Name";
            CountryListDataGridView.Rows[0].Selected = false;
        }

        private void CountryAddInsertMessage()
        {
            CountryEditTextBox.Text = "You are now adding a new country. Press the button to Save. ";
            CountryEditTextBox.Visible = true;
            CountrySaveEditBtn.Visible = true;
        }

        private void CountryAddUpdateMessage(string CountryName)
        {
            CountryEditTextBox.Text = "You are now editing the " + CountryName + " country. Press the button to Save.";
            CountryEditTextBox.Visible = true;
            CountrySaveEditBtn.Visible = true;
        }

        private void CountriesBeginEditLayout(string Action)
        {
            CountryListDataGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;
            foreach (DataGridViewRow row in CountryListDataGridView.Rows)
            {
                if (row.Index != UpdateCountriesRow)
                {
                    row.ReadOnly = true;
                }
            }
            CountriesNextBtn.Enabled = false;
            CountriesLastPage.Enabled = false;
            CountriesFirstPageBtn.Enabled = false;
            CountriesBackBtn.Enabled = false;

            if (Action == "Update")
            {
                CountryListDataGridView.AllowUserToAddRows = false;
            }
        }

        private void CountriesEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            CountryEditTextBox.Visible = false;
            CountrySaveEditBtn.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CountryListDataGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CountryListDataGridView.Rows)
            {
                if (row.Index != UpdateCountriesRow)
                {
                    row.ReadOnly = false;
                }
            }

            CountriesNextBtn.Enabled = true;
            CountriesLastPage.Enabled = true;
            CountriesFirstPageBtn.Enabled = true;
            CountriesBackBtn.Enabled = true;

            if (!CountryListDataGridView.AllowUserToAddRows)
            {
                CountryListDataGridView.AllowUserToAddRows = true;
            }
        }


        private void TypeDataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (TypeDataGrid.Columns.Contains("TypeId") && TypeDataGrid.Columns["TypeId"].Visible)
            {
                TypeDataGrid.Columns["TypeId"].Visible = false;
            }

            this.TypeDataGrid.Columns["TypeName"].HeaderText = "Conference Type";
            if (TypeDataGrid.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 55;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                TypeDataGrid.Columns.Add(deleteButtonColumn);

            }
            this.TypeDataGrid.Rows[0].Selected = false;

            //this.TypeDataGrid.Columns["ConferenceTypeName"].HeaderText = "Conference Type";


        }


        private void CategoryDataGridVIew_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CategoryDataGridView.Columns.Contains("ConferenceCategoryId") && CategoryDataGridView.Columns["ConferenceCategoryId"].Visible)
            {
                CategoryDataGridView.Columns["ConferenceCategoryId"].Visible = false;
            }

            CategoryDataGridView.Columns["ConferenceCategoryName"].HeaderText = "Conference Category";
            if (CategoryDataGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 55;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CategoryDataGridView.Columns.Add(deleteButtonColumn);
            }

            CategoryDataGridView.Rows[0].Selected = false;

        }




        //private void LoadSpeakersTab()
        //{
        //    this.Speakers = _speakerRepository.GetAllSpeakers();
        //    this.SpeakersForSearchBar = this.Speakers;
        //    int[] aux = this.CalculateTotalPages(this.Speakers.Count);
        //    this.SpeakersTotalPages = aux[0];
        //    this.SpeakersLastPageLastRow = aux[1];

        //    this.SpeakerCreatePage(this.Speakers);
        //}

        private void LoadCountyTab()
        {
            this.Counties = _countyRepository.GetCountyList(this.SelectedCountryId);
            CountiesFromSearchBar = Counties;
            int[] pages = CalculateTotalPages(Counties.Count);
            CountiesListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CountiesListGridView.AllowUserToOrderColumns = true;
            CountiesListGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountiesTotalPages = pages[0];
            CountiesLastPageLastRow = pages[1];

            CountiesCreatePage(Counties);

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
            if (CountiesListGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CountiesListGridView.Columns.Add(deleteButtonColumn);

            }
            CountiesListGridView.Columns["CountyName"].HeaderText = "County Name";
            CountiesListGridView.Rows[0].Selected = false;
        }


        private void CountyAddInsertMessage()
        {
            CountyEditTextBox.Text = "You are now adding a new county. Press the button to Save. ";
            CountyEditTextBox.Visible = true;
            CountySaveEditBtn.Visible = true;
        }

        private void CountyAddUpdateMessage(string CountyName)
        {
            CountyEditTextBox.Text = "You are now editing the " + CountyName + " county. Press the button to Save.";
            CountyEditTextBox.Visible = true;
            CountySaveEditBtn.Visible = true;
        }

        private void CountiBeginEditLayout(string Action)
        {
            CountiesListGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;
            foreach (DataGridViewRow row in CountiesListGridView.Rows)
            {
                if (row.Index != UpdateCountyRow)
                {
                    row.ReadOnly = true;
                }
            }
            CountiesNextBtn.Enabled = false;
            CountiesLastPage.Enabled = false;
            CountiesFirstPage.Enabled = false;
            CountiesBackBtn.Enabled = false;

            if (Action == "Update")
            {
                CountiesListGridView.AllowUserToAddRows = false;
            }
        }

        private void CountiesEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            CountyEditTextBox.Visible = false;
            CountySaveEditBtn.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CountiesListGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CountiesListGridView.Rows)
            {
                if (row.Index != UpdateCountyRow)
                {
                    row.ReadOnly = false;
                }
            }

            CountiesNextBtn.Enabled = true;
            CountiesLastPage.Enabled = true;
            CountiesFirstPage.Enabled = true;
            CountiesBackBtn.Enabled = true;

            if (!CountiesListGridView.AllowUserToAddRows)
            {
                CountiesListGridView.AllowUserToAddRows = true;
            }
        }
        private void SpeakerAddInsertMessage()
        {
            this.SpeakerUserMessagesBox.ForeColor = Color.MediumSeaGreen;
            this.SpeakerUserMessagesBox.Text = "You are now adding a new speaker. Press the button to Save.";
            this.SpeakerUserMessagesBox.Visible = true;
            this.SpeakerSaveButton.Visible = true;
        }


        private void AddInsertMessageType()
        {
            this.textBox3.ForeColor = Color.MediumSeaGreen;
            this.textBox3.Text = "You are now adding a new conference type. Press the button to Save.";
            this.textBox3.Visible = true;
            this.button3.Visible = true;
        }


        private void CategoryAddInsertMessage()
        {
            CategoryEditTextField.Text = "You are now adding a new conference category.  Press the button to Save.";
            CategoryEditTextField.Visible = true;
            CategoryEditSaveBtn.Visible = true;
        }



        private void SpeakerAddUpdateMessage(string fName, string lName)
        {
            this.SpeakerUserMessagesBox.ForeColor = Color.MediumSeaGreen;
            string sName = fName + " " + lName;
            this.SpeakerUserMessagesBox.Text = "You are now editing speaker " + sName + "'s informations. Press the button to Save.";
            this.SpeakerUserMessagesBox.Visible = true;
            this.SpeakerSaveButton.Visible = true;
        }

        private void AddUpdateMessageType(string name)
        {
            this.textBox3.ForeColor = Color.MediumSeaGreen;
            string confname = name;
            //int idtype = id;
            this.textBox3.Text = "You are now editing conference type " + confname + " Press the button to Save.";
            this.textBox3.Visible = true;
            this.button3.Visible = true;
        }

        private void CategoryAddUpdatedMessage(string name)
        {
            CategoryEditTextField.Text = "You are now editing conference category " + name + ". Press the Button to Save.";
            CategoryEditTextField.Visible = true;
            CategoryEditSaveBtn.Visible = true;
        }
        private void SpeakerBeginEditLayout(string opType)
        {
            this.SpeakerPaginationSelector.Enabled = false;
            this.SpeakerListDataGrid.SelectionMode = (DataGridViewSelectionMode) 0; //CellSelect
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


        private void TypeBeginEditLayout(string opType)
        {

            this.TypeDataGrid.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;

            foreach (DataGridViewRow row in TypeDataGrid.Rows)
            {
                if (row.Index != this.UpdateTypeRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.TypesNextBtn.Enabled = false;
            this.TypesBackBtn.Enabled = false;
            this.TypesFirstPage.Enabled = false;
            this.TypesLastPage.Enabled = false;

            if (opType == "u")
            {
                this.TypeDataGrid.AllowUserToAddRows = false;
            }

        }
        private void CategoryBeginEditLayout(string action)
        {
            CategoryDataGridView.Columns["delete_column"].Visible = false;
            SearchBar.Enabled = false;

            foreach (DataGridViewRow row in CategoryDataGridView.Rows)
            {
                if (row.Index != UpdateCategoryRow)
                {
                    row.ReadOnly = true;
                }
            }

            CategoriesNextBtn.Enabled = false;
            CategoriesBackBtn.Enabled = false;
            CategoriesFirstPage.Enabled = false;
            CategoriesLastPage.Enabled = false;

            if (action == "update")
            {
                CategoryDataGridView.AllowUserToAddRows = false;
            }
        }
        private void SpeakerEndEditLayout(string str1popup, string str2popup)
        {
            this.SpeakerPaginationSelector.Enabled = true;
            this.SpeakerListDataGrid.SelectionMode = (DataGridViewSelectionMode) 1; //FullRowSelect
            this.SpeakerUserMessagesBox.Visible = false;
            this.SpeakerSaveButton.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.SpeakerListDataGrid.Columns["main_speaker"].ReadOnly = false;
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

        }

        private void TypeEndEditLayout(string str1popup, string str2popup)
        {

            this.button3.Visible = false;
            this.textBox3.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.TypeDataGrid.Columns["TypeId"].Visible = false;
            this.TypeDataGrid.Columns["delete_column"].Visible = true;
            this.SearchBar.Enabled = true;

            foreach (DataGridViewRow row in TypeDataGrid.Rows)
            {
                if (row.Index != this.UpdateTypeRow)
                {
                    row.ReadOnly = false;
                }
            }
            this.TypesNextBtn.Enabled = true;
            this.TypesBackBtn.Enabled = true;
            this.TypesFirstPage.Enabled = true;
            this.TypesLastPage.Enabled = true;
            if (this.TypeDataGrid.AllowUserToAddRows == false)
            {
                this.TypeDataGrid.AllowUserToAddRows = true;
            }
            foreach (DataGridViewCell cell in TypeDataGrid.Rows[this.UpdateTypeRow].Cells)
            {
                cell.Style.BackColor = Color.White;
            }

        }

        private void CategoryEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            CategoryEditSaveBtn.Visible = false;
            CategoryEditTextField.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CategoryDataGridView.Columns["ConferenceCategoryId"].Visible = false;
            CategoryDataGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CategoryDataGridView.Rows)
            {
                if (row.Index != UpdateCategoryRow)
                {
                    row.ReadOnly = true;
                }
            }

            CategoriesNextBtn.Enabled = true;
            CategoriesBackBtn.Enabled = true;
            CategoriesFirstPage.Enabled = true;
            CategoriesLastPage.Enabled = true;
            if (CategoryDataGridView.AllowUserToAddRows == false)
            {
                CategoryDataGridView.AllowUserToAddRows = true;
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

        private void CountryListDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCountriesRow = e.RowIndex;
            if (CountryEditTextBox.Visible == false)
            {
                if (UpdateCountriesRow >= PageSize || CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && UpdateCountriesRow == CountriesLastPageLastRow || CountriesTotalPages == 0 && CountriesLastPageLastRow == 0)
                {
                    CountryAddInsertMessage();
                    CountriesBeginEditLayout("Insert");
                }
                else
                {
                    string CountryName = CountryListDataGridView.Rows[UpdateCountriesRow].Cells["CountryName"].Value.ToString();
                    CountryAddUpdateMessage(CountryName);
                    CountriesBeginEditLayout("Update");
                }
            }
            else if (UpdateCountriesRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }

        }

        private void CountiesListGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCountyRow = e.RowIndex;
            if (CountyEditTextBox.Visible == false)
            {
                if (UpdateCountyRow >= PageSize || CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && UpdateCountyRow == CountiesLastPageLastRow || CountiesTotalPages == 0 && CountiesLastPageLastRow == 0)
                {
                    CountyAddInsertMessage();
                    CountiBeginEditLayout("Insert");
                }
                else
                {
                    string CountyName = CountiesListGridView.Rows[UpdateCountyRow].Cells["CountyName"].Value.ToString();
                    CountyAddUpdateMessage(CountyName);
                    CountiBeginEditLayout("Update");
                }
            }
            else if (UpdateCountyRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }

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
                    (this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow))
                {
                    this.SpeakerAddInsertMessage();
                    this.SpeakerBeginEditLayout("i");
                }
                else
                {
                    string fName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
                    string lName = this.SpeakerListDataGrid.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
                    this.SpeakerAddUpdateMessage(fName, lName);
                    this.SpeakerBeginEditLayout("u");
                }
            }
            else if (this.UpdateSpeakerRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }


        }



        private void TypeDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateTypeRow = e.RowIndex;


            if (textBox3.Visible == false)
            {
                if (this.UpdateTypeRow >= this.PageSize ||
                    (this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && this.UpdateTypeRow == this.TypesLastPageLastRow))
                {
                    this.AddInsertMessageType();
                    this.TypeBeginEditLayout("i");
                }
                else
                {
                    int TypeId = int.Parse(this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["TypeId"].Value.ToString());
                    //string Id = this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["DictionaryConferenceTypeId"].Value.ToString();
                    string Name = this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["TypeName"].Value.ToString();
                    this.AddUpdateMessageType(Name);
                    this.TypeBeginEditLayout("u");
                }
            }
            else if (this.UpdateTypeRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }


        }


        private void CategoryDataGridVIew_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCategoryRow = e.RowIndex;
            if (!CategoryEditTextField.Visible)
            {
                if (UpdateCategoryRow >= PageSize || (CategoriesLastPageLastRow == 0 && CategoriesCurrentPage == CategoriesToatlPages && UpdateTypeRow == CategoriesLastPageLastRow))
                {
                    CategoryAddInsertMessage();
                    CategoryBeginEditLayout("insert");
                }
                else
                {
                    int CategoryId = int.Parse(CategoryDataGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryId"].Value.ToString());
                    string CategoryName = CategoryDataGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryName"].Value.ToString();
                    CategoryAddUpdatedMessage(CategoryName);
                    CategoryBeginEditLayout("update");

                }
            }
            else if (UpdateCategoryRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }



        }

        private CountryModel GetCountry()
        {
            CountryModel Country = new CountryModel();
            Country.DictionaryCountryId = Countries.Count + 1;
            Country.CountryName = CountryListDataGridView.Rows[UpdateCountriesRow].Cells["CountryName"].Value.ToString();
            // Country.CountryId = SelectedCountryId;


            return Country;
        }

        private CountyModel GetCounty()
        {
            CountyModel County = new CountyModel();
            County.CountyId = (int)CountiesListGridView.Rows[UpdateCountyRow].Cells["CountyId"].Value;
            County.CountyName = CountiesListGridView.Rows[UpdateCountyRow].Cells["CountyName"].Value.ToString();
            County.CountryId = SelectedCountryId;


            return County;
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

        private TypeModel GetType()
        {
            TypeModel type = new TypeModel();

            type.TypeId = int.Parse(this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["TypeId"].Value.ToString());
            type.TypeName = this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["TypeName"].Value.ToString();


            return type;
        }


        private CategoryModel GetCategory()
        {
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.ConferenceCategoryId = int.Parse(CategoryDataGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryId"].Value.ToString());
            categoryModel.ConferenceCategoryName = CategoryDataGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryName"].Value.ToString();
            return categoryModel;

        }


        private void SpeakerSaveButton_Click(object sender, EventArgs e)
        {
            this.SpeakerListDataGrid.EndEdit();
            if ((this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow) || (this.UpdateSpeakerRow == this.PageSize))
            {
                SpeakerModel newSpeaker = GetSpeaker();

                //_speakerRepository.InsertSpeaker(newSpeaker);
                var t = Task.Run(() => InsertSpeaker(newSpeaker));
                t.Wait();
                this.Speakers.Add(newSpeaker);
                this.SpeakersForSearchBar = this.Speakers;
                int[] aux = this.CalculateTotalPages(this.Speakers.Count);
                this.SpeakersTotalPages = aux[0];
                this.SpeakersLastPageLastRow = aux[1];
                //this.SpeakersCurrentPage = 1;
                //this.SpeakerCreatePage(this.SpeakersForSearchBar);
                SpeakerEndEditLayout("Done", "You can see the speaker you just added on the last page.");
                //this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;
            }
            else
            {
                SpeakerModel newSpeaker = GetSpeaker();
                //_speakerRepository.UpdateSpeaker(newSpeaker);
                var t = Task.Run(() => UpdateSpeaker(newSpeaker));
                t.Wait();
                SpeakerEndEditLayout("Done", "Speaker modified succesfully");
                this.SpeakerListDataGrid.CurrentCell = null;
                this.SpeakerListDataGrid.Rows[0].Selected = false;
                this.UpdateSpeakerArray(newSpeaker);

            }
            this.SpeakerListDataGrid.CurrentCell = null;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.TypeDataGrid.EndEdit();
            if ((this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && this.UpdateTypeRow == this.TypesLastPageLastRow) || (this.UpdateTypeRow == this.PageSize))
            {
                TypeModel newType = GetType();
                newType.TypeId = this.Types.Count + 1;
                //_typeRepository.InsertType(newType);
                var t = Task.Run(() => InsertType(newType));
                t.Wait();

                this.Types.Add(newType);
                this.TypesForSearchBar = this.Types;
                int[] aux = this.CalculateTotalPages(this.Types.Count);
                this.TypesTotalPages = aux[0];
                this.TypesLastPageLastRow = aux[1];
                this.TypesCurrentPage = 1;
                this.TypeCreatePage(this.Types);

                this.TypeDataGrid.CurrentCell = null;
                this.TypeDataGrid.Rows[0].Selected = false;
                this.button3.Visible = false;
                this.TypesNextBtn.Enabled = true;
                this.TypesBackBtn.Enabled = true;
                this.TypesFirstPage.Enabled = true;
                this.TypesLastPage.Enabled = true;
                this.textBox3.Visible = false;
            }
            else
            {
                TypeModel type = this.GetType();

                //_typeRepository.UpdateType(Type);
                var t = Task.Run(() => UpdateType(type));
                t.Wait();
                TypeEndEditLayout("Done", "Type modified succesfully");
                //this.TypeDataGrid.CurrentCell = null;
                this.TypeDataGrid.Rows[0].Selected = false;
                this.UpdateTypeArray(type);

            }
            //this.TypeDataGrid.CurrentCell = null;
        }

        private void UpdateTypeArray(TypeModel type)
        {
            foreach (TypeModel ts in this.Types)
            {
                if (ts.TypeId == type.TypeId)
                {
                    this.Types[this.Types.IndexOf(ts)].TypeId = type.TypeId;
                    this.Types[this.Types.IndexOf(ts)].TypeName = type.TypeName;

                }
            }
        }


        private void CategoryEditSaveBtn_Click(object sender, EventArgs e)
        {
            CategoryDataGridView.EndEdit();
            if ((CategoriesLastPageLastRow > 0 && CategoriesCurrentPage == CategoriesToatlPages && UpdateCategoryRow == CategoriesLastPageLastRow) || UpdateCategoryRow == PageSize)
            {
                CategoryModel Category = GetCategory();
                Category.ConferenceCategoryId = Categories.Count + 1;

                var t = Task.Run(() => InsertCategory(Category));
                t.Wait();
                //_categoryRepository.InsertCategory(Category);
                Categories.Add(Category);
                int[] Temp = CalculateTotalPages(Categories.Count);
                CategoriesToatlPages = Temp[0];
                CategoriesLastPageLastRow = Temp[1];
                CategoryEndEditLayout("Done", "You can see the category you just added on the last page.");

            }
            else
            {
                CategoryModel Category = GetCategory();
                var t = Task.Run(() => UpdateCategory(Category));
                t.Wait();
                //_categoryRepository.UpdateCategory(Category);
                CategoryEndEditLayout("Done", "Category modified succesfully");
                CategoryDataGridView.Rows[0].Selected = false;
                UpdateCategoryArray(Category);
            }
        }

        private void UpdateCategoryArray(CategoryModel category)
        {
            foreach (CategoryModel cat in Categories)
            {
                if (cat.ConferenceCategoryId == category.ConferenceCategoryId)
                {
                    Categories[Categories.IndexOf(cat)].ConferenceCategoryId = category.ConferenceCategoryId;
                    Categories[Categories.IndexOf(cat)].ConferenceCategoryName = category.ConferenceCategoryName;
                }
            }
        }


        private void CountySaveEditBtn_Click(object sender, EventArgs e)
        {
            CountiesListGridView.EndEdit();
            if ((CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && UpdateCountyRow == CountiesLastPageLastRow) || UpdateCountyRow == PageSize)
            {
                CountyModel NewCounty = GetCounty();
                NewCounty.CountyId = _countyRepository.GetLastCountyId();
                _countyRepository.InsertCounty(NewCounty);
                Counties.Add(NewCounty);
                int[] Temp = CalculateTotalPages(Counties.Count);
                CountiesTotalPages = Temp[0];
                CountiesLastPageLastRow = Temp[1];
                CountiesEndEditLayout("Done", "You can see the couty you just added on the last page.");
            }
            else
            {
                CountyModel County = GetCounty();
                _countyRepository.UpdateCounty(County);
                CountiesEndEditLayout("Done", "County modified succesfully");
                CountiesListGridView.CurrentCell = null;
                CountiesListGridView.Rows[0].Selected = false;
                UpdateCountiesArray(County);
            }
        }

        private void CountrySaveEditBtn_Click(object sender, EventArgs e)
        {
            CountryListDataGridView.EndEdit();
            if ((CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && UpdateCountriesRow == CountriesLastPageLastRow) || UpdateCountriesRow == PageSize)
            {
                CountryModel NewCountry = GetCountry();
                // _countryRepository.InsertCountry(NewCountry);
                var t = Task.Run(() => InsertCountry(NewCountry));
                t.Wait();
                Countries.Add(NewCountry);
                int[] Temp = CalculateTotalPages(Countries.Count);
                CountriesTotalPages = Temp[0];
                CountriesLastPageLastRow = Temp[1];
                CountriesEndEditLayout("Done", "You can see the coutry you just added on the last page.");
            }
            else
            {
                CountryModel Country = GetCountry();
                //_countryRepository.UpdateCountry(Country);
                var t = Task.Run(() => UpdateCountry(Country));
                CountriesEndEditLayout("Done", "Country modified succesfully");
                CountryListDataGridView.CurrentCell = null;
                CountryListDataGridView.Rows[0].Selected = false;
                UpdateCountriesArray(Country);
            }
        }


        private void UpdateCountriesArray(CountryModel Country)
        {
            foreach (CountryModel C in Countries)
            {
                if (C.DictionaryCountryId == Country.DictionaryCountryId)
                {
                    Countries[Countries.IndexOf(C)].CountryName = Country.CountryName;
                }
            }
        }
        private void UpdateCountiesArray(CountyModel County)
        {
            foreach (CountyModel C in Counties)
            {
                if (C.CountyId == County.CountyId)
                {
                    Counties[Counties.IndexOf(C)].CountyName = County.CountyName;
                }
            }
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

        private void CountryListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CountryListDataGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && e.RowIndex == CountriesLastPageLastRow))
                {
                    return;
                }
                int DictionaryCountryId = (int)CountryListDataGridView.Rows[e.RowIndex].Cells["DictionaryCountryId"].Value;
                if (_countryRepository.DeleteCountry(DictionaryCountryId).Equals("error"))
                {
                    popUpMethod("Unsuccessfully", "You can't delete a country that has cities assign to it");
                }
                var DeleteForm = new AreYouSure(_countryRepository, DictionaryCountryId);
                Task t = Task.Run(() => { DeleteForm.ShowDialog(); });
                t.Wait();
                LoadCountryTab();
            }
        }


        private void CountiesListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CountiesListGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && e.RowIndex == CountiesLastPageLastRow))
                {
                    return;
                }
                int CountyId = (int)CountiesListGridView.Rows[e.RowIndex].Cells["CountyId"].Value;
                if (_countyRepository.DeleteCounty(CountyId).Equals("error"))
                {
                    popUpMethod("Unsuccessfully", "You can't delete a county that has cities assign to it");
                }
                var DeleteForm = new AreYouSure(_countyRepository, CountyId);
                Task t = Task.Run(() => { DeleteForm.ShowDialog(); });
                t.Wait();
                LoadCountyTab();
            }
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
            if (this.SpeakerListDataGrid.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == this.PageSize) || (this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && e.RowIndex == this.SpeakersLastPageLastRow))
                {
                    return;
                }

                int id = (int)this.SpeakerListDataGrid.Rows[e.RowIndex].Cells["SpeakerId"].Value;

                var newDeleteForm = new AreYouSure(_speakerRepository, id);

                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadSpeakersTab();

            }

        }

        private void TypeDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (this.TypeDataGrid.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == this.PageSize) || (this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && e.RowIndex == this.TypesLastPageLastRow))
                {
                    return;
                }
                int id = (int)this.TypeDataGrid.Rows[e.RowIndex].Cells["TypeId"].Value;
                var newDeleteForm = new AreYouSure(_typeRepository, id);

                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadTypesTab();

            }

        }

        private void CategoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CategoryDataGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CategoriesLastPageLastRow > 0 && CategoriesCurrentPage == CategoriesToatlPages && e.RowIndex == CategoriesLastPageLastRow))
                {
                    return;
                }

                int CategoryId = (int)CategoryDataGridView.Rows[e.RowIndex].Cells["ConferenceCategoryId"].Value;
                var DeleteForm = new AreYouSure(_categoryRepository, CategoryId);
                Task t = Task.Run(() => { DeleteForm.ShowDialog(); });
                t.Wait();
                LoadCategoryTab();
            }
        }

        private void CountryListDataGridView_Layout(object sender, LayoutEventArgs e)
        {
            CountryListDataGridView.CurrentCell = null;
            CountryListDataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }


        private void CountiesListGridView_Layout(object sender, LayoutEventArgs e)
        {
            CountiesListGridView.CurrentCell = null;
            CountiesListGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }

        private void CountriesNextBtn_Click(object sender, EventArgs e)
        {
            CountriesCurrentPage++;
            if (CountriesFromSearchBar.Count > 0)
            {
                CountriesCreatePage(CountriesFromSearchBar);
            }
            else
            {
                CountriesCreatePage(Countries);
            }
            CountryListDataGridView.Rows[0].Selected = false;
        }

        private void CountiesNextBtn_Click(object sender, EventArgs e)
        {
            CountiesCurrentPage++;
            if (CountiesFromSearchBar.Count > 0)
            {
                CountiesCreatePage(CountiesFromSearchBar);
            }
            else
            {
                CountiesCreatePage(Counties);
            }
            CountiesListGridView.Rows[0].Selected = false;
        }



        private void CountiesLastPage_Click(object sender, EventArgs e)
        {
            CountiesCurrentPage = CountiesTotalPages;
            if (CountiesFromSearchBar.Count > 0)
            {
                CountiesCreatePage(CountiesFromSearchBar);
            }
            else
            {
                CountiesCreatePage(Counties);
            }
            CountiesListGridView.Rows[0].Selected = false;
        }

        private void CountriesLastPage_Click(object sender, EventArgs e)
        {
            CountriesCurrentPage = CountriesTotalPages;
            if (CountriesFromSearchBar.Count > 0)
            {
                CountriesCreatePage(CountriesFromSearchBar);
            }
            else
            {
                CountriesCreatePage(Countries);
            }
            CountryListDataGridView.Rows[0].Selected = false;
        }


        private void CountiesBackBtn_Click(object sender, EventArgs e)
        {
            CountiesCurrentPage--;
            if (CountiesFromSearchBar.Count > 0)
            {
                CountiesCreatePage(CountiesFromSearchBar);
            }
            else
            {
                CountiesCreatePage(Counties);
            }
            CountiesListGridView.Rows[0].Selected = false;
        }

        private void CountriesBackBtn_Click(object sender, EventArgs e)
        {
            CountriesCurrentPage--;
            if (CountriesFromSearchBar.Count > 0)
            {
                CountriesCreatePage(CountriesFromSearchBar);
            }
            else
            {
                CountriesCreatePage(Countries);
            }
            CountryListDataGridView.Rows[0].Selected = false;
        }

        private void CountriesFirstPage_Click(object sender, EventArgs e)
        {
            CountriesCurrentPage = 1;
            if (CountriesFromSearchBar.Count > 0)
            {
                CountriesCreatePage(CountriesFromSearchBar);
            }
            else
            {
                CountriesCreatePage(Countries);
            }
            CountryListDataGridView.Rows[0].Selected = false;
        }

        private void CountiesFirstPage_Click(object sender, EventArgs e)
        {
            CountiesCurrentPage = 1;
            if (CountiesFromSearchBar.Count > 0)
            {
                CountiesCreatePage(CountiesFromSearchBar);
            }
            else
            {
                CountiesCreatePage(Counties);
            }
            CountiesListGridView.Rows[0].Selected = false;
        }

        private void SpeakerListDataGrid_Layout(object sender, LayoutEventArgs e)
        {

            this.SpeakerListDataGrid.CurrentCell = null;

            this.SpeakerListDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }


        private void TypeDataGrid_Layout(object sender, LayoutEventArgs e)
        {
            this.TypeDataGrid.CurrentCell = null;

            this.TypeDataGrid.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }


        private void CategoryDataGridView_Layout(object sender, LayoutEventArgs e)
        {
            CategoryDataGridView.CurrentCell = null;
            CategoryDataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
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

        private void TypesNextBtn_Click(object sender, EventArgs e)
        {
            this.TypesCurrentPage++;
            if (this.TypesForSearchBar.Count > 0)
            {
                this.TypeCreatePage(this.TypesForSearchBar);

            }
            else
            {
                this.TypeCreatePage(this.Types);
            }
            this.TypeDataGrid.Rows[0].Selected = false;
        }


        private void CategoriesNextBtn_Click(object sender, EventArgs e)
        {
            CategoriesCurrentPage++;
            if (CategoriesFromSearch.Count > 0)
            {
                CategoryCreatePage(CategoriesFromSearch);
            }
            else
            {
                CategoryCreatePage(Categories);
            }
            CategoryDataGridView.Rows[0].Selected = false;
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

        private void CategoriesLastPage_Click(object sender, EventArgs e)
        {
            CategoriesCurrentPage = CategoriesToatlPages;
            if (CategoriesFromSearch.Count > 0)
            {
                CategoryCreatePage(CategoriesFromSearch);
            }
            else
            {
                CategoryCreatePage(Categories);
            }

            CategoryDataGridView.Rows[0].Selected = false;
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



        private void TypesBackBtn_Click(object sender, EventArgs e)
        {
            this.TypesCurrentPage--;
            if (this.TypesForSearchBar.Count > 0)
            {
                this.TypeCreatePage(this.TypesForSearchBar);

            }
            else
            {
                this.TypeCreatePage(this.Types);
            }
            this.TypeDataGrid.Rows[0].Selected = false;
        }


        private void CategoriesBackBtn_Click(object sender, EventArgs e)
        {
            CategoriesCurrentPage--;
            if (CategoriesFromSearch.Count > 0)
            {
                CategoryCreatePage(CategoriesFromSearch);
            }
            else
            {
                CategoryCreatePage(Categories);
            }
            CategoryDataGridView.Rows[0].Selected = false;
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

        private void TypesFirstPage_Click(object sender, EventArgs e)
        {
            this.TypesCurrentPage = 1;
            if (this.TypesForSearchBar.Count > 0)
            {
                this.TypeCreatePage(this.TypesForSearchBar);

            }
            else
            {
                this.TypeCreatePage(this.Types);
            }
            this.TypeDataGrid.Rows[0].Selected = false;
        }


        private void CategoriesFirstPage_Click(object sender, EventArgs e)
        {
            CategoriesCurrentPage = 1;
            if (CategoriesFromSearch.Count > 0)
            {
                CategoryCreatePage(CategoriesFromSearch);
            }
            else
            {
                CategoryCreatePage(Categories);
            }
            CategoryDataGridView.Rows[0].Selected = false;

        }



        private void SpeakerListDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.SpeakerListDataGrid.Columns["Rating"].Index)
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

        private void TypeDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //return;
            this.TypeDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;

        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if (TabControlLocation.SelectedTab.Name == "Country")
            {
                CountriesCurrentPage = 1;
                BindingList<CountryModel> countries = new BindingList<CountryModel>();
                foreach (CountryModel country in Countries)
                {
                    if (country.CountryName.ToLower().Contains(SearchBar.Text.ToLower()))
                    {
                        countries.Add(country);
                    }
                }
                int[] temp = CalculateTotalPages(countries.Count);
                CountriesTotalPages = temp[0];
                CountriesLastPageLastRow = temp[1];
                CountriesFromSearchBar = countries;
                CountriesCreatePage(CountriesFromSearchBar);
            }
            else if (TabControlLocation.SelectedTab.Name == "County")
            {
                CountiesCurrentPage = 1;
                BindingList<CountyModel> counties = new BindingList<CountyModel>();
                foreach (CountyModel county in Counties)
                {
                    if (county.CountyName.ToLower().Contains(SearchBar.Text.ToLower()))
                    {
                        counties.Add(county);
                    }
                }
                int[] temp = CalculateTotalPages(counties.Count);
                CountiesTotalPages = temp[0];
                CountiesLastPageLastRow = temp[1];
                CountiesFromSearchBar = counties;
                CountiesCreatePage(CountiesFromSearchBar);
            }
            else if (this.TabControlLocation.SelectedTab.Name == "City")
            {
                CityCurrentPage = 1;
                BindingList<CityModel> cities = new BindingList<CityModel>();
                foreach (CityModel cityModel in Cities)
                {
                    if (cityModel.CityName.ToLower().Contains(SearchBar.Text.ToLower()))
                    {
                        cities.Add(cityModel);
                    }
                }
                int[] tmp = CalculateTotalPages(cities.Count);
                CityTotalPages = tmp[0];
                CityLastPageLastRow = tmp[1];
                CitiesFromSearchBar = cities;
                CitiesCreatePage(CitiesFromSearchBar);
            }
            else if (this.TabControlLocation.SelectedTab.Name == "SpeakerTab")
            {
                //this.ActiveControl = null;
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
            else if (this.TabControlLocation.SelectedTab.Name == "TypeTab")
            {
                this.TypesCurrentPage = 1;
                BindingList<TypeModel> result = new BindingList<TypeModel>();
                foreach (TypeModel type in this.Types)
                {
                    if (type.TypeName.ToLower().Contains(this.SearchBar.Text.ToLower()))
                    {
                        result.Add(type);
                    }
                }
                int[] aux = this.CalculateTotalPages(result.Count);
                this.TypesTotalPages = aux[0];
                this.TypesLastPageLastRow = aux[1];
                this.TypesForSearchBar = result;
                this.TypeCreatePage(this.TypesForSearchBar);

            }
            else if (TabControlLocation.SelectedTab.Name == "CategoryTab")
            {
                CategoriesCurrentPage = 1;
                BindingList<CategoryModel> categoryModels = new BindingList<CategoryModel>();
                foreach (CategoryModel category in Categories)
                {
                    if (category.ConferenceCategoryName.ToLower().Contains(SearchBar.Text.ToLower()))
                    {
                        categoryModels.Add(category);
                    }
                }

                int[] temp = CalculateTotalPages(categoryModels.Count);
                CategoriesToatlPages = temp[0];
                CategoriesLastPageLastRow = temp[1];
                CategoriesFromSearch = categoryModels;
                CategoryCreatePage(CategoriesFromSearch);
            }

        }

        private void SearchBar_Enter(object sender, EventArgs e)
        {
            this.SearchBar.Text = "";
        }


        private void SpeakerPaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            int idx = this.SpeakerPaginationSelector.SelectedIndex;
            if (idx >= 0)
            {
                this.PageSize = int.Parse(this.SpeakerPaginationSelector.Items[idx].ToString());
                //if ()
                int[] aux = this.CalculateTotalPages(this.SpeakersForSearchBar.Count);
                this.SpeakersCurrentPage = 1;
                this.SpeakersTotalPages = aux[0];
                this.SpeakersLastPageLastRow = aux[1];

                this.SpeakerCreatePage(this.SpeakersForSearchBar);
            }

        }



        private void CountyPaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            int index = CountyPaginationSelector.SelectedIndex;
            if (index >= 0)
            {
                PageSize = int.Parse(CountyPaginationSelector.Items[index].ToString());

                int[] temp = CalculateTotalPages(CountiesFromSearchBar.Count);
                CountiesCurrentPage = 1;
                CountiesTotalPages = temp[0];
                CountiesLastPageLastRow = temp[1];

                CountiesCreatePage(CountiesFromSearchBar);
            }
        }

        private void CountryPaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            int index = CountriesPaginationSelector.SelectedIndex;
            if (index >= 0)
            {
                PageSize = int.Parse(CountriesPaginationSelector.Items[index].ToString());

                int[] temp = CalculateTotalPages(CountriesFromSearchBar.Count);
                CountriesCurrentPage = 1;
                CountriesTotalPages = temp[0];
                CountriesLastPageLastRow = temp[1];

                CountriesCreatePage(CountriesFromSearchBar);
            }
        }


        private void CategoryPaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            int index = CategoryPaginationSelector.SelectedIndex;
            if (index >= 0)
            {
                PageSize = int.Parse(CategoryPaginationSelector.Items[index].ToString());

                int[] temp = CalculateTotalPages(CountiesFromSearchBar.Count);
                CategoriesCurrentPage = 1;
                CategoriesToatlPages = temp[0];
                CategoriesLastPageLastRow = temp[1];

                CategoryCreatePage(CategoriesFromSearch);
            }
        }

        private async Task GetAllSpeakers()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Speaker/all_speakers");

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<BindingList<SpeakerModel>>(json);
                this.Speakers = t;
            }
            else
            {
                this.Speakers = new BindingList<SpeakerModel>();
            }
        }
        private async Task<SpeakerModel> GetSpeakerById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Speaker/speaker_by_id/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<SpeakerModel>(json);
                return t;

            }
            return new SpeakerModel();
        }


        private async Task InsertSpeaker(SpeakerModel speakerModel)
        {
            var json = JsonConvert.SerializeObject(speakerModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Speaker/insert_speaker/", httpContent);
            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You added the speaker succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }


        private async Task UpdateSpeaker(SpeakerModel speakerModel)
        {
            var json = JsonConvert.SerializeObject(speakerModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Speaker/update_speaker/id=" + speakerModel.SpeakerId, httpContent);


            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You updated the speaker succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }
        private async Task GetTypes()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Type/GetTypes/");

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<BindingList<TypeModel>>(json);
                this.Types = t;
            }
            else
            {
                this.Types = new BindingList<TypeModel>();
            }
        }
        private async Task<TypeModel> GetTypeById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Type/GetTypeById/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<TypeModel>(json);
                return t;

            }
            return new TypeModel();
        }
        private async Task InsertType(TypeModel typeModel)
        {
            var json = JsonConvert.SerializeObject(typeModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Type/InsertType/", httpContent);
            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You added the speaker succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }
        private async Task UpdateType(TypeModel typeModel)
        {
            var json = JsonConvert.SerializeObject(typeModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Type/UpdateType/id=" + typeModel.TypeId, httpContent);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You updated the speaker succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }




        private async Task InsertCountry(CountryModel countryModel)
        {
            var json = JsonConvert.SerializeObject(countryModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Country/insert_country/", httpContent);
            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You added the country succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }
        }



        private async Task UpdateCountry(CountryModel countryModel)
        {
            var json = JsonConvert.SerializeObject(countryModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.PostAsync("http://localhost:2794/api/Country/update_country/id=" + countryModel.DictionaryCountryId, httpContent);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You updated the country succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }






        private async Task GetConferenceCategories()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Category/get_categories/");
            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<BindingList<CategoryModel>>(json);
                Categories = t;

            }

        }

        private async Task InsertCategory(CategoryModel categoryModel)
        {
            var json = JsonConvert.SerializeObject(categoryModel);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient Client = new HttpClient();
            HttpResponseMessage message = await Client.PostAsync("http://localhost:2794/api/Category/insert_category", httpContent);

            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your category has been added");
            }
            else
            {
                popUpMethod("Error", "Insert failed");
            }
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            var json = JsonConvert.SerializeObject(category);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.PostAsync("http://localhost:2794/api/Category/update_category" + category.ConferenceCategoryId, httpContent);
            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your category has been updated");
            }
            else
            {
                popUpMethod("Error", "Update failed");
            }
        }

        public async Task GetCountyList(int CountryId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("http://localhost:2794/api/County/county_by_countryId?countryID=" + CountryId);
            if (message.IsSuccessStatusCode)
            {
                string json = await message.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<BindingList<CountyModel>>(json);
                Counties = t;
            }
        }

        public async Task<int> GetLastCountyId()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync("http://localhost:2794/api/County/county_last_id");
            if (message.IsSuccessStatusCode)
            {
                string json = await message.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<int>(json);
                return t;
            }
            return 1;
        }

        public async Task InsertCounty(CountyModel county)
        {
            var json = JsonConvert.SerializeObject(county);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.PostAsync("http://localhost:2794/api/County/insert_county", httpContent);
            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your county has been added");
            }
            else
            {
                popUpMethod("Error", "Insert failed");
            }
        }

        public async Task UpdateCounty(CountyModel county)
        {
            var json = JsonConvert.SerializeObject(county);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.PostAsync("http://localhost:2794/api/County/update_county", httpContent);
            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your county has been updated");
            }
            else
            {
                popUpMethod("Error", "Update failed");
            }
        }
        private async Task InsertConference(ConferenceModelWithEmail newConference)
        {
            var json = JsonConvert.SerializeObject(newConference);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient Client = new HttpClient();
            HttpResponseMessage message = await Client.PostAsync("http://localhost:2794/api/Conference/add_conference", httpContent);

            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your conference has been added");
            }
            else
            {
                popUpMethod("Error", "Insert failed");
            }       
        }
        private async Task UpdateConference(ConferenceModelWithEmail newConference)
        {
            var json = JsonConvert.SerializeObject(newConference);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpClient Client = new HttpClient();
            HttpResponseMessage message = await Client.PostAsync("http://localhost:2794/api/Conference/update_conference", httpContent);

            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "Your conference has been modified");
            }
            else
            {
                popUpMethod("Error", "Update failed");
            }
        }
        private void SpeakerListDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.SpeakerListDataGrid.BeginEdit(true);
        }

        private void CountryListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CountryListDataGridView.BeginEdit(true);
        }

        private void CountiesListGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CountiesListGridView.BeginEdit(true);
        }

        private void CityListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CityListDataGridView.BeginEdit(true);
        }

        private void TypeDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TypeDataGrid.BeginEdit(true);
        }

        private void CategoryDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CategoryDataGridView.BeginEdit(true);
        }

        private void StartHour_ValueChanged(object sender, EventArgs e)
        {
            if (this.EndHour.Value <= this.StartHour.Value)
            {
                this.EndHour.Value = this.StartHour.Value;
            }
        }

        private void StardDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if(this.EndDatePicker.Value <= this.StardDatePicker.Value)
            {
                this.EndDatePicker.Value = this.StardDatePicker.Value;
            }
        }
    }
}
