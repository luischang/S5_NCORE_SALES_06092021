using S5_NCORE_SALES.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.CORE.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> DeleteCustomer(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomers();
        Task InsertCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
    }
}