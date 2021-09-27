using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Components
{
    public class CustomersViewComponent : ViewComponent
    {
        private readonly IEmployeeCustomerService _employeeCustomerService;
        private readonly ILogger<CustomersViewComponent> _logger;
        public CustomersViewComponent(IEmployeeCustomerService employeeCustomerService, ILogger<CustomersViewComponent> logger)
        {
            try
            {
                // Settings.  
                this._employeeCustomerService = employeeCustomerService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }
        public async Task<IViewComponentResult> InvokeAsync(int employeeid)
        {
            IEnumerable<Customer> customers = await _employeeCustomerService.GetCustomersByEmployeeIdAsync(employeeid);
            return View(customers);
        }
    }
}
