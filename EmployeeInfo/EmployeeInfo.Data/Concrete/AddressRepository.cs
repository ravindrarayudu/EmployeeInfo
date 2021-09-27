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
    public class AddressRepository : IAddressRepository
    {
        private EF.EmployeeInfoContext _db;
        public AddressRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            try
            {
                return await _db.Address.Select(address => new Address()
                {
                    Id                  = address.Id,
                    AddressDescription  = address.AddressDescription,
                    AddressLineOne      = address.AddressLineOne,
                    CityId              = address.CityId,
                    LandMark            = address.LandMark,
                    ModifiedDate        = address.ModifiedDate,
                    ModifiedBy          = address.ModifiedBy

                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Address> GetAddressByIdAsync(int Id)
        {
            try
            {
                var address = await  _db.Address.Where(x => x.Id == Id).FirstAsync();

                return new Address()
                {
                    Id = address.Id,
                    AddressDescription = address.AddressDescription,
                    AddressLineOne = address.AddressLineOne,
                    CityId = address.CityId,
                    LandMark = address.LandMark,
                    ModifiedDate = address.ModifiedDate,
                    ModifiedBy = address.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Address> GetAddressByCustomerIdAsync(int CustomerId)
        {
            try
            {
                var address = await (from addresses in _db.Address
                                     join customer in _db.Customer on addresses.Id
                                     equals customer.AddressId
                                     where customer.Id == CustomerId
                                     select addresses).FirstAsync();

                return new Address()
                {
                    Id = address.Id,
                    AddressDescription = address.AddressDescription,
                    AddressLineOne = address.AddressLineOne,
                    CityId = address.CityId,
                    LandMark = address.LandMark,
                    ModifiedDate = address.ModifiedDate,
                    ModifiedBy = address.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Address> GetAddressByEmployeeIdAsync(int EmployeeId)
        {
            try
            {
                var  address = await (from addresses in _db.Address
                                     join employees in _db.Employee on addresses.Id 
                                     equals employees.AddressId
                                     where employees.EmployeeId == EmployeeId.ToString()
                               select addresses).FirstAsync();

                return new Address()
                {
                    Id = address.Id,
                    AddressDescription = address.AddressDescription,
                    AddressLineOne = address.AddressLineOne,
                    CityId = address.CityId,
                    LandMark = address.LandMark,
                    ModifiedDate = address.ModifiedDate,
                    ModifiedBy = address.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditAddressAsync(Address address)
        {
            try
            {
                var addressitem = new Address()
                {
                    Id = address.Id,
                    AddressDescription = address.AddressDescription,
                    AddressLineOne  = address.AddressLineOne,
                    CityId = address.CityId,
                    LandMark = address.LandMark,
                    ModifiedDate = address.ModifiedDate,
                    ModifiedBy = address.ModifiedBy
                };
                _db.Entry(addressitem).State = addressitem.Id == 0 ? EntityState.Added : EntityState.Modified;
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
