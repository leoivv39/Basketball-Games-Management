using main.dto;
using System.Data;

namespace main.domain;

public class Team : Entity<long>
{
    public Team(long? id, string name, City city) : base(id)
    {
        Name = name;
        City = city;
    }

    public string Name { get; set; }
    public City City { get; set; }

    public override string ToString()
    {
        return $"id={Id}, name={Name}, city={City}";
    }
}