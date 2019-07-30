using DevExpress.XtraTab;
using HRMS_ENTITY;
using HRMS_ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourceManagementSystem
{
    public partial class Frm_Employee : Form
    {
        public Frm_Employee()
        {
            InitializeComponent();
        }

        Tbl_Employee E = new Tbl_Employee();
        Tbl_EmployeeORM EORM = new Tbl_EmployeeORM();

        Tbl_Department D = new Tbl_Department();
        Tbl_DepartmentORM DORM = new Tbl_DepartmentORM();

        Tbl_Specialty S = new Tbl_Specialty();
        Tbl_SpecialtyORM SORM = new Tbl_SpecialtyORM();

        Tbl_Banks B = new Tbl_Banks();
        Tbl_BanksORM BORM = new Tbl_BanksORM();

        Frm_about__us Frmabout = new Frm_about__us();
        Frm_BirthDay FrmBirtDay = new Frm_BirthDay();

        EmekhaqqiORM EmekhORM = new EmekhaqqiORM();


        public int page;
        public void TabCtrlClear()
        {
            foreach (XtraTabPage item in xtraTabControl1.TabPages)
            {
                item.PageVisible = false;
            }
        }

        public void Txt_Clear()
        {
            txt_İban.Text = "";
            txt_BankaAdi.Text = "";
            txt_BankaKodu.Text = "";
            txt_BankaSobeAdi.Text = "";
            
        }

        private void btn_Personallar_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;                   //Panel_Slide
            panel_Slide.Height = btn_Personallar.Height;
            panel_Slide.Top = btn_Personallar.Top;

            TabCtrlClear();

            XtraPersonallar.PageVisible = true;
            xtraTabControl1.SelectedTabPage = XtraPersonallar;

           
        }

        private void btn_Departament_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;                  //Panel_Slide
            panel_Slide.Height = btn_Departament.Height;
            panel_Slide.Top = btn_Departament.Top;

            TabCtrlClear();

            xtraDepartament.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraDepartament;


        }


        private void Frm_Home_Load(object sender, EventArgs e)
        {
            panel_Slide.Visible = false;



            foreach (XtraTabPage item in xtraTabControl1.TabPages)
            {
                //if (item.Name != "XtraHome")
                //{
                    item.PageVisible = false;
                //}
                
            }
            
        }

        private void btn_ƏlavəEt_Click(object sender, EventArgs e)
        {
            Frm_EmployeeFunc FrmEmployeeFunc = new Frm_EmployeeFunc();

            DataTable dtDepart = new DataTable();
            SqlDataAdapter daDepart = new SqlDataAdapter("Select DepartmentID,Name from Tbl_Department", Tools.Con);
            daDepart.Fill(dtDepart);

            FrmEmployeeFunc.cmb_Departament.DataSource = dtDepart;
            FrmEmployeeFunc.cmb_Departament.ValueMember = "DepartmentID";
            FrmEmployeeFunc.cmb_Departament.DisplayMember = "Name";

            DataTable dtSpecialty = new DataTable();
            SqlDataAdapter daSpecialty = new SqlDataAdapter("Select SpecialtyID,SpecialtyName from Tbl_Specialty", Tools.Con);
            daSpecialty.Fill(dtSpecialty);

            FrmEmployeeFunc.cmb_Specialty.DataSource = dtSpecialty;
            FrmEmployeeFunc.cmb_Specialty.ValueMember = "SpecialtyID";
            FrmEmployeeFunc.cmb_Specialty.DisplayMember = "SpecialtyName";

            Tools.page = 0;

            FrmEmployeeFunc.btn_DaxilEt_Deyis.Text = "Daxil Et";

          

            FrmEmployeeFunc.lbl_IsdenCixiwVaxti.Visible = false;
            FrmEmployeeFunc.dtp_IsdenCixisT.Visible = false;
            FrmEmployeeFunc.ShowDialog();

            dataGridView_Employee.DataSource = EORM.Select();

           
        }

        private void btn_Bax_Click(object sender, EventArgs e)
        {
            
            Frm_EmployeeFunc FrmEmployeeFunc = new Frm_EmployeeFunc();

            FrmEmployeeFunc.txt_Adi.Enabled = false;
            FrmEmployeeFunc.txt_Adress.Enabled = false;
            FrmEmployeeFunc.txt_IstifadeciAdi.Enabled = false;
            FrmEmployeeFunc.cmb_Specialty.Enabled = false;
            FrmEmployeeFunc.txt_Parol.Enabled = false;
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Enabled = false;
            FrmEmployeeFunc.txt_Soyadi.Enabled = false;
            FrmEmployeeFunc.dtp_DogumT.Enabled = false;
            FrmEmployeeFunc.dtp_IseGirisT.Enabled = false;
            FrmEmployeeFunc.panel1.Enabled = false;
            FrmEmployeeFunc.panel2.Enabled = false;
            FrmEmployeeFunc.nud_IsTecrubesi.Enabled = false;
            FrmEmployeeFunc.mskt_ElaqeNomresi.Enabled = false;
            FrmEmployeeFunc.btn_Browse_Picture.Enabled = false;
            FrmEmployeeFunc.txt_FINKOD.Enabled = false;
            FrmEmployeeFunc.cmb_Departament.Enabled = false;
            FrmEmployeeFunc.txt_AtaAdi.Enabled = false;
            FrmEmployeeFunc.txt_DogulduguYer.Enabled = false;
            FrmEmployeeFunc.txt_Milliyeti.Enabled = false;
            FrmEmployeeFunc.mt_SHVN.Enabled = false;
            FrmEmployeeFunc.txt_EvTeli.Enabled = false;
            FrmEmployeeFunc.txt_EPosta.Enabled = false;
            FrmEmployeeFunc.txt_TeciliZngEdilecekSexsinTelName.Enabled = false;
            FrmEmployeeFunc.mt_TeciliZngEdilecekSexsNo.Enabled = false;
            FrmEmployeeFunc.txt_XariciSHVNo.Enabled = false;
            FrmEmployeeFunc.txt_SigortaNo.Enabled = false;
            FrmEmployeeFunc.cmb_İslemeNovu.Enabled = false;
            FrmEmployeeFunc.txt_EmekHaqqi.Enabled = false;
            FrmEmployeeFunc.cmb_IstirahetGunleri.Enabled = false;
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Enabled = false;
            FrmEmployeeFunc.cmb_EmrinNo.Enabled = false;
            FrmEmployeeFunc.txt_EmrdeGosterilenler.Enabled = false;
            FrmEmployeeFunc.txt_SelahiyyetliSexs.Enabled = false;
            FrmEmployeeFunc.txt_BankaAdi.Enabled = false;
            FrmEmployeeFunc.txt_BankaHesabNo.Enabled = false;
            FrmEmployeeFunc.txt_BankaSobeKodu.Enabled = false;
            FrmEmployeeFunc.txt_IBANNo.Enabled = false;
            FrmEmployeeFunc.cmb_HerbiMukellefiyyet.Enabled = false;
            FrmEmployeeFunc.cmb_Tehsili.Enabled = false;
            FrmEmployeeFunc.txt_TehsilAldigi_M.Enabled = false;
            FrmEmployeeFunc.dtp_IsdenCixisT.Enabled = false;
            

            FrmEmployeeFunc.txt_Adi.Text = dataGridView_Employee.CurrentRow.Cells["Adı"].Value.ToString();
            FrmEmployeeFunc.txt_Soyadi.Text = dataGridView_Employee.CurrentRow.Cells["Soyadı"].Value.ToString();
            FrmEmployeeFunc.txt_AtaAdi.Text = dataGridView_Employee.CurrentRow.Cells["Ata Adı"].Value.ToString();
            FrmEmployeeFunc.txt_Adress.Text = dataGridView_Employee.CurrentRow.Cells["Ünvan"].Value.ToString();
            FrmEmployeeFunc.txt_IstifadeciAdi.Text = dataGridView_Employee.CurrentRow.Cells["İstifadəçi Adı"].Value.ToString();
            FrmEmployeeFunc.txt_Parol.Text = dataGridView_Employee.CurrentRow.Cells["Şifrə"].Value.ToString();
            FrmEmployeeFunc.cmb_Specialty.Text = dataGridView_Employee.CurrentRow.Cells["İxtisası"].Value.ToString();
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Text = dataGridView_Employee.CurrentRow.Cells["Qeyd"].Value.ToString();
            FrmEmployeeFunc.mskt_ElaqeNomresi.Text = dataGridView_Employee.CurrentRow.Cells["Əlaqə.No"].Value.ToString();
            FrmEmployeeFunc.nud_IsTecrubesi.Text = dataGridView_Employee.CurrentRow.Cells["İş Təcrübəsi(İL)"].Value.ToString();
            FrmEmployeeFunc.dtp_DogumT.Text = dataGridView_Employee.CurrentRow.Cells["Doğum T"].Value.ToString();
            FrmEmployeeFunc.dtp_IseGirisT.Text = dataGridView_Employee.CurrentRow.Cells["İşə B.T"].Value.ToString();
            FrmEmployeeFunc.gender = dataGridView_Employee.CurrentRow.Cells["Cinsiyət"].Value.ToString();
            FrmEmployeeFunc.maritalstatus = dataGridView_Employee.CurrentRow.Cells["Ailə Vəziyyəti"].Value.ToString();
            FrmEmployeeFunc.txt_FINKOD.Text = dataGridView_Employee.CurrentRow.Cells["FIN Kod"].Value.ToString();
            FrmEmployeeFunc.cmb_Departament.Text = dataGridView_Employee.CurrentRow.Cells["Departament"].Value.ToString();
            FrmEmployeeFunc.txt_DogulduguYer.Text = dataGridView_Employee.CurrentRow.Cells["Doğulduğu Yer"].Value.ToString();
            FrmEmployeeFunc.txt_Milliyeti.Text = dataGridView_Employee.CurrentRow.Cells["Milliyəti"].Value.ToString();
            FrmEmployeeFunc.mt_SHVN.Text = dataGridView_Employee.CurrentRow.Cells["ŞV №"].Value.ToString();

            FrmEmployeeFunc.txt_EvTeli.Text = dataGridView_Employee.CurrentRow.Cells["Ev Telefonu"].Value.ToString();
            FrmEmployeeFunc.txt_EPosta.Text = dataGridView_Employee.CurrentRow.Cells["Email"].Value.ToString();
            FrmEmployeeFunc.mt_TeciliZngEdilecekSexsNo.Text = dataGridView_Employee.CurrentRow.Cells["Təcili Zng Ediləcək.No"].Value.ToString();
            FrmEmployeeFunc.txt_TeciliZngEdilecekSexsinTelName.Text = dataGridView_Employee.CurrentRow.Cells["Təcili Zəng Ediləcək Şəxs"].Value.ToString();
            FrmEmployeeFunc.txt_XariciSHVNo.Text = dataGridView_Employee.CurrentRow.Cells["Xarici PasportNo"].Value.ToString();
            FrmEmployeeFunc.txt_SigortaNo.Text = dataGridView_Employee.CurrentRow.Cells["SığortaNo"].Value.ToString();
            FrmEmployeeFunc.cmb_İslemeNovu.Text = dataGridView_Employee.CurrentRow.Cells["İşləmə Növü"].Value.ToString();
            FrmEmployeeFunc.txt_EmekHaqqi.Text = dataGridView_Employee.CurrentRow.Cells["Əməkhaqqı"].Value.ToString();
            FrmEmployeeFunc.cmb_IstirahetGunleri.Text = dataGridView_Employee.CurrentRow.Cells["İstirahət Günü"].Value.ToString();
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Text = dataGridView_Employee.CurrentRow.Cells["İşdən Çıxma Səbəbi"].Value.ToString();
            FrmEmployeeFunc.cmb_EmrinNo.Text = dataGridView_Employee.CurrentRow.Cells["ƏmrNo"].Value.ToString();
            FrmEmployeeFunc.txt_EmrdeGosterilenler.Text = dataGridView_Employee.CurrentRow.Cells["Əmr"].Value.ToString();
            FrmEmployeeFunc.txt_SelahiyyetliSexs.Text = dataGridView_Employee.CurrentRow.Cells["Səlahiyyətli Şəxs"].Value.ToString();

            FrmEmployeeFunc.txt_BankaAdi.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Adı"].Value.ToString();
            FrmEmployeeFunc.txt_BankaSobeKodu.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Şöbə Kodu"].Value.ToString();
            FrmEmployeeFunc.txt_BankaHesabNo.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Hesab №"].Value.ToString();
            FrmEmployeeFunc.txt_IBANNo.Text = dataGridView_Employee.CurrentRow.Cells["IBAN"].Value.ToString();
            FrmEmployeeFunc.cmb_Tehsili.Text = dataGridView_Employee.CurrentRow.Cells["Təhsil"].Value.ToString();
            FrmEmployeeFunc.txt_TehsilAldigi_M.Text = dataGridView_Employee.CurrentRow.Cells["Təhsil Müəssisəsi"].Value.ToString();
            FrmEmployeeFunc.cmb_HerbiMukellefiyyet.Text = dataGridView_Employee.CurrentRow.Cells["Hərbi Mükəlləfiyyət"].Value.ToString();

            DataTable dt = EORM.SqlReader((int)dataGridView_Employee.CurrentRow.Cells["EmployeeID"].Value);

            byte[] sekil = (byte[])dt.Rows[0][1];
            MemoryStream ms = new MemoryStream(sekil);
            FrmEmployeeFunc.pictureBox_Employee.Image = Image.FromStream(ms);
            FrmEmployeeFunc.btn_DaxilEt_Deyis.Visible = false;
            FrmEmployeeFunc.ShowDialog();
        }

        private void btn_Deyis_Click(object sender, EventArgs e)
        {

            Frm_EmployeeFunc FrmEmployeeFunc = new Frm_EmployeeFunc();

            DataTable dtDepart = new DataTable();
            SqlDataAdapter daDepart = new SqlDataAdapter("Select DepartmentID,Name from Tbl_Department", Tools.Con);
            daDepart.Fill(dtDepart);

            FrmEmployeeFunc.cmb_Departament.DataSource = dtDepart;
            FrmEmployeeFunc.cmb_Departament.ValueMember = "DepartmentID";
            FrmEmployeeFunc.cmb_Departament.DisplayMember = "Name";

            DataTable dtSpecialty = new DataTable();
            SqlDataAdapter daSpecialty = new SqlDataAdapter("Select SpecialtyID,SpecialtyName from Tbl_Specialty", Tools.Con);
            daSpecialty.Fill(dtSpecialty);

            FrmEmployeeFunc.cmb_Specialty.DataSource = dtSpecialty;
            FrmEmployeeFunc.cmb_Specialty.ValueMember = "SpecialtyID";
            FrmEmployeeFunc.cmb_Specialty.DisplayMember = "SpecialtyName";

            Tools.page = 1;

            FrmEmployeeFunc.id = (int)dataGridView_Employee.CurrentRow.Cells["EmployeeID"].Value;
            FrmEmployeeFunc.active = (bool)dataGridView_Employee.CurrentRow.Cells["Active"].Value;

            FrmEmployeeFunc.txt_Adi.Text = dataGridView_Employee.CurrentRow.Cells["Adı"].Value.ToString();
            FrmEmployeeFunc.txt_Soyadi.Text = dataGridView_Employee.CurrentRow.Cells["Soyadı"].Value.ToString();
            FrmEmployeeFunc.txt_Adress.Text = dataGridView_Employee.CurrentRow.Cells["Ünvan"].Value.ToString();
            FrmEmployeeFunc.txt_IstifadeciAdi.Text = dataGridView_Employee.CurrentRow.Cells["İstifadəçi Adı"].Value.ToString();
            FrmEmployeeFunc.txt_Parol.Text = dataGridView_Employee.CurrentRow.Cells["Şifrə"].Value.ToString();
            FrmEmployeeFunc.cmb_Specialty.Text = dataGridView_Employee.CurrentRow.Cells["İxtisası"].Value.ToString();
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Text = dataGridView_Employee.CurrentRow.Cells["Qeyd"].Value.ToString();
            FrmEmployeeFunc.mskt_ElaqeNomresi.Text = dataGridView_Employee.CurrentRow.Cells["Əlaqə.No"].Value.ToString();
            FrmEmployeeFunc.nud_IsTecrubesi.Text = dataGridView_Employee.CurrentRow.Cells["İş Təcrübəsi(İL)"].Value.ToString();
            FrmEmployeeFunc.dtp_DogumT.Text = dataGridView_Employee.CurrentRow.Cells["Doğum T"].Value.ToString();
            FrmEmployeeFunc.dtp_IseGirisT.Text = dataGridView_Employee.CurrentRow.Cells["İşə B.T"].Value.ToString();
            FrmEmployeeFunc.gender = dataGridView_Employee.CurrentRow.Cells["Cinsiyət"].Value.ToString();
            FrmEmployeeFunc.maritalstatus = dataGridView_Employee.CurrentRow.Cells["Ailə Vəziyyəti"].Value.ToString();
            FrmEmployeeFunc.txt_FINKOD.Text = dataGridView_Employee.CurrentRow.Cells["FIN Kod"].Value.ToString();
            FrmEmployeeFunc.cmb_Departament.Text = dataGridView_Employee.CurrentRow.Cells["Departament"].Value.ToString();

            FrmEmployeeFunc.mt_SHVN.Text = dataGridView_Employee.CurrentRow.Cells["ŞV №"].Value.ToString();
            FrmEmployeeFunc.txt_AtaAdi.Text = dataGridView_Employee.CurrentRow.Cells["Ata Adı"].Value.ToString();
            FrmEmployeeFunc.txt_DogulduguYer.Text = dataGridView_Employee.CurrentRow.Cells["Doğulduğu Yer"].Value.ToString();
            FrmEmployeeFunc.txt_Milliyeti.Text = dataGridView_Employee.CurrentRow.Cells["Milliyəti"].Value.ToString();

            FrmEmployeeFunc.txt_EvTeli.Text = dataGridView_Employee.CurrentRow.Cells["Ev Telefonu"].Value.ToString();
            FrmEmployeeFunc.txt_EPosta.Text = dataGridView_Employee.CurrentRow.Cells["Email"].Value.ToString();
            FrmEmployeeFunc.mt_TeciliZngEdilecekSexsNo.Text = dataGridView_Employee.CurrentRow.Cells["Təcili Zng Ediləcək.No"].Value.ToString();
            FrmEmployeeFunc.txt_TeciliZngEdilecekSexsinTelName.Text = dataGridView_Employee.CurrentRow.Cells["Təcili Zəng Ediləcək Şəxs"].Value.ToString();
            FrmEmployeeFunc.txt_XariciSHVNo.Text = dataGridView_Employee.CurrentRow.Cells["Xarici PasportNo"].Value.ToString();
            FrmEmployeeFunc.txt_SigortaNo.Text = dataGridView_Employee.CurrentRow.Cells["SığortaNo"].Value.ToString();
            FrmEmployeeFunc.cmb_İslemeNovu.Text = dataGridView_Employee.CurrentRow.Cells["İşləmə Növü"].Value.ToString();
            FrmEmployeeFunc.txt_EmekHaqqi.Text = dataGridView_Employee.CurrentRow.Cells["Əməkhaqqı"].Value.ToString();
            FrmEmployeeFunc.cmb_IstirahetGunleri.Text = dataGridView_Employee.CurrentRow.Cells["İstirahət Günü"].Value.ToString();
            FrmEmployeeFunc.txt_IsdenCixmaSebebi.Text = dataGridView_Employee.CurrentRow.Cells["İşdən Çıxma Səbəbi"].Value.ToString();
            FrmEmployeeFunc.cmb_EmrinNo.Text = dataGridView_Employee.CurrentRow.Cells["ƏmrNo"].Value.ToString();
            FrmEmployeeFunc.txt_EmrdeGosterilenler.Text = dataGridView_Employee.CurrentRow.Cells["Əmr"].Value.ToString();
            FrmEmployeeFunc.txt_SelahiyyetliSexs.Text = dataGridView_Employee.CurrentRow.Cells["Səlahiyyətli Şəxs"].Value.ToString();

            FrmEmployeeFunc.txt_BankaAdi.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Adı"].Value.ToString();
            FrmEmployeeFunc.txt_BankaSobeKodu.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Şöbə Kodu"].Value.ToString();
            FrmEmployeeFunc.txt_BankaHesabNo.Text = dataGridView_Employee.CurrentRow.Cells["Bankın Hesab №"].Value.ToString();
            FrmEmployeeFunc.txt_IBANNo.Text = dataGridView_Employee.CurrentRow.Cells["IBAN"].Value.ToString();
            FrmEmployeeFunc.cmb_Tehsili.Text = dataGridView_Employee.CurrentRow.Cells["Təhsil"].Value.ToString();
            FrmEmployeeFunc.txt_TehsilAldigi_M.Text = dataGridView_Employee.CurrentRow.Cells["Təhsil Müəssisəsi"].Value.ToString();
            FrmEmployeeFunc.cmb_HerbiMukellefiyyet.Text = dataGridView_Employee.CurrentRow.Cells["Hərbi Mükəlləfiyyət"].Value.ToString();




            DataTable dt = EORM.SqlReader((int)dataGridView_Employee.CurrentRow.Cells["EmployeeID"].Value);

            byte[] sekil = (byte[])dt.Rows[0][1];
            MemoryStream ms = new MemoryStream(sekil);
            FrmEmployeeFunc.pictureBox_Employee.Image = Image.FromStream(ms);

            FrmEmployeeFunc.btn_DaxilEt_Deyis.Text = "Dəyiş";
            FrmEmployeeFunc.ShowDialog();
            dataGridView_Employee.DataSource = EORM.Select();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialoqum = MessageBox.Show("Seçilmiç Məlumatlar Silinsin?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult.OK == dialoqum)
                {
                    E.EmployeeID = (int)dataGridView_Employee.CurrentRow.Cells["EmployeeID"].Value;
                    EORM.Delete(E.EmployeeID);
                    MessageBox.Show("Seçilmiç Məlumatlar Silindi");
                    dataGridView_Employee.DataSource = EORM.Select();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadi");
            }
        }

      

        private void XtraHome_Paint(object sender, PaintEventArgs e)
        {
            dataGridView_Employee.DataSource = EORM.Select();

            dataGridView_Employee.Columns["EmployeeID"].Visible = false;
            dataGridView_Employee.Columns["Active"].Visible = false;
            dataGridView_Employee.Columns["FIN Kod"].Visible = false;
            dataGridView_Employee.Columns["Cinsiyət"].Visible = false;
            dataGridView_Employee.Columns["Ailə Vəziyyəti"].Visible = false;
            dataGridView_Employee.Columns["İş Təcrübəsi(İL)"].Visible = false;
            dataGridView_Employee.Columns["Doğum T"].Visible = false;
            dataGridView_Employee.Columns["İşə B.T"].Visible = false;
            dataGridView_Employee.Columns["Ünvan"].Visible = false;
            dataGridView_Employee.Columns["Milliyəti"].Visible = false;
            dataGridView_Employee.Columns["İstifadəçi Adı"].Visible = false;
            dataGridView_Employee.Columns["Şifrə"].Visible = false;
            dataGridView_Employee.Columns["Ev Telefonu"].Visible = false;
            dataGridView_Employee.Columns["Email"].Visible = false;
            dataGridView_Employee.Columns["Təcili Zng Ediləcək.No"].Visible = false;
            dataGridView_Employee.Columns["Təcili Zəng Ediləcək Şəxs"].Visible = false;
            dataGridView_Employee.Columns["Xarici PasportNo"].Visible = false;
            dataGridView_Employee.Columns["SığortaNo"].Visible = false;
            dataGridView_Employee.Columns["İşləmə Növü"].Visible = false;
            dataGridView_Employee.Columns["İstirahət Günü"].Visible = false;
            dataGridView_Employee.Columns["İşdən Çıxma Səbəbi"].Visible = false;
            dataGridView_Employee.Columns["ƏmrNo"].Visible = false;
            dataGridView_Employee.Columns["Əmr"].Visible = false;
            dataGridView_Employee.Columns["Səlahiyyətli Şəxs"].Visible = false;
            dataGridView_Employee.Columns["Bankın Adı"].Visible = false;
            dataGridView_Employee.Columns["Bankın Şöbə Kodu"].Visible = false;
            dataGridView_Employee.Columns["Bankın Hesab №"].Visible = false;
            dataGridView_Employee.Columns["IBAN"].Visible = false;
            dataGridView_Employee.Columns["Təhsil"].Visible = false;
            dataGridView_Employee.Columns["Hərbi Mükəlləfiyyət"].Visible = false;
            dataGridView_Employee.Columns["ŞV №"].Visible = false;
            dataGridView_Employee.Columns["Qeyd"].Visible = false;
            dataGridView_Employee.Columns["Təhsil Müəssisəsi"].Visible = false;


            txt_Search.Visible = true;

           
           
           
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            txt_Search.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
         

        }

        private void xtraDepartament_Paint(object sender, PaintEventArgs e)
        {
            dataGridView_Departament.DataSource = DORM.Select();

            dataGridView_Departament.Columns["DepartmentID"].Visible = false;
            dataGridView_Departament.Columns["Active"].Visible = false;
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void txt_SearchDepartament_TextChanged(object sender, EventArgs e)
        {
            dataGridView_Departament.DataSource = DORM.DepartamentSearch(txt_SearchDepartament.Text);
        }

        private void btn_Shtatlar_Click(object sender, EventArgs e)
        {

            panel_Slide.Visible = true;
            panel_Slide.Height = btn_Shtatlar.Height;
            panel_Slide.Top = btn_Shtatlar.Top;

            TabCtrlClear();
            xtraShtatlar.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraShtatlar;

           

        }

        private void xtraShtatlar_Paint(object sender, PaintEventArgs e)
        {           
            dataGridView_SHtatlar.DataSource = SORM.Select();

            dataGridView_SHtatlar.Columns["SpecialtyID"].Visible = false;
        }

        private void btn_StatElaveEt_Click(object sender, EventArgs e)
        {
            Frm_SpecialtyFunc FrmSpecialtyFunc = new Frm_SpecialtyFunc();

            FrmSpecialtyFunc.btn_DaxilEt_Deyis.Text = "Daxil Et";
            Tools.PageShtat = 0;
            FrmSpecialtyFunc.ShowDialog();
            dataGridView_SHtatlar.DataSource = SORM.Select();
           
               
        }

        private void btn_StatSil_Click(object sender, EventArgs e)
        {
            try
            {
             DialogResult dialoqum =  MessageBox.Show("Seçilmiş Məlumatlar Silinsin?","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if (dialoqum==DialogResult.OK)
                {
                    S.SpecialtyID = (int)dataGridView_SHtatlar.CurrentRow.Cells["SpecialtyID"].Value;

                    SORM.Delete(S.SpecialtyID);

                    MessageBox.Show("Seçilmiş Məlumatlar Silindi");
                    dataGridView_SHtatlar.DataSource = SORM.Select();
                }               
            }
            catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadı","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
        }

        private void btn_StatRedakteEt_Click(object sender, EventArgs e)
        {
            Tools.PageShtat = 1;
            Frm_SpecialtyFunc FrmSpecialtyFunc = new Frm_SpecialtyFunc();

            FrmSpecialtyFunc.idSpecialty = (int)dataGridView_SHtatlar.CurrentRow.Cells["SpecialtyID"].Value;

            FrmSpecialtyFunc.txt_Ixtisasi.Text = dataGridView_SHtatlar.CurrentRow.Cells["İxtisas"].Value.ToString();
            FrmSpecialtyFunc.txt_VezifeOhdelikleri.Text = dataGridView_SHtatlar.CurrentRow.Cells["Vəzifə Öhdəlikləri"].Value.ToString();

            FrmSpecialtyFunc.btn_DaxilEt_Deyis.Text = "Dəyiş";

            FrmSpecialtyFunc.ShowDialog();

            dataGridView_SHtatlar.DataSource = SORM.Select();

            
        }

        private void btn_StatBax_Click(object sender, EventArgs e)
        {
            Frm_SpecialtyFunc FrmSpecialtyFunc = new Frm_SpecialtyFunc();

            FrmSpecialtyFunc.txt_Ixtisasi.Enabled = false;
            FrmSpecialtyFunc.txt_VezifeOhdelikleri.Enabled = false;
            FrmSpecialtyFunc.btn_DaxilEt_Deyis.Visible = false;

            FrmSpecialtyFunc.txt_Ixtisasi.Text = dataGridView_SHtatlar.CurrentRow.Cells["İxtisas"].Value.ToString();
            FrmSpecialtyFunc.txt_VezifeOhdelikleri.Text = dataGridView_SHtatlar.CurrentRow.Cells["Vəzifə Öhdəlikləri"].Value.ToString();

            FrmSpecialtyFunc.ShowDialog();
        }

        private void txt_ShtatSearch_TextChanged(object sender, EventArgs e)
        {
              dataGridView_SHtatlar.DataSource = SORM.ShtatSearch(txt_ShtatSearch.Text);
        }

        private void txt_Search_MouseClick_1(object sender, MouseEventArgs e)
        {
            txt_Search.Text = "";
        }

        private void txt_Search_TextChanged_1(object sender, EventArgs e)
        {
            DataTable dt = EORM.Search(txt_Search.Text);
            dataGridView_Employee.DataSource = dt;
        }

        private void txt_ShtatSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txt_ShtatSearch.Text = "";
        }

        private void btn_ElaveEtDep_Click(object sender, EventArgs e)
        {
            Frm_DepartamentFunc FrmDepartamentFunc = new Frm_DepartamentFunc();

            Tools.PageDepartment = 0;

            FrmDepartamentFunc.ShowDialog();

            dataGridView_Departament.DataSource = DORM.Select();

        }

        private void btn_RedakteEtDep_Click(object sender, EventArgs e)
        {
            Tools.PageDepartment = 1;

            Frm_DepartamentFunc FrmDepartament = new Frm_DepartamentFunc();

            FrmDepartament.departmentID = (int)dataGridView_Departament.CurrentRow.Cells["DepartmentID"].Value;

            FrmDepartament.txt_Adi.Text = dataGridView_Departament.CurrentRow.Cells["Adı"].Value.ToString();
            FrmDepartament.txt_Unvan.Text = dataGridView_Departament.CurrentRow.Cells["Ünvan"].Value.ToString();
            FrmDepartament.txt_TelNo.Text = dataGridView_Departament.CurrentRow.Cells["Əlaqə No"].Value.ToString();
            FrmDepartament.dtp_YaranmaT.Text = dataGridView_Departament.CurrentRow.Cells["Yaranma.T"].Value.ToString();
            FrmDepartament.txt_EPosta.Text = dataGridView_Departament.CurrentRow.Cells["Mail"].Value.ToString();

            FrmDepartament.btn_DaxilEt_Deyis.Text = "Dəyiş";

            FrmDepartament.ShowDialog();
            dataGridView_Departament.DataSource = DORM.Select();
        }

        private void btn_BaxDep_Click(object sender, EventArgs e)
        {
            Frm_DepartamentFunc FrmDepartament = new Frm_DepartamentFunc();

            FrmDepartament.txt_Adi.Text = dataGridView_Departament.CurrentRow.Cells["Adı"].Value.ToString();
            FrmDepartament.txt_Unvan.Text = dataGridView_Departament.CurrentRow.Cells["Ünvan"].Value.ToString();
            FrmDepartament.txt_TelNo.Text = dataGridView_Departament.CurrentRow.Cells["Əlaqə No"].Value.ToString();
            FrmDepartament.dtp_YaranmaT.Text = dataGridView_Departament.CurrentRow.Cells["Yaranma.T"].Value.ToString();
            FrmDepartament.txt_EPosta.Text = dataGridView_Departament.CurrentRow.Cells["Mail"].Value.ToString();

            FrmDepartament.txt_Adi.Enabled = false;
            FrmDepartament.txt_EPosta.Enabled = false;
            FrmDepartament.txt_TelNo.Enabled = false;
            FrmDepartament.txt_Unvan.Enabled = false;
            FrmDepartament.dtp_YaranmaT.Enabled = false;


            FrmDepartament.ShowDialog();
        }

        private void btn_SilDep_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialoqum = MessageBox.Show("Seçilmiş Məlumatlar Silinsin?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialoqum == DialogResult.OK)
                {
                D.DepartmentID = Convert.ToInt32(dataGridView_Departament.CurrentRow.Cells["DepartmentID"].Value);
                DORM.Delete(D.DepartmentID);

                    MessageBox.Show("Seçilmiş Məlumatlar Silindi");
                  dataGridView_Departament.DataSource = DORM.Select();
               }
            }
            catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadı", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_SearchDepartament_MouseClick(object sender, MouseEventArgs e)
        {
            txt_SearchDepartament.Text = "";
        }

        private void btn_Banklar_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            panel_Slide.Height = btn_Banklar.Height;
            panel_Slide.Top = btn_Banklar.Top;

            TabCtrlClear();
            xtraBanklar.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraBanklar;

            dataGridView_Banka.DataSource = BORM.Select();

            dataGridView_Banka.Columns["BankaID"].Visible = false;
        }

        private void xtraBanklar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_BankaElaveEt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_BankaAdi.Text!="" && txt_BankaKodu.Text!= "" && txt_BankaSobeAdi.Text!= "" && txt_İban.Text!= "" )
                {
                    B.BankCode = txt_BankaKodu.Text;
                    B.BankName = txt_BankaAdi.Text;
                    B.BankSectorName = txt_BankaSobeAdi.Text;
                    B.IBAN = txt_İban.Text;

                    BORM.Insert(B);

                    MessageBox.Show("Məlumatlar Yaddaşa Yazıldı");

                    dataGridView_Banka.DataSource = BORM.Select();
                    Txt_Clear();
                }
                else
                {
                    MessageBox.Show("Əməliyyat Baş Tutmadı. Zəhmət Olmasa Bütün Xanaları Doldurun","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadı", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }

        private void btn_BankaRedakteEt_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialoqum = MessageBox.Show("Məlumatlar Dəyişdirilsin?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialoqum == DialogResult.OK)
                {
                    B.BankaID = (int)dataGridView_Banka.CurrentRow.Cells["BankaID"].Value;
                    B.BankCode = txt_BankaKodu.Text;
                    B.BankName = txt_BankaAdi.Text;
                    B.BankSectorName = txt_BankaSobeAdi.Text;
                    B.IBAN = txt_İban.Text;

                    BORM.Update(B);

                    MessageBox.Show("Məlumatlar Dəyişdirildi");

                    dataGridView_Banka.DataSource = BORM.Select();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Əməliyyat Baş Tutmadı", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_Banka_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_İban.Text = dataGridView_Banka.CurrentRow.Cells["İBAN"].Value.ToString();
            txt_BankaAdi.Text = dataGridView_Banka.CurrentRow.Cells["Banka Adı"].Value.ToString();
            txt_BankaKodu.Text = dataGridView_Banka.CurrentRow.Cells["Banka Kodu"].Value.ToString();
            txt_BankaSobeAdi.Text = dataGridView_Banka.CurrentRow.Cells["Şöbə Adı"].Value.ToString();
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            Txt_Clear();
        }

        private void btn_BankaSil_Click(object sender, EventArgs e)
        {


            try
            {
                DialogResult dialoqum = MessageBox.Show("Seçilmiç Məlumatlar Silinsin?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult.OK == dialoqum)
                {
                    B.BankaID = (int)dataGridView_Banka.CurrentRow.Cells["BankaID"].Value;

                    BORM.Delete(B.BankaID);

                    MessageBox.Show("Seçilmiç Məlumatlar Silindi");
                    dataGridView_Banka.DataSource = BORM.Select();
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Əməliyyat Baş Tutmadi");
            }
        }

        private void xtraEmekHaqqi_Paint(object sender, PaintEventArgs e)
        {
            dataGridView_Emekhaqlari.DataSource = EmekhORM.Select();
        }

        private void btn_Salary_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            panel_Slide.Height = btn_Salary.Height;
            panel_Slide.Top = btn_Salary.Top;

            TabCtrlClear();
            xtraEmekHaqqi.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraEmekHaqqi;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_EmekhaqqiDeyis_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_facebook_Click(object sender, EventArgs e)
        {
            Process.Start("www.fb.com");
        }

        private void btn_Instagram_Click(object sender, EventArgs e)
        {
            Process.Start("www.instagram.com");
        }

        private void btn_Mail_Click(object sender, EventArgs e)
        {
            Process.Start("www.mail.ru");
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            Frmabout.ShowDialog();
        }

        private void btn_BirthDay_Click(object sender, EventArgs e)
        {
            FrmBirtDay.ShowDialog();
        }
    }
}
