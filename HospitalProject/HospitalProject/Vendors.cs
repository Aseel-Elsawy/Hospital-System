using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Vendors : Form
    {
        public Vendors()
        {
            InitializeComponent();
        }
        #region bindcombo
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from vendors";
            SqlDataReader dr = cmd.ExecuteReader();
            vendorcombo.Items.Clear();
            while (dr.Read())
            {
                vendorcombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void Vendors_Load(object sender, EventArgs e)
        {
            bindcombo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.vendors.save(nametxt.Text, addresstxt.Text, phonetxt.Text, mobtxt.Text, emailtxt.Text, notestxt.Text);
                RetriveData.closeconnection();
                bindcombo();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.vendors.update(int.Parse(label8.Text), nametxt.Text, addresstxt.Text, phonetxt.Text, mobtxt.Text, emailtxt.Text, notestxt.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.vendors.delete(vendorcombo.Text);
            RetriveData.closeconnection();
            bindcombo();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.vendors.search(vendorcombo.Text, dataGridView1);
            label8.Text = RetriveData.vendors.__id.ToString();
            nametxt.Text = RetriveData.vendors.ven_name_;
            phonetxt.Text = RetriveData.vendors.phone_;
            mobtxt.Text = RetriveData.vendors.mobile_;
            emailtxt.Text = RetriveData.vendors.email_;
            notestxt.Text = RetriveData.vendors.notes_;
            addresstxt.Text = RetriveData.vendors.address_;
            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            #region search

            RetriveData.openconnection();
            RetriveData.vendors.search(dataGridView1);
            RetriveData.closeconnection();

            #endregion
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Vendors_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void phonetxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
