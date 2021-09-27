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
    public class StateRepository : IStateRepository
    {
        private EF.EmployeeInfoContext _db;
        public StateRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            try
            {
                return await _db.State.Select(state => new State()
                {
                    Id = state.Id,
                    StateName = state.StateName,
                    ModifiedDate = state.ModifiedDate,
                    ModifiedBy = state.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<State> GetStateByIdAsync(int Id)
        {
            try
            {
                var state = await _db.State.SingleOrDefaultAsync(a => a.Id == Id);
                return new State()
                {
                    Id = state.Id,
                    StateName = state.StateName,
                    ModifiedDate = state.ModifiedDate,
                    ModifiedBy = state.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditStateAsync(State state)
        {
            try
            {
                var stateitem = new State()
                {
                    Id = state.Id,
                    StateName = state.StateName,
                    CountryId = state.CountryId,
                    ModifiedDate = state.ModifiedDate,
                    ModifiedBy = state.ModifiedBy
                };
                _db.Entry(stateitem).State = stateitem.Id == 0 ? EntityState.Added : EntityState.Modified;
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
