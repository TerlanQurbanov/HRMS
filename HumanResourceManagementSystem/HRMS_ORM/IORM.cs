using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ORM
{
  public  interface IORM<T>
    {
        DataTable Select();
        bool Insert(T entity);
        object InsertScalar(T entity);
        bool Update(T entity);
        bool Delete(int ID);
    }
}
