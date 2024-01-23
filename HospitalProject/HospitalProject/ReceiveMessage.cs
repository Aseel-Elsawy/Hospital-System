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
    public partial class ReceiveMessage : Form
    {
        public ReceiveMessage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region admin
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from administarion where user_name=@user and password=@pass ";
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@user", username.Text);
            pram[1] = new SqlParameter("@pass", password.Text);
            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                username1.Text = username.Text;

                RetriveData.closeconnection();

                return;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

                RetriveData.closeconnection();
            }

            #endregion
            #region submanager
            RetriveData.openconnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = RetriveData.con;
            cmd1.CommandText = "select * from sub_manager where user_name=@user and password=@pass ";
            SqlParameter[] pram1 = new SqlParameter[2];
            pram1[0] = new SqlParameter("@user", username.Text);
            pram1[1] = new SqlParameter("@pass", password.Text);
            cmd1.Parameters.AddRange(pram1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            if (dr1.HasRows)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                username1.Text = username.Text;

                RetriveData.closeconnection();
                return;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

                RetriveData.closeconnection();
            }

            #endregion
            #region employee
            RetriveData.openconnection();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = RetriveData.con;
            cmd2.CommandText = "select * from users where user_name=@user and password=@pass ";
            SqlParameter[] pram2 = new SqlParameter[2];
            pram2[0] = new SqlParameter("@user", username.Text);
            pram2[1] = new SqlParameter("@pass", password.Text);
            cmd2.Parameters.AddRange(pram2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (dr2.HasRows)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                username1.Text = username.Text;

                RetriveData.closeconnection();
                return;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;

                RetriveData.closeconnection();
            }
            #endregion
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from messages where [date]=@date and user_recieved=@user_recieved ";
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@date", date.Value.ToShortDateString());
            pram[1] = new SqlParameter("@user_recieved", username.Text);
            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            messagescombo.Items.Clear();
           while (dr.Read())
            {
                messagescombo.Items.Add(dr[1].ToString());               

            }
            RetriveData.closeconnection();
        }

        private void messagescombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from messages where [date]=@date and user_recieved=@user_recieved ";
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@date", date.Value.ToShortDateString());
            pram[1] = new SqlParameter("@user_recieved", username.Text);
            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            dr.Read();
            if (dr.HasRows)
            {
                username2.Text = dr[3].ToString();
                address.Text = dr[4].ToString();
                message.Text = dr[5].ToString();
                dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);

            }
            RetriveData.closeconnection();
        }

        private void ReceiveMessage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
