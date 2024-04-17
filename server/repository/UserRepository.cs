using System.Data.SQLite;
using log4net;
using main.domain;
using main.repository.config;

namespace main.repository;

public class UserRepository : IUserRepository
{
    private static readonly ILog Log = LogManager.GetLogger("UserRepository");
    
    public User? Save(User user)
    {
        Log.InfoFormat("Saving User {0}", user);
        string sql = "INSERT INTO user (username, password) VALUES (@name, @password)";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    long id = connection.LastInsertRowId;
                    user.Id = id;
                    return user;
                }
            }   
        }
        return null;
    }

    public User? Update(User user)
    {
        Log.InfoFormat("Updating User {0}", user);
        string sql = @"
                UPDATE user
                SET username = @username, password = @password
                WHERE id = @id
                ";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@id", user.Id);
                int affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return user;
                }
            }
        }
        return null;
    }

    public User? DeleteById(long id)
    {
        throw new NotImplementedException();
    }

    public User? FindById(long id)
    {
        Log.InfoFormat("Finding User by id {0}", id);
        string sql = "SELECT * FROM user WHERE id = @id";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var user = MapToEntity(reader);
                    return user;
                }
            }
        }
        return null;
    }

    public IEnumerable<User> FindAll()
    {
        Log.Info("Finding all Users");
        string sql = "SELECT * FROM user";
        List<User> users = new List<User>();
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(MapToEntity(reader));
                }
            }   
        }
        return users;
    }

    public User? FindByUsernameAndPassword(string username, string password)
    {
        Log.InfoFormat("Finding User by username {0} and password {1}", username, password);
        string sql = "SELECT * FROM user WHERE username = @username AND password = @password";
        using (var connection = DbConnectionConfig.CreateConnection())
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                using SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var user = MapToEntity(reader);
                    return user;
                }
            }
        }
        return null;
    }

    private User MapToEntity(SQLiteDataReader reader)
    {
        return new User(
            (long) reader.GetValue(0),
            (string) reader.GetValue(1),
            (string) reader.GetValue(2)
        );
    }
}