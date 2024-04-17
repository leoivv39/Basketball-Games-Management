using main.dto;
using main.domain;

namespace main.mapper
{
    public interface IUserMapper
    {
        UserDto ToDto(User user);
        User ToEntity(UserDto userDto);
    }
}
