using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hac.Key;
                passwordHash = hac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Encoding.UTF8.GetString(computedHash).Equals(Encoding.UTF8.GetString(passwordHash));
            }
        }
    }
}
