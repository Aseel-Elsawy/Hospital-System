//using DevExpress.XtraRichEdit.Layout.Export;
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
    public partial class BuyingItemshospital : Form
    {
        public BuyingItemshospital()
        {
            InitializeComponent();
        }
        #region bindcomboitems
        private void binditems()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from store_buy";
            SqlDataReader dr = cmd.ExecuteReader();
            itemcombo.Items.Clear();
            while (dr.Read())
            {
                itemcombo.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        #region binditems
        private void binditems1()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from items";
            SqlDataReader dr = cmd.ExecuteReader();
            itmtxt.Items.Clear();
            while (dr.Read())
            {
                itmtxt.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void calctotal()
        {
            Validation.calculations(this, groupBox4);
            double total_ =0;
            total_ = double.Parse(quantitytxt.Text) * double.Parse(pricetxt.Text);
            totaltxt.Text = total_.ToString();
        }
        private void calcremain()
        {
            Validation.calculations(this, groupBox4);
            if (double.Parse(payedtxt.Text) < double.Parse(totaltxt.Text))
            {
                remaintxt.Text = (double.Parse(totaltxt.Text) - double.Parse(payedtxt.Text)).ToString();
            }
            else
            {
                MessageBox.Show("Total is Less than Payed", "Error");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            #region fillgrid
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell hospital_name = new DataGridViewTextBoxCell();
            DataGridViewCell date = new DataGridViewTextBoxCell();
            DataGridViewCell item_name = new DataGridViewTextBoxCell();
            DataGridViewCell beneficiary_name = new DataGridViewTextBoxCell();
            DataGridViewCell quantity = new DataGridViewTextBoxCell();
            DataGridViewCell price = new DataGridViewTextBoxCell();
            DataGridViewCell total = new DataGridViewTextBoxCell();
            DataGridViewCell payed = new DataGridViewTextBoxCell();
            DataGridViewCell remained = new DataGridViewTextBoxCell();
            DataGridViewCell opponent = new DataGridViewTextBoxCell();
            row.Cells.Add(hospital_name);
            row.Cells.Add(date);
            row.Cells.Add(item_name);
            row.Cells.Add(beneficiary_name);
            row.Cells.Add(quantity);
            row.Cells.Add(price);
            row.Cells.Add(total);
            row.Cells.Add(payed);
            row.Cells.Add(remained);
            row.Cells.Add(opponent);
            row.Cells[0].Value = hospitalname.Text;
            row.Cells[1].Value = datetxt.Text;
            row.Cells[2].Value = itmtxt.Text;
            row.Cells[3].Value = benname.Text;
            row.Cells[4].Value = quantitytxt.Text;
            row.Cells[5].Value = pricetxt.Text;
            row.Cells[6].Value = totaltxt.Text;
            row.Cells[7].Value = payedtxt.Text;
            row.Cells[8].Value = remaintxt.Text;
            row.Cells[9].Value = opponenttxt.Text;
            dataGridView1.Rows.Add(row);
            #endregion

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.store_buy.search(itemcombo.Text, dataGridView1);
            label1.Text = RetriveData.store_buy.id_.ToString();
           hospitalname.Text = RetriveData.store_buy.hospital_name_;
            datetxt.Text = RetriveData.store_buy.date_.ToString();
            itmtxt.Text = RetriveData.store_buy.item_name_;
            benname.Text = RetriveData.store_buy.beneficiary_name_;
            quantitytxt.Text = RetriveData.store_buy.quantity_.ToString();
            pricetxt.Text = RetriveData.store_buy.price_.ToString();
            totaltxt.Text = RetriveData.store_buy.total_.ToString();
            payedtxt.Text = RetriveData.store_buy.payed_.ToString();
            remaintxt.Text = RetriveData.store_buy.remained_.ToString();
            opponenttxt.Text = RetriveData.store_buy.opponent_.ToString();
            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.store_buy.searchall(dataGridView1);
            RetriveData.closeconnection();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
  Validation.suretxt(this, groupBox1);
            Validation.suretxt(this, groupBox4);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.store_buy.save(hospitalname.Text, DateTime.Parse(datetxt.Text), itmtxt.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
                RetriveData.closeconnection();
                binditems();
                Validation.txtclear(this, groupBox1);
              //  Validation.txtclear(this, groupBox4);
                Validation.calculations(this, groupBox4);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.store_buy.update(int.Parse(label1.Text), hospitalname.Text, DateTime.Parse(datetxt.Text), itmtxt.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
            RetriveData.closeconnection();
            binditems();
            Validation.txtclear(this, groupBox1);
          //  Validation.txtclear(this, groupBox4);
            Validation.calculations(this, groupBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            RetriveData.openconnection();
            RetriveData.store_buy.delete(itemcombo.Text);
            RetriveData.closeconnection();
            binditems();
            Validation.txtclear(this, groupBox1);
         //   Validation.txtclear(this, groupBox4); 
            Validation.txtclear(this, groupBox3);
            Validation.calculations(this, groupBox4);
        }

        private void BuyingItemshospital_Load(object sender, EventArgs e)
        {
            binditems();
            binditems1();
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
            Validation.txtclear(this, groupBox1);
           // Validation.txtclear(this, groupBox4);
            Validation.calculations(this, groupBox4);
        }

        private void BuyingItemshospital_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           // Validation.txtclear(this, groupBox4);
            Validation.txtclear(this, groupBox3);
            
        }

        private void quantitytxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
          

        }

        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            calctotal();

        }

        private void pricetxt_TextChanged(object sender, EventArgs e)
        {
            calctotal();
        }

        private void payedtxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void payedtxt_TextChanged(object sender, EventArgs e)
        {
            calcremain();
          
        }

        private void pricetxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
