using System.Data.SQLite;
using log4net;
using main.domain;
using main.extension;
using main.repository.config;

namespace main.repository;

public class GameRepository : IGameRepository
{
    private static readonly ILog Log = LogManager.GetLogger("GameRepository");
    
    public Game? Save(Game game)
    {
        Log.InfoFormat("Saving Game {0}", game);
        string sql = @"INSERT INTO game (first_team_id, second_team_id, time, ticket_price, number_of_seats, type) 
                       VALUES (@first_id, @second_id, @time, @ticket_price, @number_of_seats, @type)";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@first_id", game.FirstTeam.Id);
                command.Parameters.AddWithValue("@second_id", game.SecondTeam.Id);
                command.Parameters.AddWithValue("@time", game.Time);
                command.Parameters.AddWithValue("@ticket_price", game.TicketPrice);
                command.Parameters.AddWithValue("@number_of_seats", game.NumberOfSeats);
                command.Parameters.AddWithValue("@type", game.Type.ParseToString());
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    long id = connection.LastInsertRowId;
                    game.Id = id;
                    return game;
                }
            }   
        }
        return null;
    }

    public Game? Update(Game game)
    {
        Log.InfoFormat("Updating Game {0}", game);
        string sql = @"
                UPDATE game
                SET first_team_id = @first_id, second_team_id = @second_id, time = @time, ticket_price = @ticket_price, number_of_seats = @number_of_seats, type = @type
                WHERE id = @game_id
                ";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@first_id", game.FirstTeam.Id);
                command.Parameters.AddWithValue("@second_id", game.SecondTeam.Id);
                command.Parameters.AddWithValue("@time", game.Time);
                command.Parameters.AddWithValue("@ticket_price", game.TicketPrice);
                command.Parameters.AddWithValue("@number_of_seats", game.NumberOfSeats);
                command.Parameters.AddWithValue("@type", game.Type.ParseToString());
                command.Parameters.AddWithValue("@game_id", game.Id);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return game;
                }
            }
        }
        return null;
    }

    public Game? DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public Game? FindById(long id)
    {
        Log.InfoFormat("Finding Game by id {0}", id);
        string sql = @"
            SELECT G.id as g_id, T1.id as t1_id, T2.id as t2_id, T1.name as t1_name, T2.name as t2_name, T1.city as t1_city, T2.city as t2_city, time, ticket_price, number_of_seats, type FROM game G
            INNER JOIN team T1 on T1.id = G.first_team_id
            INNER JOIN team T2 on T2.id = G.second_team_id
            WHERE G.id = @id
            ";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var game = MapToGame(reader);
                    return game;
                }
            }
        }
        return null;
    }

    public IEnumerable<Game> FindAll()
    {
        Log.Info("Finding all Games");
        string sql = @"
            SELECT G.id as g_id, T1.id as t1_id, T2.id as t2_id, T1.name as t1_name, T2.name as t2_name, T1.city as t1_city, T2.city as t2_city, time, ticket_price, number_of_seats, type FROM game G
            INNER JOIN team T1 on T1.id = G.first_team_id
            INNER JOIN team T2 on T2.id = G.second_team_id
            ";
        List<Game> games = new List<Game>();
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    games.Add(MapToGame(reader));
                }
            }   
        }
        return games;
    }
    
    private Game MapToGame(SQLiteDataReader reader)
    {
        return new Game(
            (long) reader.GetValue(reader.GetOrdinal("g_id")),
            MapToTeam(reader, "t1"),
            MapToTeam(reader, "t2"),
            (DateTime) reader.GetValue(reader.GetOrdinal("time")),
            (double) reader.GetValue(reader.GetOrdinal("ticket_price")),
            (int) (long) reader.GetValue(reader.GetOrdinal("number_of_seats")),
            GameTypeExtension.Parse((string) reader.GetValue(reader.GetOrdinal("type")))
        );
    }

    private Team MapToTeam(SQLiteDataReader reader, string teamPrefix)
    {
        return new Team(
            (long) reader.GetValue(reader.GetOrdinal($"{teamPrefix}_id")),
            (string) reader.GetValue(reader.GetOrdinal($"{teamPrefix}_name")),
            CityExtension.Parse((string) reader.GetValue(reader.GetOrdinal($"{teamPrefix}_city")))
        );
    }
}