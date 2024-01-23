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
    public partial class SellMedicineToPatient : Form
    {
        public SellMedicineToPatient()
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
        #region bindpatientfrompharmacy
        private void bindpatient1()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from pharmacy_sales_patient";
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

        private void button10_Click(object sender, EventArgs e)
        {
            Validation.suretxt(this, groupBox1);
            Validation.suretxt(this, groupBox4);
            int z = 0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.pharmacy_sales_patient.save(patientcombo.Text, DateTime.Parse(datetxt.Text), medicinecombo.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
                RetriveData.closeconnection();
                bindpatient1();
                Validation.txtclear(this, groupBox1);
               // Validation.txtclear(this, groupBox4);
                Validation.calculations(this, groupBox4);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.pharmacy_sales_patient.update(int.Parse(label1.Text) ,patientcombo.Text, DateTime.Parse(datetxt.Text), medicinecombo.Text, benname.Text, int.Parse(quantitytxt.Text), int.Parse(pricetxt.Text), int.Parse(totaltxt.Text), int.Parse(payedtxt.Text), int.Parse(remaintxt.Text), int.Parse(opponenttxt.Text));
            RetriveData.closeconnection();
            bindpatient1();
            Validation.txtclear(this, groupBox1);
          //  Validation.txtclear(this, groupBox4);
            Validation.calculations(this, groupBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            RetriveData.pharmacy_sales_patient.delete( medicinecombo1.Text);
            RetriveData.closeconnection();
            bindpatient1();
            Validation.txtclear(this, groupBox1);
           // Validation.txtclear(this, groupBox4);
            Validation.txtclear(this, groupBox3);
            Validation.calculations(this, groupBox4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.pharmacy_sales_patient.search(medicinecombo1.Text,dataGridView1);
            patientcombo.Text = RetriveData.pharmacy_sales_patient.patient_name_;
            medicinecombo.Text = RetriveData.pharmacy_sales_patient.medicine_name_;
            datetxt.Text = RetriveData.pharmacy_sales_patient.date_.ToString();
            benname.Text = RetriveData.pharmacy_sales_patient.beneficiary_name_;
            quantitytxt.Text = RetriveData.pharmacy_sales_patient.quantity_.ToString();
            pricetxt.Text = RetriveData.pharmacy_sales_patient.price_.ToString();
            totaltxt.Text = RetriveData.pharmacy_sales_patient.total_.ToString();
            payedtxt.Text = RetriveData.pharmacy_sales_patient.payed_.ToString();
            remaintxt.Text = RetriveData.pharmacy_sales_patient.remained_.ToString();
            opponenttxt.Text = RetriveData.pharmacy_sales_patient.opponent_.ToString();
            label1.Text = RetriveData.pharmacy_sales_patient.id_.ToString();

            RetriveData.closeconnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            RetriveData.pharmacy_sales_patient.searchall( dataGridView1);
            RetriveData.closeconnection();
        }

        private void SellMedicine_Load(object sender, EventArgs e)
        {
            bindpatient();
            bindmedicine();
            bindpatient1();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
           // Validation.txtclear(this, groupBox4);
            Validation.calculations(this, groupBox4);
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
