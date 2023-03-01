using MySql.Data.MySqlClient;
using DatabaseTest.Models;
using System;

namespace DatabaseTest.Database
{
    public static class AuthorTable
    {
        private const string getAuthorIdQuery = "SELECT id FROM author WHERE login='{0}'";
        private const string addAuthorQuery = "INSERT INTO author(name, login, email) VALUES('{0}', '{1}', '{2}')";

        public static string GetAuthorId(MySqlConnection connection, AuthorTableModel author)
        {
            var sqlQuery = String.Format(getAuthorIdQuery, author.login);
            Console.WriteLine(sqlQuery);
            string id;
            var cmd = new MySqlCommand(sqlQuery, connection);
            var rdr = cmd.ExecuteReader();
            
            if (!rdr.HasRows)
            {
                id = null;
                rdr.Close();
                return id;
            } 
            
            rdr.Read();
            id = rdr[0].ToString();
            rdr.Close();
            return id;                       
        }

        public static string AddAuthor(MySqlConnection connection, AuthorTableModel author)
        {
            var sqlQuery = String.Format(addAuthorQuery, author.name, author.login, author.email);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
            return GetAuthorId(connection, author);
        }
    }
}
