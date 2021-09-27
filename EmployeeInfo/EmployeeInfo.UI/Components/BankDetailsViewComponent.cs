using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Components
{
    public class BankDetailsViewComponent : ViewComponent
    {
        private readonly IBankDetailsService _bankDetailsService;
        private readonly ILogger<BankDetailsViewComponent> _logger;
        public BankDetailsViewComponent(IBankDetailsService bankDetailsService, ILogger<BankDetailsViewComponent> logger)
        {
            try
            {
                // Settings.  
                this._bankDetailsService = bankDetailsService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }
        public async Task<IViewComponentResult> InvokeAsync(int bankid)
        {
            BankDetails bankdetails = new BankDetails();
            bankdetails = await _bankDetailsService.GetBankDetailsByIdAsync(bankid);
            return View(bankdetails);
        }
    }
}
