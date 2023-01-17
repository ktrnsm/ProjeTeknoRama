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
        


    
        public static string HashPassword(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hash;
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            var isValid = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return isValid;
        }
    }

}

