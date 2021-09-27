using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            if (locationRepository != null)
                this._locationRepository = locationRepository;
        }

        public async Task<Location> GetLocationByIdAsync(int Id)
        {
            return await _locationRepository.GetLocationByIdAsync(Id);
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _locationRepository.GetLocationsAsync();
        }
    }
}
