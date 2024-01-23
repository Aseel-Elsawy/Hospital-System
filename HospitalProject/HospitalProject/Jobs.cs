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
    public partial class Jobs : Form
    {
        public Jobs()
        {
            InitializeComponent();
        }
        #region bind job
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from jobs ";
            SqlDataReader dr = cmd.ExecuteReader();
           jobname.Items.Clear();
            while (dr.Read())
            {
              jobname.Items.Add(dr[2].ToString());
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
                RetriveData.Jobs.save(position.Text, jobtitle.Text);
                RetriveData.closeconnection();
                bindcombo();
                Validation.txtclear(this, groupBox1);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Jobs.delete(position.Text, jobname.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Jobs.search(jobname.Text, dataGridView1);
            position.Text = RetriveData.Jobs.position_;
            jobtitle.Text = RetriveData.Jobs.job_title_;

            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Jobs.search( dataGridView1);
            RetriveData.closeconnection();
        }

        private void Jobs_Load(object sender, EventArgs e)
        {
            bindcombo();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
          
        }

        private void Jobs_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
