using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MainService
{
    class HashEncryption
    {
        private int saltLenght = 64;
        public byte[] GenerateSalt()
        {
            var salt = new byte[saltLenght];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public byte[] HashSha(string password,byte[] salt)
        {
            var sha = SHA512.Create();
            var passBytes = Encoding.UTF8.GetBytes(password);
            var value = passBytes.Concat(salt).ToArray();
            var hash = sha.ComputeHash(value);
            return hash;
        }

        public User HashPassword(User user)
        {
            var salt = GenerateSalt();
            user.salt = Convert.ToBase64String(salt);
            user.password = Convert.ToBase64String(HashSha(user.password, salt));
            return user;
        }
    }
}
