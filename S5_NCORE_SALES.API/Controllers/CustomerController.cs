using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S5_NCORE_SALES.CORE.DTOs;
using S5_NCORE_SALES.CORE.Entities;
using S5_NCORE_SALES.CORE.Interfaces;
using S5_NCORE_SALES.INFRASTRUCTURE.Data;
using S5_NCORE_SALES.INFRASTRUCTURE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer()
        {
            //var customerRepository = new CustomerRepository();
            var customers = await _customerService.GetCustomers();

            //var customerList = new List<CustomerFullNameDTO>();
            //foreach (var item in customers)
            //{
            //    var customer = new CustomerFullNameDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName
            //    };
            //    customerList.Add(customer);
            //}

            //var customersDTO = customers.Select(x => new CustomerDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    Country = x.Country,
            //    City = x.City,
            //    Phone = x.Phone
            //});
            var customersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customersDTO);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            //var customerDTO = new CustomerDTO()
            //{
            //    Id = customer.Id,
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    Country = customer.Country,
            //    City = customer.City,
            //    Phone = customer.Phone
            //};
            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("Customer")]
        public async Task<IActionResult> Customer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            //var customer = new Customer()
            //{
            //    FirstName = customerDTO.FirstName,
            //    LastName = customerDTO.LastName,
            //    Country = customerDTO.Country,
            //    City = customerDTO.City,
            //    Phone = customerDTO.Phone
            //};

            await _customerService.InsertCustomer(customer);
            return Ok(customer);
        }

        [HttpPut]
        [Route("Customer")]
        public async Task<IActionResult> Customer(int id, CustomerDTO customerDTO) 
        {
            if (id != customerDTO.Id)
                return NotFound();

            //var customer = new Customer()
            //{
            //    Id = customerDTO.Id,
            //    FirstName = customerDTO.FirstName,
            //    LastName = customerDTO.LastName,
            //    Country = customerDTO.Country,
            //    City = customerDTO.City,
            //    Phone = customerDTO.Phone
            //};
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.UpdateCustomer(customer);

            return Ok();
        }

        [HttpDelete]
        [Route("Customer/{id}")]
        public async Task<IActionResult> Customer(int id) 
        {
            await _customerService.DeleteCustomer(id);
            return Ok();
        }

    }
}
