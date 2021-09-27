using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetDesignationsAsync();
        Task<Designation> GetDesignationByIdAsync(int Id);
        Task<int> AddEditDesignationAsync(Designation designation);
    }
}
