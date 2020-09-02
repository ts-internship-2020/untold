using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Forms;

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
            YesButton.Click += DeleteCountryYesButton_Click;
            NoButton.Click += NoDeleteButton_Click;
            ObjectId = DictionaryCountryId;
        }

        private void DeleteCountryYesButton_Click(object sender, EventArgs e)
        {
            _countryRepository.DeleteCountry(ObjectId);
            Close();
        }

        private void DeleteCountyYesButton_Click(object sender, EventArgs e)
        {
            _countyRepository.DeleteCounty(ObjectId);
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
            _categoryRepository.DeleteCategory(ObjectId);
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
            _speakerRepository.DeleteSpeaker(this.ObjectId);
            this.Close();
        }

        private void ConferenceYesButton_Click(object sender, EventArgs e)
        {
            _conferenceRepository.DeleteConferenceById(this.ObjectId);
            this.Close();
        }

        private void DeleteCityYesButton_Click(Object sender, EventArgs e)
        {
            if (_cityRepository.DeleteCity(ObjectId).Equals("error"))
            {
                return;
               // popUpMethod("A conference will be in this city", "You can't delete it");
            }
            this.Close();
        }

        private void TypeYesButton_Click(Object sender, EventArgs e)
        {
            _typeRepository.DeleteType(this.ObjectId);
            this.Close();
        }
        private void NoDeleteButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
