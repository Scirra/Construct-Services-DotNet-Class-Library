using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.XP.Tests;

public enum TestResultStatus
{
    DidNotRun,
    Passed,
    Failed
}
public class TestResult
{
    public TestResultStatus ResultStatus { get; }
    public string Data { get; }

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

            var dataObject = new
            {
                baseResponse
            };
            Data = JsonConvert.SerializeObject(dataObject);
        }
    }
}