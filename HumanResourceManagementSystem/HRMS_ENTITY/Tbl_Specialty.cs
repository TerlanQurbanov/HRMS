using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ENTITY
{
    public class Tbl_Specialty : EntityBase
    {
        public Tbl_Specialty()
        {
            Active = true;
        }
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public string Positions { get; set; }
        public bool Active { get; set; }
        public override string PrimaryColumn
        {
            get
            {
                return "SpecialtyID";
            }
        }
    }
}
