using System.Collections.Generic;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Enums;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Creates a new CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/create-bucket" />
        [UsedImplicitly]
        public BucketResponse CreateBucket(CreateBucketOptions createBucketOptions)
        {
            return Request.ExecuteSyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Create,
                service,
                createBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/create-bucket" />
        [UsedImplicitly]
        public async Task<BucketResponse> CreateBucketAsync(CreateBucketOptions createBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Create,
                service,
                createBucketOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateBucketOptions(
        string name,
        CloudSaveBucketAccessMode accessMode,
        bool allowRatings = true)
    { 
        private string Name { get; } = name;
        private CloudSaveBucketAccessMode AccessMode { get; } = accessMode;
        private bool AllowRatings { get; } = allowRatings;

        [UsedImplicitly]
        public uint? MaxSaves { private get; set; } 

        [UsedImplicitly]
        public uint? MaxSaveSizeBytes { private get; set; }

        [UsedImplicitly]
        public uint? MaxSavesPerPlayer { private get; set; }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketName", Name },
                { "accessMode", AccessMode.ToString() },
                { "allowRatings", AllowRatings.ToInt().ToString() },
                { "maxBlobs", MaxSaves.ToString() },
                { "maxBlobSize", MaxSaveSizeBytes.ToString() },
                { "maxBlobsPerPlayer", MaxSavesPerPlayer.ToString() }
            };
            return formData;
        }
    }

}