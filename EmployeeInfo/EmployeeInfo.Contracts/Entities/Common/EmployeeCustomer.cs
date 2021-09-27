using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class EmployeeCustomer
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public User ModifiedByNavigation { get; set; }
    }
}
