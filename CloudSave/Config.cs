namespace ConstructServices.CloudSave;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://cloudsave.construct.net" : "https://cloudsave.constructdev.net";
    
    internal const string CreateBucketAPIEndPoint = "/createbucket.json";
    internal const string DeleteBucketAPIEndPoint = "/deletebucket.json";
    internal const string EditBucketAPIEndPoint = "/editbucket.json";
    internal const string GetBucketAPIEndPoint = "/getbucket.json";
    internal const string GetBucketsAPIEndPoint = "/getbuckets.json";
    internal const string GetSavesAPIEndPoint = "/getbucketsaves.json";
    internal const string CreateAPIEndPoint = "/create.json";
    internal const string DeleteAPIEndPoint = "/delete.json";
    internal const string DeletePictureAPIEndPoint = "/deletepicture.json";
    internal const string GetSaveAPIEndPoint = "/getcloudsave.json";
    internal const string GetPlayerSavesAPIEndPoint = "/getcloudsaves.json";
    internal const string SetPictureAPIEndPoint = "/setpicture.json";
    internal const string CreateDimensionAPIEndPoint = "/bucketcreateratingdimension.json";
    internal const string DeleteDimensionAPIEndPoint = "/bucketdeleteratingsdimension.json";
    internal const string GetDimensionsAPIEndPoint = "/bucketgetratingdimensions.json";
    internal const string RateAPIEndPoint = "/rate.json";
    internal const string EditDimensionAPIEndPoint = "/bucketeditratingdimension.json";
}