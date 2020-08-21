using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConferencePlanner.WinUi
{
    public partial class AddConf : Form
    {

        SqlConnection con = new SqlConnection("Data Source=ts-internship-2019.database.windows.net; Initial Catalog=untold; Integrated Security=True");

        public AddConf()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddConf_Load(object sender, EventArgs e)
        {
            try {
                con.Open();
                SqlCommand sc = new SqlCommand("select CountryName from DictionaryCountry", con);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable CountryTable = new DataTable();
                CountryTable.Columns.Add("Country", typeof(string));
                CountryTable.Load(reader);
                comboBox1.ValueMember = "Country";
                comboBox1.DataSource = CountryTable;
                con.Close();
            }
            catch (Exception)
            {

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConferenceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void County_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
