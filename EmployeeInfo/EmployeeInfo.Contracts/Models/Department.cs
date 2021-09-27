using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
