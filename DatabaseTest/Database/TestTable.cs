using System;
using MySql.Data.MySqlClient;
using DatabaseTest.Models;
using System.Collections.Generic;

namespace DatabaseTest.Database
{
    public static class TestTable
    {
        private const string getLatestTestQuery = "SELECT * FROM test ORDER BY id DESC LIMIT 1";
        private const string addTestQuery = "INSERT INTO test(name, status_id, method_name, project_id, session_id, env, browser, author_id) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
        private const string getTestsWithRepeatingDigitsIdQuery = "SELECT * FROM test WHERE CAST(id AS char) REGEXP '00|11|22|33|44|55|66|77|88|99' LIMIT {0}";
        private const string createCopiesOfTestsQuery = "INSERT INTO test(name, status_id, method_name, project_id, session_id, start_time, end_time," +
                    "env, browser, author_id) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9})";
        private const string updateTestByIdQuery = "UPDATE test SET {0} = {1} WHERE id={2}";
        private const string getTestByIdQuery = "SELECT * FROM test WHERE id={0}";
        private const string deleteTestsByIdQuery = "DELETE FROM test WHERE id BETWEEN {0} AND {1}";

        public static TestTableModel GetLatestTest(MySqlConnection connection)
        {
            var cmd = new MySqlCommand(getLatestTestQuery, connection);
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            var testTableModel = new TestTableModel
            {
                id = rdr["id"].ToString(),
                name = rdr["name"].ToString(),
                status_id = rdr["status_id"].ToString(),
                method_name = rdr["method_name"].ToString(),
                project_id = rdr["project_id"].ToString(),
                session_id = rdr["session_id"].ToString(),                
                env = rdr["env"].ToString(),
                browser = rdr["browser"].ToString(),
                author_id = rdr["author_id"].ToString(),
            };
            rdr.Close();
            return testTableModel;
        }

        public static void AddTest(MySqlConnection connection, TestTableModel test)
        {
            var sqlQuery = String.Format(addTestQuery, test.name, test.status_id, test.method_name, test.project_id, test.session_id, test.env, test.browser, test.author_id);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
        }

        public static List<TestTableModel> GetTestsWithRepeatingDigitsId(MySqlConnection connection, int amount)
        {
            var sqlQuery = String.Format(getTestsWithRepeatingDigitsIdQuery, amount);
            var testsList = new List<TestTableModel>();
            var cmd = new MySqlCommand(sqlQuery, connection);
            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                
                testsList.Add(new TestTableModel
                {
                    id = rdr["id"].ToString(),
                    name = rdr["name"].ToString(),
                    status_id = rdr["status_id"].ToString(),
                    method_name = rdr["method_name"].ToString(),
                    project_id = rdr["project_id"].ToString(),
                    session_id = rdr["session_id"].ToString(),
                    start_time = rdr["start_time"].ToString(),
                    end_time = rdr["end_time"].ToString(),
                    env = rdr["env"].ToString(),
                    browser = rdr["browser"].ToString(),
                    author_id = rdr["author_id"].ToString()
                });
            }
            rdr.Close();
            return testsList;
        }

        public static List<string> CreateCopiesOfTests(MySqlConnection connection, List<TestTableModel> testsList)
        {
            var copiedTestsIds = new List<string>();
            for (int i = 0; i < testsList.Count; i++)
            {
                var name = testsList[i].name;
                var status_id = testsList[i].status_id;
                var method_name = testsList[i].method_name;
                var project_id = testsList[i].project_id;
                var session_id = testsList[i].session_id;
                var start_time = DateTime.ParseExact(testsList[i].start_time, "dd.MM.yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss");
                var end_time = DateTime.ParseExact(testsList[i].end_time, "dd.MM.yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss");
                var env = testsList[i].env;
                var browser = testsList[i].browser;
                var author_id = testsList[i].author_id;
                var insertSql = String.Format(createCopiesOfTestsQuery, name, status_id, method_name, project_id, session_id, start_time, end_time, env, browser, author_id);
                var getIdSql = getLatestTestQuery;
                var addTestCmd = new MySqlCommand(insertSql, connection);
                var getIdCmd = new MySqlCommand(getIdSql, connection);
                addTestCmd.ExecuteNonQuery();
                var rdr = getIdCmd.ExecuteReader();
                rdr.Read();
                copiedTestsIds.Add(rdr["id"].ToString());
                rdr.Close();
            }
            return copiedTestsIds;
        }

        public static void UpdateTestById(MySqlConnection connection, string id, string column, string value)
        {
            var sqlQuery = String.Format(updateTestByIdQuery, column, value, id);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
        }

        public static TestTableModel GetTestById(MySqlConnection connection, string id)
        {
            var sqlQuery = String.Format(getTestByIdQuery, id);
            var cmd = new MySqlCommand(sqlQuery, connection);
            var rdr = cmd.ExecuteReader();
            rdr.Read();

            var testModel = new TestTableModel
            {
                id = rdr["id"].ToString(),
                name = rdr["name"].ToString(),
                status_id = rdr["status_id"].ToString(),
                method_name = rdr["method_name"].ToString(),
                project_id = rdr["project_id"].ToString(),
                session_id = rdr["session_id"].ToString(),
                start_time = rdr["start_time"].ToString(),
                end_time = rdr["end_time"].ToString(),
                env = rdr["env"].ToString(),
                browser = rdr["browser"].ToString(),
                author_id = rdr["author_id"].ToString()
            };

            rdr.Close();
            return testModel;
        }

        public static void DeleteTestsById(MySqlConnection connection, List<string> testsIds)
        {
            var sqlQuery = String.Format(deleteTestsByIdQuery, testsIds[0], testsIds[^1]);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
