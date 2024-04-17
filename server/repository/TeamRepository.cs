using System.Data.SQLite;
using log4net;
using main.domain;
using main.extension;
using main.repository.config;

namespace main.repository;

public class TeamRepository : ITeamRepository
{
    private static readonly ILog Log = LogManager.GetLogger("TeamRepository");
    
    public Team? Save(Team team)
    {
        Log.InfoFormat("Saving Team {0}", team);
        string sql = "INSERT INTO team (name, city) VALUES (@name, @city)";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", team.Name);
                command.Parameters.AddWithValue("@city", team.City.ParseToString());
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    long id = connection.LastInsertRowId;
                    team.Id = id;
                    return team;
                }
            }   
        }
        return null;
    }

    public Team? Update(Team team)
    {
        Log.InfoFormat("Updating Team {0}", team);
        string sql = @"
                UPDATE team
                SET name = @name, city = @city
                WHERE id = @id
                ";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", team.Name);
                command.Parameters.AddWithValue("@city", team.City.ToString());
                command.Parameters.AddWithValue("@id", team.Id);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return team;
                }
            }
        }
        return null;
    }

    public Team? DeleteById(long id)
    {
        Log.InfoFormat("Deleting Team by id {0}", id);
        Team? teamToDelete = FindById(id);
        if (teamToDelete == null)
        {
            return null;
        }
        string sql = "DELETE FROM team WHERE id = @id";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        return teamToDelete;
    }

    public Team? FindById(long id)
    {
        Log.InfoFormat("Finding Team by id {0}", id);
        string sql = "SELECT * FROM team WHERE id = @id";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var team = MapToEntity(reader);
                    return team;
                }
            }
        }
        return null;
    }

    public IEnumerable<Team> FindAll()
    {
        Log.Info("Finding all Teams");
        string sql = "SELECT * FROM team";
        List<Team> teams = new List<Team>();
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    teams.Add(MapToEntity(reader));
                }
            }   
        }
        return teams;
    }

    private Team MapToEntity(SQLiteDataReader reader)
    {
        return new Team(
            (long) reader.GetValue(0),
            (string) reader.GetValue(1),
            CityExtension.Parse((string) reader.GetValue(2))
        );
    }
}