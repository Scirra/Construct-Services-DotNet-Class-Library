using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class GameBuckets
{
    private const string DeleteBucketAPIEndPoint = "/deletebucket.json";
    
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete a bucket and all it's contained data
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteBucket(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return service.DeleteBucket(bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a bucket and all it's contained data
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBucketAsync(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return await service.DeleteBucketAsync(bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a bucket and all it's contained data
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteBucket(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteBucketAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a bucket and all it's contained data
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBucketAsync(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteBucketAPIEndPoint,
                service,
                formData
            );
        }
    }
}