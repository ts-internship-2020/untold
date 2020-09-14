using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ConferencePlanner.WinUi
{
    public partial class Form1 : Form
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICategoryRepository _categoryRepository;

        private int PageSize = 4;

        private int IndexGridChange = 1;

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


        string ConferenceName;
        string StartDate;
        string StartHour;
        string EndDate;
        string EndHour;
        string Country;
        string County;
        string City;
        string Type;
        string Speaker;
        string Category;
        private bool isEditingConference = false;

        public Form1(IConferenceRepository conferenceRepository, ICountryRepository countryRepository, ICountyRepository countyRepository, ISpeakerRepository speakerRepository, ITypeRepository typeRepository, ICityRepository cityRepository, ICategoryRepository categoryRepository)
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
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(ConferenceModel conference, IConferenceRepository conferenceRepository, ICountryRepository countryRepository, ICountyRepository countyRepository, ISpeakerRepository speakerRepository, ITypeRepository typeRepository, ICityRepository cityRepository, ICategoryRepository categoryRepository)
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
            ConfName.Text = conference.ConferenceName;

            string[] dates = conference.Period.Split(" - ");
            this.StartDatePicker.Value = DateTime.Parse(dates[0]);
            this.EndDatePicker.Value = DateTime.Parse(dates[1]);
        }
        private void ChechGridVisibility()
        {
            CountryGridView.Visible = false;
            CountryBar.Visible = false;
            CountyGridView.Visible = false;
            CountyBar.Visible = false;
            CityGridView.Visible = false;
            CityBar.Visible = false;
            TypeGridView.Visible = false;
            TypeBar.Visible = false;
            SpeakerGridView.Visible = false;
            SpeakerBar.Visible = false;
            CategoryGridView.Visible = false;
            CategoryBar.Visible = false;
            SavePanel.Visible = false;

            if (IndexGridChange == 1)
            {
                CountryGridView.Visible = true;
                CountryBar.Visible = true;
                LoadCountryTab();
                CheckIndexChangeBtns();
            }
            else if (IndexGridChange == 2)
            {
                CountyGridView.Visible = true;
                CountyBar.Visible = true;
                LoadCountyTab();
                CheckIndexChangeBtns();
            }
            else if (IndexGridChange == 3)
            {
                CityGridView.Visible = true;
                CityBar.Visible = true;
                LoadCityTab();
                CheckIndexChangeBtns();
            }
            else if(IndexGridChange == 4)
            {
                TypeGridView.Visible = true;
                TypeBar.Visible = true;
                LoadTypesTab();
                CheckIndexChangeBtns();
            }
            else if(IndexGridChange == 5)
            {
                SpeakerGridView.Visible = true;
                SpeakerBar.Visible = true;
                LoadSpeakersTab();
                CheckIndexChangeBtns();


            }
            else if(IndexGridChange == 6)
            {
                CategoryGridView.Visible = true;
                CategoryBar.Visible = true;
                LoadCategoryTab();
                CheckIndexChangeBtns();


            }
            else if(IndexGridChange == 7)
            {
                PageControlTableLayout.Visible = false;
                SearchTableLayout.Visible = false;
                SavePanel.Visible = true;
                SaveBar.Visible = true;
                LoadSaveTab();
                CheckIndexChangeBtns();

            }
        }
        private void BackGridBtn_Click(object sender, EventArgs e)
        {
            IndexGridChange--;
            ChechGridVisibility();
        }

        public bool CheckError()
        {
            if (ConfName.Text == "")
            {
                ConfNameError.SetError(ConfName, "Insert a name!");
                return false;
            }
            else
                return true;
        }
        public void PageNumber(int currentPage, int totalPages)
        {
            PagesTextBox.Text = currentPage + " in " + totalPages;
        }
        public void CheckIndexChangeBtns()
        {
            if(IndexGridChange == 1)
            {
                BackGridBtn.Enabled = false;
            }else
            {
                BackGridBtn.Enabled = true;
            }
            if(IndexGridChange == 7)
            {
                NextGridBtn.Text = "Save";
                SaveNewBtn.Visible = true;
            }else
            {
                NextGridBtn.Text = "Next";
            }
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

        private void LoadCountryTab()
        {
            this.Countries = _countryRepository.GetCountriesList();
            CountriesFromSearchBar = Countries;
            int[] pages = CalculateTotalPages(Countries.Count);
            CountryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CountryGridView.AllowUserToOrderColumns = true;
            CountryGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountriesTotalPages = pages[0];
            CountriesLastPageLastRow = pages[1];

            CountriesCreatePage(Countries);
        }


        private void LoadCountyTab()
        {
            this.Counties = _countyRepository.GetCountyList(this.SelectedCountryId);
            CountiesFromSearchBar = Counties;
            int[] pages = CalculateTotalPages(Counties.Count);
            CountyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CountyGridView.AllowUserToOrderColumns = true;
            CountyGridView.DefaultCellStyle.ForeColor = Color.Black;
            CountiesTotalPages = pages[0];
            CountiesLastPageLastRow = pages[1];

            CountiesCreatePage(Counties);

        }


        private void LoadCityTab()
        {
            CityGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var t = Task.Run(() => GetCityAsync(SelectedCountyId));
            t.Wait();
            //_cityRepository.GetCitiesByCountyId(SelectedCountyId);
            int[] pages = CalculateTotalPages(Cities.Count);
            CityGridView.AllowUserToOrderColumns = true;
            CityGridView.DefaultCellStyle.ForeColor = Color.Black;
            CityGridView.DataSource = this.Cities;
            CityTotalPages = pages[0];
            CityLastPageLastRow = pages[1];
            CitiesCreatePage(Cities);
        }

        private void LoadSpeakersTab()
        {
            SpeakerGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var t = Task.Run(() => GetAllSpeakers());
            t.Wait();

            this.SpeakersForSearchBar = this.Speakers;

            int[] aux = this.CalculateTotalPages(this.Speakers.Count);
            this.SpeakersTotalPages = aux[0];
            this.SpeakersLastPageLastRow = aux[1];

            this.SpeakerCreatePage(this.Speakers);
        }

        private void LoadTypesTab()
        {
            TypeGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var t = Task.Run(() => GetTypes());
            t.Wait();

            this.TypesForSearchBar = this.Types;
            int[] aux = this.CalculateTotalPages(this.Types.Count);
            this.TypesTotalPages = aux[0];
            this.TypesLastPageLastRow = aux[1];

            this.TypeCreatePage(this.Types);
        }

        private void LoadCategoryTab()
        {
            PageControlTableLayout.Visible = false;
            SearchTableLayout.Visible = false;

            var t = Task.Run(() => GetConferenceCategories());
            t.Wait();


            CategoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Categories = _categoryRepository.GetConferenceCategories();
            CategoriesFromSearch = Categories;
            int[] temp = CalculateTotalPages(Categories.Count);
            CategoriesToatlPages = temp[0];
            CategoriesLastPageLastRow = temp[1];

            CategoryCreatePage(Categories);
        }

        private void LoadSaveTab()
        {
            
           
            ConfNameSaveLabel.Text = "Conference name: " +  ConferenceName;
            SratdDateSaveLabel.Text = "Start date: " + StartDate + " " + StartHour;
            EndDateSaveLabel.Text = "End date: " + EndDate + " " + EndHour;
            LocationSaveLabel.Text = "Location: " + City + " , " + County + " , " + Country;
            TypeSaveLabel.Text = "Type: " + Type;
            SpeakerSaveLabel.Text = "Speaker: " + Speaker;
            CategorySaveLabel.Text = "Category: " + Category;
        }
        private bool IndexChange(string TabName, DataGridView CurrentDataGrid)
        {
            string PopUpTitle = "Warning", PopUpMessage;

            int selectedSpeakersCount = 0;
            if (CurrentDataGrid == this.SpeakerGridView)
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
            if ((CurrentDataGrid != this.SpeakerGridView && CurrentDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1) ||
                (CurrentDataGrid == this.SpeakerGridView && selectedSpeakersCount < 1))
            {
                PopUpMessage = "Select a " + TabName;
                popUpMethod(PopUpTitle, PopUpMessage);
                return false;
            }
            else if ((CurrentDataGrid != this.SpeakerGridView && CurrentDataGrid.Rows.GetRowCount(DataGridViewElementStates.Selected) > 1) ||
              (CurrentDataGrid == this.SpeakerGridView && selectedSpeakersCount > 1))
            {
                PopUpMessage = "Select just a " + TabName;
                popUpMethod(PopUpTitle, PopUpMessage);
                return false;
            }
            return true;
        }
        private void CheckPaginationButtonsVisibility(int currentPage, int totalPages)
        {
            if (currentPage == totalPages)
            {
                NextPageBtn.Enabled = false;
                LastPageBtn.Enabled = false;
            }
            if (currentPage == 1)
            {
                BackPageBtn.Enabled = false;
                FirstPageBtn.Enabled = false;
            }
            if (currentPage < totalPages)
            {
                NextPageBtn.Enabled = true;
                LastPageBtn.Enabled = true;
            }
            if (currentPage > 1)
            {
                BackPageBtn.Enabled = true;
                FirstPageBtn.Enabled = true;
            }
        }
        private void CountriesCreatePage(BindingList<CountryModel> list)
        {
            CheckPaginationButtonsVisibility(CountriesCurrentPage, CountriesTotalPages);
            PageNumber(CountriesCurrentPage, CountriesTotalPages);
            BindingList<CountryModel> CountriesList = new BindingList<CountryModel>();
            int PreviousPageOffSet = (CountriesCurrentPage - 1) * PageSize;
            int min = Math.Min(PreviousPageOffSet + PageSize, list.Count);
            for (int i = PreviousPageOffSet; i < min; i++)
            {
                CountriesList.Add(list[i]);
            }
            this.CountryGridView.DataSource = CountriesList;
        }

        private void CountiesCreatePage(BindingList<CountyModel> list)
        {
            CheckPaginationButtonsVisibility(CountiesCurrentPage, CountiesTotalPages);
            PageNumber(CountiesCurrentPage, CountiesTotalPages);
            BindingList<CountyModel> CountiesList = new BindingList<CountyModel>();
            int PreviousPageOffSet = (CountiesCurrentPage - 1) * PageSize;
            int min = Math.Min(PreviousPageOffSet + PageSize, list.Count);
            for (int i = PreviousPageOffSet; i < min; i++)
            {
                CountiesList.Add(list[i]);
            }
            this.CountyGridView.DataSource = CountiesList;
        }
        private void CitiesCreatePage(BindingList<CityModel> cityModels)
        {
            this.CheckPaginationButtonsVisibility(this.CityCurrentPage, this.CityTotalPages);
            PageNumber(CityCurrentPage, CityTotalPages);
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
            this.CityGridView.DataSource = cities;
        }
            private void SpeakerCreatePage(BindingList<SpeakerModel> lst)
        {
            this.CheckPaginationButtonsVisibility(this.SpeakersCurrentPage, this.SpeakersTotalPages);
            PageNumber(SpeakersCurrentPage, SpeakersTotalPages);
            BindingList<SpeakerModel> result = new BindingList<SpeakerModel>();
            //BindingList<SpeakerModel> result2 = new BindingList<SpeakerModel>();

            int PreviousPageOffSet = (this.SpeakersCurrentPage - 1) * this.PageSize;

            int aux = Math.Min(PreviousPageOffSet + this.PageSize, lst.Count);


            for (int i = PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.SpeakerGridView.DataSource = result;


        }

        private void TypeCreatePage(BindingList<TypeModel> lst)
        {
            this.CheckPaginationButtonsVisibility(this.TypesCurrentPage, this.TypesTotalPages);
            PageNumber(TypesCurrentPage, TypesTotalPages);
            BindingList<TypeModel> result = new BindingList<TypeModel>();
            //BindingList<SpeakerModel> result2 = new BindingList<SpeakerModel>();

            int PreviousPageOffSet = (this.TypesCurrentPage - 1) * this.PageSize;

            int aux = Math.Min(PreviousPageOffSet + this.PageSize, lst.Count);


            for (int i = PreviousPageOffSet; i < aux; i++)
            {
                result.Add(lst[i]);
            }

            this.TypeGridView.DataSource = result;
        }


        private void CategoryCreatePage(BindingList<CategoryModel> list)
        {
            CheckPaginationButtonsVisibility(CategoriesCurrentPage, CategoriesToatlPages);
            PageNumber(CategoriesCurrentPage, CategoriesToatlPages);
            BindingList<CategoryModel> categoryModels = new BindingList<CategoryModel>();

            int PreviosPageOffSet = (CategoriesCurrentPage - 1) * PageSize;
            int temp = Math.Min(PreviosPageOffSet + PageSize, list.Count);

            for (int i = PreviosPageOffSet; i < temp; i++)
            {
                categoryModels.Add(list[i]);

            }

            CategoryGridView.DataSource = categoryModels;



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





        private void popUpMethod(String titleText, String contentText)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.info;
            popup.TitleText = titleText;
            popup.ContentText = contentText;
            popup.Popup();
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

        private void CategoryGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CategoryGridView.Columns.Contains("ConferenceCategoryId") && CategoryGridView.Columns["ConferenceCategoryId"].Visible)
            {
                CategoryGridView.Columns["ConferenceCategoryId"].Visible = false;
            }

            CategoryGridView.Columns["ConferenceCategoryName"].HeaderText = "Conference Category";
            if (CategoryGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 55;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CategoryGridView.Columns.Add(deleteButtonColumn);
            }

            CategoryGridView.Rows[0].Selected = false;
        }

        private void SpeakerGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (SpeakerGridView.Columns.Contains("ImagePath"))
            {
                this.SpeakerGridView.Columns.Remove("ImagePath");
            }
            if (SpeakerGridView.Columns.Contains("SpeakerId") && SpeakerGridView.Columns["SpeakerId"].Visible)
            {
                SpeakerGridView.Columns["SpeakerId"].Visible = false;
            }
            if (SpeakerGridView.Columns.Contains("main_speaker") == false)
            {
                DataGridViewCheckBoxColumn MainSpeaker = new DataGridViewCheckBoxColumn();
                MainSpeaker.ValueType = typeof(bool);
                MainSpeaker.Name = "main_speaker";
                MainSpeaker.HeaderText = "Main Speaker";
                SpeakerGridView.Columns.Add(MainSpeaker);
            }
            if (SpeakerGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                SpeakerGridView.Columns.Add(deleteButtonColumn);

            }

            this.SpeakerGridView.Columns["FirstName"].HeaderText = "First Name";
            this.SpeakerGridView.Columns["LastName"].HeaderText = "Last Name";

            //this.SpeakerListDataGrid.CurrentCell = null;
            this.SpeakerGridView.Rows[0].Selected = false;

            this.SpeakerGridView.Controls[1].Enabled = true;
        }

        private void TypeGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (TypeGridView.Columns.Contains("TypeId") && TypeGridView.Columns["TypeId"].Visible)
            {
                TypeGridView.Columns["TypeId"].Visible = false;
            }

            this.TypeGridView.Columns["TypeName"].HeaderText = "Conference Type";
            if (TypeGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 55;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                TypeGridView.Columns.Add(deleteButtonColumn);

            }
            this.TypeGridView.Rows[0].Selected = false;
        }

        private void CityGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CityGridView.Columns.Contains("DictionaryCityId") && CityGridView.Columns["DictionaryCityId"].Visible)
            {
                CityGridView.Columns["DictionaryCityId"].Visible = false;
            }

            CityGridView.Columns["CityName"].HeaderText = "City Name";

            if (CityGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 5;
                deleteButtonColumn.DividerWidth = 10;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";
                CityGridView.Columns.Add(deleteButtonColumn);
            }
        }

        private void CountyGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CountyGridView.Columns.Contains("CountyId") && CountyGridView.Columns["CountyId"].Visible)
            {
                CountyGridView.Columns["CountyId"].Visible = false;
            }
            if (CountyGridView.Columns.Contains("CountryId") && CountyGridView.Columns["CountryId"].Visible)
            {
                CountyGridView.Columns["CountryId"].Visible = false;
            }
            if (CountyGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CountyGridView.Columns.Add(deleteButtonColumn);

            }
            CountyGridView.Columns["CountyName"].HeaderText = "County Name";
            CountyGridView.Rows[0].Selected = false;
        }

        private void CountryGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CountryGridView.Columns.Contains("DictionaryCountryId") && CountryGridView.Columns["DictionaryCountryId"].Visible)
            {
                CountryGridView.Columns["DictionaryCountryId"].Visible = false;
            }

            if (CountryGridView.Columns.Contains("delete_column") == false)
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                deleteButtonColumn.Text = "Delete";
                deleteButtonColumn.Width = 25;
                deleteButtonColumn.HeaderText = "";
                deleteButtonColumn.Name = "delete_column";

                CountryGridView.Columns.Add(deleteButtonColumn);

            }
            CountryGridView.Columns["CountryName"].HeaderText = "Country Name";
            CountryGridView.Rows[0].Selected = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCountryTab();
            CheckIndexChangeBtns();
        }

        private void NextGridBtn_Click(object sender, EventArgs e)
        {
            int SelectedRowIndex = 0;
            if (NextGridBtn.Text == "Next")
            {
                
                if(IndexGridChange == 1)
                {
                    if (CheckError())
                    {
                        if (IndexChange("Country", CountryGridView))
                        {
                            SelectedCountryId = (int)CountryGridView.SelectedRows[0].Cells["DictionaryCountryId"].Value;
                            object value = CountryGridView.SelectedRows[0].Cells["CountryName"].Value;
                            Country = (string)value;
                            IndexGridChange++;
                            ChechGridVisibility();
                        }
                    }
                }
                if (IndexGridChange == 2)
                {
                    if (IndexChange("County", CountyGridView))
                    {
                        SelectedCountyId = (int)CountyGridView.SelectedRows[0].Cells["CountyId"].Value;
                        County = (string)CountyGridView.SelectedRows[0].Cells["CountyName"].Value;
                        IndexGridChange++;
                        ChechGridVisibility();
                    }
                }
                if (IndexGridChange == 3)
                {
                    if (IndexChange("City", CityGridView))
                    {
                        SelectedCityId = (int)CityGridView.SelectedRows[0].Cells["DictionaryCityId"].Value;
                        City = (string)CityGridView.SelectedRows[0].Cells["CityName"].Value;
                        IndexGridChange++;
                        ChechGridVisibility();
                    }
                }
                if (IndexGridChange == 4)
                {
                    if (IndexChange("Type", TypeGridView))
                    {
                        SelectedTypeId = (int)TypeGridView.SelectedRows[0].Cells["TypeId"].Value;
                        Type = (string)TypeGridView.SelectedRows[0].Cells["TypeName"].Value;
                        IndexGridChange++;
                        ChechGridVisibility();
                    }
                }

                if (IndexGridChange == 5)
                {
                    if (IndexChange("Speaker", SpeakerGridView))
                    {
                        int col_idx = SpeakerGridView.Columns["main_speaker"].Index;
                        foreach (DataGridViewRow row in SpeakerGridView.Rows)
                        {

                            if (Convert.ToBoolean(row.Cells[col_idx].Value) == true)
                            {
                                SelectedRowIndex = row.Index;
                            }
                        }

                        SelectedSpeakerId = (int)SpeakerGridView.Rows[SelectedRowIndex].Cells["SpeakerId"].Value;
                        Speaker = (string)SpeakerGridView.Rows[SelectedRowIndex].Cells["FirstName"].Value + " " + (string)SpeakerGridView.Rows[SelectedRowIndex].Cells["LastName"].Value;
                        IndexGridChange++;
                        ChechGridVisibility();
                    }
                }
                if(IndexGridChange == 6)
                {
                    if(IndexChange("Category", CategoryGridView))
                    {
                        SelectedTypeId = (int)CategoryGridView.SelectedRows[0].Cells["ConferenceCategoryId"].Value;
                        Category = (string)CategoryGridView.SelectedRows[0].Cells["ConferenceCategoryName"].Value;
                        IndexGridChange++;
                        ChechGridVisibility();
                    }
                }
            }
            else
            {
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

        private void FirstPageBtn_Click(object sender, EventArgs e)
        {
            if (IndexGridChange == 1)
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
                CountryGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 2) 
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
                CountyGridView.Rows[0].Selected = false;
            }
            if(IndexGridChange == 3)
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
                this.CityGridView.Rows[0].Selected = false;
            }
            if(IndexGridChange == 4)
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
                this.TypeGridView.Rows[0].Selected = false;
            }
            if(IndexGridChange == 5)
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
                this.SpeakerGridView.Rows[0].Selected = false;
            }
            if(IndexGridChange == 6)
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
                CategoryGridView.Rows[0].Selected = false;
            }
        }

        private void BackPageBtn_Click(object sender, EventArgs e)
        {
            if (IndexGridChange == 1)
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
                CountryGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 2)
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
                CountyGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 3)
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
                this.CityGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 4)
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
                this.TypeGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 5)
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
                this.SpeakerGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 6)
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
                CategoryGridView.Rows[0].Selected = false;
            }
        }

        private void NextPageBtn_Click(object sender, EventArgs e)
        {
            if (IndexGridChange == 1)
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
                CountryGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 2)
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
                CountyGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 3)
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
                this.CityGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 4)
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
                this.TypeGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 5)
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
                this.SpeakerGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 6)
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
                CategoryGridView.Rows[0].Selected = false;
            }
        }

        private void LastPageBtn_Click(object sender, EventArgs e)
        {
            if (IndexGridChange == 1)
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
                CountryGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 2)
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
                CountyGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 3)
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
                this.CityGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 4)
            {
                TypesCurrentPage = TypesTotalPages;
                if (CategoriesFromSearch.Count > 0)
                {
                    TypeCreatePage(TypesForSearchBar);
                }
                else
                {
                    TypeCreatePage(Types);
                }

                TypeGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 5)
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
                this.SpeakerGridView.Rows[0].Selected = false;
            }
            if (IndexGridChange == 6)
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

                CategoryGridView.Rows[0].Selected = false;
            }
        }

        private void CountryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CountryGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && e.RowIndex == CountriesLastPageLastRow))
                {
                    return;
                }
                int DictionaryCountryId = (int)CountryGridView.Rows[e.RowIndex].Cells["DictionaryCountryId"].Value;
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

        private void CountryGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CountryAddInsertMessage()
        {
            EditTextBox.Text = "You are now adding a new country. Press the button to Save. ";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }
        private void CountriesBeginEditLayout(string Action)
        {
            CountryGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;
            foreach (DataGridViewRow row in CountryGridView.Rows)
            {
                if (row.Index != UpdateCountriesRow)
                {
                    row.ReadOnly = true;
                }
            }
            NextPageBtn.Enabled = false;
            LastPageBtn.Enabled = false;
            FirstPageBtn.Enabled = false;
            BackPageBtn.Enabled = false;

            if (Action == "Update")
            {
                CountryGridView.AllowUserToAddRows = false;
            }
        }
        private void CountryAddUpdateMessage(string CountryName)
        {
            EditTextBox.Text = "You are now editing the " + CountryName + " country. Press the button to Save.";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }
        private void CountryGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCountriesRow = e.RowIndex;
            if (EditTextBox.Visible == false)
            {
                if (UpdateCountriesRow >= PageSize || CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && UpdateCountriesRow == CountriesLastPageLastRow || CountriesTotalPages == 0 && CountriesLastPageLastRow == 0)
                {
                    CountryAddInsertMessage();
                    CountriesBeginEditLayout("Insert");
                }
                else
                {
                    string CountryName = CountryGridView.Rows[UpdateCountriesRow].Cells["CountryName"].Value.ToString();
                    CountryAddUpdateMessage(CountryName);
                    CountriesBeginEditLayout("Update");
                }
            }
            else if (UpdateCountriesRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void CountryGridView_Layout(object sender, LayoutEventArgs e)
        {
            CountryGridView.CurrentCell = null;
            CountryGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }

        private void CategoryAddInsertMessage()
        {
            EditTextBox.Text = "You are now adding a new conference category.  Press the button to Save.";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }
        private void CategoryBeginEditLayout(string action)
        {
            CategoryGridView.Columns["delete_column"].Visible = false;
            SearchBar.Enabled = false;

            foreach (DataGridViewRow row in CategoryGridView.Rows)
            {
                if (row.Index != UpdateCategoryRow)
                {
                    row.ReadOnly = true;
                }
            }

            NextPageBtn.Enabled = false;
            BackPageBtn.Enabled = false;
            FirstPageBtn.Enabled = false;
            LastPageBtn.Enabled = false;

            if (action == "update")
            {
                CategoryGridView.AllowUserToAddRows = false;
            }
        }
        private void CategoryAddUpdatedMessage(string name)
        {
            EditTextBox.Text = "You are now editing conference category " + name + ". Press the Button to Save.";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }
        private void CategoryGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCategoryRow = e.RowIndex;
            if (!EditTextBox.Visible)
            {
                if (UpdateCategoryRow >= PageSize || (CategoriesLastPageLastRow == 0 && CategoriesCurrentPage == CategoriesToatlPages && UpdateTypeRow == CategoriesLastPageLastRow))
                {
                    CategoryAddInsertMessage();
                    CategoryBeginEditLayout("insert");
                }
                else
                {
                    int CategoryId = int.Parse(CategoryGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryId"].Value.ToString());
                    string CategoryName = CategoryGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryName"].Value.ToString();
                    CategoryAddUpdatedMessage(CategoryName);
                    CategoryBeginEditLayout("update");

                }
            }
            else if (UpdateCategoryRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void CategoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CategoryGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CategoriesLastPageLastRow > 0 && CategoriesCurrentPage == CategoriesToatlPages && e.RowIndex == CategoriesLastPageLastRow))
                {
                    return;
                }

                int CategoryId = (int)CategoryGridView.Rows[e.RowIndex].Cells["ConferenceCategoryId"].Value;
                var DeleteForm = new AreYouSure(_categoryRepository, CategoryId);
                Task t = Task.Run(() => { DeleteForm.ShowDialog(); });
                t.Wait();
                LoadCategoryTab();
            }
        }

        private void CategoryGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoryGridView_Layout(object sender, LayoutEventArgs e)
        {
            CategoryGridView.CurrentCell = null;
            CategoryGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }
        private void SpeakerAddInsertMessage()
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            this.EditTextBox.Text = "You are now adding a new speaker. Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }
        private void SpeakerBeginEditLayout(string opType)
        {
            PaginationSelector.Enabled = false;
            SpeakerGridView.SelectionMode = (DataGridViewSelectionMode)0;
            this.SpeakerGridView.Columns["main_speaker"].ReadOnly = true;
            this.SpeakerGridView.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.LightGray;
            this.SpeakerGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;

            foreach (DataGridViewRow row in SpeakerGridView.Rows)
            {
                if (row.Index != this.UpdateSpeakerRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.NextPageBtn.Enabled = false;
            this.BackPageBtn.Enabled = false;
            this.FirstPageBtn.Enabled = false;
            this.LastPageBtn.Enabled = false;

            if (opType == "u")
            {
                this.SpeakerGridView.AllowUserToAddRows = false;
            }

        }

        private void SpeakerAddUpdateMessage(string fName, string lName)
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            string sName = fName + " " + lName;
            this.EditTextBox.Text = "You are now editing speaker " + sName + "'s informations. Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }
        private void SpeakerGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateSpeakerRow = e.RowIndex;

            if (e.ColumnIndex == this.SpeakerGridView.Columns["main_speaker"].Index)
            {
                return;
            }
            if (EditTextBox.Visible == false)
            {
                if (this.UpdateSpeakerRow >= this.PageSize ||
                    (this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow))
                {
                    this.SpeakerAddInsertMessage();
                    this.SpeakerBeginEditLayout("i");
                }
                else
                {
                    string fName = this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
                    string lName = this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
                    this.SpeakerAddUpdateMessage(fName, lName);
                    this.SpeakerBeginEditLayout("u");
                }
            }
            else if (this.UpdateSpeakerRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void SpeakerGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SpeakerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.SpeakerGridView.Columns["main_speaker"].Index && this.EditTextBox.Visible == true)
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
            if (this.SpeakerGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == this.PageSize) || (this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && e.RowIndex == this.SpeakersLastPageLastRow))
                {
                    return;
                }

                int id = (int)this.SpeakerGridView.Rows[e.RowIndex].Cells["SpeakerId"].Value;

                var newDeleteForm = new AreYouSure(_speakerRepository, id);

                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadSpeakersTab();

            }
        }

        private void SpeakerGridView_Layout(object sender, LayoutEventArgs e)
        {
            CategoryGridView.CurrentCell = null;
            CategoryGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }

        private void AddInsertMessageType()
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            this.EditTextBox.Text = "You are now adding a new conference type. Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }

        private void TypeBeginEditLayout(string opType)
        {
            PaginationSelector.Enabled = false;
            this.TypeGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;

            foreach (DataGridViewRow row in TypeGridView.Rows)
            {
                if (row.Index != this.UpdateTypeRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.NextPageBtn.Enabled = false;
            this.BackPageBtn.Enabled = false;
            this.FirstPageBtn.Enabled = false;
            this.LastPageBtn.Enabled = false;

            if (opType == "u")
            {
                this.TypeGridView.AllowUserToAddRows = false;
            }

        }
        private void AddUpdateMessageType(string name)
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            string confname = name;
            //int idtype = id;
            this.EditTextBox.Text = "You are now editing conference type " + confname + " Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }

        private void TypeGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateTypeRow = e.RowIndex;


            if (EditTextBox.Visible == false)
            {
                if (this.UpdateTypeRow >= this.PageSize ||
                    (this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && this.UpdateTypeRow == this.TypesLastPageLastRow))
                {
                    this.AddInsertMessageType();
                    this.TypeBeginEditLayout("i");
                }
                else
                {
                    int TypeId = int.Parse(this.TypeGridView.Rows[this.UpdateTypeRow].Cells["TypeId"].Value.ToString());
                    //string Id = this.TypeDataGrid.Rows[this.UpdateTypeRow].Cells["DictionaryConferenceTypeId"].Value.ToString();
                    string Name = this.TypeGridView.Rows[this.UpdateTypeRow].Cells["TypeName"].Value.ToString();
                    this.AddUpdateMessageType(Name);
                    this.TypeBeginEditLayout("u");
                }
            }
            else if (this.UpdateTypeRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void TypeGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (this.TypeGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == this.PageSize) || (this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && e.RowIndex == this.TypesLastPageLastRow))
                {
                    return;
                }
                int id = (int)this.TypeGridView.Rows[e.RowIndex].Cells["TypeId"].Value;
                var newDeleteForm = new AreYouSure(_typeRepository, id);

                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadTypesTab();

            }
        }

        private void TypeGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.TypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
        }

        private void TypeGridView_Layout(object sender, LayoutEventArgs e)
        {
            this.TypeGridView.CurrentCell = null;

            this.TypeGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }
        private void AddInsertMessageCity()
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            this.EditTextBox.Text = "You are now adding a new city. Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }
        private void CitiesBeginEditLayout(string opType)
        {
            PaginationSelector.Enabled = false;
            this.CityGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;

            foreach (DataGridViewRow row in CityGridView.Rows)
            {
                if (row.Index != this.UpdateCityRow)
                {
                    row.ReadOnly = true;
                }
            }
            this.NextPageBtn.Enabled = false;
            this.BackPageBtn.Enabled = false;
            this.FirstPageBtn.Enabled = false;
            this.LastPageBtn.Enabled = false;

            if (opType == "update")
            {
                this.CityGridView.AllowUserToAddRows = false;
            }

        }
        private void AddUpdateMessageCity(string cityName)
        {
            this.EditTextBox.ForeColor = Color.MediumSeaGreen;
            this.EditTextBox.Text = "You are now editing city " + cityName + "'s informations. Press the button to Save.";
            this.EditTextBox.Visible = true;
            this.SaveEditBtn.Visible = true;
        }
        //private void CountryGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    UpdateCountriesRow = e.RowIndex;
        //    if (EditTextBox.Visible == false)
        //    {
        //        if (UpdateCountriesRow >= PageSize || CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && UpdateCountriesRow == CountriesLastPageLastRow || CountriesTotalPages == 0 && CountriesLastPageLastRow == 0)
        //        {
        //            CountryAddInsertMessage();
        //            CountriesBeginEditLayout("Insert");
        //        }
        //        else
        //        {
        //            string CountryName = CountryGridView.Rows[UpdateCountriesRow].Cells["CountryName"].Value.ToString();
        //            CountryAddUpdateMessage(CountryName);
        //            CountriesBeginEditLayout("Update");
        //        }
        //    }
        //    else if (UpdateCountriesRow != e.RowIndex)
        //    {
        //        this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
        //    }
        //}


        private void CityGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.UpdateCityRow = e.RowIndex;

            if (EditTextBox.Visible == false)
            {
                if ((this.UpdateCityRow >= this.PageSize) ||
                    (this.CityLastPageLastRow > 0 && this.CityCurrentPage == this.CityTotalPages && this.UpdateCityRow == this.CityLastPageLastRow) ||
                    (this.CityLastPageLastRow == 0 && this.CityTotalPages == 0 && this.CityCurrentPage == 1))
                {
                    this.AddInsertMessageCity();
                    this.CitiesBeginEditLayout("insert");
                }
                else
                {
                    string city = this.CityGridView.Rows[this.UpdateCityRow].Cells["CityName"].Value.ToString();
                    this.AddUpdateMessageCity(city);
                    this.CitiesBeginEditLayout("update");
                }
            }
            else if (this.UpdateCityRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void CityGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (this.CityGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                int id = (int)this.CityGridView.Rows[e.RowIndex].Cells["DictionaryCityId"].Value;
                var newDeleteForm = new AreYouSure(_cityRepository, id);
                Task t = Task.Run(() => { newDeleteForm.ShowDialog(); });
                t.Wait();
                this.LoadCityTab();
            }
        }

        private void CityGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CityGridView_Layout(object sender, LayoutEventArgs e)
        {
            CityGridView.CurrentCell = null;
            CityGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }

        private void CountyAddInsertMessage()
        {
            EditTextBox.Text = "You are now adding a new county. Press the button to Save. ";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }

        private void CountyAddUpdateMessage(string CountyName)
        {
            EditTextBox.Text = "You are now editing the " + CountyName + " county. Press the button to Save.";
            EditTextBox.Visible = true;
            SaveEditBtn.Visible = true;
        }

        private void CountyBeginEditLayout(string Action)
        {
            PaginationSelector.Enabled = false;
            CountyGridView.Columns["delete_column"].Visible = false;
            this.SearchBar.Enabled = false;
            foreach (DataGridViewRow row in CountyGridView.Rows)
            {
                if (row.Index != UpdateCountyRow)
                {
                    row.ReadOnly = true;
                }
            }
            NextPageBtn.Enabled = false;
            LastPageBtn.Enabled = false;
            FirstPageBtn.Enabled = false;
            BackPageBtn.Enabled = false;

            if (Action == "Update")
            {
                CountyGridView.AllowUserToAddRows = false;
            }
        }

        private void CountiesEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            PaginationSelector.Enabled = true;
            EditTextBox.Visible = false;
            SaveEditBtn.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CountyGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CountyGridView.Rows)
            {
                if (row.Index != UpdateCountyRow)
                {
                    row.ReadOnly = false;
                }
            }

            NextPageBtn.Enabled = true;
            LastPageBtn.Enabled = true;
            FirstPageBtn.Enabled = true;
            BackPageBtn.Enabled = true;

            if (!CountyGridView.AllowUserToAddRows)
            {
                CountyGridView.AllowUserToAddRows = true;
            }
        }
        private void CountyGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateCountyRow = e.RowIndex;
            if (EditTextBox.Visible == false)
            {
                if (UpdateCountyRow >= PageSize || CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && UpdateCountyRow == CountiesLastPageLastRow || CountiesTotalPages == 0 && CountiesLastPageLastRow == 0)
                {
                    CountyAddInsertMessage();
                    CountyBeginEditLayout("Insert");
                }
                else
                {
                    string CountyName = CountyGridView.Rows[UpdateCountyRow].Cells["CountyName"].Value.ToString();
                    CountyAddUpdateMessage(CountyName);
                    CountyBeginEditLayout("Update");
                }
            }
            else if (UpdateCountyRow != e.RowIndex)
            {
                this.popUpMethod("Warning!", "Changes made would not be saved unless you click on the Save button");
            }
        }

        private void CountyGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex < 0)
            {
                return;
            }
            if (CountyGridView.Columns[e.ColumnIndex].Name == "delete_column")
            {
                if ((e.RowIndex == PageSize) || (CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && e.RowIndex == CountiesLastPageLastRow))
                {
                    return;
                }
                int CountyId = (int)CountyGridView.Rows[e.RowIndex].Cells["CountyId"].Value;
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

        private void CountyGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CountyGridView_Layout(object sender, LayoutEventArgs e)
        {
            CountyGridView.CurrentCell = null;
            CountyGridView.DefaultCellStyle.ForeColor = Color.FromArgb(53, 56, 49);
        }

        private CountryModel GetCountry()
        {
            CountryModel Country = new CountryModel();
            Country.DictionaryCountryId = Countries.Count + 1;
            Country.CountryName = CountryGridView.Rows[UpdateCountriesRow].Cells["CountryName"].Value.ToString();
            // Country.CountryId = SelectedCountryId;


            return Country;
        }
        private void CountriesEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            PaginationSelector.Enabled = true;
            EditTextBox.Visible = false;
            SaveEditBtn.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CountryGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CountryGridView.Rows)
            {
                if (row.Index != UpdateCountriesRow)
                {
                    row.ReadOnly = false;
                }
            }

            NextPageBtn.Enabled = true;
            LastPageBtn.Enabled = true;
            FirstPageBtn.Enabled = true;
            BackPageBtn.Enabled = true;

            if (!CountryGridView.AllowUserToAddRows)
            {
                CountryGridView.AllowUserToAddRows = true;
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
        private CountyModel GetCounty()
        {
            CountyModel County = new CountyModel();
            County.CountyId = (int)CountyGridView.Rows[UpdateCountyRow].Cells["CountyId"].Value;
            County.CountyName = CountyGridView.Rows[UpdateCountyRow].Cells["CountyName"].Value.ToString();
            County.CountryId = SelectedCountryId;


            return County;
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
            speaker.FirstName = this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["FirstName"].Value.ToString();
            speaker.LastName = this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["LastName"].Value.ToString();
            speaker.Nationality = this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["Nationality"].Value.ToString();

            speaker.SpeakerId = (int)this.SpeakerGridView.Rows[this.UpdateSpeakerRow].Cells["SpeakerId"].Value;

            return speaker;
        }
        private void SpeakerEndEditLayout(string str1popup, string str2popup)
        {
            PaginationSelector.Enabled = true;
            SpeakerGridView.SelectionMode = (DataGridViewSelectionMode)1;
            this.EditTextBox.Visible = false;
            this.SaveEditBtn.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.SpeakerGridView.Columns["main_speaker"].ReadOnly = false;
            this.SpeakerGridView.Columns["main_speaker"].DefaultCellStyle.BackColor = Color.White;

            this.SpeakerGridView.Columns["delete_column"].Visible = true;
            this.SearchBar.Enabled = true;

            foreach (DataGridViewRow row in SpeakerGridView.Rows)
            {
                if (row.Index != this.UpdateSpeakerRow)
                {
                    row.ReadOnly = false;
                }
            }
            this.NextPageBtn.Enabled = true;
            this.BackPageBtn.Enabled = true;
            this.FirstPageBtn.Enabled = true;
            this.LastPageBtn.Enabled = true;
            if (this.SpeakerGridView.AllowUserToAddRows == false)
            {
                this.SpeakerGridView.AllowUserToAddRows = true;
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
        private TypeModel GetType()
        {
            TypeModel type = new TypeModel();

            type.TypeId = int.Parse(this.TypeGridView.Rows[this.UpdateTypeRow].Cells["TypeId"].Value.ToString());
            type.TypeName = this.TypeGridView.Rows[this.UpdateTypeRow].Cells["TypeName"].Value.ToString();


            return type;
        }
        private void TypeEndEditLayout(string str1popup, string str2popup)
        {
            PaginationSelector.Enabled = true;
            this.SaveEditBtn.Visible = false;
            this.EditTextBox.Visible = false;
            this.popUpMethod(str1popup, str2popup);
            this.TypeGridView.Columns["TypeId"].Visible = false;
            this.TypeGridView.Columns["delete_column"].Visible = true;
            this.SearchBar.Enabled = true;

            foreach (DataGridViewRow row in TypeGridView.Rows)
            {
                if (row.Index != this.UpdateTypeRow)
                {
                    row.ReadOnly = false;
                }
            }
            this.NextPageBtn.Enabled = true;
            this.BackPageBtn.Enabled = true;
            this.FirstPageBtn.Enabled = true;
            this.LastPageBtn.Enabled = true;
            if (this.TypeGridView.AllowUserToAddRows == false)
            {
                this.TypeGridView.AllowUserToAddRows = true;
            }
            foreach (DataGridViewCell cell in TypeGridView.Rows[this.UpdateTypeRow].Cells)
            {
                cell.Style.BackColor = Color.White;
            }

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
        private CityModel GetCity()
        {
            CityModel cityModel = new CityModel();
            cityModel.DictionaryCityId = (int)this.CityGridView.Rows[this.UpdateCityRow].Cells["DictionaryCityId"].Value;
            cityModel.CityName = this.CityGridView.Rows[this.UpdateCityRow].Cells["CityName"].Value.ToString();
            cityModel.CountyId = SelectedCountyId;
            return cityModel;
        }
        private void CityEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            PaginationSelector.Enabled = true;
            EditTextBox.Visible = false;
            SaveEditBtn.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CityGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CityGridView.Rows)
            {
                if (row.Index != UpdateCityRow)
                {
                    row.ReadOnly = false;
                }
            }

            this.NextPageBtn.Enabled = true;
            this.BackPageBtn.Enabled = true;
            this.FirstPageBtn.Enabled = true;
            this.LastPageBtn.Enabled = true;

            if (!CityGridView.AllowUserToAddRows)
            {
                CityGridView.AllowUserToAddRows = true;
            }
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
        private CategoryModel GetCategory()
        {
            CategoryModel categoryModel = new CategoryModel();
            categoryModel.ConferenceCategoryId = int.Parse(CategoryGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryId"].Value.ToString());
            categoryModel.ConferenceCategoryName = CategoryGridView.Rows[UpdateCategoryRow].Cells["ConferenceCategoryName"].Value.ToString();
            return categoryModel;

        }

        private void CategoryEndEditLayout(string PopUpTitle, string PopUpMessage)
        {
            PaginationSelector.Enabled = true;
            SaveEditBtn.Visible = false;
            EditTextBox.Visible = false;
            popUpMethod(PopUpTitle, PopUpMessage);
            CategoryGridView.Columns["ConferenceCategoryId"].Visible = false;
            CategoryGridView.Columns["delete_column"].Visible = true;
            SearchBar.Enabled = true;
            foreach (DataGridViewRow row in CategoryGridView.Rows)
            {
                if (row.Index != UpdateCategoryRow)
                {
                    row.ReadOnly = true;
                }
            }

            NextPageBtn.Enabled = true;
            BackPageBtn.Enabled = true;
            FirstPageBtn.Enabled = true;
            LastPageBtn.Enabled = true;
            if (CategoryGridView.AllowUserToAddRows == false)
            {
                CategoryGridView.AllowUserToAddRows = true;
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

        //(this.UpdateCityRow >= this.PageSize) ||
        //            (this.CityLastPageLastRow > 0 && this.CityCurrentPage == this.CityTotalPages && this.UpdateCityRow == this.CityLastPageLastRow) ||
        //            (this.CityLastPageLastRow == 0 && this.CityTotalPages == 0 && this.CityCurrentPage == 1))
        private void SaveEditBtn_Click(object sender, EventArgs e)
        {
            if(IndexGridChange == 1)
            {
                CountryGridView.EndEdit();
                if ((CountriesLastPageLastRow > 0 && CountriesCurrentPage == CountriesTotalPages && UpdateCountriesRow == CountriesLastPageLastRow) || (UpdateCountriesRow == PageSize) ||
                        (this.CountriesLastPageLastRow == 0 && this.CountriesTotalPages == 0 && this.CountriesCurrentPage == 1))
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
                    CountryGridView.CurrentCell = null;
                    CountryGridView.Rows[0].Selected = false;
                    UpdateCountriesArray(Country);
                }
            }
            if (IndexGridChange == 2)
            {
                CountyGridView.EndEdit();
                if ((CountiesLastPageLastRow > 0 && CountiesCurrentPage == CountiesTotalPages && UpdateCountyRow == CountiesLastPageLastRow) || (UpdateCountyRow == PageSize) ||
                    (this.CountiesLastPageLastRow == 0 && this.CountiesTotalPages == 0 && this.CountiesCurrentPage == 1))
                {
                    CountyModel NewCounty = GetCounty();
                    var t=Task.Run(() => GetLastCountyId());
                    t.Wait();
                    NewCounty.CountyId = t.Result;

                    var task = Task.Run(() => InsertCounty(NewCounty));
                    task.Wait();
                    //_countyRepository.InsertCounty(NewCounty);
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
                    CountyGridView.CurrentCell = null;
                    CountyGridView.Rows[0].Selected = false;
                    UpdateCountiesArray(County);
                }
            }
            if (IndexGridChange == 3)
            {
                this.CityGridView.EndEdit();
                if ((CityLastPageLastRow > 0 && CityCurrentPage == CityTotalPages && UpdateCityRow == CityLastPageLastRow) || (UpdateCityRow == PageSize) ||
                    (this.CityLastPageLastRow == 0 && this.CityTotalPages == 0 && this.CityCurrentPage == 1))
                {

                    CityModel newCity = GetCity();
                    newCity.DictionaryCityId = _cityRepository.LastDictionaryCityId() + 1;
                    _cityRepository.InsertCity(newCity);
                    this.Cities.Add(newCity);
                    this.CitiesFromSearchBar = this.Cities;
                    int[] aux = this.CalculateTotalPages(this.Cities.Count);
                    this.CityTotalPages = aux[0];
                    this.CityLastPageLastRow = aux[1];
                    this.CityCurrentPage = 1;
                    this.CitiesCreatePage(this.CitiesFromSearchBar);
                    CityEndEditLayout("Done", "You can see the city you just added on the last page.");
                    //this.SpeakerListDataGrid.CurrentCell = null;
                    this.CityGridView.Rows[0].Selected = false;

                }
                else
                {
                    CityModel city = GetCity();
                    //city.DictionaryCityId = CityListDataGridView.Columns["DictionaryCityId"]
                    _cityRepository.UpdateCity(city);
                    CityEndEditLayout("Done", "City modified succesfully");
                    this.CityGridView.CurrentCell = null;
                    this.CityGridView.Rows[0].Selected = false;
                    this.UpdateInCityList(city);

                }
                this.CityGridView.CurrentCell = null;
            }
            if (IndexGridChange == 4)
            {
                this.TypeGridView.EndEdit();
                if ((this.TypesLastPageLastRow > 0 && this.TypesCurrentPage == this.TypesTotalPages && this.UpdateTypeRow == this.TypesLastPageLastRow) || (this.UpdateTypeRow == this.PageSize)
                    || (this.TypesLastPageLastRow == 0 && this.TypesTotalPages == 0 && this.TypesCurrentPage == 1))
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

                    this.TypeGridView.CurrentCell = null;
                    this.TypeGridView.Rows[0].Selected = false;
                    this.SaveEditBtn.Visible = false;
                    this.NextPageBtn.Enabled = true;
                    this.BackPageBtn.Enabled = true;
                    this.FirstPageBtn.Enabled = true;
                    this.LastPageBtn.Enabled = true;
                    this.EditTextBox.Visible = false;
                }
                else
                {
                    TypeModel type = this.GetType();

                    //_typeRepository.UpdateType(Type);
                    var t = Task.Run(() => UpdateType(type));
                    t.Wait();
                    TypeEndEditLayout("Done", "Type modified succesfully");
                    //this.TypeDataGrid.CurrentCell = null;
                    this.TypeGridView.Rows[0].Selected = false;
                    this.UpdateTypeArray(type);

                }
            }
            if (IndexGridChange == 5)
            {
                this.SpeakerGridView.EndEdit();
                if ((this.SpeakersLastPageLastRow > 0 && this.SpeakersCurrentPage == this.SpeakersTotalPages && this.UpdateSpeakerRow == this.SpeakersLastPageLastRow) || (this.UpdateSpeakerRow == this.PageSize) ||
                    (this.SpeakersLastPageLastRow == 0 && this.SpeakersTotalPages == 0 && this.SpeakersCurrentPage == 1))
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
                    this.SpeakerGridView.Rows[0].Selected = false;
                }
                else
                {
                    SpeakerModel newSpeaker = GetSpeaker();
                    //_speakerRepository.UpdateSpeaker(newSpeaker);
                    var t = Task.Run(() => UpdateSpeaker(newSpeaker));
                    t.Wait();
                    SpeakerEndEditLayout("Done", "Speaker modified succesfully");
                    this.SpeakerGridView.CurrentCell = null;
                    this.SpeakerGridView.Rows[0].Selected = false;
                    this.UpdateSpeakerArray(newSpeaker);

                }
                this.SpeakerGridView.CurrentCell = null;
            }
            if (IndexGridChange == 6)
            {
                CategoryGridView.EndEdit();
                if ((CategoriesLastPageLastRow > 0 && CategoriesCurrentPage == CategoriesToatlPages && UpdateCategoryRow == CategoriesLastPageLastRow) || (UpdateCategoryRow == PageSize) ||
                    (this.CategoriesLastPageLastRow == 0 && this.CategoriesToatlPages == 0 && this.CategoriesCurrentPage == 1))
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
                    CategoryGridView.Rows[0].Selected = false;
                    UpdateCategoryArray(Category);
                }
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
        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            if (IndexGridChange == 1)
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
            else if (IndexGridChange == 2)
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
            else if (IndexGridChange == 3)
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
            else if (IndexGridChange == 4)
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
            else if (IndexGridChange == 5)
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
            else if (IndexGridChange == 6)
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
        public ConferenceModelWithEmail CreateConferenceForInsert()
        {
            ConferenceModelWithEmail newConference = new ConferenceModelWithEmail();

            DateTime ConferenceStartDate = this.StartDatePicker.Value;
            DateTime ConferenceEndDate = this.EndDatePicker.Value;
            DateTime ConferenceStartHour = this.StartHourPicker.Value;
            DateTime ConferenceEndHour = this.EndHourPicker.Value;

            string startDate = ConferenceStartDate.ToString("yyyy-MM-dd hh:mm:ss").Split(" ")[0] + " " + ConferenceStartHour.ToString().Split(" ")[1];
            string endDate = ConferenceEndDate.ToString("yyyy-MM-dd hh:mm:ss").Split(" ")[0] + " " + ConferenceEndHour.ToString().Split(" ")[1];

            newConference.Email = Program.EnteredEmailAddress;
            newConference.ConferenceName = this.ConfName.Text;
            newConference.ConferenceCategoryName = this.SelectedCategoryId.ToString();
            newConference.ConferenceTypeName = this.SelectedTypeId.ToString();
            newConference.Speaker = this.SelectedSpeakerId.ToString();
            newConference.Location = this.SelectedCityId.ToString();
            newConference.Period = startDate + " - " + endDate;

            return newConference;
        }

        public void ResetForm()
        {
            ConfName.Text = string.Empty;
            StartDatePicker.Value = DateTime.Today;
            EndDatePicker.Value = DateTime.Today;
            this.StartHourPicker.Value = DateTime.Today;
            this.EndHourPicker.Value = DateTime.Today;

            //mai trebuie niste variabile 

        }
        private void SearchBar_Enter(object sender, EventArgs e)
        {
            this.SearchBar.Text = "";
        }

        private void PaginationSelector_DropDownClosed(object sender, EventArgs e)
        {
            if(IndexGridChange == 1)
            {
                int index = PaginationSelector.SelectedIndex;
                if (index >= 0)
                {
                    PageSize = int.Parse(PaginationSelector.Items[index].ToString());

                    int[] temp = CalculateTotalPages(CountriesFromSearchBar.Count);
                    CountriesCurrentPage = 1;
                    CountriesTotalPages = temp[0];
                    CountriesLastPageLastRow = temp[1];

                    CountriesCreatePage(CountriesFromSearchBar);
                }
            }
            if (IndexGridChange == 2)
            {
                int index = PaginationSelector.SelectedIndex;
                if (index >= 0)
                {
                    PageSize = int.Parse(PaginationSelector.Items[index].ToString());

                    int[] temp = CalculateTotalPages(CountiesFromSearchBar.Count);
                    CountiesCurrentPage = 1;
                    CountiesTotalPages = temp[0];
                    CountiesLastPageLastRow = temp[1];

                    CountiesCreatePage(CountiesFromSearchBar);
                }
            }
            if (IndexGridChange == 3)
            {
                int index = PaginationSelector.SelectedIndex;
                if (index >= 0)
                {
                    PageSize = int.Parse(PaginationSelector.Items[index].ToString());

                    int[] temp = CalculateTotalPages(CitiesFromSearchBar.Count);
                    CityCurrentPage = 1;
                    CityTotalPages = temp[0];
                    CityLastPageLastRow = temp[1];

                    CitiesCreatePage(CitiesFromSearchBar);
                }
            }
            if (IndexGridChange == 4)
            {
                int index = PaginationSelector.SelectedIndex;
                if (index >= 0)
                {
                    PageSize = int.Parse(PaginationSelector.Items[index].ToString());

                    int[] temp = CalculateTotalPages(TypesForSearchBar.Count);
                    TypesCurrentPage = 1;
                    TypesTotalPages = temp[0];
                    TypesLastPageLastRow = temp[1];

                    TypeCreatePage(TypesForSearchBar);
                }
            }
            if (IndexGridChange == 5)
            {
                int idx = this.PaginationSelector.SelectedIndex;
                if (idx >= 0)
                {
                    this.PageSize = int.Parse(this.PaginationSelector.Items[idx].ToString());
                    //if ()
                    int[] aux = this.CalculateTotalPages(this.SpeakersForSearchBar.Count);
                    this.SpeakersCurrentPage = 1;
                    this.SpeakersTotalPages = aux[0];
                    this.SpeakersLastPageLastRow = aux[1];

                    this.SpeakerCreatePage(this.SpeakersForSearchBar);
                }
            }
            if (IndexGridChange == 6)
            {
                int index = PaginationSelector.SelectedIndex;
                if (index >= 0)
                {
                    PageSize = int.Parse(PaginationSelector.Items[index].ToString());

                    int[] temp = CalculateTotalPages(CategoriesFromSearch.Count);
                    CategoriesCurrentPage = 1;
                    CategoriesToatlPages = temp[0];
                    CategoriesLastPageLastRow = temp[1];

                    CategoryCreatePage(CategoriesFromSearch);
                }
            }
        }

        private void ConfName_Enter(object sender, EventArgs e)
        {
            ConfNameError.Clear();
        }

        private void ConfName_Leave(object sender, EventArgs e)
        {
            if (CheckError())
            {
                ConferenceName = ConfName.Text;
                LoadSaveTab();
            }
        }

        private void SaveNewBtn_Click(object sender, EventArgs e)
        {
            ConferenceModelWithEmail newConference = CreateConferenceForInsert();

            var t = Task.Run(() => InsertConference(newConference));
            t.Wait();

            ResetForm();
        }

        private void SpeakerGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SpeakerGridView.BeginEdit(true);
        }

        private void TypeGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.TypeGridView.BeginEdit(true);
        }

        private void CityGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CityGridView.BeginEdit(true);
        }

        private void CountyGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CountyGridView.BeginEdit(true);
        }

        private void CountryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CountryGridView.BeginEdit(true);
        }

        private void CategoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CategoryGridView.BeginEdit(true);
        }

        private void StartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDate = StartDatePicker.Value.ToString();
            LoadSaveTab();
        }

        private void EndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDate = EndDatePicker.Value.ToString();
            LoadSaveTab();
        }

        private void StartHourPicker_ValueChanged(object sender, EventArgs e)
        {
            StartHour = StartHourPicker.Value.ToString();
            LoadSaveTab();
        }

        private void EndHourPicker_ValueChanged(object sender, EventArgs e)
        {
            EndHour = EndHourPicker.Value.ToString();
            LoadSaveTab();
        }
    }
}
