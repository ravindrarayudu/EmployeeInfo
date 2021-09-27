using EmployeeInfo.Contracts.Binders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInfo.Contracts.Entities.Request
{
    [ModelBinder(BinderType = typeof(EmployeeBinder))]
    public class EmployeeSearchRequest
    {
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public string Aadhar { get; set; }
        public string Uan { get; set; }
        public Guid UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int TotalCount { get; set; }
        public PaginationRequest PaginationRequest { get; set; }
    }
}
