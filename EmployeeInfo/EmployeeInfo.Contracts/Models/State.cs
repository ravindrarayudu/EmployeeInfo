using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
