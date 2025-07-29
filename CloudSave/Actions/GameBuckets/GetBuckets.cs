using ConstructServices.CloudSave.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Enums;
using ConstructServices.Common;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    /// <summary>
    /// Get paginated buckets for a game
    /// </summary>
    [UsedImplicitly]
    public static BucketsResponse Get(
        this CloudSaveService service,
        GetBucketsSortMethod sortBy,
        PaginationOptions paginationOptions)
    {
        var formData = new Dictionary<string, string>
        {
            { "orderBy", sortBy.ToString() }
        };

        const string path = "/getbuckets.json";
        return Task.Run(() => Request.ExecuteRequest<BucketsResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }
}