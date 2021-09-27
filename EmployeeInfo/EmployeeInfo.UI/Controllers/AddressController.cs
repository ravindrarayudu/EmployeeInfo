using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Controllers
{
    public class AddressController : Controller
    {

        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _addressService;
        public AddressController(
                               IAddressService addressService,
                               ILogger<AddressController> logger)
        {
            try
            {
                this._addressService = addressService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }

        [HttpGet]
        [Route("Address/Index/")]
        [Route("Address/Index/{Id?}")]
        public IActionResult Index(int Id)
        {
            return ViewComponent("AddressViewComponent",Id);
        }
    }
}