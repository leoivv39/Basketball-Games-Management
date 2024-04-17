using main.dto;
using main.domain;

namespace main.mapper
{
    public class TeamMapper : ITeamMapper
    {
        public TeamDto ToDto(Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                City = team.City
            };
        }

        public Team ToEntity(TeamDto teamDto)
        {
            return new Team(teamDto.Id, teamDto.Name, teamDto.City);
        }
    }
}
