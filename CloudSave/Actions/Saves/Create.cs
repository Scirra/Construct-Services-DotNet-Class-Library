using ConstructServices.CloudSave.Objects;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Saves
{
    extension(CloudSaveService service)
    {
        public CloudSaveResponse CreateCloudSave(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return Request.ExecuteMultiPartFormSyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }

        public async Task<CloudSaveResponse> CreateCloudSaveAsync(
            CreateCloudSaveOptions createCloudSaveOptions)
        {
            return await Request.ExecuteMultiPartFormAsyncRequest<CloudSaveResponse>(
                Config.EndPointPaths.Saves.Create,
                service,
                createCloudSaveOptions.BuildFormData(),
                createCloudSaveOptions.BuildBinaryFormData()
            );
        }
    }
}