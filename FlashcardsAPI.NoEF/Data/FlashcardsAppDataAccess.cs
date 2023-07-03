using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace FlashcardsAPI.Data;

public class FlashcardsAppDataAccess
{
    // can be "Data Source"
    private const string ConnectionString = "Server=(LocalDb)\\FlashcardsLocalDB;Database=FlashcardsAppDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public static async Task CreateCommand()
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string createStacksTableQuery = @"CREATE TABLE IF NOT EXISTS Stacks (
                Id INT PRIMARY KEY AUTOINCREMENT, 
                StackName VARCHAR(50),
                )";
        await using (var command = new SqlCommand(createStacksTableQuery, connection))
        {
            await command.ExecuteNonQueryAsync();
        }

        const string createFlashcardsTableQuery = @"CREATE TABLE IF NOT EXISTS Flashcards (
                Id INT PRIMARY KEY,
                StackName VARCHAR(50),
                Question VARCHAR(100),
                Description VARCHAR(100),
                StackId INT,
                FOREIGN KEY (StackId) REFERENCES Stacks(Id)
                )";
        await using (var command = new SqlCommand(createFlashcardsTableQuery, connection))
        {
            await command.ExecuteNonQueryAsync();
        }

        await connection.CloseAsync();
    }
    
}
