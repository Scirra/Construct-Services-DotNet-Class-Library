using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Enums;
using ConstructServices.CloudSave.Objects;

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
        public BaseResponse UpdateBucket(UpdateBucketOptions updateBucketOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Update an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/edit-bucket" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateBucketAsync(UpdateBucketOptions updateBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class UpdateBucketOptions
    {    
        private Guid BucketID { get; }

        [UsedImplicitly]
        public string Name { get; set; }

        [UsedImplicitly]
        public CloudSaveBucketAccessMode AccessMode { get; set; }

        [UsedImplicitly]
        public bool AllowRatings { get; set; }

        [UsedImplicitly]
        public uint? MaxSaves { get; set; }

        [UsedImplicitly]
        public uint? MaxSaveSizeBytes { get; set; }

        [UsedImplicitly]
        public uint? MaxSavesPerPlayer { get; set; }

        public UpdateBucketOptions(string strBucketID)
        {
            BucketID = Guid.Parse(strBucketID);
        }
        public UpdateBucketOptions(Guid bucketID)
        {
            BucketID = bucketID;
        }
        public UpdateBucketOptions(Bucket bucket)
        {
            BucketID = bucket.ID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketName", Name },
                { "accessMode", AccessMode.ToString() },
                { "allowRatings", AllowRatings.ToInt().ToString() },
                { "maxBlobs", MaxSaves.ToString() },
                { "maxBlobSize", MaxSaveSizeBytes.ToString() },
                { "maxBlobsPerPlayer", MaxSavesPerPlayer.ToString() },
                { "bucketID", BucketID.ToString() }
            };
            return formData;
        }
    }
}