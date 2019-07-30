using HRMS_ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ORM
{
   public class Tbl_SpecialtyORM:ORMBase<Tbl_Specialty>
    {
        public  DataTable ShtatSearch(string search)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ROW_NUMBER() OVER(Order by SpecialtyID desc)'S/S', SpecialtyID,SpecialtyName'İxtisas',Positions'Vəzifə Öhdəlikləri' from Tbl_Specialty where SpecialtyName like '%" + search+ "%' or Positions like '"+search+"' ", Tools.Con);
            da.Fill(dt);
            return dt;
           
        } 
    }
}
