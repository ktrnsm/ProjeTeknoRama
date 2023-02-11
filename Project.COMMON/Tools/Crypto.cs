using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Project.COMMON.Tools
{
    public class Crypto

    //The Crypto class is used for secure password storage and verification.
    //It uses the BCrypt library for hashing and verifying passwords.
    //The HashPassword method generates a random salt, adds it to the input password, and then hashes the resulting string.
    //The resulting hash is stored in the database to protect the password.
    //The VerifyPassword method takes in the original password and the hash stored in the database, and returns a boolean indicating if the password is correct.
    {
        // monitor critic problem assault chief essay prevent glance orient response air save



        public static string HashPassword(string password)
        {
            //Generates a random salt and uses it to hash the input password
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return hash;
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            //Verifies if the input password matches the stored password hash
            var isValid = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return isValid;
        }
    }

}

