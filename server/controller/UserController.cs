using main.dto;
using main.response;
using main.exception;
using main.facade;
using main.request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using main.payload;

namespace main.controller
{
    public class UserController : IUserController
    {
        private IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public Response GetUserByUsernameAndPassword(UserDto userDto)
        {
            try
            {
                UserDto user = _userFacade.GetUserByUsernameAndPassword(userDto);
                return new Response
                {
                    Status = ResponseStatus.Ok,
                    Payload = new Payload
                    {
                        Type = PayloadType.User,
                        Data = user
                    }
                };
            }
            catch (EntityNotFoundException e)
            {
                return new Response
                {
                    Status = ResponseStatus.NotFound,
                    Payload = new Payload
                    {
                        Type = PayloadType.String,
                        Data = e.Message
                    }
                };
            }
        }
    }
}
