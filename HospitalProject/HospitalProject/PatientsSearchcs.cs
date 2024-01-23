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
    public partial class PatientsSearchcs : Form
    {
        public PatientsSearchcs()
        {
            InitializeComponent();
        }
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
        private void PatientsSearchcs_Load(object sender, EventArgs e)
        {
            bindpatient();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            #region search
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from patients where full_name='" + patientcombo.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15], dr[16], dr[17], dr[18]);
            }

            RetriveData.closeconnection();
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Patients.search(dataGridView1);
            RetriveData.closeconnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Patients.delete(patientcombo.Text);
            RetriveData.closeconnection();
            bindpatient();
            Validation.txtclear(this, groupBox3);
        }
    }
}
