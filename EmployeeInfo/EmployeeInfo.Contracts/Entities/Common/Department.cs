using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Department
    {      
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
