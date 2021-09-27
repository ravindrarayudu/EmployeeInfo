using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/Department")]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;
        private readonly ILogger<DepartmentController> _logger;

        /// <summary>
        /// DepartmentController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public DepartmentController(IDepartmentService service, ILogger<DepartmentController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary> 
        /// Get Departments Asynchronously
        /// </summary>
        /// <returns>Returns lists of Departments.</returns>
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            _logger.LogInformation("List all Departments Asynchronously");
            var Departments = await _service.GetDepartmentsAsync();
            if (Departments != null && Departments.Any())
            {
                return new OkObjectResult(Departments);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Get Department by Department name
        /// </summary>
        /// <param name="Department name"></param>
        /// <returns>A single Department.</returns>
        /// 
        [Route("GetDepartmentByIdAsync")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentByIdAsync(int Id)
        {
            RequestResult result = null;
            _logger.LogInformation("Get customer by customer name");
            var Departments = await _service.GetDepartmentByIdAsync(Id);
            if (Departments != null)
            {
                result = new RequestResult
                {
                    Msg = "Department Retrieved Successfully",
                    State = RequestState.Success,
                    Data = Departments
                };
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }
    }
}