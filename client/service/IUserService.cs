using main.dto;

namespace client.service
{
    public interface IUserService
    {
        UserDto GetUserByUsernameAndPassword(UserDto userDto);
    }
}
