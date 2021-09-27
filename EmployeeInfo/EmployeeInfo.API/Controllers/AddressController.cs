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
    [Route("api/Address")]
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _service;
        private readonly ILogger<AddressController> _logger;

        /// <summary>
        /// AddressController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public AddressController(IAddressService service, ILogger<AddressController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary> 
        /// Get Addresss Asynchronously
        /// </summary>
        /// <returns>Returns lists of Addresss.</returns>
        [HttpGet]
        [Route("GetAddresses")]
        public async Task<IActionResult> GetAddresses()
        {
            _logger.LogInformation("List all Addresss Asynchronously");
            var Addresss = await _service.GetAddressesAsync();
            if (Addresss != null && Addresss.Any())
            {
                return new OkObjectResult(Addresss);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Get Address by Address name
        /// </summary>
        /// <param name="Address name"></param>
        /// <returns>A single Address.</returns>
        /// 
        [Route("GetAddressByEmployeeId")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAddressByEmployeeId(int Id)
        {
            RequestResult result = null;
            _logger.LogInformation("Get customer by customer name");
            var Addresss = await _service.GetAddressByEmployeeIdAsync(Id);
            if (Addresss != null)
            {
                result = new RequestResult
                {
                    Msg = "Address Retrieved Successfully",
                    State = RequestState.Success,
                    Data = Addresss
                };
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }
    }
}