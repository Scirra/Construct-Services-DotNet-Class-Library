namespace ConstructServices.Leaderboards.Responses
{
    public class ShadowBanResponse : BaseResponse
    {
        public ShadowBanResponse()
        {
        }
        public ShadowBanResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
