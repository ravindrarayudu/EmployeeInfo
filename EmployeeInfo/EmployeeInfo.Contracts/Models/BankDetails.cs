using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class BankDetails
    {
        public BankDetails()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string Ifsccode { get; set; }
        public string BranchName { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
