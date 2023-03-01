using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace DatabaseTest.Utils
{
    public static class TestContextUtil
    {
        public static string GetOutcome(TestContext testContext)
        {
            var outcome = testContext.Result.Outcome.Status;
            return outcome switch
            {
                TestStatus.Passed => "1",
                TestStatus.Failed => "2",
                TestStatus.Skipped => "3",
                _ => "False",
            };
        }
    }
}
