using main.repository;
using main.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.exception;

namespace main.service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return userRepository.FindByUsernameAndPassword(username, password) ?? throw new EntityNotFoundException("User not found");
        }
    }
}
