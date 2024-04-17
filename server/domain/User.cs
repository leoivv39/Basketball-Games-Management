namespace main.domain;

public class User : Entity<long>
{
    public User(long? id, string username, string password) : base(id)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; set; }
    public string Password { get; set; }
}