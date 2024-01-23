using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Specialization : Form
    {
        public Specialization()
        {
            InitializeComponent();
        }
        #region bind specilization
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from specilization";
            SqlDataReader dr = cmd.ExecuteReader();
            specilizationcombo.Items.Clear();
            while (dr.Read())
            {
                specilizationcombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bind clinics
        private void bindcomboclinic()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from clinics";
            SqlDataReader dr = cmd.ExecuteReader();
           clinicname.Items.Clear();
            while (dr.Read())
            {
                clinicname.Items.Add(dr[1].ToString());
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
                RetriveData.specilizations.save(specilizationtxt.Text, clinicname.Text);
                RetriveData.closeconnection();
                bindcombo();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.specilizations.delete(specilizationtxt.Text, clinicname.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.specilizations.search(specilizationcombo.Text, dataGridView1);
            specilizationtxt.Text = RetriveData.specilizations.specilization_;
            clinicname.Text = RetriveData.specilizations.clinic_;
            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.specilizations.search( dataGridView1);
            RetriveData.closeconnection();
        }

        private void Specialization_Load(object sender, EventArgs e)
        {
            bindcombo();
            bindcomboclinic();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Specialization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
