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
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConferencePlanner.WinUi
{
    public partial class SpeakerDetails : Form
    {

        private readonly SpeakerModel Speaker;

        public SpeakerDetails(SpeakerModel speaker)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.Speaker = speaker;
            InitializeComponent();
        }

        public SpeakerDetails()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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
            Image img;
            try
            {
                img = Image.FromFile(this.Speaker.ImagePath);
            }
            catch (System.ArgumentNullException ex)
            {
                img = Image.FromFile("../../../Resources/speakersPhotos/unknown_user.jpg");
            }
          

            this.speakerPhoto.Image = img;
            this.speakerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            //    RightArrowPagButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            //RightArrowPagButton.BackgroundImageLayout = ImageLayout.Center;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
