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
    public partial class Nurses : Form
    {
        public Nurses()
        {
            InitializeComponent();
        }
        #region bindnurse
        private void bindnurse()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nurses";
            SqlDataReader dr = cmd.ExecuteReader();
           nursecombo.Items.Clear();
            while (dr.Read())
            {
                nursecombo.Items.Add(dr[3].ToString());
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
        #region job
        private void bindjob()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from jobs";
            SqlDataReader dr = cmd.ExecuteReader();
            jobtxt.Items.Clear();
            while (dr.Read())
            {
                jobtxt.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void Nurses_Load(object sender, EventArgs e)
        {
            bindjob();
            bindnationality();
            bindnurse();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Nurses.search(nursecombo.Text);
            label1.Text = RetriveData.Nurses.id__.ToString();
            nursenum.Text = RetriveData.Nurses.nurse_id_.ToString();
            firstname.Text = RetriveData.Nurses.first_name_;
            lastname.Text = RetriveData.Nurses.last_name_;
            fullname.Text = RetriveData.Nurses.full_name_;
            birthdate.Text = RetriveData.Nurses.dateof_birth_.ToString();
            birthplace.Text = RetriveData.Nurses.placeof_birth_;
            hiringdate.Text = RetriveData.Nurses.work_date_.ToString();
            bloodsymbol.Text = RetriveData.Nurses.blood_type_;
            nationality.Text = RetriveData.Nurses.nationality_;
            id.Text = RetriveData.Nurses.national_id_;
            gender.Text = RetriveData.Nurses.gender_;
            maritalstat.Text = RetriveData.Nurses.marital_status_;
            notes.Text = RetriveData.Nurses.notes_;
            jobtxt.Text = RetriveData.Nurses.job_;
            mobile.Text = RetriveData.Nurses.mobile_;
            phone.Text = RetriveData.Nurses.phone_;
            email.Text = RetriveData.Nurses.email_;
           
            RetriveData.closeconnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Nurses.save(int.Parse(nursenum.Text), jobtxt.Text, fullname.Text, firstname.Text, lastname.Text
                    , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                    , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
                RetriveData.closeconnection();
                bindnurse();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Nurses.delete(nursecombo.Text);
            RetriveData.closeconnection();
            bindnurse();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Nurses.update(int.Parse(label1.Text), fullname.Text, int.Parse(nursenum.Text), jobtxt.Text, firstname.Text, lastname.Text
                , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
            RetriveData.closeconnection();
            bindnurse();
            Validation.txtclear(this, groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchNurses sn = new SearchNurses();

            sn.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Nurses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
