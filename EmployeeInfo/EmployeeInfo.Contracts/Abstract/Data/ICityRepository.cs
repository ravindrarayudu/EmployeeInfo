using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int Id);
        Task<int> AddEditCityAsync(City city);
    }
}
