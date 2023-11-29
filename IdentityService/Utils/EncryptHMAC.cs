using System.Security.Cryptography;
using System.Text;

namespace IdentityService.Utils
{
    public class EncryptHMAC
    {
        public static void GetHMAC52(string input, out byte[] hashedText, out byte[] hashedSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                hashedSalt = hmac.Key;
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                hashedText = computedHash;
            }
        }

        public static bool CompareHMAC512(string input, byte[] hashedText, byte[] hashedSalt)
        {
            using(var hmac = new HMACSHA512(hashedSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                return computeHash.SequenceEqual(hashedText);
            }
        }
    }
}
