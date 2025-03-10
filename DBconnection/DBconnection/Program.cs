using DBconnection;
using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create and test SqlConnection
            DBConnection sqlConnection = new SqlConnection("Server=myServer;Database=myDb;");
            sqlConnection.Open();
            sqlConnection.Close();

            Console.WriteLine();

            // Create and test OracleConnection
            DBConnection oracleConnection = new OracleConnection("OracleDb=myOracleDb;");
            oracleConnection.Open();
            oracleConnection.Close();

            Console.WriteLine();

            // Try invalid connection (should throw an exception)
            DBConnection invalidConnection = new SqlConnection("");

            DBCommand command = new DBCommand(sqlConnection, "SELECT * FROM myTable");

            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}