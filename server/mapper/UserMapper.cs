using main.dto;
using main.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.mapper
{
    public class UserMapper : IUserMapper
    {
        public UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password
            };
        }

        public User ToEntity(UserDto userDto)
        {
            return new User(userDto.Id, userDto.Username, userDto.Password);
        }
    }
}
