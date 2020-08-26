using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.WinUi
{
    public partial class SpeakerDetails : Form
    {

        private readonly SpeakerModel Speaker;

        public SpeakerDetails(SpeakerModel speaker)
        {
            this.Speaker = speaker;
            InitializeComponent();
        }

        public SpeakerDetails()
        {
            InitializeComponent();
        }


    private void SpeakerDetails_Load(object sender, EventArgs e)
        {
            this.speakerName.Text = this.Speaker.FirstName + " " + this.Speaker.LastName;
            this.speakerNationality.Text = this.Speaker.Nationality;
            //this.speakerRating.Text = this.Speaker.Rating.ToString();

        }
    }
}
