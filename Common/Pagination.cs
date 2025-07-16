using Newtonsoft.Json;

namespace ConstructServices.Common
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "requestedPage")]
        public int RequestedPage { get; private set; }

        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; private set; }
    
        [JsonProperty(PropertyName = "recordsPerPage")]
        public int RecordsPerPage { get; private set; }

        [JsonProperty(PropertyName = "totalRecords")]
        public int TotalRecords { get; private set; }
        
        [JsonProperty(PropertyName = "nextPage")]
        public int NextPage => RequestedPage + 1;
        public bool ShouldSerializeNextPage() => NextPage <= TotalPages;
        
        [JsonProperty(PropertyName = "prevPage")]
        public int PrevPage => RequestedPage - 1;
        public bool ShouldSerializePrevPage() => PrevPage > 0;

        public Pagination()
        {
        }
    }
}
