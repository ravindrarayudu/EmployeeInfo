using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Models
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual User ModifiedByNavigation { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
