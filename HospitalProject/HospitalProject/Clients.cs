//using DevExpress.DashboardWeb.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HospitalProject
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }
        #region bindcombo
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from clients";
            SqlDataReader dr = cmd.ExecuteReader();
           clientcombo.Items.Clear();
            while (dr.Read())
            {
                clientcombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Clients.save(nametxt.Text, addresstxt.Text, phonetxt.Text, mobtxt.Text, emailtxt.Text, notestxt.Text);
                RetriveData.closeconnection();
                bindcombo();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            RetriveData.openconnection();
            RetriveData.Clients.update(int.Parse(label8.Text),nametxt.Text, addresstxt.Text, phonetxt.Text, mobtxt.Text, emailtxt.Text, notestxt.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Clients.delete(clientcombo.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Clients.search(clientcombo.Text,dataGridView1);
            label8.Text = RetriveData.Clients.__id.ToString();
            nametxt.Text = RetriveData.Clients.client_name_;
            phonetxt.Text = RetriveData.Clients.phone_;
            mobtxt.Text = RetriveData.Clients.mobile_;
            emailtxt.Text = RetriveData.Clients.email_;
            notestxt.Text = RetriveData.Clients.notes_;
            addresstxt.Text = RetriveData.Clients.address_;
            RetriveData.closeconnection();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            bindcombo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Clients.search(dataGridView1);
            RetriveData.closeconnection();

         
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           
        }

        private void Clients_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
