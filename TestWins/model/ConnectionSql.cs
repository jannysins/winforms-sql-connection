namespace TestWins.Model;

using MySql.Data.MySqlClient;

public class ConnectionSql
{
    private readonly string _connectionString = "server=localhost;database=student;uid=root;pwd=root";

    public MySqlConnection connectSql()
    {
        // Return a fresh connection object. The 'using' blocks in your repository will handle opening and disposing it.
        return new MySqlConnection(_connectionString);
    }
}
