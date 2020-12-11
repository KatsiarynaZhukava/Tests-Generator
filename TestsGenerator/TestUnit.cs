using System;

namespace TestsGenerator
{
    public class TestUnit
    {
        public string TestCode { get; }
        public string TestName { get; }

        public TestUnit(string testCode, string testName)
        {
            TestCode = testCode;
            TestName = testName;
        }
    }
}
