using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DesignationName { get; set; }
        public string DesignationDescription { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
