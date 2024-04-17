using main.dto;
using main.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.controller
{
    public interface IUserController
    {
        Response GetUserByUsernameAndPassword(UserDto userDto);
    }
}
