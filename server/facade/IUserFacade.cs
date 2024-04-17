using main.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.facade
{
    public interface IUserFacade
    {
        UserDto GetUserByUsernameAndPassword(UserDto userDto);
    }
}
