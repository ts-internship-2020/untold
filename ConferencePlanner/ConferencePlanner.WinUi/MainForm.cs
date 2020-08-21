using ConferencePlanner.Abstraction.Repository;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = _conferenceRepository.GetConferencesByOrganizer("test");

            var index = this.dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = x.FirstOrDefault().ConferenceName;
            dataGridView1.Rows[index].Cells[2].Value = x.FirstOrDefault().ConferenceTypeName;
            dataGridView1.Rows[index].Cells[3].Value = x.FirstOrDefault().ConferenceCategoryName;
            //dataGridView1.Rows[index].Cells[5].Value = x.FirstOrDefault();

            //listBox2.Items.Insert()
            //Add(x.FirstOrDefault().ConferenceName, );
            //listBox2.Items.Add(x.FirstOrDefault().ConferenceId);

            //label1.Text = x.FirstOrDefault().ConferenceId.ToString();
            //listBox1.DataSource = x;

            //listBox1.DisplayMember = "Name";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
