using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Deployment.Internal;
using System.Xml;
using static HospitalProject.RetriveData;
//using DevExpress.XtraEditors.Filtering;
using static HospitalProject.RetriveData.Doctors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Reflection;
//using DevExpress.Internal.WinApi;
using System.Net;
using System.ComponentModel;
using System.Data.Linq.Mapping;
//using DevExpress.XtraPrinting;
//using DevExpress.XtraEditors.Filtering.Templates;
//using DevExpress.ClipboardSource.SpreadsheetML;
using System.IO;
using System.Security.Cryptography.X509Certificates;
//using DevExpress.XtraSpellChecker.Parser;
//using DevExpress.XtraBars.ToastNotifications;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HospitalProject
{
    public static class RetriveData
    {
        #region connection_string
        public static SqlConnection con = new SqlConnection($@"Server=DESKTOP-678O052\Aseel;Database=hospital;User Id=sa;Password=samah;");

        #endregion
        #region open_connection
        public static void openconnection()
        {
            con.Open();
        }
        #endregion
        #region close_connection
        public static void closeconnection()
        {
            con.Close();
        }
        #endregion
       
        public struct Login
        {
            public static int i;
            #region admin
            public static void admin(string user, string pass)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from administarion where user_name=@user and password=@pass ";
                SqlParameter[] pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@user", user);
                pram[1] = new SqlParameter("@pass", pass);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                   
                    i = 0;

                }
                else
                {
                    MessageBox.Show("No Account Found", "login");
                    i = 1;
                }
            }
            #endregion
            #region submanager
            public static void submanager(string user, string pass)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from sub_manager where user_name=@user and password=@pass ";
                SqlParameter[] pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@user", user);
                pram[1] = new SqlParameter("@pass", pass);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                }
                else
                {
                    MessageBox.Show("No Account Found", "login");
                }
            }
            #endregion
            #region employee
            public static void employee(string user, string pass)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from users where user_name=@user and password=@pass ";
                SqlParameter[] pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@user", user);
                pram[1] = new SqlParameter("@pass", pass);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {

                }
                else
                {
                    MessageBox.Show("No Account Found", "login");
                }
            }
            #endregion
        }
        public struct Clinic
        {

            public static int id;
            public static string clinic_name_;
            public static string specilization_;
            #region savedata
            public static void save(string clinic_name, string specilization)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into clinics (clinic_name,specialization) values(@clinic_name ,@specilization)";
                SqlParameter[] prams = new SqlParameter[2];
                prams[0] = new SqlParameter("@clinic_name", clinic_name);
                prams[1] = new SqlParameter("@specilization", specilization);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Clinics");

                }
                else
                {
                    MessageBox.Show("Failed", "Clinics");

                }

            }
            #endregion
            #region search
            public static void search(string clinicname__, DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from clinics where clinic_name=@clinic_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@clinic_name", clinicname__);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                if (dr.HasRows == true)
                {
                    id = int.Parse(dr[0].ToString());
                    clinic_name_ = dr[1].ToString();
                    specilization_ = dr[2].ToString();
                    dg.Rows.Add(dr[0], dr[1], dr[2]);
                }
                dr.Close();

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from clinics";

                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    dg.Rows.Add(dr[0], dr[1], dr[2]);
                }
            }
            #endregion
            #region SearchClinicFromTicket
            public static void SearchClinetFromTicket(string tk_clinic, string tk_name, DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from tickets where tk_clinic=@tk_clinic ";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@tk_clinic", tk_clinic);

                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dg.Rows.Add(dr[2], dr[3], dr[5], dr[1], dr[4]);
                }

            }
            #endregion
            #region deletePatient
            public static void deletepatient(string tk_clinic, string tk_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from tickets where tk_clinic=@tk_clinic and tk_name=@tk_name";
                SqlParameter[] prams = new SqlParameter[2];
                prams[0] = new SqlParameter("@tk_clinic", tk_clinic);
                prams[1] = new SqlParameter("@tk_name", tk_name);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Clinics");

                }
                else
                {
                    MessageBox.Show("Failed", "Clinics");

                }
            }


            #endregion
            #region delete
            public static void delete(int id)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from clinics where id=@id";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Clinics");

                }
                else
                {
                    MessageBox.Show("Failed", "Clinics");
                }
            }
            #endregion
        }
        public struct Clients
        {
            public static int __id;
            public static string client_name_;
            public static string address_;
            public static string phone_;
            public static string mobile_;
            public static string email_;
            public static string notes_;
            #region save
            public static void save(string client_name, string address, string phone, string mobile, string email, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into clients (client_name,[address],phone,mobile,email,notes) values(@client_name,@address,@phone,@mobile,@email,@notes)";
                SqlParameter[] pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@client_name", client_name);
                pram[1] = new SqlParameter("@address", address);
                pram[2] = new SqlParameter("@phone", phone);
                pram[3] = new SqlParameter("@mobile", mobile);
                pram[4] = new SqlParameter("@email", email);
                pram[5] = new SqlParameter("@notes", notes);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Clients");

                }
                else
                {
                    MessageBox.Show("Failed", "Clients");

                }

            }
            #endregion
            #region update
            public static void update(int id, string client_name, string address, string phone, string mobile, string email, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update clients set client_name=@client_name,[address]=@address,phone=@phone,mobile=@mobile,email=@email,notes=@notes  where id=@id";
                SqlParameter[] pram = new SqlParameter[7];
                pram[0] = new SqlParameter("@client_name", client_name);
                pram[1] = new SqlParameter("@address", address);
                pram[2] = new SqlParameter("@phone", phone);
                pram[3] = new SqlParameter("@mobile", mobile);
                pram[4] = new SqlParameter("@email", email);
                pram[5] = new SqlParameter("@notes", notes);
                pram[6] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Clients");

                }
                else
                {
                    MessageBox.Show("Updated", "Clients");

                }

            }
            #endregion
            #region delete
            public static void delete(string client_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from clients where client_name=@client_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@client_name", client_name);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Clients");

                }
                else
                {
                    MessageBox.Show("Deleted", "Clients");

                }
            }

            #endregion
            #region search
            public static void search(string client_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from clients where client_name=@client_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@client_name", client_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    __id = int.Parse(dr[0].ToString());
                    client_name_ = dr[1].ToString();
                    address_ = dr[2].ToString();
                    phone_ = dr[3].ToString();
                    mobile_ = dr[4].ToString();
                    email_ = dr[5].ToString();
                    notes_ = dr[6].ToString();
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }

            }
            #endregion
            #region searchall
            public static void search(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from clients ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }

            }
            #endregion

        }
        public struct Doctors
        {
            public static int id__;
            public static int doctor_id_;
            public static string specialization_;
            public static string full_name_;
            public static string first_name_;
            public static string last_name_;
            public static DateTime dateof_birth_;
            public static string gender_;
            public static string mobile_;
            public static string phone_;
            public static DateTime work_date_;
            public static string nationality_;
            public static string email_;
            public static string blood_type_;
            public static string national_id_;
            public static string placeof_birth_;
            public static string marital_status_;
            public static string notes_;
            #region savedata
            public static void save(int doctor_id, string specialization, string full_name, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
"insert into  doctors(doctor_id,specialization,full_name,first_name,last_name,dateof_birth,gender,mobile,phone,work_date,nationality,email,\r\nblood_type,national_id,placeof_birth,marital_status,notes) values\r\n(@doctor_id,@specialization,@full_name,@first_name,@last_name,@dateof_birth,@gender,@mobile,@phone,@work_date,@nationality,@email,\r\n@blood_type,@national_id,@placeof_birth,@marital_status,@notes)";
                SqlParameter[] prams = new SqlParameter[17];
                prams[0] = new SqlParameter("@doctor_id", doctor_id);
                prams[1] = new SqlParameter("@specialization", specialization);
                prams[2] = new SqlParameter("@full_name", full_name);
                prams[3] = new SqlParameter("@first_name", first_name);
                prams[4] = new SqlParameter("@last_name", last_name);
                prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                prams[6] = new SqlParameter("@gender", gender);
                prams[7] = new SqlParameter("@mobile", mobile);
                prams[8] = new SqlParameter("@phone", phone);
                prams[9] = new SqlParameter("@work_date", work_date);
                prams[10] = new SqlParameter("@nationality", nationality);
                prams[11] = new SqlParameter("@email", email);
                prams[12] = new SqlParameter("@blood_type", blood_type);
                prams[13] = new SqlParameter("@national_id", national_id);
                prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                prams[15] = new SqlParameter("@marital_status", marital_status);
                prams[16] = new SqlParameter("@notes", notes);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Doctors");

                }
                else
                {
                    MessageBox.Show("Failed", "Doctors");

                }

            }
            #endregion
            #region delete
            public static void delete(string full_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from doctors where full_name=@full_name";
                SqlParameter[] prams = new SqlParameter[1];

                prams[0] = new SqlParameter("@full_name", full_name);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Doctors");

                }
                else
                {
                    MessageBox.Show("Failed", "Doctors");
                }
            }

            #endregion
            #region search
            public static void search(string full_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from doctors  where full_name=@full_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@full_name", full_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                if (dr.HasRows == true)
                {
                    id__ = int.Parse(dr[0].ToString());
                    doctor_id_ = int.Parse(dr[1].ToString());
                    specialization_ = dr[2].ToString();
                    full_name_ = dr[3].ToString();
                    first_name_ = dr[4].ToString();
                    last_name_ = dr[5].ToString();
                    dateof_birth_ = DateTime.Parse(dr[6].ToString());
                    gender_ = dr[7].ToString();
                    mobile_ = dr[8].ToString();
                    phone_ = dr[9].ToString();
                    work_date_ = DateTime.Parse(dr[10].ToString());
                    nationality_ = dr[11].ToString();
                    email_ = dr[12].ToString();
                    blood_type_ = dr[13].ToString();
                    national_id_ = dr[14].ToString();
                    placeof_birth_ = dr[15].ToString();
                    marital_status_ = dr[16].ToString();
                    notes_ = dr[17].ToString();

                }
                dr.Close();

            }
            #endregion
            #region update
            public static void update(int id, string full_name, int doctor_id, string specialization, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
"update  doctors set doctor_id = @doctor_id,specialization = @specialization,full_name = @full_name,first_name = @first_name,last_name = @last_name,dateof_birth = @dateof_birth,gender = @gender,mobile = @mobile,phone = @phone,work_date = @work_date,nationality = @nationality,email = @email,blood_type = @blood_type,national_id = @national_id,placeof_birth = @placeof_birth,marital_status = @marital_status,notes = @notes where id=@id";

                SqlParameter[] prams = new SqlParameter[18];
                prams[0] = new SqlParameter("@full_name", full_name);
                prams[1] = new SqlParameter("@specialization", specialization);
                prams[2] = new SqlParameter("@doctor_id", doctor_id);
                prams[3] = new SqlParameter("@first_name", first_name);
                prams[4] = new SqlParameter("@last_name", last_name);
                prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                prams[6] = new SqlParameter("@gender", gender);
                prams[7] = new SqlParameter("@mobile", mobile);
                prams[8] = new SqlParameter("@phone", phone);
                prams[9] = new SqlParameter("@work_date", work_date);
                prams[10] = new SqlParameter("@nationality", nationality);
                prams[11] = new SqlParameter("@email", email);
                prams[12] = new SqlParameter("@blood_type", blood_type);
                prams[13] = new SqlParameter("@national_id", national_id);
                prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                prams[15] = new SqlParameter("@marital_status", marital_status);
                prams[16] = new SqlParameter("@notes", notes);
                prams[17] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Doctors");

                }
                else
                {
                    MessageBox.Show("Failed", "Doctors");

                }

            }
            #endregion


        }
        public struct Employees
        {
            public static int id__;
            public static int emp_id_;
            public static string job_;
            public static string full_name_;
            public static string first_name_;
            public static string last_name_;
            public static DateTime dateof_birth_;
            public static string gender_;
            public static string mobile_;
            public static string phone_;
            public static DateTime work_date_;
            public static string nationality_;
            public static string email_;
            public static string blood_type_;
            public static string national_id_;
            public static string placeof_birth_;
            public static string marital_status_;
            public static string notes_;
          
            #region savedata
            public static void save(int emp_id, string job, string full_name, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
"insert into  employees(employee_id,job,full_name,first_name,last_name,dateof_birth,gender,mobile,phone,work_date,nationality,email,\r\nblood_type,national_id,placeof_birth,marital_status,notes) values\r\n(@emp_id,@job,@full_name,@first_name,@last_name,@dateof_birth,@gender,@mobile,@phone,@work_date,@nationality,@email,\r\n@blood_type,@national_id,@placeof_birth,@marital_status,@notes)";
                SqlParameter[] prams = new SqlParameter[17];
                prams[0] = new SqlParameter("@emp_id", emp_id);
                prams[1] = new SqlParameter("@job", job);
                prams[2] = new SqlParameter("@full_name", full_name);
                prams[3] = new SqlParameter("@first_name", first_name);
                prams[4] = new SqlParameter("@last_name", last_name);
                prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                prams[6] = new SqlParameter("@gender", gender);
                prams[7] = new SqlParameter("@mobile", mobile);
                prams[8] = new SqlParameter("@phone", phone);
                prams[9] = new SqlParameter("@work_date", work_date);
                prams[10] = new SqlParameter("@nationality", nationality);
                prams[11] = new SqlParameter("@email", email);
                prams[12] = new SqlParameter("@blood_type", blood_type);
                prams[13] = new SqlParameter("@national_id", national_id);
                prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                prams[15] = new SqlParameter("@marital_status", marital_status);
                prams[16] = new SqlParameter("@notes", notes);
              
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Employees");

                }
                else
                {
                    MessageBox.Show("Failed", "Employees");

                }

            }
            #endregion
            #region delete
            public static void delete(string full_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from employees where full_name=@full_name";
                SqlParameter[] prams = new SqlParameter[1];

                prams[0] = new SqlParameter("@full_name", full_name);
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Employees");

                }
                else
                {
                    MessageBox.Show("Failed", "Employees");
                }
            }

            #endregion
            #region search
            public static void search(string full_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from employees  where full_name=@full_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@full_name", full_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();
                if (dr.HasRows == true)
                {
                    id__ = int.Parse(dr[0].ToString());
                    emp_id_ = int.Parse(dr[1].ToString());
                    job_ = dr[2].ToString();
                    full_name_ = dr[3].ToString();
                    first_name_ = dr[4].ToString();
                    last_name_ = dr[5].ToString();
                    dateof_birth_ = DateTime.Parse(dr[6].ToString());
                    gender_ = dr[7].ToString();
                    mobile_ = dr[8].ToString();
                    phone_ = dr[9].ToString();
                    work_date_ = DateTime.Parse(dr[10].ToString());
                    nationality_ = dr[11].ToString();
                    email_ = dr[12].ToString();
                    blood_type_ = dr[13].ToString();
                    national_id_ = dr[14].ToString();
                    placeof_birth_ = dr[15].ToString();
                    marital_status_ = dr[16].ToString();
                     notes_ = dr[17].ToString();


                }
                dr.Close();

            }
            #endregion
            #region update
            public static void update(int id, string full_name, int emp_id, string job, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText =
"update  employees set employee_id = @emp_id,job = @job,full_name = @full_name,first_name = @first_name,last_name = @last_name,dateof_birth = @dateof_birth,gender = @gender,mobile = @mobile,phone = @phone,work_date = @work_date,nationality = @nationality,email = @email,blood_type = @blood_type,national_id = @national_id,placeof_birth = @placeof_birth,marital_status = @marital_status,notes = @notes  where id=@id";

                SqlParameter[] prams = new SqlParameter[18];
                prams[0] = new SqlParameter("@full_name", full_name);
                prams[1] = new SqlParameter("@job", job);
                prams[2] = new SqlParameter("@emp_id", emp_id);
                prams[3] = new SqlParameter("@first_name", first_name);
                prams[4] = new SqlParameter("@last_name", last_name);
                prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                prams[6] = new SqlParameter("@gender", gender);
                prams[7] = new SqlParameter("@mobile", mobile);
                prams[8] = new SqlParameter("@phone", phone);
                prams[9] = new SqlParameter("@work_date", work_date);
                prams[10] = new SqlParameter("@nationality", nationality);
                prams[11] = new SqlParameter("@email", email);
                prams[12] = new SqlParameter("@blood_type", blood_type);
                prams[13] = new SqlParameter("@national_id", national_id);
                prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                prams[15] = new SqlParameter("@marital_status", marital_status);
                prams[16] = new SqlParameter("@notes", notes);
                prams[17] = new SqlParameter("@id", id);
               
                cmd.Parameters.AddRange(prams);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Employees");

                }
                else
                {
                    MessageBox.Show("Failed", "Employees");

                }

            }
            #endregion

        }
        public struct Hospital_transfer
        {
            public static int id_;
            public static string department_from_;
            public static string department_to_;
            public static string hospital_from_;
            public static string hospital_to_;
            public static DateTime date_;
            public static string patient_name_;
            public static string file_no_;
            #region save
            public static void save(string department_from, string department_to, string hospital_from, string hospital_to, DateTime date, string patient_name, string file_no)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into hospital_transfer (department_from,department_to,hospital_from,hospital_to,[date],patient_name,file_no)values(@department_from,@department_to,@hospital_from,@hospital_to,@date,@patient_name,@file_no)\r\n";
                SqlParameter[] pram = new SqlParameter[7];
                pram[0] = new SqlParameter("@department_from", department_from);
                pram[1] = new SqlParameter("@department_to", department_to);
                pram[2] = new SqlParameter("@hospital_from", hospital_from);
                pram[3] = new SqlParameter("@hospital_to", hospital_to);
                pram[4] = new SqlParameter("@date", date);
                pram[5] = new SqlParameter("@patient_name", patient_name);
                pram[6] = new SqlParameter("@file_no", file_no);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Hospital Transfer");

                }
                else
                {
                    MessageBox.Show("Failed", "Hospital Transfer");

                }
            }
            #endregion
            #region update
            public static void update(int id, string department_from, string department_to, string hospital_from, string hospital_to, DateTime date, string patient_name, string file_no)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update  hospital_transfer set department_from=@department_from,department_to=@department_to,hospital_from=@hospital_from,hospital_to=@hospital_to,[date]=@date,patient_name=@patient_name,file_no=@file_no where id=@id\r\n";
                SqlParameter[] pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@department_from", department_from);
                pram[1] = new SqlParameter("@department_to", department_to);
                pram[2] = new SqlParameter("@hospital_from", hospital_from);
                pram[3] = new SqlParameter("@hospital_to", hospital_to);
                pram[4] = new SqlParameter("@date", date);
                pram[5] = new SqlParameter("@patient_name", patient_name);
                pram[6] = new SqlParameter("@file_no", file_no);
                pram[7] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Hospital Transfer");

                }
                else
                {
                    MessageBox.Show("Failed", "Hospital Transfer");

                }
            }
            #endregion
            #region delete
            public static void delete(int id)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from hospital_transfer where id=@id";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Hospital Transfer");

                }
                else
                {
                    MessageBox.Show("Failed", "Hospital Transfer");

                }

            }
            #endregion
            #region search 
            public static void search(int id,DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from hospital_transfer where id=@id";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    id_ = int.Parse(dr[0].ToString());
                    department_from_ = dr[1].ToString();
                    department_to_ = dr[2].ToString();
                    hospital_from_ = dr[3].ToString();
                    hospital_to_ = dr[4].ToString();
                    date_ = DateTime.Parse(dr[5].ToString());
                    patient_name_ = dr[6].ToString();
                    file_no_ = dr[7].ToString();
                    dg.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
            }
            #endregion
            #region searchall
            public static void search(DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from hospital_transfer ";

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dg.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }


            }
            #endregion
        }

        public struct Jobs
        {
            public static int id_;
          public static  string position_; 
            public static string job_title_;
            #region save
            public static void save(string position, string job_title)

            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into jobs (position,job_title) values (@position,@job_title)";
                SqlParameter[] pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@position", position);
                pram[1] = new SqlParameter("@job_title", job_title);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "jobs");

                }
                else
                {
                    MessageBox.Show("Failed", "jobs");

                }
            }
            #endregion
            #region delete
            public static void delete(string position, string job_title)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from jobs where position =@position and job_title =@job_title";
                SqlParameter[] pram = new SqlParameter[2];
                pram[0] = new SqlParameter("@position", position);
                pram[1] = new SqlParameter("@job_title", job_title);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Delete", "jobs");

                }
                else
                {
                    MessageBox.Show("Failed", "jobs");

                }
            }
            #endregion
            #region search 
            public static void search(string job_name, DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from jobs where job_title=@job_title";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@job_title", job_name);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    id_ =int.Parse( dr[0].ToString());
                    position_ = dr[1].ToString();
                    job_title_ = dr[2].ToString();
                    dg.Rows.Add( dr[1], dr[2]);
                }
            }
            #endregion
            #region search all
            public static void search( DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from jobs ";
               
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                   
                    dg.Rows.Add(dr[1], dr[2]);
                }
            }
            #endregion

        }
        public struct Medicine_items
            {
                public static int id_;
                public static string medicine_name_;
                public static DateTime production_date_;
                public static DateTime expired_date_;
                public static int quantity_;
                public static string notes_;
                #region save
                public static void save(string medicine_name, DateTime production_date, DateTime expired_date, int quantity, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into medicine(medicine_name,production_date,expired_date,quantity,notes)values(@medicine_name,@production_date,@expired_date,@quantity,@notes)";
                    SqlParameter[] pram = new SqlParameter[5];
                    pram[0] = new SqlParameter("@medicine_name", medicine_name);
                    pram[1] = new SqlParameter("@production_date", production_date);
                    pram[2] = new SqlParameter("@expired_date", expired_date);
                    pram[3] = new SqlParameter("@quantity", quantity);
                    pram[4] = new SqlParameter("@notes", notes);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Medicine");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Medicine");

                    }
                }
                #endregion
                #region update
                public static void update(int id, string medicine_name, DateTime production_date, DateTime expired_date, int quantity, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update medicine set medicine_name=@medicine_name,production_date=@production_date,expired_date=@expired_date,quantity=@quantity,notes=@notes  where\r\nid=@id";
                    SqlParameter[] pram = new SqlParameter[6];
                    pram[0] = new SqlParameter("@medicine_name", medicine_name);
                    pram[1] = new SqlParameter("@production_date", production_date);
                    pram[2] = new SqlParameter("@expired_date", expired_date);
                    pram[3] = new SqlParameter("@quantity", quantity);
                    pram[4] = new SqlParameter("@notes", notes);
                    pram[5] = new SqlParameter("@id", id);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Medicine");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Medicine");

                    }
                }
                #endregion
                #region delete
                public static void delete(string medicine_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from medicine where medicine_name=@medicine_name";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@medicine_name", medicine_name);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Medicine");

                    }
                    else
                    {
                        MessageBox.Show("Deleted", "Medicine");

                    }
                }

                #endregion
                #region search
                public static void search(string medicine_name, DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from medicine where medicine_name=@medicine_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@medicine_name", medicine_name);
                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        id_ = int.Parse(dr[0].ToString());
                        medicine_name_ = dr[1].ToString();
                        production_date_ = DateTime.Parse(dr[2].ToString());
                        expired_date_ = DateTime.Parse(dr[3].ToString());
                        quantity_ = int.Parse(dr[4].ToString());
                        notes_ = dr[5].ToString();
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }

                }
                #endregion
                #region searchall
                public static void searchall(DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from medicine ";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        id_ = int.Parse(dr[0].ToString());
                        medicine_name_ = dr[1].ToString();
                        production_date_ = DateTime.Parse(dr[2].ToString());
                        expired_date_ = DateTime.Parse(dr[3].ToString());
                        quantity_ = int.Parse(dr[4].ToString());
                        notes_ = dr[5].ToString();
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }

                }
                #endregion
            }
            public struct Messages
            {
            }
            public struct Nurses
            {
                public static int id__;
                public static int nurse_id_;
                public static string job_;
                public static string full_name_;
                public static string first_name_;
                public static string last_name_;
                public static DateTime dateof_birth_;
                public static string gender_;
                public static string mobile_;
                public static string phone_;
                public static DateTime work_date_;
                public static string nationality_;
                public static string email_;
                public static string blood_type_;
                public static string national_id_;
                public static string placeof_birth_;
                public static string marital_status_;
                public static string notes_;

                #region savedata
                public static void save(int nurse_id, string job, string full_name, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
    string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
    "insert into  nurses(nurse_id,job,full_name,first_name,last_name,dateof_birth,gender,mobile,phone,work_date,nationality,email,\r\nblood_type,national_id,placeof_birth,marital_status,notes) values\r\n(@nurse_id,@job,@full_name,@first_name,@last_name,@dateof_birth,@gender,@mobile,@phone,@work_date,@nationality,@email,\r\n@blood_type,@national_id,@placeof_birth,@marital_status,@notes)";
                    SqlParameter[] prams = new SqlParameter[17];
                    prams[0] = new SqlParameter("@nurse_id", nurse_id);
                    prams[1] = new SqlParameter("@job", job);
                    prams[2] = new SqlParameter("@full_name", full_name);
                    prams[3] = new SqlParameter("@first_name", first_name);
                    prams[4] = new SqlParameter("@last_name", last_name);
                    prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                    prams[6] = new SqlParameter("@gender", gender);
                    prams[7] = new SqlParameter("@mobile", mobile);
                    prams[8] = new SqlParameter("@phone", phone);
                    prams[9] = new SqlParameter("@work_date", work_date);
                    prams[10] = new SqlParameter("@nationality", nationality);
                    prams[11] = new SqlParameter("@email", email);
                    prams[12] = new SqlParameter("@blood_type", blood_type);
                    prams[13] = new SqlParameter("@national_id", national_id);
                    prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                    prams[15] = new SqlParameter("@marital_status", marital_status);
                    prams[16] = new SqlParameter("@notes", notes);

                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Nurses");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Nurses");

                    }

                }
                #endregion
                #region delete
                public static void delete(string full_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from nurses where full_name=@full_name";
                    SqlParameter[] prams = new SqlParameter[1];

                    prams[0] = new SqlParameter("@full_name", full_name);
                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Nurses");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Nurses");
                    }
                }

                #endregion
                #region search
                public static void search(string full_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from nurses  where full_name=@full_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@full_name", full_name);
                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        id__ = int.Parse(dr[0].ToString());
                        nurse_id_ = int.Parse(dr[1].ToString());
                        job_ = dr[2].ToString();
                        full_name_ = dr[3].ToString();
                        first_name_ = dr[4].ToString();
                        last_name_ = dr[5].ToString();
                        dateof_birth_ = DateTime.Parse(dr[6].ToString());
                        gender_ = dr[7].ToString();
                        mobile_ = dr[8].ToString();
                        phone_ = dr[9].ToString();
                        work_date_ = DateTime.Parse(dr[10].ToString());
                        nationality_ = dr[11].ToString();
                        email_ = dr[12].ToString();
                        blood_type_ = dr[13].ToString();
                        national_id_ = dr[14].ToString();
                        placeof_birth_ = dr[15].ToString();
                        marital_status_ = dr[16].ToString();

                        notes_ = dr[17].ToString();


                    }
                    dr.Close();

                }
                #endregion
                #region searchall
                public static void search(DataGridView dg)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from nurses";

                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15], dr[16], dr[17]);


                    }
                    dr.Close();

                }
                #endregion
                #region update
                public static void update(int id, string full_name, int nurse_id, string job, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, DateTime work_date, string nationality, string email,
    string blood_type, string national_id, string placeof_birth, string marital_status, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
    "update  nurses set nurse_id = @nurse_id,job = @job,full_name = @full_name,first_name = @first_name,last_name = @last_name,dateof_birth = @dateof_birth,gender = @gender,mobile = @mobile,phone = @phone,work_date = @work_date,nationality = @nationality,email = @email,blood_type = @blood_type,national_id = @national_id,placeof_birth = @placeof_birth,marital_status = @marital_status,notes = @notes where id=@id";

                    SqlParameter[] prams = new SqlParameter[18];
                    prams[0] = new SqlParameter("@full_name", full_name);
                    prams[1] = new SqlParameter("@job", job);
                    prams[2] = new SqlParameter("@nurse_id", nurse_id);
                    prams[3] = new SqlParameter("@first_name", first_name);
                    prams[4] = new SqlParameter("@last_name", last_name);
                    prams[5] = new SqlParameter("@dateof_birth", dateof_birth);
                    prams[6] = new SqlParameter("@gender", gender);
                    prams[7] = new SqlParameter("@mobile", mobile);
                    prams[8] = new SqlParameter("@phone", phone);
                    prams[9] = new SqlParameter("@work_date", work_date);
                    prams[10] = new SqlParameter("@nationality", nationality);
                    prams[11] = new SqlParameter("@email", email);
                    prams[12] = new SqlParameter("@blood_type", blood_type);
                    prams[13] = new SqlParameter("@national_id", national_id);
                    prams[14] = new SqlParameter("@placeof_birth", placeof_birth);
                    prams[15] = new SqlParameter("@marital_status", marital_status);
                    prams[16] = new SqlParameter("@notes", notes);
                    prams[17] = new SqlParameter("@id", id);

                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Nurses");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Nurses");

                    }

                }
                #endregion
            }
            public struct Nationality
            {
                #region save
                public static void save(string nation_name)

                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into nationality (nationality_name) values (@national_name)";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@national_name", nation_name);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Nationality");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Nationality");

                    }
                }
                #endregion
                #region delete
                public static void delete(string nation_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from nationality where nationality_name =@national_name";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@national_name", nation_name);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Nationality");

                    }
                    else
                    {
                        MessageBox.Show("Deleted", "Nationality");

                    }
                }
                #endregion
            }


            public struct Operations
            {
                public static int id_;
                public static string doc1_name_;
                public static string doc2_name_;
                public static string drug_kind_;
                public static DateTime date_;
                public static string operation_name_;
                public static string notes_;
                public static string patient_name_;
                #region save
                public static void save(string doc1_name, string doc2_name, string drug_kind, DateTime date, string operation_name, string notes, string patient_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into operations(doc1_name,doc2_name,drug_kind,[date],operation_name,notes,patient_name) values(@doc1_name,@doc2_name,@drug_kind,@date,@operation_name,@notes,@patient_name)";
                    SqlParameter[] pram = new SqlParameter[7];
                    pram[0] = new SqlParameter("@doc1_name", doc1_name);
                    pram[1] = new SqlParameter("@doc2_name", doc2_name);
                    pram[2] = new SqlParameter("@drug_kind", drug_kind);
                    pram[3] = new SqlParameter("@date", date);
                    pram[4] = new SqlParameter("@operation_name", operation_name);
                    pram[5] = new SqlParameter("@notes", notes);
                    pram[6] = new SqlParameter("@patient_name", patient_name);


                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Operations");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Operations");

                    }
                }
                #endregion
                #region update
                public static void update(int id, string doc1_name, string doc2_name, string drug_kind, DateTime date, string operation_name, string notes, string patient_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update operations set doc1_name=@doc1_name,doc2_name=@doc2_name,drug_kind=@drug_kind,[date]=@date,operation_name=@operation_name,notes=@notes,patient_name=@patient_name where id=@id";
                    SqlParameter[] pram = new SqlParameter[8];
                    pram[0] = new SqlParameter("@doc1_name", doc1_name);
                    pram[1] = new SqlParameter("@doc2_name", doc2_name);
                    pram[2] = new SqlParameter("@drug_kind", drug_kind);
                    pram[3] = new SqlParameter("@date", date);
                    pram[4] = new SqlParameter("@operation_name", operation_name);
                    pram[5] = new SqlParameter("@notes", notes);
                    pram[6] = new SqlParameter("@patient_name", patient_name);
                    pram[7] = new SqlParameter("@id", id);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Operations");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Operations");

                    }
                }
                #endregion
                #region delete
                public static void delete(string patient_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from operations where  patient_name=@patient_name  ";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@patient_name", patient_name);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Operations");

                    }
                    else
                    {
                        MessageBox.Show("Deleted", "Operations");

                    }
                }

                #endregion
                #region search
                public static void search(string patient_name, DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from operations where patient_name=@patient_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@patient_name", patient_name);

                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        id_ = int.Parse(dr[0].ToString());
                        doc1_name_ = dr[1].ToString();
                        doc2_name_ = dr[2].ToString();
                        drug_kind_ = dr[3].ToString();
                        date_ = DateTime.Parse(dr[4].ToString());
                        operation_name_ = dr[5].ToString();
                        notes_ = dr[6].ToString();
                        patient_name_ = dr[7].ToString();


                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                    }

                }
                #endregion
                #region searchall
                public static void searchall(DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from operations ";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);

                    }

                }
                #endregion
            }
            public struct Patients
            {
                public static int id__;
                public static string job_name_;
                public static string full_name_;
                public static string first_name_;
                public static string last_name_;
                public static DateTime dateof_birth_;
                public static string gender_;
                public static string mobile_;
                public static string phone_;
                public static string age_;
                public static string nationality_;
                public static string email_;
                public static string blood_type_;
                public static string national_id_;
                public static string placeof_birth_;
                public static string marital_status_;
                public static string notes_;
                public static DateTime opening_file_;
                public static int file_num_;

                #region savedata
                public static void save(string job_name, string full_name, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, string age, string nationality, string email,
    string blood_type, string national_id, string placeof_birth, string marital_status, string notes, int file_num, DateTime opening_file)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
    "insert into  patients(job_name,full_name,first_name,last_name,dateof_birth,gender,mobile,phone,age,nationality,email,\r\nblood_type,national_id,placeof_birth,marital_status,notes,file_number,opening_file) values\r\n(@job_name,@full_name,@first_name,@last_name,@dateof_birth,@gender,@mobile,@phone,@age,@nationality,@email,\r\n@blood_type,@national_id,@placeof_birth,@marital_status,@notes,@file_number,@opening_file)";
                    SqlParameter[] prams = new SqlParameter[18];
                    prams[0] = new SqlParameter("@job_name", job_name);
                    prams[1] = new SqlParameter("@full_name", full_name);
                    prams[2] = new SqlParameter("@first_name", first_name);
                    prams[3] = new SqlParameter("@last_name", last_name);
                    prams[4] = new SqlParameter("@dateof_birth", dateof_birth);
                    prams[5] = new SqlParameter("@gender", gender);
                    prams[6] = new SqlParameter("@mobile", mobile);
                    prams[7] = new SqlParameter("@phone", phone);
                    prams[8] = new SqlParameter("@age", age);
                    prams[9] = new SqlParameter("@nationality", nationality);
                    prams[10] = new SqlParameter("@email", email);
                    prams[11] = new SqlParameter("@blood_type", blood_type);
                    prams[12] = new SqlParameter("@national_id", national_id);
                    prams[13] = new SqlParameter("@placeof_birth", placeof_birth);
                    prams[14] = new SqlParameter("@marital_status", marital_status);
                    prams[15] = new SqlParameter("@notes", notes);
                    prams[16] = new SqlParameter("@opening_file", opening_file);
                    prams[17] = new SqlParameter("@file_number", file_num);


                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Patients");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Patients");

                    }

                }
                #endregion
                #region delete
                public static void delete(string full_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from patients where full_name=@full_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@full_name", full_name);
                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Patients");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Patients");
                    }
                }

                #endregion
                #region search
                public static void search(string full_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from patients  where full_name=@full_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@full_name", full_name);
                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        id__ = int.Parse(dr[0].ToString());
                        job_name_ = dr[1].ToString();
                        full_name_ = dr[2].ToString();
                        first_name_ = dr[3].ToString();
                        last_name_ = dr[4].ToString();
                        dateof_birth_ = DateTime.Parse(dr[5].ToString());
                        gender_ = dr[6].ToString();
                        mobile_ = dr[7].ToString();
                        phone_ = dr[8].ToString();
                        age_ = dr[9].ToString();
                        nationality_ = dr[10].ToString();
                        email_ = dr[11].ToString();
                        blood_type_ = dr[12].ToString();
                        national_id_ = dr[13].ToString();
                        placeof_birth_ = dr[14].ToString();
                        marital_status_ = dr[15].ToString();
                        notes_ = dr[16].ToString();
                        opening_file_ = DateTime.Parse(dr[17].ToString());
                        file_num_ = int.Parse(dr[18].ToString());

                    }
                    dr.Close();

                }
                #endregion
                #region searchall
                public static void search(DataGridView dg)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from patients  ";

                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11], dr[12], dr[13], dr[14], dr[15], dr[16], dr[17], dr[18]);


                    }
                    dr.Close();

                }
                #endregion
                #region update
                public static void update(int id, string full_name, string job_name, string first_name, string last_name, DateTime dateof_birth, string gender, string mobile, string phone, string age, string nationality, string email,
    string blood_type, string national_id, string placeof_birth, string marital_status, string notes, DateTime opening_file, int file_num)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText =
    "update  patients set job_name = @job_name,full_name = @full_name,first_name = @first_name,last_name = @last_name,dateof_birth = @dateof_birth,gender = @gender,mobile = @mobile,phone = @phone,age=@age,nationality = @nationality,email = @email,blood_type = @blood_type,national_id = @national_id,placeof_birth = @placeof_birth,marital_status = @marital_status,notes = @notes,file_number = @file_number,opening_file = @opening_file where id=@id";

                    SqlParameter[] prams = new SqlParameter[19];
                    prams[0] = new SqlParameter("@job_name", job_name);
                    prams[1] = new SqlParameter("@full_name", full_name);
                    prams[2] = new SqlParameter("@first_name", first_name);
                    prams[3] = new SqlParameter("@last_name", last_name);
                    prams[4] = new SqlParameter("@dateof_birth", dateof_birth);
                    prams[5] = new SqlParameter("@gender", gender);
                    prams[6] = new SqlParameter("@mobile", mobile);
                    prams[7] = new SqlParameter("@phone", phone);
                    prams[8] = new SqlParameter("@age", age);
                    prams[9] = new SqlParameter("@nationality", nationality);
                    prams[10] = new SqlParameter("@email", email);
                    prams[11] = new SqlParameter("@blood_type", blood_type);
                    prams[12] = new SqlParameter("@national_id", national_id);
                    prams[13] = new SqlParameter("@placeof_birth", placeof_birth);
                    prams[14] = new SqlParameter("@marital_status", marital_status);
                    prams[15] = new SqlParameter("@notes", notes);
                    prams[16] = new SqlParameter("@opening_file", opening_file);
                    prams[17] = new SqlParameter("@file_number", file_num);
                    prams[18] = new SqlParameter("@id", id);

                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Patients");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Patients");

                    }

                }
                #endregion
            }
            public struct Permission
            {
            }
            public struct pharmacy_sell_hospital
            {
            public static int id_;
            public static string hospital_name_;
            public static DateTime date_;
            public static string medicine_name_;
            public static string beneficiary_name_;
            public static int quantity_;
            public static int price_;
            public static int total_;
            public static int payed_;
            public static int remained_;
            public static int opponent_;
            #region save
            public static void save(string hospital_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into pharmacy_sell_hospital(hospital_name,[date],medicine_name,beneficiary_name,quantity,price,total,payed,remained,opponent)values(@hospital_name,@date,@medicine_name,@beneficiary_name,@quantity,@price,@total,@payed,@remained,@opponent)";
                SqlParameter[] pram = new SqlParameter[10];
                pram[0] = new SqlParameter("@hospital_name", hospital_name);
                pram[1] = new SqlParameter("@medicine_name", medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region update
            public static void update(int id, string hospital_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update pharmacy_sell_hospital set  hospital_name=@hospital_name,[date]=@date,medicine_name=@medicine_name,beneficiary_name=@beneficiary_name,quantity=@quantity,price=@price,total=@total,payed=@payed,remained=@remained,opponent=@opponent\r\nwhere id=@id";
                SqlParameter[] pram = new SqlParameter[11];
                pram[0] = new SqlParameter("@hospital_name", hospital_name);
                pram[1] = new SqlParameter("@medicine_name", medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);
                pram[10] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region delete
            public static void delete(string medicine_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from pharmacy_sell_hospital where medicine_name=@medicine_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@medicine_name", medicine_name);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
            }

            #endregion
            #region search
            public static void search(string medicine_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from  pharmacy_sell_hospital where medicine_name=@medicine_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@medicine_name",medicine_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    id_ = int.Parse(dr[0].ToString());
                    hospital_name_ = dr[1].ToString();
                    date_ = DateTime.Parse(dr[2].ToString());
                    medicine_name_ = dr[3].ToString();
                    beneficiary_name_ = dr[4].ToString();
                    quantity_ = int.Parse(dr[5].ToString());
                    price_ = int.Parse(dr[6].ToString());
                    total_ = int.Parse(dr[7].ToString());
                    payed_ = int.Parse(dr[8].ToString());
                    remained_ = int.Parse(dr[9].ToString());
                    opponent_ = int.Parse(dr[10].ToString());

                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from pharmacy_sell_hospital ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);

                }

            }
            #endregion
        }
        public struct pharmacy_sales_patient
            {
            public static int id_;
            public static string patient_name_;
            public static DateTime date_;
            public static string medicine_name_;
            public static string beneficiary_name_;
            public static int quantity_;
            public static int price_;
            public static int total_;
            public static int payed_;
            public static int remained_;
            public static int opponent_;
            #region save
            public static void save(string patient_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into pharmacy_sales_patient(patient_name,[date],medicine_name,beneficiary_name,quantity,price,total,payed,remained,opponent)values(@patient_name,@date,@medicine_name,@beneficiary_name,@quantity,@price,@total,@payed,@remained,@opponent)";
                SqlParameter[] pram = new SqlParameter[10];
                pram[0] = new SqlParameter("@patient_name", patient_name);
                pram[1] = new SqlParameter("@medicine_name", medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region update
            public static void update(int id, string patient_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update pharmacy_sales_patient set  patient_name=@patient_name,[date]=@date,medicine_name=@medicine_name,beneficiary_name=@beneficiary_name,quantity=@quantity,price=@price,total=@total,payed=@payed,remained=@remained,opponent=@opponent\r\nwhere id=@id";
                SqlParameter[] pram = new SqlParameter[11];
                pram[0] = new SqlParameter("@patient_name", patient_name);
                pram[1] = new SqlParameter("@medicine_name",medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);
                pram[10] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region delete
            public static void delete(string medicine_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from pharmacy_sales_patient where medicine_name=@medicine_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@medicine_name", medicine_name);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
            }

            #endregion
            #region search
            public static void search(string medicine_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from  pharmacy_sales_patient where medicine_name=@medicine_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@medicine_name", medicine_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    id_ = int.Parse(dr[0].ToString());
                   patient_name_ = dr[1].ToString();
                    date_ = DateTime.Parse(dr[2].ToString());
                    medicine_name_ = dr[3].ToString();
                    beneficiary_name_ = dr[4].ToString();
                    quantity_ = int.Parse(dr[5].ToString());
                    price_ = int.Parse(dr[6].ToString());
                    total_ = int.Parse(dr[7].ToString());
                    payed_ = int.Parse(dr[8].ToString());
                    remained_ = int.Parse(dr[9].ToString());
                    opponent_ = int.Parse(dr[10].ToString());

                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from pharmacy_sales_patient ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);

                }

            }
            #endregion
        }
        public struct pharmacy_buy_vendor 
        {
            public static int id_;
            public static string vendor_name_;
            public static DateTime date_;
            public static string medicine_name_;
            public static string beneficiary_name_;
            public static int quantity_;
            public static int price_;
            public static int total_;
            public static int payed_;
            public static int remained_;
            public static int opponent_;
            #region save
            public static void save(string vendor_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into pharmacy_buy_vendors(vendor_name,[date],medicine_name,beneficiary_name,quantity,price,total,payed,remained,opponent)values(@vendor_name,@date,@medicine_name,@beneficiary_name,@quantity,@price,@total,@payed,@remained,@opponent)";
                SqlParameter[] pram = new SqlParameter[10];
                pram[0] = new SqlParameter("@vendor_name", vendor_name);
                pram[1] = new SqlParameter("@medicine_name", medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region update
            public static void update(int id, string vendor_name, DateTime date, string medicine_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update pharmacy_buy_vendors set  vendor_name=@vendor_name,[date]=@date,medicine_name=@medicine_name,beneficiary_name=@beneficiary_name,quantity=@quantity,price=@price,total=@total,payed=@payed,remained=@remained,opponent=@opponent\r\nwhere id=@id";
                SqlParameter[] pram = new SqlParameter[11];
                pram[0] = new SqlParameter("@vendor_name", vendor_name);
                pram[1] = new SqlParameter("@medicine_name", medicine_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);
                pram[10] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Failed", "Pharmacy");

                }
            }
            #endregion
            #region delete
            public static void delete(string medicine_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from pharmacy_buy_vendors where medicine_name=@medicine_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@medicine_name", medicine_name);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
                else
                {
                    MessageBox.Show("Deleted", "Pharmacy");

                }
            }

            #endregion
            #region search
            public static void search(string medicine_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from pharmacy_buy_vendors where medicine_name=@medicine_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@medicine_name",medicine_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    id_ = int.Parse(dr[0].ToString());
                    vendor_name_ = dr[1].ToString();
                    date_ = DateTime.Parse(dr[2].ToString());
                    medicine_name_ = dr[3].ToString();
                    beneficiary_name_ = dr[4].ToString();
                    quantity_ = int.Parse(dr[5].ToString());
                    price_ = int.Parse(dr[6].ToString());
                    total_ = int.Parse(dr[7].ToString());
                    payed_ = int.Parse(dr[8].ToString());
                    remained_ = int.Parse(dr[9].ToString());
                    opponent_ = int.Parse(dr[10].ToString());

                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from pharmacy_buy_vendors ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);

                }

            }
            #endregion
        }
        public struct tests
            {
            public static int id_;
            public static string patient_name_;
            public static DateTime date_;
            public static string test_;
            public static string result_;
            public static string temp_;
            public static string heart_beat_;
            public static string nurse_name_;
            public static string notes_;
            #region save
            public static void save(string patient_name,DateTime date,string test,string result,string temp ,string heart_beat,string nurse_name,string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into examinations(patient_name,[date],tests,results,tempreture,heartbeat,nurse,notes)values(@patient_name,@date,@tests,@results,@tempreture,@heartbeat,@nurse,@notes)";
                SqlParameter[] pram = new SqlParameter[8];
                pram[0] = new SqlParameter("@patient_name", patient_name);
                pram[1] = new SqlParameter("@date", date);
                pram[2] = new SqlParameter("@tests", test);
                pram[3] = new SqlParameter("@results", result);
                pram[4] = new SqlParameter("@tempreture", temp);
                pram[5] = new SqlParameter("@heartbeat" ,heart_beat);
                pram[6] = new SqlParameter("@nurse", nurse_name);
                pram[7] = new SqlParameter("@notes", notes);
              
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Examanations");

                }
                else
                {
                    MessageBox.Show("Failed", "Examanations");

                }
            }
            #endregion
            #region update
            public static void update(int id, string patient_name, DateTime date, string test, string result, string temp, string heart_beat, string nurse_name, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update examinations set patient_name=@patient_name,[date]=@date,tests=@tests,results=@results,tempreture=@tempreture,heartbeat=@heartbeat,nurse=@nurse,notes=@notes where id=@id\r\n";
                SqlParameter[] pram = new SqlParameter[9];
                pram[0] = new SqlParameter("@patient_name", patient_name);
                pram[1] = new SqlParameter("@date", date);
                pram[2] = new SqlParameter("@tests", test);
                pram[3] = new SqlParameter("@results", result);
                pram[4] = new SqlParameter("@tempreture", temp);
                pram[5] = new SqlParameter("@heartbeat", heart_beat);
                pram[6] = new SqlParameter("@nurse", nurse_name);
                pram[7] = new SqlParameter("@notes", notes);
                pram[8] = new SqlParameter("@id", id);
               
                cmd.Parameters.AddRange(pram);
              
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("update", "Examanations");

                }
                else
                {
                    MessageBox.Show("Failed", "Examanations");

                }
            }
                #endregion
                #region delete
                public static void delete(string patient_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from examinations where patient_name=@patient_name";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@patient_name", patient_name);
                    
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Examanations");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Examanations");

                    }
                }
            #endregion
            #region search
            public static void search(string patient_name,DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from examinations where patient_name=@patient_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@patient_name", patient_name);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    id_ = int.Parse(dr[0].ToString());
                    patient_name_ = dr[1].ToString();
                    date_ = DateTime.Parse(dr[2].ToString());
                    test_ = dr[3].ToString();
                    result_ = dr[4].ToString();
                    temp_ = dr[5].ToString();
                    heart_beat_ = dr[6].ToString();
                    nurse_name_ = dr[7].ToString();
                    notes_ = dr[8].ToString();
                    dg.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);

                }
            }
            #endregion
            #region search all
            public static void search(DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
                cmd.CommandText = "select * from examinations ";
                SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
                if (dr.HasRows)
                {
            dg.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
                }
    }
    #endregion

}
        public struct specilizations
            {

            public static int id_;
          public static  string specilization_;
          public static  string clinic_;
                #region save
                public static void save(string specilization, string clinic)

                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into specilization (specilization,clinic_name) values (@specilization,@clinic)";
                    SqlParameter[] pram = new SqlParameter[2];
                    pram[0] = new SqlParameter("@specilization", specilization);
                    pram[1] = new SqlParameter("@clinic", clinic);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Specilization");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Specilization");

                    }
                }
                #endregion
                #region delete
                public static void delete(string specilization, string clinic)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from specilization where specilization =@specilization and clinic_name =@clinic";
                    SqlParameter[] pram = new SqlParameter[2];
                    pram[0] = new SqlParameter("@specilization", specilization);
                    pram[1] = new SqlParameter("@clinic", clinic);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Delete", "Specilization");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Specilization");

                    }
                }
            #endregion
            #region search 
            public static void search(string specilization, DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from specilization where specilization=@specilization";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@specilization", specilization);
                cmd.Parameters.AddRange(pram);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    id_ = int.Parse(dr[0].ToString());
                   specialization_ = dr[1].ToString();
                   clinic_ = dr[2].ToString();
                    dg.Rows.Add(dr[1], dr[2]);
                }
            }
            #endregion
            #region search all
            public static void search(DataGridView dg)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from specilization ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    dg.Rows.Add(dr[1], dr[2]);
                }
            }
            #endregion
        }
        public struct store_buy
            {
            public static int id_;
            public static string hospital_name_;
            public static DateTime date_;
            public static string item_name_;
            public static string beneficiary_name_;
            public static int quantity_;
            public static int price_;
            public static int total_;
            public static int payed_;
            public static int remained_;
            public static int opponent_;
            #region save
            public static void save(string hospital_name, DateTime date, string item_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into store_buy(hospital_name,[date],item_name,beneficiary_name,quantity,price,total,payed,remained,opponent)values(@hospital_name,@date,@item_name,@beneficiary_name,@quantity,@price,@total,@payed,@remained,@opponent)";
                SqlParameter[] pram = new SqlParameter[10];
                pram[0] = new SqlParameter("@hospital_name", hospital_name);
                pram[1] = new SqlParameter("@item_name", item_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Store");

                }
                else
                {
                    MessageBox.Show("Failed", "Store");

                }
            }
            #endregion
            #region update
            public static void update(int id, string hospital_name, DateTime date, string item_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update store_buy set  hospital_name=@hospital_name,[date]=@date,item_name=@item_name,beneficiary_name=@beneficiary_name,quantity=@quantity,price=@price,total=@total,payed=@payed,remained=@remained,opponent=@opponent\r\nwhere id=@id";
                SqlParameter[] pram = new SqlParameter[11];
                pram[0] = new SqlParameter("@hospital_name", hospital_name);
                pram[1] = new SqlParameter("@item_name", item_name);
                pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@price", price);
                pram[5] = new SqlParameter("@total", total);
                pram[6] = new SqlParameter("@payed", payed);
                pram[7] = new SqlParameter("@remained", remained);
                pram[8] = new SqlParameter("@opponent", opponent);
                pram[9] = new SqlParameter("@date", date);
                pram[10] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Store");

                }
                else
                {
                    MessageBox.Show("Failed", "Store");

                }
            }
            #endregion
            #region delete
            public static void delete(string item_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from store_buy where item_name=@item_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@item_name", item_name);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Store");

                }
                else
                {
                    MessageBox.Show("Deleted", "Store");

                }
            }

            #endregion
            #region search
            public static void search(string item_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from store_buy where item_name=@item_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@item_name", item_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    id_ = int.Parse(dr[0].ToString());
                   hospital_name_ = dr[1].ToString();
                    date_ = DateTime.Parse(dr[2].ToString());
                    item_name_ = dr[3].ToString();
                    beneficiary_name_ = dr[4].ToString();
                    quantity_ = int.Parse(dr[5].ToString());
                    price_ = int.Parse(dr[6].ToString());
                    total_ = int.Parse(dr[7].ToString());
                    payed_ = int.Parse(dr[8].ToString());
                    remained_ = int.Parse(dr[9].ToString());
                    opponent_ = int.Parse(dr[10].ToString());

                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from store_buy ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);

                }

            }
            #endregion
        }

        public struct store_sell
            {
                public static int id_;
                public static string vendor_name_;
                public static DateTime date_;
                public static string item_name_;
                public static string beneficiary_name_;
                public static int quantity_;
                public static int price_;
                public static int total_;
                public static int payed_;
                public static int remained_;
                public static int opponent_;
                #region save
                public static void save(string vendor_name, DateTime date, string item_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into store_sell(vendor_name,[date],item_name,beneficiary_name,quantity,price,total,payed,remained,opponent)values(@vendor_name,@date,@item_name,@beneficiary_name,@quantity,@price,@total,@payed,@remained,@opponent)";
                    SqlParameter[] pram = new SqlParameter[10];
                    pram[0] = new SqlParameter("@vendor_name", vendor_name);
                    pram[1] = new SqlParameter("@item_name", item_name);
                    pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                    pram[3] = new SqlParameter("@quantity", quantity);
                    pram[4] = new SqlParameter("@price", price);
                    pram[5] = new SqlParameter("@total", total);
                    pram[6] = new SqlParameter("@payed", payed);
                    pram[7] = new SqlParameter("@remained", remained);
                    pram[8] = new SqlParameter("@opponent", opponent);
                    pram[9] = new SqlParameter("@date", date);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Store");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Store");

                    }
                }
                #endregion
                #region update
                public static void update(int id, string vendor_name, DateTime date, string item_name, string beneficiary_name, int quantity, int price, int total, int payed, int remained, int opponent)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update store_sell set  vendor_name=@vendor_name,[date]=@date,item_name=@item_name,beneficiary_name=@beneficiary_name,quantity=@quantity,price=@price,total=@total,payed=@payed,remained=@remained,opponent=@opponent\r\nwhere id=@id";
                    SqlParameter[] pram = new SqlParameter[11];
                    pram[0] = new SqlParameter("@vendor_name", vendor_name);
                    pram[1] = new SqlParameter("@item_name", item_name);
                    pram[2] = new SqlParameter("@beneficiary_name", beneficiary_name);
                    pram[3] = new SqlParameter("@quantity", quantity);
                    pram[4] = new SqlParameter("@price", price);
                    pram[5] = new SqlParameter("@total", total);
                    pram[6] = new SqlParameter("@payed", payed);
                    pram[7] = new SqlParameter("@remained", remained);
                    pram[8] = new SqlParameter("@opponent", opponent);
                    pram[9] = new SqlParameter("@date", date);
                    pram[10] = new SqlParameter("@id", id);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Store");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Store");

                    }
                }
                #endregion
                #region delete
                public static void delete(string item_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from store_sell where item_name=@item_name";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@item_name", item_name);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Store");

                    }
                    else
                    {
                        MessageBox.Show("Deleted", "Store");

                    }
                }

                #endregion
                #region search
                public static void search(string item_name, DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from store_sell where item_name=@item_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@item_name", item_name);
                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        id_ = int.Parse(dr[0].ToString());
                        vendor_name_ = dr[1].ToString();
                        date_ = DateTime.Parse(dr[2].ToString());
                        item_name_ = dr[3].ToString();
                        beneficiary_name_ = dr[4].ToString();
                        quantity_ = int.Parse(dr[5].ToString());
                        price_ = int.Parse(dr[6].ToString());
                        total_ = int.Parse(dr[7].ToString());
                        payed_ = int.Parse(dr[8].ToString());
                        remained_ = int.Parse(dr[9].ToString());
                        opponent_ = int.Parse(dr[10].ToString());

                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                    }

                }
                #endregion
                #region searchall
                public static void searchall(DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from store_sell ";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);

                    }

                }
                #endregion
            }
            public struct store_items
            {
            public static int id_;
            public static string item_name_;
            public static DateTime production_date_;
            public static string purpose_;
            public static int quantity_;
            public static string notes_;
            #region save
            public static void save(string item_name, DateTime production_date,string purpose, int quantity, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into items(item_name,production_date,purpose,quantity,notes)values(@item_name,@production_date,@purpose,@quantity,@notes)";
                SqlParameter[] pram = new SqlParameter[5];
                pram[0] = new SqlParameter("@item_name", item_name);
                pram[1] = new SqlParameter("@production_date", production_date);
                pram[2] = new SqlParameter("@purpose", purpose);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@notes", notes);

                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Saved", "Items");

                }
                else
                {
                    MessageBox.Show("Failed", "Items");

                }
            }
            #endregion
            #region update
            public static void update(int id, string item_name, DateTime production_date, string purpose, int quantity, string notes)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update items set item_name=@item_name,production_date=@production_date,purpose=@purpose,quantity=@quantity,notes=@notes  where\r\nid=@id";
                SqlParameter[] pram = new SqlParameter[6];
                pram[0] = new SqlParameter("@item_name", item_name);
                pram[1] = new SqlParameter("@production_date", production_date);
                pram[2] = new SqlParameter("@purpose", purpose);
                pram[3] = new SqlParameter("@quantity", quantity);
                pram[4] = new SqlParameter("@notes", notes);
                pram[5] = new SqlParameter("@id", id);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Updated", "Items");

                }
                else
                {
                    MessageBox.Show("Failed", "Items");

                }
            }
            #endregion
            #region delete
            public static void delete(string item_name)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from items where item_name=@item_name";
                SqlParameter[] pram = new SqlParameter[1];
                pram[0] = new SqlParameter("@item_name",item_name);
                cmd.Parameters.AddRange(pram);
                int aff = cmd.ExecuteNonQuery();
                if (aff > 0)
                {
                    MessageBox.Show("Deleted", "Items");

                }
                else
                {
                    MessageBox.Show("Deleted", "Items");

                }
            }

            #endregion
            #region search
            public static void search(string item_name, DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from items where item_name=@item_name";
                SqlParameter[] prams = new SqlParameter[1];
                prams[0] = new SqlParameter("@item_name", item_name);
                cmd.Parameters.AddRange(prams);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows == true)
                {
                    id_ = int.Parse(dr[0].ToString());
                   item_name_ = dr[1].ToString();
                    production_date_ = DateTime.Parse(dr[2].ToString());
                    purpose_ =dr[3].ToString();
                    quantity_ = int.Parse(dr[4].ToString());
                    notes_ = dr[5].ToString();
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
                }

            }
            #endregion
            #region searchall
            public static void searchall(DataGridView dg)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from items ";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   
                    dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5]);
                }

            }
            #endregion
        }
        public struct tickets
            {
            #region savedata
           
                public static void Save(int tk_id, string tk_name, string tk_age, string tk_address, string tk_phone, string tk_clinic, DateTime date)
                {
               
                SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("insert into tickets (tk_id,tk_name,tk_age,tk_address,tk_phone,tk_clinic,[date]) values (@tk_id,@tk_name,@tk_age,@tk_address,@tk_phone,@tk_clinic,@date)");
                    SqlParameter[] prams = new SqlParameter[7];
                    prams[0] = new SqlParameter("@tk_id", tk_id);
                    prams[1] = new SqlParameter("@tk_name", tk_name);
                    prams[2] = new SqlParameter("@tk_age", tk_age);
                    prams[3] = new SqlParameter("@tk_address", tk_address);
                    prams[4] = new SqlParameter("@tk_phone", tk_phone);
                    prams[5] = new SqlParameter("@tk_clinic", tk_clinic);
                    prams[6] = new SqlParameter("@date", date);
                    cmd.Parameters.AddRange(prams);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Tickets");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Tickets");

                    }
                }
                #endregion
            }
            public struct vendors
            {
                public static int __id;
                public static string ven_name_;
                public static string address_;
                public static string phone_;
                public static string mobile_;
                public static string email_;
                public static string notes_;
                #region save
                public static void save(string ven_name, string address, string phone, string mobile, string email, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into vendors (ven_name,[address],phone,mobile,email,notes) values(@ven_name,@address,@phone,@mobile,@email,@notes)";
                    SqlParameter[] pram = new SqlParameter[6];
                    pram[0] = new SqlParameter("@ven_name", ven_name);
                    pram[1] = new SqlParameter("@address", address);
                    pram[2] = new SqlParameter("@phone", phone);
                    pram[3] = new SqlParameter("@mobile", mobile);
                    pram[4] = new SqlParameter("@email", email);
                    pram[5] = new SqlParameter("@notes", notes);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Saved", "Vendors");

                    }
                    else
                    {
                        MessageBox.Show("Failed", "Vendors");

                    }

                }
                #endregion
                #region update
                public static void update(int id, string ven_name, string address, string phone, string mobile, string email, string notes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update  vendors set ven_name=@ven_name,[address]=@address,phone=@phone,mobile=@mobile,email=@email,notes=@notes  where id=@id";
                    SqlParameter[] pram = new SqlParameter[7];
                    pram[0] = new SqlParameter("@ven_name", ven_name);
                    pram[1] = new SqlParameter("@address", address);
                    pram[2] = new SqlParameter("@phone", phone);
                    pram[3] = new SqlParameter("@mobile", mobile);
                    pram[4] = new SqlParameter("@email", email);
                    pram[5] = new SqlParameter("@notes", notes);
                    pram[6] = new SqlParameter("@id", id);
                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Updated", "Vendors");

                    }
                    else
                    {
                        MessageBox.Show("Updated", "Vendors");

                    }

                }
                #endregion
                #region delete
                public static void delete(string ven_name)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from vendors where ven_name=@ven_name";
                    SqlParameter[] pram = new SqlParameter[1];
                    pram[0] = new SqlParameter("@ven_name", ven_name);

                    cmd.Parameters.AddRange(pram);
                    int aff = cmd.ExecuteNonQuery();
                    if (aff > 0)
                    {
                        MessageBox.Show("Deleted", "Vendors");

                    }
                    else
                    {
                        MessageBox.Show("Deleted", "Vendors");

                    }
                }

                #endregion
                #region search
                public static void search(string ven_name, DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from vendors where ven_name=@ven_name";
                    SqlParameter[] prams = new SqlParameter[1];
                    prams[0] = new SqlParameter("@ven_name", ven_name);
                    cmd.Parameters.AddRange(prams);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows == true)
                    {
                        __id = int.Parse(dr[0].ToString());
                        ven_name_ = dr[1].ToString();
                        address_ = dr[2].ToString();
                        phone_ = dr[3].ToString();
                        mobile_ = dr[4].ToString();
                        email_ = dr[5].ToString();
                        notes_ = dr[6].ToString();
                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    }

                }
                #endregion
                #region searchall
                public static void search(DataGridView dg)
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from vendors ";

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        dg.Rows.Add(dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                    }

                }
                #endregion
            }
        }
    }


    


