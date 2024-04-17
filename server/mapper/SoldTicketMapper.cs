using main.dto;
using main.domain;

namespace main.mapper
{
    public class SoldTicketMapper : ISoldTicketMapper
    {
        private IUserMapper _userMapper;
        private IGameMapper _gameMapper;

        public SoldTicketMapper(IUserMapper userMapper, IGameMapper gameMapper)
        {
            _userMapper = userMapper;
            _gameMapper = gameMapper;
        }

        public SoldTicketDto ToDto(SoldTicket soldTicket)
        {
            UserDto soldBy = _userMapper.ToDto(soldTicket.SoldBy);
            GameDto game = _gameMapper.ToDto(soldTicket.Game);
            return new SoldTicketDto
            {
                Id = soldTicket.Id,
                SoldBy = soldBy,
                Game = game,
                SoldAt = soldTicket.SoldAt,
                NumberOfSeats = soldTicket.NumberOfSeats,
                Username = soldTicket.Username
            };
        }

        public SoldTicket ToEntity(SoldTicketDto soldTicketDto)
        {
            User soldBy = _userMapper.ToEntity(soldTicketDto.SoldBy);
            Game game = _gameMapper.ToEntity(soldTicketDto.Game);
            return new SoldTicket(soldTicketDto.Id, soldBy, game, soldTicketDto.SoldAt, soldTicketDto.Username, soldTicketDto.NumberOfSeats);
        }
    }
}
