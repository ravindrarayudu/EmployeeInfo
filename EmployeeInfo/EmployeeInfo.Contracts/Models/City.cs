using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
