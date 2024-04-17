using main.dto;
using main.domain;

namespace main.mapper
{
    public interface ITeamMapper
    {
        TeamDto ToDto(Team team);
        Team ToEntity(TeamDto teamDto);
    }
}
