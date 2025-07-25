using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects;

public class Pagination : ConstructServices.Common.Pagination
{
    [JsonProperty(PropertyName = "formattedRequestedPage")]
    public string FormattedRequestedPage { get; private set; }

    [JsonProperty(PropertyName = "formattedTotalPages")]
    public string FormattedTotalPages { get; private set; }

    [JsonProperty(PropertyName = "formattedRecordsPerPage")]
    public string FormattedRecordsPerPage { get; private set; }

    [JsonProperty(PropertyName = "formattedTotalRecords")]
    public string FormattedTotalRecords { get; private set; }

    [JsonProperty(PropertyName = "formattedNextPage")]
    public string FormattedNextPage { get; private set; }

    [JsonProperty(PropertyName = "formattedPrevPage")]
    public string FormattedPrevPage { get; private set; }

    public Pagination()
    {

    }
}