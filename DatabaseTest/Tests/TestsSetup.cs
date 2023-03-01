using NUnit.Framework;
using DatabaseTest.Database;
using DatabaseTest.Models;
using DatabaseTest.Utils;

namespace DatabaseTest.Tests
{
    [SetUpFixture]
    public class TestsSetup
    {
        private ConfigModel config => JsonUtil.GetConfig();
        public static AuthorTableModel author;
        public static ProjectTableModel project;
        public static DatabaseConnection connection;
        public static string sessionId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            connection = DatabaseConnection.MakeConnection(config.server, config.user, config.database, config.port, config.password);
            author = JsonUtil.GetAuthorModel();
            project = JsonUtil.GetProjectModel();
            sessionId = SessionTable.AddSession(connection.Get());
            var authorId = AuthorTable.GetAuthorId(connection.Get(), author);
            var projectId = ProjectTable.GetProjectId(connection.Get(), project);

            if (authorId == null)
            {
                authorId = AuthorTable.AddAuthor(connection.Get(), author);                
            }
            author.id = authorId;

            if (projectId == null)
            {
                projectId = ProjectTable.AddProject(connection.Get(), project);
            }
            project.id = projectId;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            connection.Stop();
        }
    }
}
