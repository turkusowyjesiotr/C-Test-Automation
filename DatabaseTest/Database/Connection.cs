using System;
using MySql.Data.MySqlClient;

namespace DatabaseTest.Database
{
    public class DatabaseConnection
    {
        private readonly MySqlConnection connection;
        private static DatabaseConnection instance;
        private static readonly object padlock = new object();
        private const string connString = "server={0};user={1};database={2};port={3};password={4}";

        private DatabaseConnection(string server, string user, string database, string port, string password)
        {
            var connectionString = String.Format(connString, server, user, database, port, password);
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();                                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public static DatabaseConnection MakeConnection(string server, string user, string database, string port, string password)
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DatabaseConnection(server, user, database, port, password);
                    }
                }
            }
            return instance;
        }

        public MySqlConnection Get()
        {
            return connection;
        }

        public void Stop()
        {
            connection.Close();
        }       
    }
}
