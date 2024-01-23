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
    public partial class SellingItemstohospital : Form
    {
        public SellingItemstohospital()
        {
            InitializeComponent();
        }
        #region bindcombo
        private void bindhospital()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from pharmacy_sell_hospital";
            SqlDataReader dr = cmd.ExecuteReader();
            medicinecombo1.Items.Clear();
            while (dr.Read())
            {
                medicinecombo1.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
#endregion
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
        private void calctotal()
        {
            Validation.calculations(this, groupBox4);
            double total_ = 0;
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
        private void SellingItemstohospital_Load(object sender, EventArgs e)
        {
            bindhospital();
            bindmedicine();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            #region fillgrid
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell vendor_name = new DataGridViewTextBoxCell();
            DataGridViewCell date = new DataGridViewTextBoxCell();
            DataGridViewCell item_name = new DataGridViewTextBoxCell();
            DataGridViewCell beneficiary_name = new DataGridViewTextBoxCell();
            DataGridViewCell quantity = new DataGridViewTextBoxCell();
            DataGridViewCell price = new DataGridViewTextBoxCell();
            DataGridViewCell total = new DataGridViewTextBoxCell();
            DataGridViewCell payed = new DataGridViewTextBoxCell();
            DataGridViewCell remained = new DataGridViewTextBoxCell();
            DataGridViewCell opponent = new DataGridViewTextBoxCell();
            row.Cells.Add(vendor_name);
            row.Cells.Add(date);
            row.Cells.Add(item_name);
            row.Cells.Add(beneficiary_name);
            row.Cells.Add(quantity);
            row.Cells.Add(price);
            row.Cells.Add(total);
            row.Cells.Add(payed);
            row.Cells.Add(remained);
            row.Cells.Add(opponent);
            row.Cells[0].Value = medicinecombo1.Text;
            row.Cells[1].Value = datetxt.Text;
            row.Cells[2].Value = medicinecombo.Text;
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
            RetriveData.pharmacy_sell_hospital.search(medicinecombo1.Text, dataGridView1);
         hospitaltxt.Text = RetriveData.pharmacy_sell_hospital.hospital_name_;
            medicinecombo.Text = RetriveData.pharmacy_sell_hospital.medicine_name_;
            datetxt.Text = RetriveData.pharmacy_sell_hospital.date_.ToString();
            benname.Text = RetriveData.pharmacy_sell_hospital.beneficiary_name_;
            quantitytxt.Text = RetriveData.pharmacy_sell_hospital.quantity_.ToString();
            pricetxt.Text = RetriveData.pharmacy_sell_hospital.price_.ToString();
            totaltxt.Text = RetriveData.pharmacy_sell_hospital.total_.ToString();
            payedtxt.Text = RetriveData.pharmacy_sell_hospital.payed_.ToString();
            remaintxt.Text = RetriveData.pharmacy_sell_hospital.remained_.ToString();
            opponenttxt.Text = RetriveData.pharmacy_sell_hospital.opponent_.ToString();
            label1.Text = RetriveData.pharmacy_sell_hospital.id_.ToString();

            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.pharmacy_sell_hospital.searchall(dataGridView1);
            RetriveData.closeconnection();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            Validation.suretxt(this, groupBox4);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.pharmacy_sell_hospital.save(hospitaltxt.Text, DateTime.Parse(datetxt.Text), medicinecombo.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
                RetriveData.closeconnection();
                bindhospital();
                Validation.txtclear(this, groupBox1);
                Validation.clearcalculations(this, groupBox4);
                Validation.calculations(this, groupBox4);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.pharmacy_sell_hospital.update(int.Parse(label1.Text),hospitaltxt.Text, DateTime.Parse(datetxt.Text), medicinecombo.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
            RetriveData.closeconnection();
            bindhospital();
            Validation.txtclear(this, groupBox1);
            Validation.clearcalculations(this, groupBox4);
            Validation.calculations(this, groupBox4);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.pharmacy_sell_hospital.delete(medicinecombo1.Text);
            RetriveData.closeconnection();
            bindhospital();
            Validation.txtclear(this, groupBox1);
            Validation.clearcalculations(this, groupBox4);
            Validation.txtclear(this, groupBox3);
            Validation.calculations(this, groupBox4);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           Validation.clearcalculations(this, groupBox4);
           // Validation.calculations(this, groupBox4);
        }

        private void SellingItemstohospital_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
            Validation.clearcalculations(this, groupBox4);
            Validation.txtclear(this, groupBox3);
        }

        private void totaltxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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

        private void payedtxt_TextChanged(object sender, EventArgs e)
        {
            calcremain();
        }

        private void quantitytxt_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
