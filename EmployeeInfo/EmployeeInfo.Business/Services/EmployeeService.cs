using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Contracts.Entities.Custom;
using EmployeeInfo.Contracts.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            if (employeeRepository != null)
                this._employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(Id);
        }
        public async Task<Employee> GetEmployeeByEmployeeIdAsync(string employeeId)
        {
            return await _employeeRepository.GetEmployeeByEmployeeIdAsync(employeeId);
        }
        public async Task<EmployeeSearchResult> GetEmployeesAsync(string employeeName, string mobile, string aadhar, string uan, DateTime? dateFrom, DateTime? dateTo, PaginationRequest paging, int totalCount, int newPageIndex)
        {
            return await _employeeRepository.GetEmployeesAsync(employeeName, mobile, aadhar, uan, dateFrom, dateTo, paging, totalCount, newPageIndex);
        }
        public async Task<EmployeeSearchResult> GetEmployeesAsync(EmployeeSearchRequest employeeSearchRequest)
        {
            return await _employeeRepository.GetEmployeesAsync(employeeSearchRequest);
        }
        public async Task<int> AddEditEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddEditEmployeeAsync(employee);
        }
    }
}
