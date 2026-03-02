using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Responses;

[UsedImplicitly]
public sealed class ShadowBanResponse : BaseResponse
{
    public ShadowBanResponse()
    {
    }

    internal ShadowBanResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}