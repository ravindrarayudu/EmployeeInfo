using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Components
{
    public class CustomerViewComponent : ViewComponent
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerViewComponent> _logger;
        public CustomerViewComponent(ICustomerService customerService, ILogger<CustomerViewComponent> logger)
        {
            try
            {
                // Settings.  
                this._customerService = customerService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            Customer customer = await _customerService.GetCustomerByIdAsync(id);
            return View(customer);
        }
    }
}
