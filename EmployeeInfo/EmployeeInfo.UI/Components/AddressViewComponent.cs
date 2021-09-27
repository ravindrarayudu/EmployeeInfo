using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeInfo.UI.Components
{
    public class AddressViewComponent : ViewComponent
    {
        private readonly IAddressService _addressService;
        private readonly ILogger<AddressViewComponent> _logger;
        public AddressViewComponent(IAddressService addressService, ILogger<AddressViewComponent> logger)
        {
            try
            {
                // Settings.  
                this._addressService = addressService;
                this._logger = logger;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }
        public async Task<IViewComponentResult> InvokeAsync(int id,string type)
        {
            Address address = new Address();
            
            if (type == "Employee")
            {
                address = await _addressService.GetAddressByEmployeeIdAsync(id);
            }
            else if(type == "Customer")
            {
                address = await _addressService.GetAddressByCustomerIdAsync(id);
            }
            
            return View(address);
        }
    }
}
