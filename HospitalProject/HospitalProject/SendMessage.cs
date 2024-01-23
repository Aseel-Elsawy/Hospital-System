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
//using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace HospitalProject
{
    public partial class SendMessage : Form
    {
        public SendMessage()
        {
            InitializeComponent();
        }
        #region save
      private void save()
        {
            RetriveData.openconnection();
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = RetriveData.con;
            cmd4.CommandText = "insert into [messages]([date],user_sent,user_recieved,[address],[message],[time])values(@date,@user_sent,@user_recieved,@address,@message,@time)";
            SqlParameter[] pram4 = new SqlParameter[6];
            pram4[0] = new SqlParameter("@date",date.Value.ToShortDateString());
            pram4[1] = new SqlParameter("@user_sent",username.Text);
            pram4[2] = new SqlParameter("@user_recieved", username2.Text);
            pram4[3] = new SqlParameter("@address", address.Text);
            pram4[4] = new SqlParameter("@message", message.Text);
            pram4[5] = new SqlParameter("@time", date.Value.TimeOfDay);
            cmd4.Parameters.AddRange(pram4);
            int aff = cmd4.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Sent", "Messages");
                RetriveData.closeconnection();
            }
            else
            {
                MessageBox.Show("Failed", "Messages");
                RetriveData.closeconnection();

            }
        }
        #endregion
        private void button4_Click(object sender, EventArgs e)
        {
            #region admin
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData. con;
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
                groupBox2.Visible =false;
               
                RetriveData.closeconnection();
            }
          
            #endregion
            #region submanager
            RetriveData.openconnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = RetriveData. con;
            cmd1.CommandText = "select * from sub_manager where user_name=@user and password=@pass ";
            SqlParameter[] pram1 = new SqlParameter[2];
            pram1[0] = new SqlParameter("@user", username.Text);
            pram1[1] = new SqlParameter("@pass",password.Text);
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
            cmd2.Connection =RetriveData.con;
            cmd2.CommandText = "select * from users where user_name=@user and password=@pass ";
            SqlParameter[] pram2 = new SqlParameter[2];
            pram2[0] = new SqlParameter("@user", username.Text);
            pram2[1] = new SqlParameter("@pass",password.Text);
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

        private void SendMessage_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            #region admin
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from administarion where user_name=@user  ";
            SqlParameter[] pram = new SqlParameter[1];
            pram[0] = new SqlParameter("@user", username2.Text);

            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                RetriveData.closeconnection();
                save();

              

                return;
            }
            else
            {
               
                RetriveData.closeconnection();
                
            }

            #endregion
            #region submanager
            RetriveData.openconnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = RetriveData.con;
            cmd1.CommandText = "select * from sub_manager where user_name=@user  ";
            SqlParameter[] pram1 = new SqlParameter[1];
            pram1[0] = new SqlParameter("@user", username2.Text);

            cmd1.Parameters.AddRange(pram1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            if (dr1.HasRows)
            {
                RetriveData.closeconnection();
                save();
               
                return;
            }
            else
            {
               

                RetriveData.closeconnection();
             
            }

            #endregion
            #region employee
            RetriveData.openconnection();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = RetriveData.con;
            cmd2.CommandText = "select * from users where user_name=@user ";
            SqlParameter[] pram2 = new SqlParameter[1];
            pram2[0] = new SqlParameter("@user", username2.Text);

            cmd2.Parameters.AddRange(pram2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (dr2.HasRows)
            {
                RetriveData.closeconnection();
                save();
 
                return;
            }
            else
            {
               

                RetriveData.closeconnection();
             
            }
            MessageBox.Show("No User Found", "Messages");
            #endregion
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ReceiveMessage rm = new ReceiveMessage();
            rm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText="select * from [messages] where user_sent='"+username.Text+"'";
            dataGridView1.Rows.Clear();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);

            }
            RetriveData.closeconnection();
        }
    }
}
