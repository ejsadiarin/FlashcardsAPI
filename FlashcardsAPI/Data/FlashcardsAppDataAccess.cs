using Microsoft.Data.SqlClient;
namespace FlashcardsAPI.Data;

public class FlashcardsAppDataAccess
{
    private const string ConnectionString = "Server=(LocalDb)\\FlashcardsLocalDB;Database=FlashcardsAppDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public void CreateCommand(string query)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        const string createStacksTableQuery = @"CREATE TABLE IF NOT EXISTS Stacks (
                Id INT PRIMARY KEY AUTOINCREMENT, 
                StackName VARCHAR(50),
                )";
        using (var command = new SqlCommand(createStacksTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        const string createFlashcardsTableQuery = @"CREATE TABLE IF NOT EXISTS Flashcards (
                Id INT PRIMARY KEY,
                StackName VARCHAR(50),
                Question VARCHAR(100),
                Description VARCHAR(100),
                StackId INT,
                FOREIGN KEY (StackId) REFERENCES Stacks(Id)
                )";
        using (var command = new SqlCommand(createFlashcardsTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }

        connection.Close();
    }
}
