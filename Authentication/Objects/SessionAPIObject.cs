using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Objects
{
    public sealed class EndSessionOptions
    {
        [UsedImplicitly]
        public string SessionKey { get; private set; }        
        
        public EndSessionOptions(string sessionKey)
        {
            SessionKey = sessionKey;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
    public sealed class RefreshSessionOptions
    {
        [UsedImplicitly]
        public string SessionKey { get; private set; }        
        
        public RefreshSessionOptions(string sessionKey)
        {
            SessionKey = sessionKey;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
    public sealed class GetSessionOptions
    {
        [UsedImplicitly]
        public string SessionKey { get; private set; }        
        
        public GetSessionOptions(string sessionKey)
        {
            SessionKey = sessionKey;
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}
