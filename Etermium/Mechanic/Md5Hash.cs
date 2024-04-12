using System.Security.Cryptography;
using System.Text;

namespace Etermium.Mechanic;

public abstract class Md5Hash
{
    public static string CalculateMd5Hash(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        using (var md5 = MD5.Create())
        {
            var hashBytes = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var t in hashBytes)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}