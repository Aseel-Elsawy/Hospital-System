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
    public partial class Pharmacy : Form
    {
        public Pharmacy()
        {
            InitializeComponent();
        }
        #region bindmedicine
        private void bindmedicine()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from medicine";
            SqlDataReader dr = cmd.ExecuteReader();
            medicinecombo.Items.Clear();
            while (dr.Read())
            {
                medicinecombo.Items.Add(dr[1].ToString());
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
                RetriveData.Medicine_items.save(medicinename.Text, DateTime.Parse(date.Text), DateTime.Parse(date1.Text), int.Parse(quantity.Text), howtouse.Text);
                RetriveData.closeconnection();
                bindmedicine();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Medicine_items.update(int.Parse(label1.Text), medicinename.Text, DateTime.Parse(date.Text), DateTime.Parse(date1.Text), int.Parse(quantity.Text), howtouse.Text);
            RetriveData.closeconnection();
            bindmedicine();
            Validation.txtclear(this, groupBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.Medicine_items.delete( medicinename.Text);
            RetriveData.closeconnection();
            bindmedicine();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Medicine_items.search(medicinecombo.Text, dataGridView1);
            label1.Text = RetriveData.Medicine_items.id_.ToString();
            medicinename.Text = RetriveData.Medicine_items.medicine_name_;
            date.Text = RetriveData.Medicine_items.production_date_.ToString();
            date1.Text = RetriveData.Medicine_items.expired_date_.ToString();
            quantity.Text = RetriveData.Medicine_items.quantity_.ToString();
            howtouse.Text = RetriveData.Medicine_items.notes_;
            RetriveData.closeconnection();
        }

        private void Pharmacy_Load(object sender, EventArgs e)
        {
            bindmedicine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.Medicine_items.searchall(dataGridView1);
            RetriveData.closeconnection();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }
    }
}
