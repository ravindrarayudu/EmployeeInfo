using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressDescription { get; set; }
        public string AddressLineOne { get; set; }
        public int CityId { get; set; }
        public string LandMark { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
