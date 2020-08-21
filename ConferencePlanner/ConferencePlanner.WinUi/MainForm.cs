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
        
        private readonly IAttendeeRepository _attendeeRepository;

        private readonly IGetDemoRepository _getDemoRepository;
        public MainForm(IAttendeeRepository attendeeRepository)
        {
            
            _attendeeRepository = attendeeRepository;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = _getDemoRepository.GetDemo("hello");

            label1.Text = x.FirstOrDefault().Name;
            listBox1.DataSource = x;
            listBox1.DisplayMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // var x = _getDemoRepository.GetDemo()


            

        }

       

        private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            var x = _attendeeRepository.AttendeeConferences("attendee@test.com");
            AttendeeGridView.DataSource = x.ToList();
        }
    }
}
