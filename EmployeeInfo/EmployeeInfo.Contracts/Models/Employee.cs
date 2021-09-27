using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeCustomer = new HashSet<EmployeeCustomer>();
        }

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string BloodGroup { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public string Mobile { get; set; }
        public string Aadhar { get; set; }
        public int LocationId { get; set; }
        public string Uan { get; set; }
        public string Esi { get; set; }
        public int BankId { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        public virtual Address Address { get; set; }
        public virtual BankDetails Bank { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Location Location { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<EmployeeCustomer> EmployeeCustomer { get; set; }
    }
}
