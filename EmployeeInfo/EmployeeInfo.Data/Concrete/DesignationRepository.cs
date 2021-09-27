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
    public class DesignationRepository : IDesignationRepository
    {
        private EF.EmployeeInfoContext _db;
        public DesignationRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<Designation>> GetDesignationsAsync()
        {
            try
            {
                return await _db.Designation.Select(designation => new Designation()
                {
                    Id                      = designation.Id,
                    DesignationName         = designation.DesignationName,
                    DesignationDescription  = designation.DesignationDescription,
                    ModifiedDate            = designation.ModifiedDate,
                    ModifiedBy              = designation.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Designation> GetDesignationByIdAsync(int Id)
        {
            try
            {
                var designation = await _db.Designation.SingleOrDefaultAsync(a => a.Id == Id);
                return new Designation()
                {
                    Id                      = designation.Id,
                    DesignationName         = designation.DesignationName,
                    DesignationDescription  = designation.DesignationDescription,
                    ModifiedDate            = designation.ModifiedDate,
                    ModifiedBy              = designation.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditDesignationAsync(Designation designation)
        {
            try
            {
                var designationitem = new Designation()
                {
                    Id = designation.Id,
                    DesignationName = designation.DesignationName,
                    DesignationDescription = designation.DesignationDescription,
                    ModifiedDate = designation.ModifiedDate,
                    ModifiedBy = designation.ModifiedBy
                };

                _db.Entry(designationitem).State = designationitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
