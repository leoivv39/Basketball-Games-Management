namespace main.domain;

public class SoldTicket : Entity<long>
{
    public SoldTicket(long? id, User soldBy, Game game, DateTime soldAt, string username, int numberOfSeats) : base(id)
    {
        SoldBy = soldBy;
        Game = game;
        SoldAt = soldAt;
        Username = username;
        NumberOfSeats = numberOfSeats;
    }

    public SoldTicket() { }

    public User SoldBy { get; set; }
    public Game Game { get; set; }
    public DateTime SoldAt { get; set; }
    public int NumberOfSeats { get; set; }
    public string Username { get; set; }

    public override string ToString()
    {
        return $"id={Id}, SoldBy={SoldBy}, Game={Game}, SoldAt={SoldAt}";
    }
}