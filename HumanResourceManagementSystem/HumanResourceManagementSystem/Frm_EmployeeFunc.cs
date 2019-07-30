using HRMS_ENTITY;
using HRMS_ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HumanResourceManagementSystem
{
    public partial class Frm_EmployeeFunc : Form
    {
        public Frm_EmployeeFunc()
        {
            InitializeComponent();
        }

        Tbl_Employee E = new Tbl_Employee();
        Tbl_EmployeeORM EORM = new Tbl_EmployeeORM();

        Tbl_Pictures P = new Tbl_Pictures();
        Tbl_PicturesORM PORM = new Tbl_PicturesORM();

        public int id;
        public bool active;
        public string gender;
        public string maritalstatus;

        string Gender;
        string MaritalStatus;

        bool FINCode = false;
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Gender = "Kişi";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            Gender = "Qadın";
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            MaritalStatus = "Subay";
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            MaritalStatus = "Evli";
        }

        private void btn_Browser_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Sekil Sec";
            openFileDialog1.Filter = "All|*.*|Png|*.png|Jpg|*.jpg";
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (DialogResult.OK == dialog)
            {
                pictureBox_Employee.ImageLocation = openFileDialog1.FileName.ToString();
            }
        }

        private void Frm_EmployeeFunc_Load(object sender, EventArgs e)
        {

            if (gender == "Kişi")
            {
                radioButton1.Checked = true;
            }
            else if (gender == "Qadın")
            {
                radioButton2.Checked = true;
            }

            if (maritalstatus == "Evli")
            {
                radioButton3.Checked = true;
            }
            else if (maritalstatus == "Subay")
            {
                radioButton4.Checked = true;
            }

        }

        private void btn_DaxilEt_Deyis_Click(object sender, EventArgs e)
        {

            if (Tools.page == 0)
            {
                try
                {

                    if (txt_FINKOD.Text == "" || FINCode == false)
                {
                        MessageBox.Show("FIN Kod-u Düzgün Daxil Edin !!!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                 }
                if (cmb_Departament.Text=="" && cmb_Specialty.Text=="")
                {
                    MessageBox.Show("Departament və ya Vəzifəni Düzgün Seçin !!! Secin","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                    FileStream fs = new FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] images = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    E.Name = txt_Adi.Text;
                    E.Surname = txt_Soyadi.Text;
                    E.FatherName = txt_AtaAdi.Text;
                    E.SHVN = mt_SHVN.Text;
                    E.Gender = Gender.ToString();
                    E.MaritalStatus = MaritalStatus.ToString();
                    E.specialtyID = Convert.ToInt32(cmb_Specialty.SelectedValue);
                    E.Experience_Year = nud_IsTecrubesi.Value.ToString();
                    E.DateOfBirth = dtp_DogumT.Value;
                    E.DateOfJoin = dtp_IseGirisT.Value;
                    E.ContactNumber = mskt_ElaqeNomresi.Text;
                    E.BirthPlace = txt_DogulduguYer.Text;
                    E.Adress = txt_Adress.Text;
                    E.Nationality = txt_Milliyeti.Text;
                    E.Description = txt_IsdenCixmaSebebi.Text;
                    E.UserName = txt_IstifadeciAdi.Text;
                    E.Password = txt_Parol.Text;
                    E.FINCode = txt_FINKOD.Text;
                    E.departmentID = Convert.ToInt32(cmb_Departament.SelectedValue);

                    E.HomeTelNo = txt_EvTeli.Text;
                    E.EPosta = txt_EPosta.Text;
                    E.EmergencyCall = mt_TeciliZngEdilecekSexsNo.Text;
                    E.EmergencyName = txt_TeciliZngEdilecekSexsinTelName.Text;
                    E.OuterSHVN = txt_XariciSHVNo.Text;
                    E.InsuranceNo = txt_SigortaNo.Text;
                    E.WorkingType = cmb_IstirahetGunleri.Text;
                    E.Salary = Convert.ToDecimal(txt_EmekHaqqi.Text);
                    E.RestDay = cmb_IstirahetGunleri.Text;
                    E.ReasonForDismissal = txt_IsdenCixmaSebebi.Text;
                    E.CommandNo = cmb_EmrinNo.Text;
                    E.CommandNote = txt_EmrdeGosterilenler.Text;
                    E.AuthorizedPerson = txt_SelahiyyetliSexs.Text;

                    E.BankName = txt_BankaAdi.Text;
                    E.BankDepartamentNo = txt_BankaSobeKodu.Text;
                    E.BankAccountNo = txt_BankaHesabNo.Text;
                    E.IBANNo = txt_IBANNo.Text;
                    E.Education = cmb_Tehsili.Text;
                    E.EducationEnterprise = txt_TehsilAldigi_M.Text;
                    E.MilitaryService = cmb_HerbiMukellefiyyet.Text;

                    if (EORM.EmployeeControl(mt_SHVN.Text, txt_FINKOD.Text) == false)
                    {
                        MessageBox.Show("Bu Qeyd Movcuddur !!!","",MessageBoxButtons.OK,MessageBoxIcon.Stop);

                        Frm_EmployeeControl FrmEmployeeControl = new Frm_EmployeeControl();

                        Tools.Con.Open();
                     
                        SqlCommand cmd = new SqlCommand("prc_EmployeeControlYazdir", Tools.Con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@SHVN", mt_SHVN.Text);
                        cmd.Parameters.AddWithValue("@FINCode", txt_FINKOD.Text);

                        SqlDataReader oxu = cmd.ExecuteReader();
                        
                        while (oxu.Read())
                        {
                            FrmEmployeeControl.lbl_SHVN.Text = oxu["SHVN"].ToString();
                            FrmEmployeeControl.lbl_FinCod.Text = oxu["FINCode"].ToString();
                            FrmEmployeeControl.lbl_Adi.Text = oxu["Name"].ToString();
                            FrmEmployeeControl.lbl_Soyadi.Text = oxu["Surname"].ToString();
                            FrmEmployeeControl.lbl_Vezifesi.Text = oxu["SpecialtyName"].ToString();
                            byte[] img = (byte[])oxu[5];

                            if (img == null)
                            {
                                FrmEmployeeControl.pictureBox_ControlYazdir.Image = null;
                            }
                            else
                            {
                                MemoryStream ms = new MemoryStream(img);
                                FrmEmployeeControl.pictureBox_ControlYazdir.Image = Image.FromStream(ms);
                            }
                        }

                        Tools.Con.Close();

                        FrmEmployeeControl.ShowDialog();
                    }

                    int IDScalar = Convert.ToInt32(EORM.InsertScalar(E));

                    if (IDScalar > 0)
                    {
                        P.employeeID = IDScalar;
                        P.Picture = images;

                        PORM.SekilElaveET(P);

                        MessageBox.Show("Yaddaşa Yazıldı");
                        this.Close();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Zəhmət Olmasa Məlumatları Əlavə Edin !!!");
                }
            }

            else if (Tools.page == 1)
            {
                try
                {
                    DialogResult dialoqum = MessageBox.Show("Seçilmiç Məlumatlar Dəyişdirilsin?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (DialogResult.OK == dialoqum)
                {
                    byte[] images = null;
                    FileStream fs = new FileStream(openFileDialog1.FileName.ToString(), FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    images = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    E.EmployeeID = id;
                    E.Name = txt_Adi.Text;
                    E.Surname = txt_Soyadi.Text;
                    E.FatherName = txt_AtaAdi.Text;
                    E.SHVN = mt_SHVN.Text;
                    E.Gender = Gender.ToString();
                    E.MaritalStatus = MaritalStatus.ToString();
                    E.specialtyID = Convert.ToInt32(cmb_Specialty.SelectedValue);
                    E.Experience_Year = nud_IsTecrubesi.Value.ToString();
                    E.DateOfBirth = dtp_DogumT.Value;
                    E.DateOfJoin = dtp_IseGirisT.Value;
                    E.ContactNumber = mskt_ElaqeNomresi.Text;
                    E.BirthPlace = txt_DogulduguYer.Text;
                    E.Adress = txt_Adress.Text;
                    E.Nationality = txt_Milliyeti.Text;
                    E.Description = txt_IsdenCixmaSebebi.Text;
                    E.Active = active;
                    E.UserName = txt_IstifadeciAdi.Text;
                    E.Password = txt_Parol.Text;
                    E.departmentID = Convert.ToInt32(cmb_Departament.SelectedValue);
                    E.FINCode = txt_FINKOD.Text;

                    E.HomeTelNo = txt_EvTeli.Text;
                    E.EPosta = txt_EPosta.Text;
                    E.EmergencyCall = mt_TeciliZngEdilecekSexsNo.Text;
                    E.EmergencyName = txt_TeciliZngEdilecekSexsinTelName.Text;
                    E.OuterSHVN = txt_XariciSHVNo.Text;
                    E.InsuranceNo = txt_SigortaNo.Text;
                    E.WorkingType = cmb_IstirahetGunleri.Text;
                    E.Salary = Convert.ToDecimal(txt_EmekHaqqi.Text);
                    E.RestDay = cmb_IstirahetGunleri.Text;
                    E.ReasonForDismissal = txt_IsdenCixmaSebebi.Text;
                    E.CommandNo = cmb_EmrinNo.Text;
                    E.CommandNote = txt_EmrdeGosterilenler.Text;
                    E.AuthorizedPerson = txt_SelahiyyetliSexs.Text;

                    E.BankName = txt_BankaAdi.Text;
                    E.BankDepartamentNo = txt_BankaSobeKodu.Text;
                    E.BankAccountNo = txt_BankaHesabNo.Text;
                    E.IBANNo = txt_IBANNo.Text;
                    E.Education = cmb_Tehsili.Text;
                    E.EducationEnterprise = txt_TehsilAldigi_M.Text;
                    E.MilitaryService = cmb_HerbiMukellefiyyet.Text;

                    EORM.Update(E);

                    PORM.SekilDeyis(id, images);

                    MessageBox.Show("Məlumatlar Dəyişdirildi");

                    this.Close();
                }

            }
                catch (Exception)
            {

                MessageBox.Show("Zəhmət Olmasa Boş Qalan Xanalrı Doldurun !!!", "Error");
            }
        }

        }

        private void txt_FINKOD_TextChanged(object sender, EventArgs e)
        {
            //txt_FINKOD.Text = txt_FINKOD.Text.ToUpper();

            string finkod = txt_FINKOD.Text;
            char[] array = finkod.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if ((char.IsDigit(array[i]) || ((int)'A' <= (int)array[i] && (int)array[i] <= (int)'Z')))
                {
                    if (txt_FINKOD.Text.Length == 7)
                    {
                        FINCode = true;
                    }
                }
                else
                {
                    FINCode = false;
                    return;
                }
            }
        }

        private void btn_Browse_Picture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Sekil Sec";
            openFileDialog1.Filter = "All|*.*|Png|*.png|Jpg|*.jpg";
            DialogResult dialog = openFileDialog1.ShowDialog();
            if (DialogResult.OK == dialog)
            {
                pictureBox_Employee.ImageLocation = openFileDialog1.FileName.ToString();
            }
        }

       
    }
}

