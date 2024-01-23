//using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class Operations : Form
    {
        public Operations()
        {
            InitializeComponent();
        }
        #region bindcombopatientfromoperation
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from operations";
            SqlDataReader dr = cmd.ExecuteReader();
          patientcombo2.Items.Clear();
            while (dr.Read())
            {
               patientcombo2.Items.Add(dr[7].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion

        #region bindcombodoctor
        private void binddoctor()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from doctors";
            SqlDataReader dr = cmd.ExecuteReader();
           surgeoncombo.Items.Clear();
            anethcombo.Items.Clear();
            while (dr.Read())
            {
                surgeoncombo.Items.Add(dr[3].ToString()); 
               anethcombo.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region bindpatient
        private void bindcombopatient()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from patients";
            SqlDataReader dr = cmd.ExecuteReader();
            patientcombo1.Items.Clear();
            while (dr.Read())
            {
                patientcombo1.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void clientname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.Operations.save(surgeoncombo.Text, anethcombo.Text, drugtxt.Text, DateTime.Parse(date.Text), operationname.Text, status.Text, patientcombo1.Text);
                RetriveData.closeconnection();
                bindcombo();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Operations.update(int.Parse(label1.Text) ,surgeoncombo.Text, anethcombo.Text, drugtxt.Text, DateTime.Parse(date.Text), operationname.Text, status.Text, patientcombo1.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Operations.delete( patientcombo2.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Operations.search(patientcombo2.Text,dataGridView1);
            label1.Text = RetriveData.Operations.id_.ToString();
            patientcombo1.Text = RetriveData.Operations.patient_name_;
            surgeoncombo.Text = RetriveData.Operations.doc1_name_;
            anethcombo.Text = RetriveData.Operations.doc2_name_;
            drugtxt.Text = RetriveData.Operations.drug_kind_;
            operationname.Text = RetriveData.Operations.operation_name_;
            date.Text = RetriveData.Operations.date_.ToString();
            status.Text = RetriveData.Operations.notes_;

            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Operations.searchall( dataGridView1);
            RetriveData.closeconnection();
        }

        private void Operations_Load(object sender, EventArgs e)
        {
            bindcombo();
            bindcombopatient();
            binddoctor();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Operations_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
