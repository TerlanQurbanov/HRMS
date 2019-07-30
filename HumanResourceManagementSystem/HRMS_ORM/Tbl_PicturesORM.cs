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
   public class Tbl_PicturesORM:ORMBase<Tbl_Pictures>
    {
        public bool SekilElaveET(Tbl_Pictures p)
        {
            SqlCommand cmd = new SqlCommand("prc_Tbl_Pictures_Insert",Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@employeeID", p.employeeID);
            cmd.Parameters.AddWithValue("@picture", p.Picture.Length).Value=p.Picture;

            return Tools.SqlExecute(cmd);
        }

        public bool SekilDeyis(int ID,byte[] img)
        {
            Tools.Con.Open();
            SqlCommand cmd = new SqlCommand("prc_Tbl_Pictures_Update", Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Picture",img);
            cmd.Parameters.AddWithValue("@employeeID", ID);

            int etk = cmd.ExecuteNonQuery();
            Tools.Con.Close();
            return etk > 0 ? true : false;
        }

    }
}
