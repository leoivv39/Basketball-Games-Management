using System.Data.SQLite;
using main.domain;
using main.extension;
using main.repository.config;
using log4net;

namespace main.repository;

public class SoldTicketRepository : ISoldTicketRepository
{
    private static readonly ILog Log = LogManager.GetLogger("SoldTicketRepository");
    
    public SoldTicket? Save(SoldTicket soldTicket)
    {
        Log.InfoFormat("Saving SoldTicket {0}", soldTicket);
        string sql = @"INSERT INTO sold_ticket (id, sold_by_id, game_id, sold_at, no_of_tickets, username) 
                       VALUES (@id, @sold_by_id, @game_id, @sold_at, @no_of_tickets, @username)";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", soldTicket.Id);
                command.Parameters.AddWithValue("@sold_by_id", soldTicket.SoldBy.Id);
                command.Parameters.AddWithValue("@game_id", soldTicket.Game.Id);
                command.Parameters.AddWithValue("@sold_at", soldTicket.SoldAt);
                command.Parameters.AddWithValue("@no_of_tickets", soldTicket.NumberOfSeats);
                command.Parameters.AddWithValue("@username", soldTicket.Username);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    long id = connection.LastInsertRowId;
                    soldTicket.Id = id;
                    return soldTicket;
                }
            }   
        }
        return null;
    }

    public SoldTicket? Update(SoldTicket soldTicket)
    {
        Log.InfoFormat("Updating SoldTicket {0}", soldTicket);
        string sql = @"
                UPDATE sold_ticket
                SET sold_by_id = @sold_by_id, game_id = @game_id, sold_at = @sold_at, no_of_tickets = @no_of_tickets, username = @username
                WHERE id = @id
                ";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@sold_by_id", soldTicket.SoldBy.Id);
                command.Parameters.AddWithValue("@game_id", soldTicket.Game.Id);
                command.Parameters.AddWithValue("@sold_at", soldTicket.SoldAt);
                command.Parameters.AddWithValue("@id", soldTicket.Id);
                command.Parameters.AddWithValue("@no_of_tickets", soldTicket.NumberOfSeats);
                command.Parameters.AddWithValue("@username", soldTicket.Username);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return soldTicket;
                }
            }
        }
        return null;
    }

    public SoldTicket? DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public SoldTicket? FindById(long id)
    {
        Log.InfoFormat("Finding SoldTicket by id {0}", id);
        string sql = @"
            SELECT ST.id as st_id, U.id as u_id, U.username as u_username, U.password as u_password, G.id as g_id, T1.id as t1_id, T2.id as t2_id, T1.name as t1_name, T2.name as t2_name, T1.city as t1_city, T2.city as t2_city, G.time, G.ticket_price, G.number_of_seats, G.type, ST.sold_at, ST.no_of_tickets as st_no_of_tickets, ST.username as st_username FROM sold_ticket ST
            INNER JOIN user U on U.id = ST.sold_by_id
            INNER JOIN game G on G.id = ST.game_id
            INNER JOIN team T1 on T1.id = G.first_team_id
            INNER JOIN team T2 on T2.id = G.second_team_id
            WHERE ST.id = @id
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
                    var soldTicket = MapToSoldTicket(reader);
                    return soldTicket;
                }
            }
        }
        return null;
    }

    public IEnumerable<SoldTicket> FindAll()
    {
        Log.Info("Finding all SoldTickets");
        string sql = @"
            SELECT ST.id as st_id, U.id as u_id, U.username as u_username, U.password as u_password, G.id as g_id, T1.id as t1_id, T2.id as t2_id, T1.name as t1_name, T2.name as t2_name, T1.city as t1_city, T2.city as t2_city, G.time, G.ticket_price, G.number_of_seats, G.type, ST.sold_at, ST.no_of_tickets as st_no_of_tickets, ST.username as st_username FROM sold_ticket ST
            INNER JOIN user U on U.id = ST.sold_by_id
            INNER JOIN game G on G.id = ST.game_id
            INNER JOIN team T1 on T1.id = G.first_team_id
            INNER JOIN team T2 on T2.id = G.second_team_id
            ";
        List<SoldTicket> tickets = new List<SoldTicket>();
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (var command = new SQLiteCommand(sql, connection))
            {
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tickets.Add(MapToSoldTicket(reader));
                }
            }   
        }
        return tickets;
    }
    
    private SoldTicket MapToSoldTicket(SQLiteDataReader reader)
    {
        return new SoldTicket(
            (long) reader.GetValue(reader.GetOrdinal("st_id")),
            MapToUser(reader),
            MapToGame(reader),
            (DateTime) reader.GetValue(reader.GetOrdinal("sold_at")),
            (string) reader.GetValue(reader.GetOrdinal("st_username")),
            (int) reader.GetValue(reader.GetOrdinal("st_no_of_tickets"))
        );
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
    
    private User MapToUser(SQLiteDataReader reader)
    {
        return new User(
            (long) reader.GetValue(reader.GetOrdinal("u_id")),
            (string) reader.GetValue(reader.GetOrdinal("u_username")),
            (string) reader.GetValue(reader.GetOrdinal("u_password"))
        );
    }
}