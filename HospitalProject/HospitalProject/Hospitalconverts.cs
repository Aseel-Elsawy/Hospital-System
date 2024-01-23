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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalProject
{
    public partial class Hospitalconverts : Form
    {
        public Hospitalconverts()
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
            fromdep.Items.Clear();
            todep.Items.Clear();
            while (dr.Read())
            {
                fromdep.Items.Add(dr[1].ToString());
                todep.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bindcombomovementnumber
        private void bindcombomovement()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from hospital_transfer";
            SqlDataReader dr = cmd.ExecuteReader();
            movementcombo.Items.Clear();
            while (dr.Read())
            {
             movementcombo.Items.Add(dr[0].ToString());
               
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
            patientcombo1.Items.Clear();
            while (dr.Read())
            {
                patientcombo1.Items.Add(dr[2].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void Hospitalconverts_Load(object sender, EventArgs e)
        {
            bindcomboclinics();
            bindcombomovement();
            bindpatient();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Hospital_transfer.save(fromdep.Text, todep.Text, fromhospital.Text, tohospital.Text, DateTime.Parse(date.Text), patientcombo1.Text, filenumber.Text);
                RetriveData.closeconnection();
                bindcombomovement();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Hospital_transfer.update(int.Parse(label1.Text),fromdep.Text, todep.Text, fromhospital.Text, tohospital.Text, DateTime.Parse(date.Text), patientcombo1.Text, filenumber.Text);
            RetriveData.closeconnection();
            bindcombomovement();
            Validation.txtclear(this, groupBox1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Hospital_transfer.delete(int.Parse( movementcombo.Text));
            RetriveData.closeconnection();
            bindcombomovement();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Hospital_transfer.search(int.Parse(movementcombo.Text),dataGridView1);
            fromdep.Text = RetriveData.Hospital_transfer.department_from_;
            todep.Text = RetriveData.Hospital_transfer.department_to_;
            fromhospital.Text = RetriveData.Hospital_transfer.hospital_from_;
            tohospital.Text = RetriveData.Hospital_transfer.hospital_to_;
            date.Text = RetriveData.Hospital_transfer.date_.ToString();
            patientcombo1.Text = RetriveData.Hospital_transfer.patient_name_;
            filenumber.Text = RetriveData.Hospital_transfer.file_no_;
            label1.Text = RetriveData.Hospital_transfer.id_.ToString();
            RetriveData.closeconnection();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Hospital_transfer.search( dataGridView1);
            RetriveData.closeconnection();
           
        }

        private void patientcombo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void patientcombo1_SelectedValueChanged(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from patients where full_name=@full_name ";
            SqlParameter[] pram = new SqlParameter[1];
            pram[0] = new SqlParameter("@full_name",patientcombo1.Text);
           
            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                filenumber.Text=dr[18].ToString();

            }
            RetriveData.closeconnection();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            
        }

        private void Hospitalconverts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
