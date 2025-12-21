using System.Security.Cryptography;
using System.Text;

namespace ConstructServices.Common;

internal static class Functions
{
    internal static int ToInt(this bool v) => v ? 1 : 0;
    internal static string GetSHA256Hash(string key)
    {
        key = key.Normalize();
        using (var sha256Hash = SHA256.Create())
        {
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(key));
            var builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}