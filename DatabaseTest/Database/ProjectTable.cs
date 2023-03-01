using MySql.Data.MySqlClient;
using DatabaseTest.Models;
using System;

namespace DatabaseTest.Database
{
    public static class ProjectTable
    {
        private const string getProjectIdQuery = "SELECT id FROM project WHERE name='{0}'";
        private const string addProjectQuery = "INSERT INTO project(name) VALUES ('{0')";

        public static string GetProjectId(MySqlConnection connection, ProjectTableModel project)
        {
            var sqlQuery = String.Format(getProjectIdQuery, project.name);
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

        public static string AddProject(MySqlConnection connection, ProjectTableModel project)
        {
            var sqlQuery = String.Format(addProjectQuery, project.name);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
            return GetProjectId(connection, project);
        }
    }
}
