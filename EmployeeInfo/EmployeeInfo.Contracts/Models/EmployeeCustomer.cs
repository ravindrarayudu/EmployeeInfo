using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class EmployeeCustomer
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
    }
}
