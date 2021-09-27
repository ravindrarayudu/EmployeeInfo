using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class BankDetails
    {     
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Ifsccode { get; set; }
        public string BranchName { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
