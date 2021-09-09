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
    public class UserRepository : IUserRepository
    {
        private readonly Sales2021Context _context;

        public UserRepository(Sales2021Context context)
        {
            _context = context;
        }


        public async Task<User> Authentication(string username, string password)
        {
            return await _context
                    .User.Where(z => z.Username == username && z.Password == password)
                    .FirstOrDefaultAsync();

        }


    }
}
