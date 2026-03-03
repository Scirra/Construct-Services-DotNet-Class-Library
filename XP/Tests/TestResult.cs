using ConstructServices.Common;

namespace ConstructServices.XP.Tests
{
    public enum TestResultStatus
    {
        DidNotRun,
        Passed,
        Failed
    }
    public class TestResult
    {
        public TestResultStatus ResultStatus { get; }

        public TestResult()
        {
            ResultStatus = TestResultStatus.DidNotRun;
        }

        public TestResult(BaseResponse baseResponse)
        {
            if (baseResponse.Success)
            {
                ResultStatus = TestResultStatus.Passed;
            }
            else
            {
                ResultStatus = TestResultStatus.Failed;
            }
        }
    }
}
