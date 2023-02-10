using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Project.COMMON.Tools
{
    public class Crypto
    {
        // monitor critic problem assault chief essay prevent glance orient response air save



        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hash;
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            var isValid = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return isValid;
        }
    }

}

