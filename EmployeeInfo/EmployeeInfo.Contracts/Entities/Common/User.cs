using System;
using System.Collections.Generic;

namespace EmployeeInfo.Contracts.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string ContactName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsForgotPassword { get; set; }
        public int? LocationId { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
