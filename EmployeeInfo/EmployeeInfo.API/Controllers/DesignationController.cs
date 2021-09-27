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
    [Route("api/Designation")]
    [Authorize]
    public class DesignationController : Controller
    {
        private readonly IDesignationService _service;
        private readonly ILogger<DesignationController> _logger;

        /// <summary>
        /// DesignationController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public DesignationController(IDesignationService service, ILogger<DesignationController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary> 
        /// Get Designations Asynchronously
        /// </summary>
        /// <returns>Returns lists of Designations.</returns>
        [HttpGet]
        [Route("GetDesignations")]
        public async Task<IActionResult> GetDesignations()
        {
            _logger.LogInformation("List all Designations Asynchronously");
            var Designations = await _service.GetDesignationsAsync();
            if (Designations != null && Designations.Any())
            {
                return new OkObjectResult(Designations);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Get Designation by Designation name
        /// </summary>
        /// <param name="Designation name"></param>
        /// <returns>A single Designation.</returns>
        /// 
        [Route("GetDesignationByIdAsync")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetDesignationByIdAsync(int Id)
        {
            RequestResult result = null;
            _logger.LogInformation("Get customer by customer name");
            var Designations = await _service.GetDesignationByIdAsync(Id);
            if (Designations != null)
            {
                result = new RequestResult
                {
                    Msg = "Designation Retrieved Successfully",
                    State = RequestState.Success,
                    Data = Designations
                };
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }
    }
}