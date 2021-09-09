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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            var user = await _userRepository.Authentication(username, password);
            if (user == null)
                throw new GeneralException("Usuario o Clave inválida");
            return user;

        }


    }
}
