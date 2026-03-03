using JetBrains.Annotations;
using Newtonsoft.Json;

namespace ConstructServices.Common.Tests;

public enum TestResultStatus
{
    DidNotRun,
    Passed,
    Failed
}

[UsedImplicitly]
public class TestResult
{
    public TestResultStatus ResultStatus { [UsedImplicitly] get; }
    public string Data { [UsedImplicitly] get; }
    
    public TestResult()
    {
        ResultStatus = TestResultStatus.DidNotRun;
    }
    public TestResult(TestResultStatus status, string data = null)
    {
        ResultStatus = TestResultStatus.DidNotRun;
        Data = data;
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