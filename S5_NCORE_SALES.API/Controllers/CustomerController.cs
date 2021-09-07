using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S5_NCORE_SALES.CORE.Interfaces;
using S5_NCORE_SALES.INFRASTRUCTURE.Data;
using S5_NCORE_SALES.INFRASTRUCTURE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer() 
        {
            //var customerRepository = new CustomerRepository();
            var customers = await _customerRepository.GetCustomers();
            return Ok(customers);
        }


    }
}
