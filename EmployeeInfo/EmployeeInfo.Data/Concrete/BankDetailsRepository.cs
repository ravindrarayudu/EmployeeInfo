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
    public class BankDetailsRepository : IBankDetailsRepository
    {
        private EF.EmployeeInfoContext _db;
        public BankDetailsRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<IEnumerable<BankDetails>> GetBankDetailsAsync()
        {
            try
            {
                return await _db.BankDetails.Select(bankdetails => new BankDetails()
                {
                    Id = bankdetails.Id,
                    BankName = bankdetails.BankName,
                    BranchName = bankdetails.BranchName,
                    Ifsccode  = bankdetails.Ifsccode,
                    ModifiedDate = bankdetails.ModifiedDate,
                    ModifiedBy = bankdetails.ModifiedBy
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<BankDetails> GetBankDetailsByIdAsync(int Id)
        {
            try
            {
              
                var bankdetails = await _db.BankDetails.SingleOrDefaultAsync(a => a.Id == Id);

                if (bankdetails != null)
                {
                    return new BankDetails()
                    {
                        Id = bankdetails.Id,
                        BankName = bankdetails.BankName,
                        BranchName = bankdetails.BranchName,
                        Ifsccode = bankdetails.Ifsccode,
                        ModifiedDate = bankdetails.ModifiedDate,
                        ModifiedBy = bankdetails.ModifiedBy
                    };
                }
                else
                {
                    return new BankDetails();
                }

            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditBankDetailsAsync(BankDetails bankdetails)
        {
            try
            {
                var Bankdetailsitem = new BankDetails()
                {
                    Id = bankdetails.Id,
                    BankName = bankdetails.BankName,
                    BranchName = bankdetails.BranchName,
                    Ifsccode  = bankdetails.Ifsccode,
                    ModifiedDate = bankdetails.ModifiedDate,
                    ModifiedBy = bankdetails.ModifiedBy
                };

                _db.Entry(Bankdetailsitem).State = Bankdetailsitem.Id == 0 ? EntityState.Added : EntityState.Modified;

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
