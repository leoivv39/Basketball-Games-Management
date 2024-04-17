using main.dto;
using main.domain;

namespace main.mapper
{
    public class GameMapper : IGameMapper
    {
        private ITeamMapper _teamMapper;

        public GameMapper(ITeamMapper teamMapper)
        {
            _teamMapper = teamMapper;
        }

        public GameDto ToDto(Game game)
        {
            TeamDto firstTeam = _teamMapper.ToDto(game.FirstTeam);
            TeamDto secondTeam = _teamMapper.ToDto(game.SecondTeam);
            return new GameDto
            {
                Id = game.Id,
                FirstTeam = firstTeam,
                SecondTeam = secondTeam,
                Time = game.Time,
                TicketPrice = game.TicketPrice,
                NumberOfSeats = game.NumberOfSeats,
                Type = game.Type
            };
        }

        public IEnumerable<GameDto> ToDto(IEnumerable<Game> games)
        {
            return games.Select(ToDto);
        }

        public Game ToEntity(GameDto gameDto)
        {
            Team firstTeam = _teamMapper.ToEntity(gameDto.FirstTeam);
            Team secondTeam = _teamMapper.ToEntity(gameDto.SecondTeam);
            return new Game(gameDto.Id, firstTeam, secondTeam, gameDto.Time, gameDto.TicketPrice, gameDto.NumberOfSeats, gameDto.Type);
        }
    }
}
