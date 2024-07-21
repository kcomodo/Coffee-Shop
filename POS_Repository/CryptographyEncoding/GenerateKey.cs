using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace POS_Folders.CryptographyEncoding
{
    public class GenerateKey
    {
        static void Main()
        {
            // Generate a 256-bit (32-byte) key
            var key = GenerateNewKey(32);

            // Convert the key to a Base64 string for easy storage
            var base64Key = Convert.ToBase64String(key);

            Console.WriteLine($"Generated Key (Base64): {base64Key}");
        }

        static byte[] GenerateNewKey(int sizeInBytes)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var key = new byte[sizeInBytes];
                rng.GetBytes(key);
                return key;
            }
        }
    }

}
