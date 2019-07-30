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
   public class Tbl_DepartmentORM:ORMBase<Tbl_Department>
    {
        public DataTable DepartamentSearch(string search)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ROW_NUMBER() Over(order by DepartmentID desc)'S/S',DepartmentID,Name'Adı',Adress'Ünvan',TelNo'Əlaqə No',Mail,CreationDate'Yaranma.T' from Tbl_Department where Name like '%" + search + "%' or Adress like'%" + search + "%' or TelNo like '%" + search + "%' or Mail like '%" + search + "%' or CreationDate like '" + search + "' ", Tools.Con);

            da.Fill(dt);
            return dt;
        }
    }
}
