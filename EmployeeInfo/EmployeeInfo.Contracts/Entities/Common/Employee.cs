using EmployeeInfo.Contracts.Entities.Custom;
using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public int AddressId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
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
        public Address Address { get; set; }
        public BankDetails Bank { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
        public Location Location { get; set; }
        public User ModifiedByNavigation { get; set; }
        public IEnumerable<EmployeeCustomer> EmployeeCustomer { get; set; }
    }
}
