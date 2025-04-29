using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "requestedPage")]
        public int RequestedPage { get; private set; }

        [JsonProperty(PropertyName = "formattedRequestedPage")]
        public string FormattedRequestedPage { get; private set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; private set; }

        [JsonProperty(PropertyName = "formattedTotalPages")]
        public string FormattedTotalPages { get; private set; }

        [JsonProperty(PropertyName = "recordsPerPage")]
        public int RecordsPerPage { get; private set; }

        [JsonProperty(PropertyName = "formattedRecordsPerPage")]
        public string FormattedRecordsPerPage { get; private set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; private set; }

        [JsonProperty(PropertyName = "formattedTotalRecords")]
        public string FormattedTotalRecords { get; private set; }

        [JsonProperty(PropertyName = "nextPage")]
        public int NextPage => RequestedPage + 1;

        [JsonProperty(PropertyName = "formattedNextPage")]
        public string FormattedNextPage { get; private set; }

        [JsonProperty(PropertyName = "prevPage")]
        public int PrevPage => RequestedPage - 1;

        [JsonProperty(PropertyName = "formattedPrevPage")]
        public string FormattedPrevPage { get; private set; }

        public Pagination()
        {

        }
    }
}
