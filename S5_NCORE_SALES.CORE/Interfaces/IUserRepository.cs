using S5_NCORE_SALES.CORE.Entities;
using System.Threading.Tasks;

namespace S5_NCORE_SALES.CORE.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authentication(string username, string password);
    }
}