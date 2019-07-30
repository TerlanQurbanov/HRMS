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
    public partial class Frm_SpecialtyFunc : Form
    {
        public Frm_SpecialtyFunc()
        {
            InitializeComponent();
        }

      public  int idSpecialty;

        Frm_Employee FrmEmployee = new Frm_Employee(); 

        Tbl_Specialty S = new Tbl_Specialty();
        Tbl_SpecialtyORM SORM = new Tbl_SpecialtyORM();

        private void btn_DaxilEt_Deyis_Click(object sender, EventArgs e)
        {
            if (Tools.PageShtat==0)
            {
                try
                {
                    S.SpecialtyName = txt_Ixtisasi.Text;
                    S.Positions = txt_VezifeOhdelikleri.Text;

                      SORM.Insert(S);
                    MessageBox.Show("Məlumatlar Yaddaşa Yazıldı");
                    this.Close();
                }
                catch (Exception)
                {

                    MessageBox.Show("Əməliyyat Baş Tutmadı","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               

                this.Close();
            }

            else if (Tools.PageShtat==1)
            {
                try
                {
                    DialogResult dialoqum = MessageBox.Show("Məlumatlar Dəyişdirilsin?","Update",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                    if (dialoqum==DialogResult.OK)
                    {
                        S.SpecialtyID = idSpecialty;
                        S.SpecialtyName = txt_Ixtisasi.Text;
                        S.Positions = txt_VezifeOhdelikleri.Text;

                        SORM.Update(S);
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
