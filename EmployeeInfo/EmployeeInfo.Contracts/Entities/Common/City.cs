using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class City
    {     
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
