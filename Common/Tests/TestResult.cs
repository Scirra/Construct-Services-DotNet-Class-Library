using System.Diagnostics;
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
    public long ExecutionTimeMS { [UsedImplicitly] get; }
    
    public TestResult()
    {
        ResultStatus = TestResultStatus.DidNotRun;
    }
    public TestResult(TestResultStatus status, Stopwatch stopwatch, string data = null)
    {
        ResultStatus = status;
        Data = data;
        ExecutionTimeMS = stopwatch.ElapsedMilliseconds;
    }

    public TestResult(BaseResponse baseResponse, Stopwatch stopwatch)
    {
        ExecutionTimeMS = stopwatch.ElapsedMilliseconds;
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