using HRMS_ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ORM
{
    public class Tbl_EmployeeORM : ORMBase<Tbl_Employee>
    {
        public DataTable SqlReader(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("prc_Tbl_EmployeeReader_Select", Tools.Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@EmployeeID", id);
            da.Fill(dt);
            return dt;
        }

        public DataTable Search(string Search)
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select ROW_NUMBER() OVER(Order by EmployeeID desc)'S/S', EmployeeID,e.Name'Adı',Surname'Soyadı',FatherName'AtaAdı',d.Name 'Departament',SpecialtyName'İxtisası',ContactNumber'Əlaqə.No',BirthPlace 'Doğulduğu Yer',Salary'Əməkhaqqı',DateOfBirth'Doğum T',FINCode'FIN Kod',Gender'Cinsiyət',MaritalStatus'Ailə Vəziyyəti',Experience_Year'İş Təcrübəsi(İL)',DateOfJoin'İşə B.T',e.Adress'Ünvan',Description'Qeyd',e.Active,UserName'İstifadəçi Adı',Password'Şifrə'from Tbl_Employee e Left Join Tbl_Department d on e.departmentID=d.DepartmentID  Left Join Tbl_Specialty s  on s.SpecialtyID=e.specialtyID where e.Name like'%" + Search + "%' or Surname like'%" + Search + "%' or FINCode like'%" + Search + "%' or ContactNumber like'%" + Search + "%' or FatherName like'%" + Search + "%' or Gender like'%" + Search + "%' or MaritalStatus like'%" + Search + "%' or SpecialtyName like'%" + Search + "%' or d.Name like'%" + Search + "%' or Experience_Year like'%" + Search + "%' or DateOfBirth like'%" + Search + "%' or DateOfJoin like'%" + Search + "%' or ContactNumber like '%" + Search + "%' or BirthPlace like'%" + Search + "%' or e.Adress like'%" + Search + "%' or Nationality like'%" + Search + "%' or Description like'%" + Search + "%' or UserName like'%" + Search + "%' or Password like'%" + Search + "%'    or HomeTelNo like'%" + Search + "%'   or EPosta like'%" + Search + "%'   or EmergencyCall like'%" + Search + "%'   or InsuranceNo like'%" + Search + "%'   or WorkingType like'%" + Search + "%'   or Salary like'%" + Search + "%'   or RestDay like'%" + Search + "%'  or BankName like'%" + Search + "%'     or BankDepartamentNo like'%" + Search + "%'     or BankAccountNo like'%" + Search + "%'     or ReasonForDismissal like'%" + Search + "%'     or CommandNo like'%" + Search + "%'     or CommandNote like'%" + Search + "%'      or IBANNo like'%" + Search + "%'     or Education like'%" + Search + "%'     or EducationEnterprise like'%" + Search + "%'     or MilitaryService like'%" + Search + "%' or AuthorizedPerson like '%" + Search + "%' ", Tools.Con);


            da.Fill(dt);
            return dt;

        }

        public bool EmployeeControl(string prmSHVN, string prmFINCode)
        {
            bool control = true;
            Tools.Con.Open();
            SqlCommand cmd = new SqlCommand("prc_EmployeeControl", Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SHVN", prmSHVN);
            cmd.Parameters.AddWithValue("@FINCode", prmFINCode);

            SqlDataReader oxu = cmd.ExecuteReader();

            while (oxu.Read())
            {
                if (prmSHVN == oxu["SHVN"].ToString() || prmFINCode == oxu["FINCode"].ToString())
                {
                    control = false;

                }
                else
                {
                    control = true;
                }

            }

            Tools.Con.Close();
            return control;
        }

        public DataTable BirthDay()
        {
            Tools.Con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("prc_BirthDay_Select",Tools.Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            Tools.Con.Close();

            return dt;
        }
    }
}
