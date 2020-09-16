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

        private SpeakerModel MainSpeaker = new SpeakerModel();

        public SpeakerDetails(int conferenceId)
        {
            var t = Task.Run(() => GetSpeakerByConferenceId(conferenceId));
            t.Wait();

            if(this.MainSpeaker.SpeakerId != 21)
            {
                InitializeComponent();
            }
            else
            {
                this.Close();
            }
        }

        public SpeakerDetails()
        {    
            InitializeComponent();
        }


    private void SpeakerDetails_Load(object sender, EventArgs e)
        {
            this.speakerName.Text = MainSpeaker.FirstName + " " + this.MainSpeaker.LastName;
            this.speakerNationality.Text = this.MainSpeaker.Nationality;
            this.speakerRating.Text = this.MainSpeaker.Rating.ToString() + " / 10";

            //StringBuilder strB = new StringBuilder("", 50);
            //strB.AppendFormat("../../../Resources/speakersPhotos/{0}_{1}.jpg", this.Speaker.LastName.ToLower(), this.Speaker.FirstName.ToLower());

            //Image img = Image.FromFile(strB.ToString());
            Image img;
            try
            {
                img = Image.FromFile(this.MainSpeaker.ImagePath);
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

        private async Task GetSpeakerByConferenceId(int conferenceId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage s = await client.GetAsync("http://localhost:2794/api/Speaker/speaker_by_conference_id/id=" + conferenceId);

            if (s.IsSuccessStatusCode)
            {
                string json = await s.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SpeakerModel>(json);

                this.MainSpeaker = result;
            }
        }
    }
}
