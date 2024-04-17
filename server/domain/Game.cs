using main.dto;

namespace main.domain;

public class Game : Entity<long>
{
    public Game(long? id, Team firstTeam, Team secondTeam, DateTime time, double ticketPrice, int numberOfSeats, GameType type) : base(id)
    {
        FirstTeam = firstTeam;
        SecondTeam = secondTeam;
        Time = time;
        TicketPrice = ticketPrice;
        NumberOfSeats = numberOfSeats;
        Type = type;
    }

    public Game() { }

    public Team FirstTeam { get; set; }
    public Team SecondTeam { get; set; }
    public DateTime Time { get; set; }
    public double TicketPrice { get; set; }
    public int NumberOfSeats { get; set; }
    public GameType Type { get; set; }

    public override string ToString()
    {
        return $"FirstTeam={FirstTeam}, SecondTeam={SecondTeam}, Time={Time}, TicketPrice={TicketPrice}, NumberOfSeats={NumberOfSeats}, Type={Type}";
    }
}