using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Location
    {       
        public int Id { get; set; }
        public string LocationName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
