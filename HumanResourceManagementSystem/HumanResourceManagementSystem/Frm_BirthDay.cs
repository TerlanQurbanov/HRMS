using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRMS_ENTITY;
using HRMS_ORM;
using System.Data.SqlClient;

namespace HumanResourceManagementSystem
{
    public partial class Frm_BirthDay : Form
    {
        public Frm_BirthDay()
        {
            InitializeComponent();
        }

        Tbl_EmployeeORM EORM = new Tbl_EmployeeORM(); 

        private void Frm_BirthDay_Load(object sender, EventArgs e)
        {
            dataGridView_BirthDay.DataSource = EORM.BirthDay();

            DateTime vaxt = DateTime.Now;
            string s = vaxt.ToString("dd.MM.yyyy 00:00:00");

            MessageBox.Show(vaxt.ToString());
            btn_Geri.Text = s.ToString();

            Tools.Con.Open();

            SqlCommand cmd = new SqlCommand("Select DateOfBirth from Tbl_Employee", Tools.Con);
            SqlDataReader oxu = cmd.ExecuteReader();

            while (oxu.Read())
            {
                if (s== oxu["DateOfBirth"].ToString())
                {
                    MessageBox.Show("AD GUNUDUR");
                }
                label1.Text = oxu["DateOfBirth"].ToString();
            }

            Tools.Con.Close();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
