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
    public class LocationRepository : ILocationRepository
    {
        private EF.EmployeeInfoContext _db;
        public LocationRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<Location> GetLocationByIdAsync(int Id)
        {
            try
            {
                var location = await _db.Location.SingleOrDefaultAsync(a => a.Id == Id);

                return new Location()
                {
                    Id = location.Id,
                    LocationName = location.LocationName,                   
                    ModifiedDate = location.ModifiedDate,
                    ModifiedBy = location.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {
                return await _db.Location.Select(location => new Location()
                {
                    Id = location.Id,
                    LocationName = location.LocationName,
                    ModifiedDate = location.ModifiedDate,
                    ModifiedBy = location.ModifiedBy

                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditLocationAsync(Location location)
        {
            try
            {
                var locationitem = new Location()
                {
                    Id = location.Id,
                    LocationName = location.LocationName,
                    ModifiedDate = location.ModifiedDate,
                    ModifiedBy = location.ModifiedBy
                };

                _db.Entry(locationitem).State = locationitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
