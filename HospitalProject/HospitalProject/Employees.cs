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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        #region bindcomboemp
        private void bindemployee()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from employees";
            SqlDataReader dr = cmd.ExecuteReader();
            Empcombo.Items.Clear();
            while (dr.Read())
            {
                Empcombo.Items.Add(dr[3].ToString());
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
        private void button4_Click(object sender, EventArgs e)
        {

            RetriveData.openconnection();
            RetriveData.Employees.search(Empcombo.Text);
            label1.Text = RetriveData.Employees.id__.ToString();
           empnum.Text = RetriveData.Employees.emp_id_.ToString();
            firstname.Text = RetriveData.Employees.first_name_;
            lastname.Text = RetriveData.Employees.last_name_;
            fullname.Text = RetriveData.Employees.full_name_;
            birthdate.Text = RetriveData.Employees.dateof_birth_.ToString();
            birthplace.Text = RetriveData.Employees.placeof_birth_;
            hiringdate.Text = RetriveData.Employees.work_date_.ToString();
            bloodsymbol.Text = RetriveData.Employees.blood_type_;
            nationality.Text = RetriveData.Employees.nationality_;
            id.Text = RetriveData.Employees.national_id_;
            gender.Text = RetriveData.Employees.gender_;
            maritalstat.Text = RetriveData.Employees.marital_status_;
            notes.Text = RetriveData.Employees.notes_;
           jobtxt.Text = RetriveData.Employees.job_;
            mobile.Text = RetriveData.Employees.mobile_;
            phone.Text = RetriveData.Employees.phone_;
            email.Text = RetriveData.Employees.email_;
            
            RetriveData.closeconnection();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            bindemployee();
            bindjob();
            bindnationality();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Employees.save(int.Parse(empnum.Text), jobtxt.Text, fullname.Text, firstname.Text, lastname.Text
                    , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                    , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
                RetriveData.closeconnection();
                bindemployee();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            RetriveData.openconnection();
            RetriveData.Employees.delete(Empcombo.Text);
            RetriveData.closeconnection();
            bindemployee();
            Validation.txtclear(this, groupBox1);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Employees.update(int.Parse(label1.Text), fullname.Text, int.Parse(empnum.Text), jobtxt.Text, firstname.Text, lastname.Text
                , DateTime.Parse(birthdate.Text), gender.Text, mobile.Text, phone.Text, DateTime.Parse(hiringdate.Text), nationality.Text, email.Text, bloodsymbol.Text
                , id.Text, birthplace.Text, maritalstat.Text, notes.Text);
            RetriveData.closeconnection();
            bindemployee();
            Validation.txtclear(this, groupBox1);
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchEmployees sp = new SearchEmployees();

            sp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           
        }

        private void Employees_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
