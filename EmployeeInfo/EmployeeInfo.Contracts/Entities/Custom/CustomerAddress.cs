using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInfo.Contracts.Entities.Custom
{
    class CustomerAddress
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string AddressDescription { get; set; }
        public string AddressLineOne { get; set; }
        public int CityName { get; set; }
        public string LandMark { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
