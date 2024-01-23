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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        #region check status

        private void check()
        {
            RetriveData.openconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = RetriveData.con;
            cmd.CommandText = "select * from permissions where [user_name]='" + usertxt.Text + "'";
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
                RetriveData.closeconnection();
            }
            else
            {
                MessageBox.Show("Employee Not Found", "Permissions");
                RetriveData.closeconnection();
                return;
            }

        }
        #endregion

        #region check permissions
        private void checkpermissions()
        {


            if (tickets.Checked == true)
            {
                ticketsToolStripMenuItem.Enabled = true;
            }
            else
            {
                ticketsToolStripMenuItem.Enabled =false;
            }
            if (main_data.Checked == true)
            {
                mainDatToolStripMenuItem.Enabled = true;

            }
            else
            {
                mainDatToolStripMenuItem.Enabled = false;

            }
            if (employees.Checked == true)
            {
                employeesToolStripMenuItem.Enabled = true;
            }
            else
            {
                employeesToolStripMenuItem.Enabled = false;
            }
            if (stores.Checked == true)
            {
                storesToolStripMenuItem.Enabled = true;
            }
            else
            {
                storesToolStripMenuItem.Enabled = false;
            }
            if (departments.Checked == true)
            {
                departmentsToolStripMenuItem.Enabled = true;
            }
            else
            {
                departmentsToolStripMenuItem.Enabled = false;
            }
            if (messages.Checked == true)
            {
                messagesToolStripMenuItem.Enabled = true;
            }
            else
            {
                messagesToolStripMenuItem.Enabled = false;
            }
            if (pharmacy.Checked == true)
            {
                pharmacyToolStripMenuItem.Enabled = true;
            }
            else
            {
                pharmacyToolStripMenuItem.Enabled = false;
            }
            if (reporst.Checked == true)
            {
                reportsToolStripMenuItem.Enabled = true;
            }
            else
            {
                reportsToolStripMenuItem.Enabled = false;
            }
            if (system_managment.Checked == true)
            {
                systemManagmentToolStripMenuItem.Enabled = true;
            }
            else
            {
                systemManagmentToolStripMenuItem.Enabled =false;
            }
        }
        #endregion

        private void mainDatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Tickets tk = new Tickets();
            tk.MdiParent = this;
            tk.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
           

        }

        private void clinicsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clinics cl = new Clinics();
            cl.MdiParent = this;
            cl.Show();

        }

        private void nationalityToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Nationality nl = new Nationality();
            nl.MdiParent = this;
            nl.Show();
        }

        private void specilizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Specialization sp = new Specialization();
           sp.MdiParent = this;
           sp.Show();
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Doctors dr = new Doctors();
            dr.MdiParent = this;
            dr.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients cl = new Clients();
            cl.MdiParent = this;
            cl.Show();
        }

        private void employeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employees emp = new Employees();
            emp.MdiParent = this;
            emp.Show();
        }

        private void nursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Nurses sn = new Nurses();
            sn.MdiParent = this;
            sn.Show();
        }

        private void enrollItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsDetails im = new ItemsDetails();
            im.MdiParent = this;
            im.Show();
        }

        private void sellingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selling_Items_vendors si = new selling_Items_vendors();
            si.MdiParent = this;
            si.Show();
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operations op = new Operations();
            op.MdiParent = this;
            op.Show();
        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendMessage sm = new SendMessage();
            sm.MdiParent = this;
            sm.Show();
        }

        private void recieveMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveMessage rm = new ReceiveMessage();
            rm.MdiParent = this;
            rm.Show();
        }

        private void sellingMedicineToPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellMedicineToPatient sm = new SellMedicineToPatient();
            sm.MdiParent = this;
            sm.Show();
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendors vn = new Vendors();
            vn.MdiParent = this;
            vn.Show();
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Patients pt = new Patients();
            pt.MdiParent = this;
            pt.Show();
        }

        private void hospitalTransformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hospitalconverts hc = new Hospitalconverts();
            hc.MdiParent = this;
            hc.Show();
        }

        private void testsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medical_examinations mx = new medical_examinations();
            mx.MdiParent = this;
            mx.Show();
        }

        private void jobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jobs jb = new Jobs();
            jb.MdiParent = this;
            jb.Show();

        }

        private void sellingMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellingItemstohospital sl = new SellingItemstohospital();
            sl.MdiParent=this;
            sl.Show();
        }

        private void buyingMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyMedicine bm = new BuyMedicine();
            bm.MdiParent = this;
            bm.Show();

        }

        private void enrollMedicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Pharmacy ph = new Pharmacy();
            ph.MdiParent = this;
            ph.Show();

        }

        private void buyingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuyingItemshospital bh = new BuyingItemshospital();
            bh.MdiParent = this;
            bh.Show();
        }

        private void systemManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permissions pg = new Permissions();
            pg.MdiParent = this;
            pg.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region suredata
            if (usertxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            if (passtxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            #endregion
            #region User
            RetriveData.openconnection();
            RetriveData.Login.admin(usertxt.Text, passtxt.Text);
            int z;
            
            z = RetriveData.Login.i;
            if (z == 0)
            {
                ticketsToolStripMenuItem.Enabled = true;

                MainDataToolStripMenuItem.Enabled = true;


                employeesToolStripMenuItem.Enabled = true;

                storesToolStripMenuItem.Enabled = true;


                departmentsToolStripMenuItem.Enabled = true;



                messagesToolStripMenuItem.Enabled = true;


                pharmacyToolStripMenuItem.Enabled = true;

                reportsToolStripMenuItem.Enabled = true;


                systemManagmentToolStripMenuItem.Enabled = true;

                groupBox1.Visible = false;
               
            }
            RetriveData.closeconnection();

            Validation.txtclear(this, groupBox1);
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            check();
            checkpermissions();
            #region suredata
            if (usertxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            if (passtxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            #endregion
            #region User
            RetriveData.openconnection();
            RetriveData.Login.employee(usertxt.Text, passtxt.Text);
            groupBox1.Visible = false;
            RetriveData.closeconnection();
            Validation.txtclear(this, groupBox1);
        
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check();
            checkpermissions();
            #region suredata
            if (usertxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            if (passtxt.Text == "")
            {
                MessageBox.Show("Please Enter Correct Data ", "Login");
                return;
            }
            #endregion
            #region User
            RetriveData.openconnection();
            RetriveData.Login.submanager(usertxt.Text, passtxt.Text);
            groupBox1.Visible = false;
            RetriveData.closeconnection();
            Validation.txtclear(this, groupBox1);
        
            #endregion
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                button2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                button3.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                button4.Visible = false;
            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
            }

            if (checkBox3.Checked == false)
            {
                button2.Visible = false;
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                button2.Visible = false;
                button4.Visible = false;
                button3.Visible = true;
            }

            if (checkBox2.Checked == false)
            {
                button3.Visible = false;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = true;
            }

            if (checkBox1.Checked == false)
            {
                button4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ticketsToolStripMenuItem.Enabled = false;

            MainDataToolStripMenuItem.Enabled = false;


            employeesToolStripMenuItem.Enabled = false;

            storesToolStripMenuItem.Enabled = false;


            departmentsToolStripMenuItem.Enabled = false;



            messagesToolStripMenuItem.Enabled = false;


            pharmacyToolStripMenuItem.Enabled = false;

            reportsToolStripMenuItem.Enabled = false;


            systemManagmentToolStripMenuItem.Enabled = false;

            groupBox1.Visible = true;
            Validation.txtclear(this, groupBox1);

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ticketsToolStripMenuItem.Enabled = false;

            MainDataToolStripMenuItem.Enabled = false;


            employeesToolStripMenuItem.Enabled = false;

            storesToolStripMenuItem.Enabled = false;


            departmentsToolStripMenuItem.Enabled = false;



            messagesToolStripMenuItem.Enabled = false;


            pharmacyToolStripMenuItem.Enabled = false;

            reportsToolStripMenuItem.Enabled = false;


            systemManagmentToolStripMenuItem.Enabled = false;

            groupBox1.Visible = true;
            Validation.txtclear(this, groupBox1);

        }
    }
}
