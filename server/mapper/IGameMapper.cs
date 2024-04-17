using main.dto;
using main.domain;

namespace main.mapper
{
    public interface IGameMapper
    {
        GameDto ToDto(Game game);
        IEnumerable<GameDto> ToDto(IEnumerable<Game> games);
        Game ToEntity(GameDto gameDto);
    }
}
