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
    public partial class ItemsDetails : Form
    {
        public ItemsDetails()
        {
            InitializeComponent();
        }
        #region binditems
        private void binditems()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from items";
            SqlDataReader dr = cmd.ExecuteReader();
           itmcombo.Items.Clear();
            while (dr.Read())
            {
                itmcombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ItemsDetails_Load(object sender, EventArgs e)
        {
            binditems();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.store_items.search(itmcombo.Text, dataGridView1);
            label1.Text = RetriveData.store_items.id_.ToString();
           itmname.Text = RetriveData.store_items.item_name_;
            date.Text = RetriveData.store_items.production_date_.ToString();
            purpose.Text = RetriveData.store_items.purpose_;
            quantity.Text = RetriveData.store_items.quantity_.ToString();
          qualities.Text = RetriveData.store_items.notes_;
            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.store_items.searchall(dataGridView1);
            RetriveData.closeconnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.store_items.save(itmname.Text, DateTime.Parse(date.Text), purpose.Text, int.Parse(quantity.Text), qualities.Text);
                RetriveData.closeconnection();
                binditems();
                Validation.txtclear(this, groupBox1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.store_items.update(int.Parse(label1.Text), itmname.Text, DateTime.Parse(date.Text), purpose.Text, int.Parse(quantity.Text),qualities.Text);
            RetriveData.closeconnection();
            binditems();
            Validation.txtclear(this, groupBox1);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.store_items.delete(itmcombo.Text);
            RetriveData.closeconnection();
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
          
        }

        private void ItemsDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.txtclear(this, groupBox3);
        }
    }
}
