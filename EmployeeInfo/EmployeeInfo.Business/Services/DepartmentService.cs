using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            if (departmentRepository != null)
                this._departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await _departmentRepository.GetDepartmentsAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(Id);
        }
    }
}
