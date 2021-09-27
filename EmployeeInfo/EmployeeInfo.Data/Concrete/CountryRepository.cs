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
    public class CountryRepository : ICountryRepository
    {
        private EF.EmployeeInfoContext _db;
        public CountryRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            try
            {
                return await _db.Country.Select(country => new Country()
                {
                    Id = country.Id,
                    CountryName = country.CountryName,
                    ModifiedDate = country.ModifiedDate,
                    ModifiedBy = country.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Country> GetCountryByIdAsync(int Id)
        {
            try
            {
                var country = await _db.Country.SingleOrDefaultAsync(a => a.Id == Id);
                return new Country()
                {
                    Id = country.Id,
                    CountryName = country.CountryName,
                    ModifiedDate = country.ModifiedDate,
                    ModifiedBy = country.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditCountryAsync(Country country)
        {
            try
            {
                var countryitem = new Country()
                {
                    Id = country.Id,
                    CountryName = country.CountryName,
                    ModifiedDate = country.ModifiedDate,
                    ModifiedBy = country.ModifiedBy
                };

                _db.Entry(countryitem).State = countryitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
