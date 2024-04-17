using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace main.repository.config;

public class DbConnectionConfig
{
    public static SQLiteConnection CreateConnection(string id = "Basketball_db") => new(ConnectionString(id));
    public static string ConnectionString(string id = "Basketball_db") => ConfigurationManager.ConnectionStrings[id].ConnectionString;
}