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
    [Route("api/BankDetails")]
    [Authorize]
    public class BankDetailsController : Controller
    {
        private readonly IBankDetailsService _service;
        private readonly ILogger<BankDetailsController> _logger;

        /// <summary>
        /// BankDetailsController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public BankDetailsController(IBankDetailsService service, ILogger<BankDetailsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        /// <summary> 
        /// Get BankDetails Asynchronously
        /// </summary>
        /// <returns>Returns lists of BankDetails.</returns>
        [HttpGet]
        [Route("GetBankDetails")]
        public async Task<IActionResult> GetBankDetails()
        {
            _logger.LogInformation("List all BankDetails Asynchronously");
            var bankdetails = await _service.GetBankDetailsAsync();
            if (bankdetails != null && bankdetails.Any())
            {
                return new OkObjectResult(bankdetails);
            }
            return new NotFoundResult();
        }

        /// <summary>
        /// Get BankDetails by BankDetails name
        /// </summary>
        /// <param name="BankDetails name"></param>
        /// <returns>A single BankDetails.</returns>
        /// 
        [Route("GetBankDetailsByIdAsync")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetBankDetailsByIdAsync(int Id)
        {
            RequestResult result = null;
            _logger.LogInformation("Get customer by customer name");
            var bankdetails = await _service.GetBankDetailsByIdAsync(Id);
            if (bankdetails != null)
            {
                result = new RequestResult
                {
                    Msg = "BankDetails Retrieved Successfully",
                    State = RequestState.Success,
                    Data = bankdetails
                };
                return new OkObjectResult(result);
            }
            return new NotFoundResult();
        }
    }
}