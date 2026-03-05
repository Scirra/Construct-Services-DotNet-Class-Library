using System;
using System.Collections.Generic;
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
        /// Update an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/edit-bucket" />
        [UsedImplicitly]
        public BaseResponse UpdateBucket(Guid bucketID, UpdateBucketOptions updateBucketOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData(bucketID)
            );
        }

        /// <summary>
        /// Update an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/edit-bucket" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateBucketAsync(Guid bucketID, UpdateBucketOptions updateBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData(bucketID)
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class UpdateBucketOptions
    {    
        [UsedImplicitly]
        public string Name { private get; set; }

        [UsedImplicitly]
        public CloudSaveBucketAccessMode AccessMode { private get; set; }

        [UsedImplicitly]
        public bool AllowRatings { private get; set; }

        [UsedImplicitly]
        public uint? MaxSaves { private get; set; }

        [UsedImplicitly]
        public uint? MaxSaveSizeBytes { private get; set; }

        [UsedImplicitly]
        public uint? MaxSavesPerPlayer { private get; set; }
        
        internal Dictionary<string, string> BuildFormData(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketName", Name },
                { "accessMode", AccessMode.ToString() },
                { "allowRatings", AllowRatings.ToInt().ToString() },
                { "maxBlobs", MaxSaves.ToString() },
                { "maxBlobSize", MaxSaveSizeBytes.ToString() },
                { "maxBlobsPerPlayer", MaxSavesPerPlayer.ToString() },
                { "bucketID", bucketID.ToString() }
            };
            return formData;
        }
    }
}