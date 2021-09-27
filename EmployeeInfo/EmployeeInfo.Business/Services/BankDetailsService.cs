using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class BankDetailsService : IBankDetailsService
    {
        private IBankDetailsRepository _bankdetailsRepository;

        public BankDetailsService(IBankDetailsRepository bankdetailsRepository)
        {
            if (bankdetailsRepository != null)
                this._bankdetailsRepository = bankdetailsRepository;
        }

        public async Task<IEnumerable<BankDetails>> GetBankDetailsAsync()
        {
            return await _bankdetailsRepository.GetBankDetailsAsync();
        }

        public async Task<BankDetails> GetBankDetailsByIdAsync(int Id)
        {
            return await _bankdetailsRepository.GetBankDetailsByIdAsync(Id);
        }
    }
}
