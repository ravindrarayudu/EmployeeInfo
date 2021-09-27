using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Address
    {
        public Address()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string AddressDescription { get; set; }
        public string AddressLineOne { get; set; }
        public int CityId { get; set; }
        public string LandMark { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        public virtual City City { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
