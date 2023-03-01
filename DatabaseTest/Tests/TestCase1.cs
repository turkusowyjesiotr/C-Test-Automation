using NUnit.Framework;
using DatabaseTest.Database;
using DatabaseTest.Models;
using DatabaseTest.Utils;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseTest.Tests
{
    [TestFixture, Order(0)]
    public class SuccessTest
    {
        private readonly MySqlConnection connection = TestsSetup.connection.Get();
        private readonly AuthorTableModel author = TestsSetup.author;
        private readonly ProjectTableModel project = TestsSetup.project;
        private readonly string sessionId = TestsSetup.sessionId;

        [Test]
        public void AdditionTest()
        {
            int a = 2;
            int b = 3;
            Assert.That(a + b == 5, "a + b is not equal to 5");
        }

        [TearDown]
        public void TearDown()
        {
            var successTestModelToAdd = new TestTableModel
            {
                name = "Database Training Task: verify that 2 + 3 == 5",
                status_id = TestContextUtil.GetOutcome(TestContext.CurrentContext),
                method_name = TestContext.CurrentContext.Test.FullName,
                project_id = project.id,
                session_id = sessionId,
                env = "X",
                browser = "desktop",
                author_id = author.id
            };

            TestTable.AddTest(connection, successTestModelToAdd);
            var addedSuccessTestModel = TestTable.GetLatestTest(connection);

            if (!successTestModelToAdd.Equals(addedSuccessTestModel))
            {
                throw new Exception("Test results weren't added to the database");
            }
        }
    }

    [TestFixture, Order(1)]
    public class FailTest
    {
        private readonly MySqlConnection connection = TestsSetup.connection.Get();
        private readonly AuthorTableModel author = TestsSetup.author;
        private readonly ProjectTableModel project = TestsSetup.project;
        private readonly string sessionId = TestsSetup.sessionId;

        [Test]
        public void AdditionTest()
        {
            int a = 2;
            int b = 3;
            Assert.That(a + b == 4, "a + b is not equal to 4");            
        }

        [TearDown]
        public void TearDown()
        {
            var failTestModelToAdd = new TestTableModel
            {
                name = "Database Training Task: verify that 2 + 3 == 4",
                status_id = TestContextUtil.GetOutcome(TestContext.CurrentContext),
                method_name = TestContext.CurrentContext.Test.FullName,
                project_id = project.id,
                session_id = sessionId,
                env = "X",
                browser = "desktop",
                author_id = author.id
            };

            TestTable.AddTest(connection, failTestModelToAdd);
            var addedFailTestModel = TestTable.GetLatestTest(connection);

            if (!failTestModelToAdd.Equals(addedFailTestModel))
            {
                throw new Exception("Test results weren't added to the database");
            }
        }
    }    
}