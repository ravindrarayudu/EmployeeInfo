using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            if (countryRepository != null)
                this._countryRepository = countryRepository;
        }       
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _countryRepository.GetCountriesAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int Id)
        {
            return await _countryRepository.GetCountryByIdAsync(Id);
        }
    }
}
