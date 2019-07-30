using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ORM
{
   public static class Tools
    {
        private static SqlConnection con;

        public static int page;
        public static int PageShtat;
        public static int PageDepartment;

        public static SqlConnection Con
        {
            get {
                if (con==null)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
                }
                return con;
            }
           
        }

        public static bool SqlExecute(SqlCommand cmd)
        {
            //    try
            //    {
            //        if (cmd.Connection.State==ConnectionState.Closed)
            //        {
            //            cmd.Connection.Open();
            //        }

            //        int etk = cmd.ExecuteNonQuery();
            //        return etk > 0 ? true : false;
            //    }
            //    catch (Exception)
            //    {

            //        return false;
            //    }
            //    finally
            //    {
            //        if (cmd.Connection.State==ConnectionState.Open)
            //        {
            //            cmd.Connection.Close();
            //        }
            //    }

            con.Open();
            int etk = cmd.ExecuteNonQuery();
            con.Close();
            return etk > 0 ? true : false;
            
        }

        public static object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State==ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }

               return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                if (cmd.Connection.State==ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }

    }
}
