using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class AreYouSure : Form
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ISpeakerRepository _speakerRepository;

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
            this.NoButton.Click += ConferenceNoButton_Click;
            this.ObjectId = conferenceId;
        }

        public AreYouSure(ISpeakerRepository speakerRepository, int speakerId)
        {
            _speakerRepository = speakerRepository;
            InitializeComponent();

            this.YesButton.Click += SpeakerYesButton_Click;
            this.NoButton.Click += SpeakerNoButton_Click;
            this.ObjectId = speakerId;

        }

        private void SpeakerNoButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SpeakerYesButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConferenceYesButton_Click(object sender, EventArgs e)
        {
            _conferenceRepository.DeleteConferenceById(this.ObjectId);
        }
        private void ConferenceNoButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
