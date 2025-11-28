using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.CloudSave;

[UsedImplicitly]
public class CloudSaveService : BaseService
{
    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="aPIKey">API key</param>
    /// <param name="requestedLanguage">ISO Alpha 2 language to return translatable strings to</param>
    /// <param name="culture">Culture to return formatted values in</param>
    public CloudSaveService(Guid gameID, SecretAPIKey aPIKey, string requestedLanguage = null, CultureInfo culture = null) 
        : base(gameID, Config.APIDomain, aPIKey, requestedLanguage, culture)
    {
    }

    /// <summary>
    /// Create a new instance of auth service
    /// </summary>
    /// <param name="gameID">Game ID service is for</param>
    /// <param name="requestedLanguage">ISO Alpha 2 language to return translatable strings to</param>
    /// <param name="culture">Culture to return formatted values in</param>
    public CloudSaveService(Guid gameID, string requestedLanguage = null, CultureInfo culture = null) 
        : base(gameID, Config.APIDomain, null, requestedLanguage, culture)
    {
    }

    internal override void AddServiceSpecificFormData(Dictionary<string, string> formData)
    {
    }
}