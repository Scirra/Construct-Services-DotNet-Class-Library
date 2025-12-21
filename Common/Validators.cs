using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ConstructServices.Common;

internal static class Validators
{
    internal static bool IsValidJson(this string strInput)
    {
        strInput = strInput.Trim();
        if ((!strInput.StartsWith("{", StringComparison.Ordinal) || !strInput.EndsWith("}", StringComparison.Ordinal)) && //For object
            (!strInput.StartsWith("[", StringComparison.Ordinal) || !strInput.EndsWith("]", StringComparison.Ordinal))) return false; //For array
        try
        {
            JToken.Parse(strInput);
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