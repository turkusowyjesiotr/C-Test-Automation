using NUnit.Framework;
using DatabaseTest.Database;
using DatabaseTest.Models;
using DatabaseTest.Utils;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace DatabaseTest.Tests
{
    [TestFixture]
    public class TestCase2
    {
        private List<TestTableModel> testsWithRepeatingId;
        private List<string> copiedTestsIds;
        private readonly MySqlConnection connection = TestsSetup.connection.Get();
        private readonly AuthorTableModel author = TestsSetup.author;
        private readonly ProjectTableModel project = TestsSetup.project;

        [SetUp]
        public void Setup()
        {
            testsWithRepeatingId = TestTable.GetTestsWithRepeatingDigitsId(connection, 10);
            for (int i = 0; i < testsWithRepeatingId.Count; i++)
            {
                testsWithRepeatingId[i].author_id = author.id;
                testsWithRepeatingId[i].project_id = project.id;               
            }
            copiedTestsIds = TestTable.CreateCopiesOfTests(connection, testsWithRepeatingId);
        }

        [Test]
        public void ProcessingTestData()
        {
            // We will simulate as if every copied test failed its execution
            var updatedTestsStatusIdList = new List<string>();
            var expectedStatusIdList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                expectedStatusIdList.Add("2");
            }
            foreach (string id in copiedTestsIds)
            {
                TestTable.UpdateTestById(connection, id, "status_id", "2");
                var updatedTest = TestTable.GetTestById(connection, id);
                updatedTestsStatusIdList.Add(updatedTest.status_id);
            }
            CollectionAssert.AreEqual(updatedTestsStatusIdList, expectedStatusIdList, "Tests were not updated properly");
        }

        [TearDown]
        public void TearDown()
        {
            TestTable.DeleteTestsById(connection, copiedTestsIds);
        }
    }
}
