using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            BankDetails = new HashSet<BankDetails>();
            City = new HashSet<City>();
            Country = new HashSet<Country>();
            Customer = new HashSet<Customer>();
            Department = new HashSet<Department>();
            Designation = new HashSet<Designation>();
            Employee = new HashSet<Employee>();
            EmployeeCustomer = new HashSet<EmployeeCustomer>();
            Location = new HashSet<Location>();
            State = new HashSet<State>();
        }

        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string ContactName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsForgotPassword { get; set; }
        public int? LocationId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<BankDetails> BankDetails { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Country> Country { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Designation> Designation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<EmployeeCustomer> EmployeeCustomer { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
