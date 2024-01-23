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
    public partial class SearchNurses : Form
    {
        public SearchNurses()
        {
            InitializeComponent();
        }
        #region bindnurse
        private void bindnurse()
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nurses";
            SqlDataReader dr = cmd.ExecuteReader();
            nursecombo.Items.Clear();
            while (dr.Read())
            {
                nursecombo.Items.Add(dr[3].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            #region search
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from nurses where full_name='" + nursecombo.Text + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15], dr[16], dr[17]);
            }

            RetriveData.closeconnection();
            #endregion
        }

        private void SearchNurses_Load(object sender, EventArgs e)
        {
            bindnurse();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region search
            RetriveData.openconnection();
            RetriveData.Nurses.search(dataGridView1);
            RetriveData.closeconnection();
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {

            RetriveData.openconnection();
            RetriveData.Nurses.delete(nursecombo.Text);
            RetriveData.closeconnection();
            bindnurse();
            Validation.txtclear(this, groupBox3);
        }
    }
}
