using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Contracts.Entities.Custom;
using EmployeeInfo.Contracts.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int Id);
        Task<Employee> GetEmployeeByEmployeeIdAsync(string employeeId);
        Task<EmployeeSearchResult> GetEmployeesAsync(string employeeName, string mobile, string aadhar, string uan, DateTime? dateFrom, DateTime? dateTo, PaginationRequest paging, int totalCount, int newPageIndex);
        Task<EmployeeSearchResult> GetEmployeesAsync(EmployeeSearchRequest employeeSearchRequest);
        Task<int> AddEditEmployeeAsync(Employee employee);
    }
}
