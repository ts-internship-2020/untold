using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainPage : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        private readonly ICountryRepository _countryRepository;

        private readonly IGetDemoRepository _getDemoRepository;

        private readonly IAttendeeButtonsRepository _attendeeButtons;

        public MainPage(IConferenceRepository conferenceRepository, ICountryRepository countryRepository, IGetDemoRepository getDemoRepository, 
            IAttendeeButtonsRepository attendeeButtonsRepository)
        {
            _conferenceRepository = conferenceRepository;

            _countryRepository = countryRepository;

            _getDemoRepository = getDemoRepository;

            _attendeeButtons = attendeeButtonsRepository;

        InitializeComponent();
            
        }

        public MainPage() {

            InitializeComponent();
        }
        //metoda de generat codul de bare.

        public String BarcodeGenerator()
        {
            Random random = new Random();
            int length = 10;
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                sb.Append((char)(random.Next(1, 26) + 64)).ToString();
            }
            return sb.ToString().ToLower();
        }

        private void AddConferenceButton_Click(object sender, EventArgs e)
        {
            var varAddConf = new AddConf(_conferenceRepository, _countryRepository);

            varAddConf.ShowDialog();
        }

        private void TabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        { //Program.EnteredEmailAddress
            var x = _conferenceRepository.GetConferencesByOrganizer(Program.EnteredEmailAddress);

            if (x.Count() == 0)
            {
                OrganizerDataGrid.Visible = false;
                NoConferenceLabel.Visible = true;
            }

            OrganizerDataGrid.DataSource = x.ToList();
          
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            // var x = _getDemoRepository.GetDemo()
            
        }

       

        private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            //var x = _getDemoRepository.GetDemo()
            var x = _conferenceRepository.AttendeeConferences("attendee@test.com");
            AttendeeGridView.DataSource = x.ToList();

        }

        private void TabAttendee_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barcodeGenerator = BarcodeGenerator();
            _attendeeButtons.AddEmail(Program.EnteredEmailAddress, barcodeGenerator);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //a = statusul participantului
            int a = 1;
            _attendeeButtons.WithdrawnCommand(Program.EnteredEmailAddress, a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //a = statusul participantului
            var newform = new WebviewForm();
            newform.ShowDialog();
            _attendeeButtons.JoinCommand();
        }

    }
}
