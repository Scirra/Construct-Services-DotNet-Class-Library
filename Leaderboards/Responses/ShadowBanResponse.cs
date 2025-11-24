using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ShadowBanResponse : BaseResponse
{
    public ShadowBanResponse()
    {
    }

    internal ShadowBanResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}