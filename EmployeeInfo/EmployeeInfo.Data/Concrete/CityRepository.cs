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
    public class CityRepository : ICityRepository
    {
        private EF.EmployeeInfoContext _db;
        public CityRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            try
            {
                return await _db.City.Select(city => new City()
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    ModifiedDate = city.ModifiedDate,
                    ModifiedBy = city.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<City> GetCityByIdAsync(int Id)
        {
            try
            {
                var city = await _db.City.SingleOrDefaultAsync(a => a.Id == Id);

                return new City()
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    ModifiedDate = city.ModifiedDate,
                    ModifiedBy = city.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditCityAsync(City city)
        {
            try
            {
                var cityitem = new City()
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    StateId = city.StateId,
                    ModifiedDate = city.ModifiedDate,
                    ModifiedBy = city.ModifiedBy
                };

                _db.Entry(cityitem).State = cityitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
