using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS_ENTITY
{
   public class Tbl_Banks:EntityBase
    {
        public Tbl_Banks()
        {
            Active = true;
        }
        public int BankaID { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string IBAN { get; set; }
        public string BankSectorName { get; set; }
        public bool Active { get; set; }

        public override string PrimaryColumn
        {
            get
            {
                return "BankaID";
            }
        }
    }
}
