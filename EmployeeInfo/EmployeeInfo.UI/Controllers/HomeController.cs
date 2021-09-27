using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeInfo.UI.Models;
using EmployeeInfo.Contracts.Abstract;
using Microsoft.Extensions.Logging;
using EmployeeInfo.Contracts.Entities.Request;
using System.Security.Claims;
using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Contracts.Entities.Custom;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeInfo.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IEmployeeService _employeeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IEmployeeService employeeService, ILogger<HomeController> logger)
        {

            _employeeService = employeeService;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string EmployeeName = "",string Mobile = "",string Aadhar = "",string Uan = "",string DateFrom = "",string DateTo = "",string sortOrder = "",string currentFilter = "",string pageIndex = "")
        {
            var employeeSearchRequest = new EmployeeSearchRequest
            {
                EmployeeName = "",
                Mobile = "",
                Aadhar = "",
                Uan = ""
            };
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString(), out Guid userid);

            employeeSearchRequest.UserId = userid;

            if (EmployeeName != "" || Mobile != "" || Aadhar != "" || Uan!="" || DateFrom!= "" || DateTo != "" )
            {
                employeeSearchRequest.EmployeeName = (EmployeeName != "" && EmployeeName != null ? EmployeeName : "");
                employeeSearchRequest.Mobile = (Mobile != "" && Mobile != null ? Mobile : "");
                employeeSearchRequest.Aadhar = (Aadhar != "" && Aadhar != null ? Aadhar : "");
                employeeSearchRequest.Uan = (Uan != "" && Uan != null ? Uan : "");
                employeeSearchRequest.DateFrom = DateFrom != "" ? Convert.ToDateTime(DateFrom) : (DateTime?)null;
                employeeSearchRequest.DateTo = DateTo != "" ? Convert.ToDateTime(DateTo) : (DateTime?)null;
            }
            employeeSearchRequest.PaginationRequest = new PaginationRequest()
            {
                PageIndex = 0,
                PageSize = 10,
                Sort = new Sort()
                {
                    SortBy = "EmployeeName",
                    SortDirection = SortDirection.Ascending
                }
            };
            if (sortOrder != "" || currentFilter != "" || pageIndex != "")
            {
                employeeSearchRequest.PaginationRequest = new PaginationRequest()
                {
                    PageIndex = (pageIndex != "" ? Convert.ToInt32(pageIndex) : 0),
                    PageSize = 10,
                    Sort = new Sort()
                    {
                        SortBy = currentFilter != "" ? currentFilter : "EmployeeName",
                        SortDirection = (SortDirection)(sortOrder != "" ? (sortOrder == "Ascending" ? SortDirection.Ascending : SortDirection.Descending) : SortDirection.Ascending)
                    }
                };
            }

            //Task<EmployeeSearchResult> task = Task.Run<EmployeeSearchResult>(async () => await _employeeService.GetEmployeesAsync(employeeSearchRequest));
            //var employeeSearchResult = task.Result;

            ViewData["EmployeeSearchResult"] = await _employeeService.GetEmployeesAsync(employeeSearchRequest);

            return View(employeeSearchRequest);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
