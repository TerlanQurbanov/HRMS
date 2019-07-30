using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ENTITY
{
   public class Tbl_Pictures:EntityBase
    {
        public int PictureID { get; set; }
        public byte[] Picture { get; set; }
        public int employeeID { get; set; }
        public bool Active { get; set; }

        public override string PrimaryColumn
        {
            get
            {
                return "PictureID";
            }
        }
    }
}
