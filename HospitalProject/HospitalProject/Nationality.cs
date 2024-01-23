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
    public partial class Nationality : Form
    {
        public Nationality()
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
            nationalitycombo.Items.Clear();
            while (dr.Read())
            {
               nationalitycombo.Items.Add(dr[1].ToString());
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
                RetriveData.Nationality.save(nationalitytxt.Text);
                RetriveData.closeconnection();
                Validation.txtclear(this, groupBox1);
                bindnationality();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Nationality.delete(nationalitycombo.Text);
            RetriveData.closeconnection();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox4);
        }

        private void Nationality_Load(object sender, EventArgs e)
        {
            bindnationality();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nationality where nationality_name ='"+nationalitycombo.Text+"'";
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0],dr[1]);
                nationalitytxt.Text = dr[1].ToString();
                    }
            RetriveData.closeconnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nationality ";
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1]);
            }
            RetriveData.closeconnection();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Nationality_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox4);
        }
    }
}
