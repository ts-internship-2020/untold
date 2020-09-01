﻿using ConferencePlanner.Abstraction.Model;
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
        private readonly ITypeRepository _typeRepository;

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
            YesButton.Click += DeleteCounntyYesButton_Click;
            NoButton.Click += NoDeleteButton_Click;
            ObjectId = CountyId;
        }

        private void DeleteCounntyYesButton_Click(object sender, EventArgs e)
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
