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
    public class DepartmentRepository : IDepartmentRepository
    {
        private EF.EmployeeInfoContext _db;
        public DepartmentRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            try
            {
                return await _db.Department.Select(department => new Department()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                    Description = department.Description,
                    ModifiedDate = department.ModifiedDate,
                    ModifiedBy = department.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            try
            {
                var department = await _db.Department.SingleOrDefaultAsync(a => a.Id == Id);
                return new Department()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                    Description = department.Description,
                    ModifiedDate = department.ModifiedDate,
                    ModifiedBy = department.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditDepartmentAsync(Department department)
        {
            try
            {
                var departmentitem = new Department()
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                    Description = department.Description,
                    ModifiedDate = department.ModifiedDate,
                    ModifiedBy = department.ModifiedBy
                };

                _db.Entry(departmentitem).State = departmentitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
