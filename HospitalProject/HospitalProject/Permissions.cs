using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalProject
{
    public partial class Permissions : Form
    {
        public Permissions()
        {
            InitializeComponent();
        }
        #region bind 
        private void bindcombo()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "Select * from permissions ";
            SqlDataReader dr = cmd.ExecuteReader();
            empcombo.Items.Clear();
            while (dr.Read())
            {
                empcombo.Items.Add(dr[10].ToString());
            }
            RetriveData.closeconnection();
        }
        #endregion
        private void button4_Click(object sender, EventArgs e)
        {
            #region admin
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from administarion where user_name=@user and password=@pass ";
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@user", usertxt1.Text);
            pram[1] = new SqlParameter("@pass", passtxt1.Text);
            cmd.Parameters.AddRange(pram);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                groupBox4.Visible = true;
              
              label9.Text = emptxt.Text;

                RetriveData.closeconnection();

                return;
            }
            else
            {
                
                RetriveData.closeconnection();
            }
            MessageBox.Show("User Not Found", "Permissions");

            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region submanager
            RetriveData.openconnection();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = RetriveData.con;
            cmd1.CommandText = "select * from sub_manager where user_name=@user  ";
            SqlParameter[] pram1 = new SqlParameter[1];
            pram1[0] = new SqlParameter("@user", emptxt.Text);
       
            cmd1.Parameters.AddRange(pram1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            dr1.Read();
            if (dr1.HasRows)
            {
                groupBox5.Visible = true;
                groupBox6.Visible = true;
              

                RetriveData.closeconnection();
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
            cmd2.CommandText = "select * from employees where user_name=@user  ";
            SqlParameter[] pram2 = new SqlParameter[1];
            pram2[0] = new SqlParameter("@user", emptxt.Text);
         
            cmd2.Parameters.AddRange(pram2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            if (dr2.HasRows)
            {
                groupBox5.Visible = true;
                groupBox6.Visible = true;
               

                RetriveData.closeconnection();
                return;
            }
            else
            {
               

                RetriveData.closeconnection();
            }
            MessageBox.Show("Employees Not Found", "Permissions");
            #endregion
        }

        private void Privileges_Load(object sender, EventArgs e)
        {
            bindcombo();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            #region save
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "insert into [permissions] (tickets,main_data,employee_admin,hospital_store,departments,[messages],pharmacy,reports,managment_admin,user_name)values('"+tickets.Checked+ "','"+main_data.Checked+ "','"+employees.Checked+ "','"+stores.Checked+ "','"+departments.Checked+ "','"+messages.Checked+ "','"+pharmacy.Checked+ "','"+reporst.Checked+ "','"+system_managment.Checked+"','"+emptxt.Text+"')";
            int aff = cmd.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Saved", "Permessions");
            }else
            {
                MessageBox.Show("failed", "Permessions");
            }
            RetriveData.closeconnection();
            bindcombo();
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region search
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from permissions where [user_name]='"+empcombo.Text+"'";
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                tickets.Checked = dr.GetBoolean(1);
                main_data.Checked = dr.GetBoolean(2);
                employees.Checked = dr.GetBoolean(3);
                stores.Checked = dr.GetBoolean(4);
                departments.Checked = dr.GetBoolean(5);
                messages.Checked = dr.GetBoolean(6);
                pharmacy.Checked = dr.GetBoolean(7);
                reporst.Checked = dr.GetBoolean(8);
                system_managment.Checked = dr.GetBoolean(9);

            }
            else {
                MessageBox.Show("Employee Not Found","Permissions");
                    }
            RetriveData.closeconnection();
            #endregion
        }

        private void button7_Click(object sender, EventArgs e)
        {
            #region update
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = " update permissions set tickets='"+tickets.Checked+"',main_data='"+main_data.Checked+"',employee_admin='"+employees.Checked+"',hospital_store='"+stores.Checked+"',departments='"+departments.Checked+"',messages='"+messages.Checked+"',pharmacy='"+pharmacy.Checked+"',reports='"+reporst.Checked+"',managment_admin='"+system_managment.Checked+"' where user_name='"+empcombo.Text+"'";
            int aff = cmd.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Updated", "Permessions");
            }
            else
            {
                MessageBox.Show("failed", "Permessions");
            }
            RetriveData.closeconnection();
            bindcombo();
            #endregion

        }

        private void button8_Click(object sender, EventArgs e)
        {
            #region delete
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = " delete from permissions where user_name='" + empcombo.Text + "'";
            int aff = cmd.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Deleted", "Permessions");
            }
            else
            {
                MessageBox.Show("failed", "Permessions");
            }
            RetriveData.closeconnection();
            bindcombo();
            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "insert into sub_manager(user_name,password)values('"+usertxt2.Text+"','"+passtxt2.Text+"')";
            int aff = cmd.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Saved", "Permessions");
            }
            else
            {
                MessageBox.Show("failed", "Permessions");
            }
            RetriveData.closeconnection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "insert into users(user_name,password)values('" + usertxt3.Text + "','" + passtxt3.Text + "')";
            int aff = cmd.ExecuteNonQuery();
            if (aff > 0)
            {
                MessageBox.Show("Saved", "Permessions");
            }
            else
            {
                MessageBox.Show("failed", "Permessions");
            }
            RetriveData.closeconnection();
        }
    }
}
