using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task<Address> GetAddressByEmployeeIdAsync(int EmployeeId);
        Task<int> AddEditAddressAsync(Address address);
        Task<Address> GetAddressByIdAsync(int Id);
        Task<Address> GetAddressByCustomerIdAsync(int CustomerId);
    }
}
