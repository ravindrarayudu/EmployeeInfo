using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface IEmployeeCustomerService
    {
        Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersAsync();
        Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersByEmployeeIdAsync(int Id);
        Task<IEnumerable<Customer>> GetCustomersByEmployeeIdAsync(int Id);
        Task<IEnumerable<Customer>> GetCustomersNotWithEmployeeIdAsync(int Id);
    }
}
