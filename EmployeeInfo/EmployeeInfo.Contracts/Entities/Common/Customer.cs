using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Customer
    {
       
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public User ModifiedByNavigation { get; set; }
        public ICollection<EmployeeCustomer> EmployeeCustomer { get; set; }
    }
}
