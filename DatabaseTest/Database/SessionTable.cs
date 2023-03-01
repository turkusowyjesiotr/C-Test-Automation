using System;
using MySql.Data.MySqlClient;

namespace DatabaseTest.Database
{
    public static class SessionTable
    {
        private const string addSessionQuery = "INSERT INTO session(session_key, created_time, build_number) VALUES ('{0}', CURRENT_TIMESTAMP, 1)";
        private const string getSessionIdQuery = "SELECT id FROM session WHERE session_key LIKE '%{0}%'";

        public static string AddSession(MySqlConnection connection)
        {
            var dateNow = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
            var sessionKey = $"a1qa_training {dateNow}";
            var sqlQuery = String.Format(addSessionQuery, sessionKey);
            var cmd = new MySqlCommand(sqlQuery, connection);
            cmd.ExecuteNonQuery();
            return GetSessionId(connection, dateNow);
        }

        private static string GetSessionId(MySqlConnection connection, string dateNow)
        {
            string sessionId;
            var sqlQuery = String.Format(getSessionIdQuery, dateNow);
            var cmd = new MySqlCommand(sqlQuery, connection);
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            sessionId = rdr[0].ToString();
            rdr.Close();
            return sessionId;
        }
    }
}
