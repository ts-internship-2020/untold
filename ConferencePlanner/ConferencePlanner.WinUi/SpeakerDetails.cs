using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.WinUi.Properties;

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
            this.speakerRating.Text = this.Speaker.Rating.ToString() + " / 10";

            //StringBuilder strB = new StringBuilder("", 50);
            //strB.AppendFormat("../../../Resources/speakersPhotos/{0}_{1}.jpg", this.Speaker.LastName.ToLower(), this.Speaker.FirstName.ToLower());

            //Image img = Image.FromFile(strB.ToString());

            Image img = Image.FromFile(this.Speaker.ImagePath);

            this.speakerPhoto.Image = img;
            this.speakerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
