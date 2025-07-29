using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ConstructServices.Common;

internal static class Validators
{
    internal static bool IsValidJson(this string strInput)
    {
        strInput = strInput.Trim();
        if ((!strInput.StartsWith("{") || !strInput.EndsWith("}")) && //For object
            (!strInput.StartsWith("[") || !strInput.EndsWith("]"))) return false; //For array
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