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
    public partial class Clinics : Form
    {
        public Clinics()
        {
            InitializeComponent();
        }
        #region bindcomboclinics
        private void bindcomboclinics()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from clinics";
            SqlDataReader dr = cmd.ExecuteReader();
            clinicnamecombo.Items.Clear();
            while (dr.Read())
            {
                clinicnamecombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bind clinics
        private void bindcombospecilization()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from clinics";
            SqlDataReader dr = cmd.ExecuteReader();
           specializationtxt.Items.Clear();
            while (dr.Read())
            {
               specializationtxt.Items.Add(dr[2].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bind combo clinics from tckets
        private void bindcomboclinicsFromTickets()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from tickets";
            SqlDataReader dr = cmd.ExecuteReader();
           clinicname3.Items.Clear();
            while (dr.Read())
            {
                clinicname3.Items.Add(dr[6].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bind patients
        private void bindcombopatients()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from tickets where tk_clinic='"+clinicname3.Text+"'";
            SqlDataReader dr = cmd.ExecuteReader();
            patientname.Items.Clear();
            while (dr.Read())
            {
               patientname.Items.Add(dr[2].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion

        private void Clinics_Load(object sender, EventArgs e)
        {
            bindcomboclinics();
            bindcombospecilization();
            bindcomboclinicsFromTickets();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            Validation.suretxt(this, groupBox4);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Clinic.save(clinicname.Text, specializationtxt.Text);
                RetriveData.closeconnection();
                bindcomboclinics();
                bindcombospecilization();
                Validation.txtclear(this, groupBox1);
                Validation.txtclear(this, groupBox4);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Clinic.search(clinicnamecombo.Text,dataGridView1);
            clinicname.Text = RetriveData.Clinic.clinic_name_;
            specializationtxt.Text = RetriveData.Clinic.specilization_;
            codetxt.Text = RetriveData.Clinic.id.ToString();
            RetriveData.closeconnection();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Clinic.delete(int.Parse(codetxt.Text));
            RetriveData.closeconnection();
            bindcomboclinics();
            bindcombospecilization();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
            Validation.txtclear(this, groupBox4);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region searchall
            RetriveData.openconnection();
            RetriveData.Clinic.searchall(dataGridView1);
            RetriveData.closeconnection();
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Clinic.SearchClinetFromTicket(clinicname3.Text, patientname.Text,dataGridView2);
            RetriveData.closeconnection();
            bindcombopatients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Clinic.deletepatient(clinicname3.Text,patientname.Text);
            RetriveData.closeconnection();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox4);
            Validation.txtclear(this, groupBox3);
           
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Clinics_Activated(object sender, EventArgs e)
        {
   
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
          
        }
    }
}
