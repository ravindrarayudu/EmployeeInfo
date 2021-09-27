using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF = EmployeeInfo.Data.DataContext;

namespace EmployeeInfo.Data.Concrete
{
    public class EmployeeCustomerRepository : IEmployeeCustomerRepository
    {
        private EF.EmployeeInfoContext _db;
        public EmployeeCustomerRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _db.Customer.Select(customer => new Customer()
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    AddressId = customer.AddressId,
                    ModifiedDate = customer.ModifiedDate,
                    ModifiedBy = customer.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            try
            {
                var customer = await _db.Customer.SingleOrDefaultAsync(a => a.Id == Id);
                return new Customer()
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    AddressId = customer.AddressId,
                    ModifiedDate = customer.ModifiedDate,
                    ModifiedBy = customer.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }

        public Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeCustomer>> GetEmployeeCustomersByEmployeeIdAsync(int Id)
        {
            try
            {
                var employeeCustomers = await _db.EmployeeCustomer.Where(a => a.EmployeeId == Id).
                    Select(a => new EmployeeCustomer
                    {
                        Id = a.Id,
                        EmployeeId = a.EmployeeId,
                        CustomerId = a.CustomerId,
                        ModifiedBy = a.ModifiedBy,
                        ModifiedDate = a.ModifiedDate
                    }).ToListAsync();

                return employeeCustomers;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersNotWithEmployeeIdAsync(int Id)
        {
            try
            {
                var customerlist = await (from customer in _db.Customer
                                          join employeecustomer in _db.EmployeeCustomer
                                          on customer.Id equals employeecustomer.CustomerId
                                          join employee in _db.Employee
                                          on employeecustomer.EmployeeId equals employee.Id
                                          where employee.Id == Id
                                          select customer).ToListAsync();

                var customers = await (from customer in _db.Customer where !customerlist.Contains(customer)
                                       select new Customer
                                       {
                                           Id = customer.Id,
                                           CustomerName = customer.CustomerName,
                                           AddressId = customer.AddressId                                           
                                       }).ToListAsync();

                return customers;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor

            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersByEmployeeIdAsync(int Id)
        {
            try
            {
                var customers = await (from customer in _db.Customer
                                       join employeecustomer in _db.EmployeeCustomer
                                       on customer.Id equals employeecustomer.CustomerId
                                       join employee in _db.Employee
                                       on employeecustomer.EmployeeId equals employee.Id
                                       where employee.Id == Id
                                       select new Customer
                                       {
                                           Id = customer.Id,
                                           CustomerName = customer.CustomerName
                                       }).ToListAsync();

                return customers;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }

        public async Task<int> AddEditEmployeeCustomerAsync(EmployeeCustomer employeecustomer)
        {
            try
            {
                var employeecustomeritem = new EmployeeCustomer()
                {
                    Id = employeecustomer.Id,
                    EmployeeId = employeecustomer.EmployeeId,
                    CustomerId = employeecustomer.CustomerId,
                    ModifiedDate = employeecustomer.ModifiedDate,
                    ModifiedBy = employeecustomer.ModifiedBy
                };

                _db.Entry(employeecustomeritem).State = employeecustomeritem.Id == 0 ? EntityState.Added : EntityState.Modified;

                int x = await (_db.SaveChangesAsync());
                return x;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
    }
}
