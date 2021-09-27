using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class EmployeeCustomerService : IEmployeeCustomerService
    {
        private IEmployeeCustomerRepository _employeecustomerRepository;

        public EmployeeCustomerService(IEmployeeCustomerRepository employeecustomerRepository)
        {
            if (employeecustomerRepository != null)
                this._employeecustomerRepository = employeecustomerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByEmployeeIdAsync(int Id)
        {
            return await _employeecustomerRepository.GetCustomersByEmployeeIdAsync(Id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersNotWithEmployeeIdAsync(int Id)
        {
            return await _employeecustomerRepository.GetCustomersNotWithEmployeeIdAsync(Id);
        }

        public async Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersAsync()
        {
            return await _employeecustomerRepository.GetEmployeeCustomersAsync();
        }

        public async Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersByEmployeeIdAsync(int Id)
        {
            return await _employeecustomerRepository.GetEmployeeCustomersByEmployeeIdAsync(Id);
        }
    }
}
