using Microsoft.Data.SqlClient;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        /// <summary>
        /// VULNERABILITY: Hardcoded Secret.
        /// A database password is included directly in the source code.
        /// </summary>
        _connectionString = "Server=myServer;Database=myDataBase;User Id=myUser;Password=MyPassword123!;";
    }

    public void GetUserData(string userId)
    {
        /// <summary>
        /// VULNERABILITY: SQL Injection.
        /// User input 'userId' is directly concatenated into the SQL query.
        /// </summary>
        string query = "SELECT * FROM Users WHERE UserId = '" + userId + "'";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Executing insecure query...");
        }
    }
}