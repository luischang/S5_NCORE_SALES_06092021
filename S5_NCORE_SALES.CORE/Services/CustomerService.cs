using S5_NCORE_SALES.CORE.Entities;
using S5_NCORE_SALES.CORE.Exceptions;
using S5_NCORE_SALES.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.CORE.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);

            if (customer == null)
                throw new GeneralException("El cliente no existe");

            return customer;
        }

        public async Task InsertCustomer(Customer customer)
        {
            await _customerRepository.InsertCustomer(customer);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }



    }
}
