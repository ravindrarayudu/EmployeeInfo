using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeInfo.UI.Controllers
{
    public class CustomerEmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeCustomerService _employeeCustomerService;
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;
        public CustomerEmployeeController(                              
                               IEmployeeCustomerService employeeCustomerService,
                               ICustomerService customerService,
                               IAddressService addressService,
                               ICityService cityService,
                               ILogger<EmployeeController> logger)
        {
            try
            {               
                this._employeeCustomerService = employeeCustomerService;
                this._customerService = customerService;
                this._addressService = addressService;
                this._cityService = cityService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }

        [HttpGet]
        [Route("CustomerEmployee/CustomersNotWithEmployee/{EmployeeId?}")]
        public async Task<ActionResult> CustomersNotWithEmployee(int employeeId)
        {
            try
            {
                ViewBag.Customers = await _employeeCustomerService.GetCustomersNotWithEmployeeIdAsync(employeeId);
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("CustomerEmployee/CustomerById/{Id?}")]
        public async Task<ActionResult> CustomerById(int id)
        {   
            ViewBag.City = await _cityService.GetCitiesAsync();
            return ViewComponent("CustomerViewComponent", id);
        }
    }
}