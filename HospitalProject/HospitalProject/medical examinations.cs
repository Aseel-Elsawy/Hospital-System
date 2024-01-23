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
    public partial class medical_examinations : Form
    {
        public medical_examinations()
        {
            InitializeComponent();
        }
        #region bindpatient from patients
        private void bindpatient()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from patients";
            string data = cmd.CommandText;
            SqlDataReader dr = cmd.ExecuteReader();
            patientcombo1.Items.Clear();
            while (dr.Read())
            {
               
                patientcombo1.Items.Add(dr[2].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bindpatient from emanations
        private void bindpatient1()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from examinations";
            string data = cmd.CommandText;
            SqlDataReader dr = cmd.ExecuteReader();
            patientcombo2.Items.Clear();
            while (dr.Read())
            {

                patientcombo2.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
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
        private void medical_examinations_Load(object sender, EventArgs e)
        {
            bindpatient();
            bindpatient1();
          bindnurse();
        }

        private void patientcombo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.tests.save(patientcombo1.Text, DateTime.Parse(date.Text), Requiredtests.Text, results.Text, tempreture.Text, heartbeat.Text, nursecombo.Text, notes.Text);
                RetriveData.closeconnection();
                bindpatient1();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.tests.update(int.Parse(label1.Text) ,patientcombo1.Text, DateTime.Parse(date.Text), Requiredtests.Text, results.Text, tempreture.Text, heartbeat.Text, nursecombo.Text, notes.Text);
            RetriveData.closeconnection();
            bindpatient1();
            Validation.txtclear(this, groupBox1);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.tests.delete(patientcombo2.Text);
            RetriveData.closeconnection();
            bindpatient1();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.tests.search(patientcombo2.Text,dataGridView1);
            label1.Text = RetriveData.tests.id_.ToString();
            patientcombo1.Text = RetriveData.tests.patient_name_;
            date.Text = RetriveData.tests.date_.ToString();
            Requiredtests.Text = RetriveData.tests.test_;
            results.Text = RetriveData.tests.result_;
            tempreture.Text = RetriveData.tests.temp_;
            heartbeat.Text = RetriveData.tests.heart_beat_;
            nursecombo.Text = RetriveData.tests.nurse_name_;
            notes.Text = RetriveData.tests.notes_;
            RetriveData.closeconnection();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.tests.search(dataGridView1);
            RetriveData.closeconnection();
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            Validation.txtclear(this, groupBox1);

        }

        private void medical_examinations_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
