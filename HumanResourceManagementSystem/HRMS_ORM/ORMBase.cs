using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ORM
{
    public class ORMBase<T> : IORM<T>
    {
        Type TipGetir
        {
            get
            {
                return typeof(T);
            }
        }

        public bool Delete(int ID)
        {
            T ent = Activator.CreateInstance<T>();

            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Delete", TipGetir.Name), Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo property = TipGetir.GetProperty("PrimaryColumn");

            string prmValue = "@" + property.GetValue(ent);
            cmd.Parameters.AddWithValue(prmValue, ID);
            return Tools.SqlExecute(cmd);

        }

        public bool Insert(T entity)
        {
            
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Insert",TipGetir.Name),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo[] propertys = TipGetir.GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                string prmName = "@" + pi.Name;
                if (pi.Name== "PrimaryColumn") 
                {
                    continue;
                }
                object prmValue = pi.GetValue(entity);
                cmd.Parameters.AddWithValue(prmName, prmValue);
            }
            return Tools.SqlExecute(cmd);

        }

        public object InsertScalar(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Insert", TipGetir.Name), Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo[] propertys = TipGetir.GetProperties();

            foreach (PropertyInfo pi in propertys)
            {
                string prAdi = "@" + pi.Name;
                if (pi.Name=="PrimaryColumn")
                {
                    continue;
                }
                object prValues = pi.GetValue(entity);

                cmd.Parameters.AddWithValue(prAdi, prValues);
            }
            return Tools.ExecuteScalar(cmd);
            
        }

        public DataTable Select()
        {
        
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(string.Format("prc_{0}_Select",TipGetir.Name),Tools.Con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            return dt;
            
        }

        public bool Update(T entity)
        {
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Update",TipGetir.Name),Tools.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo[] propertys = TipGetir.GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                string prmName = "@" + pi.Name;
                if (pi.Name == "PrimaryColumn")
                {
                    continue;
                }
                object prmValue = pi.GetValue(entity);
                cmd.Parameters.AddWithValue(prmName, prmValue);
            }
            return Tools.SqlExecute(cmd);
        }

    }
}
