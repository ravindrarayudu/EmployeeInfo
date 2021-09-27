using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = EmployeeInfo.Data.DataContext;

namespace EmployeeInfo.Data.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private EF.EmployeeInfoContext _db;
        public CustomerRepository(EF.EmployeeInfoContext context)
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
        public async Task<int> AddEditCustomerAsync(Customer customer)
        {
            try
            {
                var customeritem = new Customer()
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    AddressId = customer.AddressId,
                    ModifiedDate = customer.ModifiedDate,
                    ModifiedBy = customer.ModifiedBy
                };

                _db.Entry(customeritem).State = customeritem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
