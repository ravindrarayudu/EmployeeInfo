using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.UI.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeCustomerService _employeeCustomerService;
        private readonly IAddressService _addressService;
        private readonly IBankDetailsService _bankDetailsService;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;
        private readonly ICityService _cityService;
        private readonly ILocationService _locationService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
                                IUserService userService,
                                IEmployeeService employeeService,
                                IEmployeeCustomerService employeeCustomerService,
                                IAddressService addressService,
                                IBankDetailsService bankDetailsService,
                                IDepartmentService departmentService,
                                IDesignationService designationService,
                                ILocationService locationService, 
                                ICityService cityService,
                                ILogger<EmployeeController> logger)
        {
            try
            {
                this._userService = userService;
                this._employeeService = employeeService;
                this._employeeCustomerService = employeeCustomerService;
                this._addressService = addressService;
                this._bankDetailsService = bankDetailsService;
                this._departmentService = departmentService;
                this._designationService = designationService;
                this._locationService = locationService;
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
        [Route("Employee/Index/")]
        [Route("Employee/Index/{EmployeeId?}")]
        public async Task<ActionResult> Index(string EmployeeId)
        {
            var employee = new Employee();

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString(), out Guid userid);

            var userinfo = await _userService.GetUserByIdAsync(userid);

            HttpContext.Session.SetObject("UserInfo", userinfo);

            if (!string.IsNullOrEmpty(EmployeeId))
            {
                employee = await _employeeService.GetEmployeeByEmployeeIdAsync(EmployeeId);

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("EmployeeId")))
                {
                    HttpContext.Session.SetString("EmployeeId", EmployeeId);
                }
                else
                {
                    HttpContext.Session.Remove("EmployeeId");
                    HttpContext.Session.SetString("EmployeeId", EmployeeId);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("EmployeeId")))
                {
                    employee = await _employeeService.GetEmployeeByEmployeeIdAsync(HttpContext.Session.GetString("EmployeeId"));
                }
            }

            if (employee != null && employee.ModifiedBy != null) { employee.ModifiedBy = userinfo.UserId; }


            employee.EmployeeCustomer = await _employeeCustomerService.GetEmployeeCustomersByEmployeeIdAsync(employee.Id);

            ViewBag.Address = await _addressService.GetAddressesAsync();
            ViewBag.BankDetails = await _bankDetailsService.GetBankDetailsAsync();
            ViewBag.Department = await _departmentService.GetDepartmentsAsync();
            ViewBag.Designation = await _designationService.GetDesignationsAsync();
            ViewBag.Location = await _locationService.GetLocationsAsync();
            ViewBag.City = await _cityService.GetCitiesAsync();
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Index(Employee employee)
        {
            int status = await _employeeService.AddEditEmployeeAsync(employee);
            return View(employee);
        }


        [HttpGet]
        [Route("Employee/CustomerDetails/{EmployeeId?}")]
        public IActionResult CustomersByEmployeeId(int employeeid)
        {
            return ViewComponent("Customers", employeeid);
        }

        public IActionResult BankDetails(int bankid)
        {
            return ViewComponent("BankDetails",bankid);
        }
    }
}