using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ENTITY
{
  public class Tbl_Department:EntityBase
    {
        public Tbl_Department()
        {
            Active = true;
        }
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TelNo { get; set; }
        public string Mail { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        public override string PrimaryColumn
        {
            get
            {
                return "DepartmentID";
            }
        }
    }
}
