using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Contracts.Abstract
{
    public interface IBankDetailsService
    {
        Task<IEnumerable<BankDetails>> GetBankDetailsAsync();
        Task<BankDetails> GetBankDetailsByIdAsync(int Id);
    }
}
