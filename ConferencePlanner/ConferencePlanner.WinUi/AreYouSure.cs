using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ConferencePlanner.WinUi
{
    public partial class AreYouSure : Form
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountyRepository _countyRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly ICategoryRepository _categoryRepository;

        private int ObjectId;
        public AreYouSure()
        {
            InitializeComponent();
        }
        
        public AreYouSure(IConferenceRepository conferenceRepository, int conferenceId)
        {
            _conferenceRepository = conferenceRepository;
            InitializeComponent();

            this.YesButton.Click += ConferenceYesButton_Click;
            this.NoButton.Click += NoDeleteButton_Click;
            this.ObjectId = conferenceId;
        }

        public AreYouSure(ISpeakerRepository speakerRepository, int speakerId)
        {
            _speakerRepository = speakerRepository;
            
            InitializeComponent();
            this.YesButton.Click += SpeakerYesButton_Click;
            this.NoButton.Click += NoDeleteButton_Click;
            this.ObjectId = speakerId;
        }

        public AreYouSure(ICountyRepository countyRepository, int CountyId)
        {
            _countyRepository = countyRepository;

            InitializeComponent();
            YesButton.Click += DeleteCountyYesButton_Click;
            NoButton.Click += NoDeleteButton_Click;
            ObjectId = CountyId;
        }

        public AreYouSure(ICountryRepository countryRepository, int DictionaryCountryId)
        {
            _countryRepository = countryRepository;

            InitializeComponent();
            YesButton.Click += CountryYesButton_Click;
            NoButton.Click += NoDeleteButton_Click;
            ObjectId = DictionaryCountryId;
        }


        private void CountryYesButton_Click(object sender, EventArgs e)
        {
           // _countryRepository.DeleteCountry(ObjectId);
            var t = Task.Run(() => DeleteCountry(ObjectId));
            t.Wait();
            Close();
        }


        private void DeleteCountyYesButton_Click(object sender, EventArgs e)
        {
            //if (_countyRepository.DeleteCounty(ObjectId).Equals("error"))
            //{
            //    popUpMethod("Error", "This county has cities and can't be deleted.");
            //}
            var t = Task.Run(() => DeleteCounty(ObjectId));
            t.Wait();
            Close();
        }

        public AreYouSure(ITypeRepository typeRepository, int confid)
        {
            _typeRepository = typeRepository;

            InitializeComponent();

            this.YesButton.Click += TypeYesButton_Click;
            this.NoButton.Click += NoDeleteButton_Click;
            this.ObjectId = confid;
        }


        public AreYouSure(ICategoryRepository categoryRepository, int CategoryId)
        {
            _categoryRepository = categoryRepository;
            InitializeComponent();
            YesButton.Click += CategoryYesButton_Click;
            NoButton.Click += NoDeleteButton_Click;
            ObjectId = CategoryId;
        }

        private void CategoryYesButton_Click(object sender, EventArgs e)
        {
            //_categoryRepository.DeleteCategory(ObjectId);
            var t = Task.Run(() => DeleteCategory(ObjectId));
            t.Wait();
            
            Close();
        }

        public AreYouSure(ICityRepository cityRepository, int cityId)
        {
            _cityRepository = cityRepository;


            InitializeComponent();
            this.YesButton.Click += DeleteCityYesButton_Click;
            this.NoButton.Click += NoDeleteButton_Click;
            this.ObjectId = cityId;
        }



        private void SpeakerYesButton_Click(object sender, EventArgs e)
        {
            //_speakerRepository.DeleteSpeaker(this.ObjectId);
            var t = Task.Run(() => DeleteSpeaker(this.ObjectId));
            t.Wait();
            this.Close();
        }

        

        private void ConferenceYesButton_Click(object sender, EventArgs e)
        {
            //_conferenceRepository.DeleteConferenceById(this.ObjectId);
            var t = Task.Run(() => DeleteConference(this.ObjectId));
            t.Wait();
            this.Close();
        }

        private void DeleteCityYesButton_Click(Object sender, EventArgs e)
        {
            //if (_cityRepository.DeleteCity(ObjectId).Equals("error"))
            //{

            //   popUpMethod("A conference will be in this city", "You can't delete it");
            //    return;
            //}
            var t = Task.Run(() => DeteleteCityAsync(ObjectId));
            t.Wait();
            Close();
            this.Close();
        }

        private void TypeYesButton_Click(Object sender, EventArgs e)
        {
            //_typeRepository.DeleteType(this.ObjectId);
            try
            {
                var t = Task.Run(() => DeleteType(this.ObjectId));
                t.Wait();
                this.Close();
            }
               
            
            catch(Exception x)
            {
                this.Close();
                this.popUpMethod("Warning", "You can't delete this row!");
            }
        }
        private void NoDeleteButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task DeleteSpeaker(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.DeleteAsync("http://localhost:2794/api/Speaker/delete_speaker/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You deleted the speaker succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }
        private async Task DeleteConference(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.DeleteAsync("http://localhost:2794/api/Conference/delete_conference/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You deleted the conference succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }

        private async Task DeleteCountry(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.DeleteAsync("http://localhost:2794/api/Country/delete_country/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You deleted the country succesfully");
            }
            else
            {
                this.popUpMethod("Error", "Something went wrong");
            }

        }

        private async Task DeleteType(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage s = await client.DeleteAsync("http://localhost:2794/api/Type/DeleteType/id=" + id);

            if (s.IsSuccessStatusCode)
            {
                this.popUpMethod("Done", "You deleted the conference succesfully");
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

        private async Task DeleteCounty(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.DeleteAsync("http://localhost:2794/api/County/delete_county/id=" + id);
            if (s.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "The County was deleted!");
            }
            else
            {
                popUpMethod("Error", "This county has cities and can't be deleted.");
            }

        }

        private async Task DeleteCategory(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync("http://localhost:2794/api/Category/delete_category");
            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "The category was deleted!");
            }
            else
            {
                popUpMethod("Error", "Unexpected error");
            }
        }

        private async Task DeteleteCityAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.DeleteAsync("http://localhost:2794/api/City/DeleteCity=" + id);
            if (message.IsSuccessStatusCode)
            {
                popUpMethod("Succes", "The city was deleted!");
            }
            else
            {
                popUpMethod("Error", "Unexpected error");
            }
        }

    }
}
