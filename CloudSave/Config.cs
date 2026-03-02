namespace ConstructServices.CloudSave;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://cloudsave.construct.net" : "https://cloudsave.constructdev.net";

    internal static class EndPointPaths
    {
        internal static class Buckets
        {
            internal const string Create = "/createbucket.json";
            internal const string Delete = "/deletebucket.json";
            internal const string Update = "/editbucket.json";
            internal const string Get = "/getbucket.json";
            internal const string List = "/getbuckets.json";
        }

        internal static class Ratings
        {
            internal const string CreateDimension = "/bucketcreateratingdimension.json";
            internal const string DeleteDimension = "/bucketdeleteratingsdimension.json";
            internal const string ListDimensions = "/bucketgetratingdimensions.json";
            internal const string UpdateDimension = "/bucketeditratingdimension.json";
            internal const string Rate = "/rate.json";
        }

        internal static class Saves
        {
            internal const string ListBucketSaves = "/getbucketsaves.json";
            internal const string Create = "/create.json";
            internal const string Delete = "/delete.json";
            internal const string DeletePicture = "/deletepicture.json";
            internal const string Get = "/getcloudsave.json";
            internal const string ListPlayerSaves = "/getcloudsaves.json";
            internal const string SetPicture = "/setpicture.json";
        }
    }
}