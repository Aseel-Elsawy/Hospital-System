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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HospitalProject
{
    public partial class Doctors : Form
    {
        public Doctors()
        {
            InitializeComponent();
        }
        #region bindcombodoctor
        private void binddoctor()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from doctors";
            SqlDataReader dr = cmd.ExecuteReader();
          doctorcombo.Items.Clear();
            while (dr.Read())
            {
                doctorcombo.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
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
        #region specilization
        private void bindspecilization()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from specilization";
            SqlDataReader dr = cmd.ExecuteReader();
           specializationtxt.Items.Clear();
            while (dr.Read())
            {
                specializationtxt.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Doctors.save(int.Parse(doctornum.Text), specializationtxt.Text, fullname.Text, firstname.Text, lastname.Text
                    , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                    , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
                RetriveData.closeconnection();
                binddoctor();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void Doctors_Load(object sender, EventArgs e)
        {
            binddoctor();
            bindnationality();
            bindspecilization();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Doctors.delete(doctorcombo.Text);
            RetriveData.closeconnection();
            binddoctor();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Doctors.search(doctorcombo.Text);
            label1.Text = RetriveData.Doctors.id__.ToString();
            doctornum.Text = RetriveData.Doctors.doctor_id_.ToString();
            firstname.Text = RetriveData.Doctors.first_name_;
            lastname.Text = RetriveData.Doctors.last_name_;
            fullname.Text = RetriveData.Doctors.full_name_;
            birthdate.Text = RetriveData.Doctors.dateof_birth_.ToString();
            birthplace.Text = RetriveData.Doctors.placeof_birth_;
            hiringdate.Text = RetriveData.Doctors.work_date_.ToString();
            bloodsymbol.Text = RetriveData.Doctors.blood_type_;
            nationality.Text = RetriveData.Doctors.nationality_;
            id.Text = RetriveData.Doctors.national_id_;
            gender.Text = RetriveData.Doctors.gender_;
            maritalstat.Text = RetriveData.Doctors.marital_status_;
            notes.Text = RetriveData.Doctors.notes_;
            specializationtxt.Text = RetriveData.Doctors.specialization_;
            mobile.Text = RetriveData.Doctors.mobile_;
            phone.Text = RetriveData.Doctors.phone_;
            email.Text = RetriveData.Doctors.email_;

            RetriveData.closeconnection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Doctors.update(int.Parse(label1.Text),fullname.Text,int.Parse(doctornum.Text), specializationtxt.Text, firstname.Text, lastname.Text
                , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
            RetriveData.closeconnection();
            binddoctor();
            Validation.txtclear(this, groupBox1);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchDoctors sd = new SearchDoctors();
           
            sd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           
        }

        private void Doctors_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
