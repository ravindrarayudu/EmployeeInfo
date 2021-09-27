using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Customer
    {
        public Customer()
        {
            EmployeeCustomer = new HashSet<EmployeeCustomer>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<EmployeeCustomer> EmployeeCustomer { get; set; }
    }
}
