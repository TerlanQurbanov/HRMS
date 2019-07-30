using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HRMS_ENTITY
{
  public class Tbl_Employee:EntityBase
    {
        public Tbl_Employee()
        {
            Active = true;
        }
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string SHVN { get; set; }
        public string FINCode { get; set; }
        public string  Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int specialtyID { get; set; }
        public int departmentID { get; set; }
        public string Experience_Year { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string ContactNumber { get; set; }
        public string BirthPlace { get; set; }
        public string Adress { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string HomeTelNo { get; set; }
        public string EPosta { get; set; }
        public string EmergencyCall { get; set; }
        public string EmergencyName { get; set; }
        public string OuterSHVN { get; set; }
        public string InsuranceNo { get; set; }
        public string WorkingType { get; set; }
        public decimal Salary { get; set; }
        public string RestDay { get; set; }
        public string ReasonForDismissal { get; set; }
        public string CommandNo { get; set; }
        public string CommandNote { get; set; }
        public string AuthorizedPerson { get; set; }
        public string BankName { get; set; }
        public string BankDepartamentNo { get; set; }
        public string BankAccountNo { get; set; }
        public string IBANNo { get; set; }
        public string Education { get; set; }
        public string EducationEnterprise { get; set; }
        public string MilitaryService { get; set; }

        public override string PrimaryColumn
        {
            get
            {
                return "EmployeeID";
            }
        }
    }
}
