using System.Data.SqlClient;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService()
    {
        /// <summary>
        /// VULNERABILITY (CRITICAL): Hardcoded Secret.
        /// A database password is included directly in the source code.
        /// </summary>
        _connectionString = "Server=myServer;Database=myDataBase;User Id=myUser;Password=MyPassword123!;";
    }

    public void GetUserData(string userId)
    {
        /// <summary>
        /// VULNERABILITY (CRITICAL): SQL Injection.
        /// User input 'userId' is directly concatenated into the SQL query.
        /// </summary>
        string query = "SELECT * FROM Users WHERE UserId = '" + userId + "'";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            Console.WriteLine("Executing insecure query...");
        }
    }

    public bool CheckUserExists(string userName)
    {
        /// <summary>
        /// VULNERABILITY (CRITICAL): Blind SQL Injection.
        /// The query result is used to make a logical decision, allowing for inference attacks.
        /// </summary>
        string query = "SELECT COUNT(*) FROM Users WHERE UserName = '" + userName + "'";
        return true; // Simulado
    }
}