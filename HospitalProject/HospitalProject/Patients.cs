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
    public partial class Patients : Form
    {
        public Patients()
        {
            InitializeComponent();
        }
        #region bindnationality
        private void bindnationality()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nationality";
            SqlDataReader dr = cmd.ExecuteReader();
            nationality.Items.Clear();
            while (dr.Read())
            {
                nationality.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bindpatient
        private void bindpatient()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from patients";
            SqlDataReader dr = cmd.ExecuteReader();
          patientcombo.Items.Clear();
            while (dr.Read())
            {
               patientcombo.Items.Add(dr[2].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
      
        private void patientname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Patients_Load(object sender, EventArgs e)
        {
            bindnationality();
            bindpatient();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Patients.save(job.Text, fullname.Text, firstname.Text, lastname.Text
                    , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, age.Text, nationality.Text, email.Text, bloodsymbol.Text
                    , id.Text, birthplace.Text, maritalstat.Text, notes.Text, int.Parse(filenum.Text), DateTime.Parse(openingdate.Text));
                RetriveData.closeconnection();
                bindpatient();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                  RetriveData.openconnection();
            RetriveData.Patients.update(int.Parse(label1.Text), fullname.Text,job.Text, firstname.Text, lastname.Text
                , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, age.Text, nationality.Text, email.Text, bloodsymbol.Text
                , id.Text, birthplace.Text, maritalstat.Text, notes.Text, DateTime.Parse(openingdate.Text), int.Parse(filenum.Text));
            RetriveData.closeconnection();
            bindpatient();
            Validation.txtclear(this, groupBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Patients.delete(patientcombo.Text);
            RetriveData.closeconnection();
            bindpatient();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Patients.search(patientcombo.Text);
            label1.Text = RetriveData.Patients.id__.ToString();
            filenum.Text = RetriveData.Patients.file_num_.ToString();
            firstname.Text = RetriveData.Patients.first_name_;
            lastname.Text = RetriveData.Patients.last_name_;
            fullname.Text = RetriveData.Patients.full_name_;
            birthdate.Text = RetriveData.Patients.dateof_birth_.ToString();
            birthplace.Text = RetriveData.Patients.placeof_birth_;
            openingdate.Text = RetriveData.Patients.opening_file_.ToString();
            bloodsymbol.Text = RetriveData.Patients.blood_type_;
            nationality.Text = RetriveData.Patients.nationality_;
            id.Text = RetriveData.Patients.national_id_;
            gender.Text = RetriveData.Patients.gender_;
            maritalstat.Text = RetriveData.Patients.marital_status_;
            notes.Text = RetriveData.Patients.notes_;
            job.Text = RetriveData.Patients.job_name_;
            mobile.Text = RetriveData.Patients.mobile_;
            phone.Text = RetriveData.Patients.phone_;
            email.Text = RetriveData.Patients.email_;
            age.Text = RetriveData.Patients.age_;


            RetriveData.closeconnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientsSearchcs ps = new PatientsSearchcs();
            ps.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Patients_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
