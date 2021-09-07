using Microsoft.EntityFrameworkCore;
using S5_NCORE_SALES.CORE.Entities;
using S5_NCORE_SALES.CORE.Interfaces;
using S5_NCORE_SALES.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.INFRASTRUCTURE.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Sales2021Context _context;

        public CustomerRepository(Sales2021Context context)
        {
            _context = context;
        }

        public CustomerRepository()
        {

        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            //using var context = new Sales2021Context();
            var customers = await _context.Customer.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            //using var context = new Sales2021Context();
            var customer = await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task InsertCustomer(Customer customer)
        {
            //using var context = new Sales2021Context();
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            //using var context = new Sales2021Context();
            var customerNow = await _context.Customer.Where(x => x.Id == customer.Id).FirstOrDefaultAsync();
            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customerNow.City = customer.City;
            customerNow.Phone = customer.Phone;
            customerNow.Country = customer.Country;

            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            //using var context = new Sales2021Context();
            var customerNow = await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Customer.Remove(customerNow);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }



    }
}
