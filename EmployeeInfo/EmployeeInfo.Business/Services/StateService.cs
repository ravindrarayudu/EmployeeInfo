using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class StateService : IStateService
    {
        private IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            if (stateRepository != null)
                this._stateRepository = stateRepository;
        }       
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            return await _stateRepository.GetStatesAsync();
        }

        public async Task<State> GetStateByIdAsync(int Id)
        {
            return await _stateRepository.GetStateByIdAsync(Id);
        }
    }
}
