using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            if (addressRepository != null)
                this._addressRepository = addressRepository;
        }

        public async Task<int> AddEditAddressAsync(Address address)
        {
            return await AddEditAddressAsync(address);
        }

        public async Task<Address> GetAddressByCustomerIdAsync(int CustomerId)
        {
            return await GetAddressByCustomerIdAsync(CustomerId);
        }

        public async Task<Address> GetAddressByEmployeeIdAsync(int EmployeeId)
        {
            return await GetAddressByEmployeeIdAsync(EmployeeId);
        }

        public async Task<Address> GetAddressByIdAsync(int Id)
        {
            return await _addressRepository.GetAddressByIdAsync(Id);
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _addressRepository.GetAddressesAsync();
        }
    }
}
