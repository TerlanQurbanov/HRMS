using HRMS_ENTITY;
using HRMS_ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourceManagementSystem
{
    public partial class Frm_DepartamentFunc : Form
    {
        public Frm_DepartamentFunc()
        {
            InitializeComponent();
        }

        Tbl_Department D = new Tbl_Department();
        Tbl_DepartmentORM DORM = new Tbl_DepartmentORM();

       public int departmentID;
        private void btn_DaxilEt_Deyis_Click(object sender, EventArgs e)
        {
            if (Tools.PageDepartment == 0)
            {
                try
                {
                    D.Adress = txt_Unvan.Text;
                    D.CreationDate =Convert.ToDateTime(dtp_YaranmaT.Text);
                    D.Mail = txt_EPosta.Text;
                    D.Name = txt_Adi.Text;
                    D.TelNo = txt_TelNo.Text;

                    DORM.Insert(D);
                    MessageBox.Show("Məlumatlar Yaddaşa Yazıldı");
                    this.Close();
            }
                catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadı", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            else if (Tools.PageDepartment == 1)
            {
                try
                {
                    DialogResult dialoqum = MessageBox.Show("Məlumatlar Dəyişdirilsin?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialoqum == DialogResult.OK)
                    {
                        D.DepartmentID = departmentID;

                        D.Adress = txt_Unvan.Text;
                        D.CreationDate = Convert.ToDateTime(dtp_YaranmaT.Text);
                        D.Mail = txt_EPosta.Text;
                        D.Name = txt_Adi.Text;
                        D.TelNo = txt_TelNo.Text;

                        DORM.Update(D);
                        MessageBox.Show("Məlumatlar Dəyişdirildi");

                        this.Close();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Əməliyyat Baş Tutmadı", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

       

      


