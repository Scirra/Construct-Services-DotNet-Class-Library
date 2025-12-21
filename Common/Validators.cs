using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ConstructServices.Common;

internal static class Validators
{
    extension(string strValue)
    {
        internal ValidationObjectResponse<Guid> IsValidGuid()
        {
            if (!Guid.TryParse(strValue, out var guid) || guid == Guid.Empty)
            {
                return new InvalidObjectResponse<Guid>("{0} is not a valid Guid.");
            }
            return new ValidObjectResponse<Guid>(guid);
        }

        internal bool IsValidJson()
        {
            strValue = strValue.Trim();
            if ((!strValue.StartsWith("{", StringComparison.Ordinal) || !strValue.EndsWith("}", StringComparison.Ordinal)) && //For object
                (!strValue.StartsWith("[", StringComparison.Ordinal) || !strValue.EndsWith("]", StringComparison.Ordinal))) return false; //For array
            try
            {
                JToken.Parse(strValue);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}