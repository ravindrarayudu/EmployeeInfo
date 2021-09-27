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
    [Route("api/Location")]
    [Authorize]
    public class LocationController : Controller
    {
        private readonly ILocationService _service;
        private readonly ILogger<LocationController> _logger;

        /// <summary>
        /// LocationController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public LocationController(ILocationService service, ILogger<LocationController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary> 
        /// Get Locations Asynchronously
        /// </summary>
        /// <returns>Returns lists of Locations.</returns>
        [HttpGet]
        [Route("GetLocations")]
        public async Task<IActionResult> GetLocations()
        {
            _logger.LogInformation("List all Locations Asynchronously");
            var Locations = await _service.GetLocationsAsync();
            if (Locations != null && Locations.Any())
            {
                return new OkObjectResult(Locations);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Get Location by Location name
        /// </summary>
        /// <param name="Location name"></param>
        /// <returns>A single Location.</returns>
        /// 
        [Route("GetLocationByIdAsync")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetLocationByIdAsync(int Id)
        {
            RequestResult result = null;
            _logger.LogInformation("Get customer by customer name");
            var Locations = await _service.GetLocationByIdAsync(Id);
            if (Locations != null)
            {
                result = new RequestResult
                {
                    Msg = "Location Retrieved Successfully",
                    State = RequestState.Success,
                    Data = Locations
                };
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }
    }
}