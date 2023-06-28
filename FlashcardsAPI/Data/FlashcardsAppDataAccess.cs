using System.Data;
using Microsoft.Data.SqlClient;
namespace FlashcardsAPI.Data;

public class FlashcardsAppDataAccess
{
    private string connectionString =
        "Server=(LocalDb)\\FlashcardsLocalDB;Database=FlashcardsAppDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public void CreateCommand(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string createStacksTableQuery =
                @"CREATE TABLE IF NOT EXISTS Stacks (
                Id INT PRIMARY KEY AUTOINCREMENT, 
                StackName VARCHAR(50),
                )";
            using (SqlCommand command = new SqlCommand(createStacksTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string createFlashcardsTableQuery =
                @"CREATE TABLE IF NOT EXISTS Flashcards (
                Id INT PRIMARY KEY,
                Question VARCHAR(100),
                Description VARCHAR(100),
                StackId INT,
                FOREIGN KEY (StackId) REFERENCES Stacks(Id)
                )";
            using (SqlCommand command = new SqlCommand(createFlashcardsTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
}
