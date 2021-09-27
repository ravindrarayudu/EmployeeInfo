using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Location
    {
        public Location()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string LocationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
