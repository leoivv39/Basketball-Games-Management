using main.dto;
using main.domain;
using main.mapper;
using main.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.facade
{
    public class UserFacade : IUserFacade
    {
        private IUserService _userService;
        private IUserMapper _userMapper;

        public UserFacade(IUserService userService, IUserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        public UserDto GetUserByUsernameAndPassword(UserDto userDto)
        {
            User foundUser = _userService.GetUserByUsernameAndPassword(userDto.Username, userDto.Password);
            return _userMapper.ToDto(foundUser);
        }
    }
}
