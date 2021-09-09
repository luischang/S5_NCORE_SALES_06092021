using S5_NCORE_SALES.CORE.Entities;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.CORE.Interfaces
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}