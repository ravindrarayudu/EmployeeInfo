using EmployeeInfo.Contracts.Entities.Request;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeInfo.Contracts.Entities.Custom
{
    public class EmployeeSearchViewModel
    {      
        public EmployeeSearch employeeSearch { get; set; }
        public EmployeeSearchResult employeeSearchResult { get; set; }
        public EmployeeSearchRequest employeeSearchRequest { get; set; }
    }
    public class EmployeeSearchResult
    {
        public int TotalCount { get; set; }
        public int NewPageIndex { get; set; }
        public IEnumerable<EmployeeSearch> EmployeeSearchList { get; set; }
    }
    public class EmployeeSearch
    {
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public string Aadhar { get; set; }
        public string Uan { get; set; }
        public DateTime? DateOfJoining { get; set; }
    }
}
