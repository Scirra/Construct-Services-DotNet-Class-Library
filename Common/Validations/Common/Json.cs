using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConstructServices.Common.Validations.Common;
internal static partial class Functions
{
    internal static bool IsValidJson(this string strValue)
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