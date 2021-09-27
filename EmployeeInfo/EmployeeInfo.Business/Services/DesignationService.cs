using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class DesignationService : IDesignationService
    {
        private IDesignationRepository _designationRepository;

        public DesignationService(IDesignationRepository designationRepository)
        {
            if (designationRepository != null)
                this._designationRepository = designationRepository;
        }

        public async Task<IEnumerable<Designation>> GetDesignationsAsync()
        {
            return await _designationRepository.GetDesignationsAsync();
        }

        public async Task<Designation> GetDesignationByIdAsync(int Id)
        {
            return await _designationRepository.GetDesignationByIdAsync(Id);
        }
    }
}
