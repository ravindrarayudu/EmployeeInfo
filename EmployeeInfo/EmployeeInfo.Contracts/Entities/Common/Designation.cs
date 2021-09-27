using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public  class Designation
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public string DesignationDescription { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
