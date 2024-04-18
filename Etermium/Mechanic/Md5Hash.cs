using System.Security.Cryptography;
using System.Text;
using System;
using System.Threading;

namespace Etermium.Mechanic;

/// <summary>
/// Class responsible for calculating MD5 hashes.
/// </summary>
public abstract class Md5Hash
{
    /// <summary>
    /// Method to calculate the MD5 hash of the input string.
    /// </summary>
    /// <param name="input">The input string to be hashed.</param>
    /// <returns>The MD5 hash of the input string.</returns>
    public static string CalculateMd5Hash(string? input)
    {
        if (input != null)
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

        return null!;
    }
}