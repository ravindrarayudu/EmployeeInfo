using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
