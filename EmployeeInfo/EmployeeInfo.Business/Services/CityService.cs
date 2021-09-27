using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class CityService : ICityService
    {
        private ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            if (cityRepository != null)
                this._cityRepository = cityRepository;
        }       
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _cityRepository.GetCitiesAsync();
        }

        public async Task<City> GetCityByIdAsync(int Id)
        {
            return await _cityRepository.GetCityByIdAsync(Id);
        }
    }
}
