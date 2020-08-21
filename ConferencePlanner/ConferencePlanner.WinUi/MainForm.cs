using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        private readonly IConferenceRepository _conferenceRepository;

        public MainForm(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;

            InitializeComponent();
            
        }

        public MainForm() { }

        private void button1_Click(object sender, EventArgs e)
        {
            //var x = _getDemoRepository.GetDemo("hello");

            //label1.Text = x.FirstOrDefault().Name;
            //listBox1.DataSource = x;
            //listBox1.DisplayMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabOrganizer_SelectedIndexChanged(object sender, EventArgs e)
        { //Program.EnteredEmailAddress
            var x = _conferenceRepository.GetConferencesByOrganizer("organizer@test.com");

            if (x.Count() == 0)
            {
                organizerDataGrid.Visible = false;
            }

            organizerDataGrid.DataSource = x.ToList();
          
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
            var x = _conferenceRepository.AttendeeConferences("attendee@test.com");
            AttendeeGridView.DataSource = x.ToList();
        }

    }
}
