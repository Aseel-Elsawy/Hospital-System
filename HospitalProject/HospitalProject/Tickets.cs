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
using static HospitalProject.RetriveData;

namespace HospitalProject
{
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();
        }
        #region bindcomboclinics
        private void bindcomboclinics()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from clinics";
            SqlDataReader dr = cmd.ExecuteReader();
            cliniccombo.Items.Clear();
            while (dr.Read())
            {
                cliniccombo.Items.Add(dr[1].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void button7_Click(object sender, EventArgs e)
        {

            Validation.suretxt(this, groupBox1);
            int z=0;
            if (z == Validation.i)
            {
                RetriveData.openconnection();
                RetriveData.tickets.Save(int.Parse(codetxt.Text), nametxt.Text, agetxt.Text, addrstxt.Text, phonetxt.Text, cliniccombo.Text, DateTime.Parse(date.Text));
                RetriveData.closeconnection();
                Validation.txtclear(this, groupBox1);
            }
           
          
           
        
            
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            bindcomboclinics();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }

        private void Tickets_FormClosed(object sender, FormClosedEventArgs e)
        {
            Validation.txtclear(this, groupBox1);
        }
    }
}
